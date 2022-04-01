using Xunit;

namespace Calculator.Tests
{
    public class ParserTests
    {
        [Theory]
        [InlineData("+")]
        [InlineData("-")]
        [InlineData("*")]
        [InlineData("/")]
        public void TryParseOperatorOrQuit_WithRightOperator_FalseExpected(string arg)
        {
            Assert.False(CalculatorF.Parser.TryParseOperatorOrQuit(arg, out _));
        }

        [Theory]
        [InlineData("1")]
        [InlineData("41")]
        [InlineData("++")]
        public void TryParseOperatorOrQuit_WithWrongOperator_TrueExpected(string arg)
        {
            Assert.True(CalculatorF.Parser.TryParseOperatorOrQuit(arg, out _));
        }

        [Theory]
        [InlineData("41")]
        [InlineData("1")]
        [InlineData("7")]
        [InlineData("494")]
        public void TryParseArgOrQuit_WithIntArgument_FalseExpected(string arg)
        {
            Assert.False(CalculatorF.Parser.TryParseArgsOrQuit(arg, out _));
        }

        [Theory]
        [InlineData("-")]
        [InlineData("44rfqwe")]
        [InlineData("++")]
        public void TryParseArgOrQuit_WithWrongArgument_TrueExpected(string arg)
        {
            Assert.True(CalculatorF.Parser.TryParseArgsOrQuit(arg, out _));
        }

        [Theory]
        [InlineData("1", "+", "6")]
        [InlineData("`", "q", "a")]
        [InlineData("1daw", "7ryhe", "`3`1d")]
        public void CheckArgsLenghtOrQuit_With3Args_FalseExpected(params string[] args)
        {
            Assert.False(CalculatorF.Parser.CheckArgsLenghtOrQuit(args));
        }

        [Theory]
        [InlineData("af", "4")]
        [InlineData("1", "2", "3", "fqw12")]
        [InlineData("")]
        public void CheckArgsLenghtOrQuit_WithLessOrMore3Args_TrueExpected(params string[] args)
        {
            Assert.True(CalculatorF.Parser.CheckArgsLenghtOrQuit(args));
        }
    }
}