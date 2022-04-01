namespace CalculatorF

module Calculator =
    type Operation =
        | Plus = 1
        | Minus = 2
        | Divide = 3
        | Multiply = 4

    let Calculate val1 operation val2 (result:outref<int>) =
        let mutable flag = false
        match operation with
        | Operation.Plus -> result <- val1 + val2
        | Operation.Minus -> result <- val1 - val2
        | Operation.Multiply -> result <- val1 * val2
        | Operation.Divide ->
            if val2 = 0 then flag <- true
            else result <- val1 / val2
        flag