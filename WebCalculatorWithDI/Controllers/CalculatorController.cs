using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCalculatorWithDI.CalcExpressionTreeBuilder;

namespace WebCalculatorWithDI.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet, Route("Calcs")]
        public IActionResult Calcs(
            [FromServices] ExceptionLogHandler handler,
            [FromServices] CalculatorVisitorCache visitor,
            [FromServices] IExpressionCalculator calculator,
            string expressionString)
        {
            if (!calculator.TryParseStringIntoExpression(expressionString, out var exp))
            {
                return Ok("Error");
            }

            try
            {
                var result = visitor.StartVisiting(exp);
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                handler.Handle(LogLevel.Error, ex);
                return BadRequest();
            }
        }
    }
}
