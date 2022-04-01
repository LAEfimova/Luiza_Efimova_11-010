using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WebCalculatorWithDI.Cache;
using WebCalculatorWithDI.DataBase;

namespace WebCalculatorWithDI.CalcExpressionTreeBuilder
{
    public class CalculatorVisitorCache
    {
        private ExpressionDbCache _cache;

        public CalculatorVisitorCache(ExpressionDbCache cache) =>
            _cache = cache;

        public Expression StartVisiting(Expression expression) =>
            Visit((dynamic)expression);

        private Expression Visit(ConstantExpression node)
        { 
            return node;
        }

            private Expression Visit(BinaryExpression node)
        {
            var left = Task.Run(() => StartVisiting(node.Left));
            var right = Task.Run(() => StartVisiting(node.Right));

            var delay = Task.Delay(1000);
            Task.WhenAll(left, right);

            var leftResult = (decimal) ((ConstantExpression) left.Result)?.Value!;
            var rightResult = (decimal) ((ConstantExpression) right.Result)?.Value!;

            var operation = node.NodeType switch
            {
                ExpressionType.Add => "+",
                ExpressionType.Subtract => "-",
                ExpressionType.Multiply => "*",
                ExpressionType.Divide => "/"
            };

            var expressionEntity = new ExpressionEntity()
            {
                V1 = leftResult,
                V2 = rightResult,
                Op = operation
            };

            return Expression.Constant(_cache.GetOrSet(expressionEntity, () =>
            {
                var result = (decimal) CalculatorF.Program.GetResult(new string[]
                    {
                        expressionEntity.V1.ToString(),
                        expressionEntity.Op,
                        expressionEntity.V2.ToString()
                    })
                    .Value;
                delay.Wait();
                return result;
            }).Res);
        }

        private Expression Visit(UnaryExpression node)
        {
            var result =  (ConstantExpression) (node.Operand is BinaryExpression binary
                    ? Visit(binary)
                    : node.Operand);
            return Expression.Constant(node.Method?.Invoke(default, new[] { result?.Value }));
        }
    }
}