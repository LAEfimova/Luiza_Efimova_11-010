using CalculatorF;

namespace WebCalculatorWithDI.Models
{
    public class CalculatorAdapter : ICalculator
    {
        public int Calculate(string[] input)
        {
            return CalculatorF.Program.GetResult(input).Value;
        }
    }
}
