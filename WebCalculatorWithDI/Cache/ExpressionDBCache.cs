using System;
using System.Linq;
using WebCalculatorWithDI.DataBase;

namespace WebCalculatorWithDI.Cache
{
    public class ExpressionDbCache
    {
        private readonly ExpressionEntitysContext _context;

        public ExpressionDbCache(ExpressionEntitysContext context) =>
            _context = context;

        public ExpressionEntity GetOrSet(
            ExpressionEntity expWithoutRes,
            Func<decimal> resultBuilder)
        {
            try
            {
                lock (_context)
                {
                    return _context.Items.First(expression =>
                       expression.Expression == expWithoutRes.Expression);
                }
            }
            catch
            {
                expWithoutRes.Res = resultBuilder();
                lock (_context)
                {
                    _context.Items.Add(expWithoutRes);
                    _context.SaveChanges();
                }
                return expWithoutRes;
            }
        }
    }
}