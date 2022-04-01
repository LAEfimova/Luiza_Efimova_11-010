using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCalculatorWithDI.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet, Route("Calcs")]
        public IActionResult Calcs()
        {
            return Ok("s");
        }

        [HttpGet, Route("calc")]
        public IActionResult Calc([FromServices] ICalculator calculator, [FromQuery] CalculatorValues args)
        {
            try
            {
                return Ok(calculator.Calculate(new string[] { args.Val1, args.Operation, args.Val2 }));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ObjectResult(e.Message)
                {
                    StatusCode = 450
                };
            }
        }

        public class CalculatorValues
        {
            public string Val1 { get; set; }
            public string Operation { get; set; }
            public string Val2 { get; set; }
        }
    }
}
