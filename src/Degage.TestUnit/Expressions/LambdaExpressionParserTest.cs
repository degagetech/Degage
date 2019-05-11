using Microsoft.VisualStudio.TestTools.UnitTesting;
using Degage.Extension;
using System.Linq.Expressions;
namespace Degage.TestUnit
{
    [TestClass]
    public class LambdaExpressionParserTest
    {
        [TestMethod]
        public void ConvertExpression()
        {
            LambdaExpressionParser parser = new LambdaExpressionParser();
            //var expression = parser.GetExpression("[apl]==32&&DAP==32||AD=98", null, '$');
            //if (expression.Item1 == null)
            //{
            //    Assert.Fail(expression.Item2);
            //}

            var expression = parser.GetExpressionEx("[apl]==32+2/8&&DAP==32||AD=98", null, '$',out var message);
            if (expression == null)
            {
                Assert.Fail(message);
            }
        }
    }

}
