using Xunit;
using static Calculator.Calculator;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(2, Operation.Plus, 4)]
        [InlineData(12, Operation.Plus, 4)]
        [InlineData(70, Operation.Plus, 34)]
        public void Calculate_WithPlusOperation_SumReturned(int val1, Operation operation, int val2)
        {
            var resultExpected = val1 + val2;
            Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(10, Operation.Minus, 4)]
        [InlineData(0, Operation.Minus, 4)]
        [InlineData(307, Operation.Minus, 157)]
        public void Calculate_WithMinusOperation_DifferenceReturned(int val1, Operation operation, int val2)
        {
            var resultExpected = val1 - val2;
            Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(4, Operation.Multiply, 1)]
        [InlineData(7, Operation.Multiply, 0)]
        [InlineData(15, Operation.Multiply, 7)]
        public void Calculate_WithMultiplyOperation_ManyReturned(int val1, Operation operation, int val2)
        {
            var resultExpected = val1 * val2;
            Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(10, Operation.Divide, 4)]
        [InlineData(0, Operation.Divide, 4)]
        [InlineData(307, Operation.Divide, 10)]
        public void Calculate_WithDevideOperation_QuotientReturned(int val1, Operation operation, int val2)
        {
            var resultExpected = val1 / val2;
            Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(307, Operation.Divide, 0)]
        public void Calculate_DivisionByZero_trueReturned(int val1, Operation operation, int val2)
        {
            Assert.True(Calculate(val1, operation, val2, out var result));
        }
    }
}