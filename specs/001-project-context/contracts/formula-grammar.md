# Formula Grammar Contract: Phase 2 – Extended Formula Library

**Branch**: `001-project-context` | **Date**: 2026-02-28
**Input**: [spec.md](../spec.md), [research.md](../research.md), [data-model.md](../data-model.md)

---

## Purpose

This contract specifies the complete extended formula grammar as an EBNF reference. It defines
what strings the `FormulaEvaluator` accepts and rejects after the Phase 2 extension. Implementers
and test authors should treat this as authoritative.

---

## Extended Formula Grammar (EBNF)

```ebnf
(* Top-level entry point *)
formula       = expression ;

(* Expression hierarchy — unchanged from Phase 1 except via factor *)
expression    = simple_expr , { ( "+" | "-" ) , simple_expr } ;
simple_expr   = term , { ( "*" | "/" ) , term } ;
term          = signed_factor , { "^" , signed_factor } ;
signed_factor = [ "-" ] , factor ;
factor        = "(" , expression , ")"
              | number
              | identifier_factor ;

(* Identifier-based: cell reference, range sum, or function call *)
identifier_factor
              = cell_ref , [ ">" , cell_ref ]    (* range sum: A1>B5 *)
              | aggregate_call                    (* MIN, MAX, AVERAGE, COUNT *)
              | if_call                           (* IF *)
              | round_call                        (* ROUND *)
              | legacy_function_call ;            (* ABS, SQRT, SQR, … FACT *)

(* Cell reference *)
cell_ref      = column , row ;
column        = "A" | "B" | "C" | "D" | "E" | "F" | "G" ;   (* case-insensitive *)
row           = digit , { digit } ;   (* 1–21 inclusive *)

(* NEW: Aggregate functions — range or expression argument *)
aggregate_call = ( "MIN" | "MAX" | "AVERAGE" | "COUNT" ) ,   (* case-insensitive *)
                 "(" , range_arg , ")" ;
range_arg      = cell_ref , ">" , cell_ref    (* rectangular range *)
               | expression ;                  (* single cell ref or computed value *)

(* NEW: IF conditional expression *)
if_call        = "IF" , "(" ,               (* case-insensitive *)
                   condition_expr , "," ,
                   expression , "," ,
                   expression ,
                 ")" ;

condition_expr = expression , relop , expression ;
relop          = "=" | "<>" | "<" | "<=" | ">=" | ">" ;

(*
   Disambiguation rule for ">" in condition_expr:
   - When both sides of ">" are bare cell_refs (ColLetter followed immediately by digits),
     ">" is treated as the RANGE operator (existing semantics — yields a range sum).
   - When the right-hand expression is NOT a bare cell_ref (e.g., it is a numeric literal,
     an arithmetic expression, or a function call), ">" is the GREATER-THAN operator.
   Implementation: IsRangeOperatorStart() checks _text[pos+1] is A–G AND _text[pos+2] is a digit.
*)

(* NEW: ROUND function *)
round_call     = "ROUND" , "(" ,            (* case-insensitive *)
                   expression , "," ,
                   expression ,
                 ")" ;
(*
   decimals argument: non-negative numeric expression.
   Non-integer values are truncated to integer part (no error).
   Negative values produce: "ROUND: Negative Nachkommastellen sind nicht erlaubt."
*)

(* Existing single-argument functions — unchanged *)
legacy_function_call
              = function_name , "(" , expression , ")" ;
function_name = "ABS" | "SQRT" | "SQR" | "SIN" | "COS"
              | "ARCTAN" | "LN" | "LOG" | "EXP" | "FACT" ;   (* case-insensitive *)

(* Number literal *)
number        = [ digits ] , [ "." , [ digits ] ] , [ exponent ] ;
exponent      = ( "E" | "e" ) , [ "+" | "-" ] , digits ;
digits        = digit , { digit } ;
digit         = "0" | "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9" ;
```

---

## Grammar Notes

### Whitespace

Whitespace (space, tab) is allowed before every token. The `SkipWhitespace()` call appears
before every `ParseXxx` call. Whitespace is NOT allowed mid-token (e.g., `A 1` is invalid;
`A1` is required for cell references).

### Case Insensitivity

All function names and column letters are normalized to uppercase via
`char.ToUpperInvariant()` / `.ToUpperInvariant()` before matching. Formulas `min(a1>a5)`,
`Min(A1>A5)`, and `MIN(A1>A5)` are equivalent.

### Operator Precedence (unchanged from Phase 1)

| Precedence | Operator | Associativity |
|------------|----------|---------------|
| 1 (lowest) | `+`, `-` | Left |
| 2          | `*`, `/` | Left |
| 3          | `^`      | Left (repeated application) |
| 4 (highest)| Unary `-` | Right |
| —          | `(` `)` | Grouping |

Relational operators inside `IF` conditions do not participate in the main precedence hierarchy —
they are parsed by `ParseRelationalOperator()` after the left sub-expression is fully evaluated.

---

## Valid Examples

| Formula | Result | Notes |
|---------|--------|-------|
| `MIN(A1>A5)` | smallest of A1–A5 | Range argument |
| `MAX(A1>G21)` | largest in full grid | Max-scale range |
| `AVERAGE(A1>B2)` | mean of 4 cells | Rectangular range |
| `COUNT(A1>A5)` | count of numeric cells | Sparse range |
| `MIN(42)` | 42 | Single literal (list of one) |
| `COUNT(A1)` | 1 if numeric, 0 otherwise | Single cell ref |
| `ROUND(3.14159, 2)` | 3.14 | Positive decimals |
| `ROUND(2.5, 0)` | 3 | AwayFromZero |
| `ROUND(-2.5, 0)` | -3 | AwayFromZero (not toward zero) |
| `ROUND(AVERAGE(A1>A5), 2)` | rounded mean | Function composition |
| `IF(A1>100, 1, 0)` | 1 or 0 | `>` as greater-than (right side is literal) |
| `IF(A1>B5, 1, 0)` | range-sum≠0 ? 1 : 0 | `>` as range (both sides are cell refs) |
| `IF(A1=A2, 10, 20)` | 10 or 20 | Equality condition |
| `IF(A1<>0, A1, 0)` | A1 or 0 | Not-equal condition |
| `IF(A1-B1>0, 1, 0)` | 1 or 0 | Left side is expression, `>` is comparison |
| `IF(A1>0, MAX(A1>A5), MIN(A1>A5))` | max or min | Nested functions in branches |
| `MIN(A1>A5)+MAX(A1>A5)` | sum of min+max | Aggregate in arithmetic |

---

## Invalid Examples

| Formula | Error | Reason |
|---------|-------|--------|
| `IF(A1, 1, 0)` | `"IF: Bedingung muss einen Vergleichsoperator enthalten…"` | No relational op |
| `IF(A1>0, 1)` | `"IF erwartet 3 Argumente: Bedingung, Wahr-Wert, Falsch-Wert."` | Missing false branch |
| `ROUND(3.14, -1)` | `"ROUND: Negative Nachkommastellen sind nicht erlaubt."` | Negative decimals |
| `MIN()` | `"Unerwartetes Zeichen."` or parse error | Empty argument |
| `SQRT(-1)` | `"SQRT erwartet einen Wert >= 0."` | Existing domain error |
| `A8` | `"Zeile außerhalb des gültigen Bereichs."` | Row > 21 |
| `H1` | `"Ungültige Spalte."` | Column H beyond G |

---

## Backward Compatibility

All Phase 1 formulas remain valid. No syntax changes are made to:
- Arithmetic expressions
- Cell references and range sums (`A1>B5`)
- All 10 existing functions (ABS, SQRT, SQR, SIN, COS, ARCTAN, LN, LOG, EXP, FACT)

The `>` disambiguation guard is strictly additive: it only suppresses `>` consumption in the
range path when the right side is NOT a valid cell address start. For all inputs that were valid
in Phase 1, `IsRangeOperatorStart()` returns `true` (since `A1>B5` always has `ColLetter+Digit`
on the right), preserving existing behavior unchanged.
