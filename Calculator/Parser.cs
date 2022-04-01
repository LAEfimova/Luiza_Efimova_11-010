using System;
namespace Calculator
{
    public static class Parser
    {
        public static bool TryParseOperatorOrQuit(string arg, out Calculator.Operation operation)
        {
            switch (arg)
            {
                case "+":
                    operation = Calculator.Operation.Plus;
                    break;
                case "-":
                    operation
                    = Calculator.Operation.Minus;
                    break;
                case "*":
                    operation =
                 Calculator.Operation.Multiply;
                    break;
                case "/":
                    operation = Calculator.Operation.Divide;
                    break;
                default:
                    operation = default;
                    return true;
            };
            return false;
        }
        public static bool TryParseArgsOrQuit(string arg, out int result)
        {
            if (!int.TryParse(arg, out result))
            {
                Console.WriteLine($"Inputed value isn't int: {arg}");
                return true;
            }
            return false;
        }

        public static bool CheckArgsLenghtOrQuit(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine($"Programm needs 3 args, but there is {args.Length}");
                return true;
            }
            return false;
        }
    }
}
