using Microsoft.AspNetCore.Mvc;
using WebCalculatorWithDI.CalcExpressionTreeBuilder;

namespace WebCalculatorWithDI.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet, Route("Calcs")]
        public IActionResult Calcs([FromServices] IExpressionCalculator calculator, string expressionString)
        {
            if (!calculator.TryParseStringIntoExpression(expressionString, out var exp))
            {
                return Ok("Error");
            }

            var result = new CalculatorVisitor().Visit(exp);
            return Ok(result.ToString());
        }
    }
}
