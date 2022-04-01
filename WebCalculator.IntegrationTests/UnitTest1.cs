using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using WebCalculatorWithDI;
using Xunit;

namespace WebApplication.Tests
{
    public class CalculatorTests
    {
        private WebApplicationFactory<Startup> factory;
        private HttpClient client;

       
        public CalculatorTests()
        {
            factory = new WebApplicationFactory<Startup>();
            client = factory.CreateClient();
        }

        private async Task<decimal> Action(decimal val1, string operation, decimal val2)
        {
            var response = await client.GetAsync($"http://localhost:7145/calc?val1={val1}&operation={operation}&val2={val2}");

            var strNumber = await response.Content.ReadAsStringAsync();
            decimal parsed;
            try
            {
                parsed = decimal.Parse(strNumber, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new Exception($"Cant parse, the number is {strNumber}");
            }

            return parsed;
        }

        private async Task<decimal> Sum(decimal val1, decimal val2) => await Action(val1, "%2B", val2);
        private async Task<decimal> Dif(decimal val1, decimal val2) => await Action(val1, "-", val2);
        private async Task<decimal> Mult(decimal val1, decimal val2) => await Action(val1, "*", val2);
        private async Task<decimal> Div(decimal val1, decimal val2) => await Action(val1, "/" ,val2);

        private static void CheckEquality(decimal val1, decimal val2) => Assert.True(Math.Round(val1 - val2) < 0.0001m);

        [Fact]
        public async Task Sums()
        {
            CheckEquality(2m, await Sum(0, 2));
            CheckEquality(10m, await Sum(5, 5));
            CheckEquality(19m, await Sum(17, 2));
            CheckEquality(105m, await Sum(6, 99));
            CheckEquality(980m, await Sum(61, 919));
        }

        [Fact]
        public async Task Difs()
        {
            CheckEquality(0m, await Dif(7, 7));
            CheckEquality(5m, await Dif(10, 5));
            CheckEquality(-1m, await Dif(55, 56));
            CheckEquality(-145m, await Dif(55, 200));
            CheckEquality(9111m, await Dif(11111, 2000));
        }

        [Fact]
        public async Task Mults()
        {
            CheckEquality(0m, await Mult(1, 0));
            CheckEquality(7m, await Mult(7, 1));
            CheckEquality(144m, await Mult(12, 12));
            CheckEquality(150m, await Mult(15, 10));
            CheckEquality(1320m, await Mult(110, 12));
        }

        [Fact]
        public async Task Divs()
        {
            CheckEquality(0m, await Div(0, 555));
            CheckEquality(5m, await Div(25, 5));
            CheckEquality(25m, await Div(25, 1));
            CheckEquality(110m, await Div(990, 9));
            CheckEquality(2.5m, await Div(100, 40));
        }

        [Fact]
        public async Task SomeFails()
        {
            var response = await client.GetAsync("http://localhost:7240/?val1=1");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            response = await client.GetAsync("http://localhost:7240/?val1=1&operation=qwe&val2=24");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}