namespace CalculatorF

open System

module Parser =
    let CheckArgsLenghtOrQuit (args:string[]) =
        if args.Length <> 3 then    
            printf $"Programm needs 3 args, but there is {args.Length}"
            true
        else
            false

    let TryParseArgsOrQuit (arg:string) (result:outref<int>) =
        if Int32.TryParse(arg, &result) then
            false
        else
            Console.WriteLine($"value is not int. The value was {arg}");
            true    

    let TryParseOperatorOrQuit arg (result:outref<Calculator.Operation>) =
        let mutable flag = false
        match arg with
        | "+" -> result <- Calculator.Operation.Plus
        | "-" -> result <- Calculator.Operation.Minus
        | "*" -> result <- Calculator.Operation.Multiply
        | "/" -> result <- Calculator.Operation.Divide
        | _ -> flag <- true
        flag