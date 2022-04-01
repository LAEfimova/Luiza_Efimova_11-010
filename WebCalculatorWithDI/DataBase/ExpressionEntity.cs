using System.ComponentModel.DataAnnotations.Schema;
using CalculatorF;

namespace WebCalculatorWithDI.DataBase
{
    public class ExpressionEntity
    {
        public int Id { get; set; }
        public decimal V1 { get; init; }
        public decimal V2 { get; init; }
        public string Op { get; init; }
        public decimal? Res { get; set; }
    }
}