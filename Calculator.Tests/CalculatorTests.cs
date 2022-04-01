using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(2, CalculatorF.Calculator.Operation.Plus, 4)]
        [InlineData(12, CalculatorF.Calculator.Operation.Plus, 4)]
        [InlineData(70, CalculatorF.Calculator.Operation.Plus, 34)]
        public void Calculate_WithPlusOperation_SumReturned(int val1, CalculatorF.Calculator.Operation operation, int val2)
        {
            var resultExpected = val1 + val2;
            CalculatorF.Calculator.Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(10, CalculatorF.Calculator.Operation.Minus, 4)]
        [InlineData(0, CalculatorF.Calculator.Operation.Minus, 4)]
        [InlineData(307, CalculatorF.Calculator.Operation.Minus, 157)]
        public void Calculate_WithMinusOperation_DifferenceReturned(int val1, CalculatorF.Calculator.Operation operation, int val2)
        {
            var resultExpected = val1 - val2;
            CalculatorF.Calculator.Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(4, CalculatorF.Calculator.Operation.Multiply, 1)]
        [InlineData(7, CalculatorF.Calculator.Operation.Multiply, 0)]
        [InlineData(15, CalculatorF.Calculator.Operation.Multiply, 7)]
        public void Calculate_WithMultiplyOperation_ManyReturned(int val1, CalculatorF.Calculator.Operation operation, int val2)
        {
            var resultExpected = val1 * val2;
            CalculatorF.Calculator.Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(10, CalculatorF.Calculator.Operation.Divide, 4)]
        [InlineData(0, CalculatorF.Calculator.Operation.Divide, 4)]
        [InlineData(307, CalculatorF.Calculator.Operation.Divide, 10)]
        public void Calculate_WithDevideOperation_QuotientReturned(int val1, CalculatorF.Calculator.Operation operation, int val2)
        {
            var resultExpected = val1 / val2;
            CalculatorF.Calculator.Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(307, CalculatorF.Calculator.Operation.Divide, 0)]
        public void Calculate_DivisionByZero_trueReturned(int val1, CalculatorF.Calculator.Operation operation, int val2)
        {
            Assert.True(CalculatorF.Calculator.Calculate(val1, operation, val2, out var result));
        }
    }
}