using System.Collections.Generic;
using System.Text;

namespace System.Linq.Expressions
{
    /// <summary>
    /// 用于将其他形式的表达式转换为 .NET  表达式
    /// </summary>
    public class LambdaExpressionParser
    {
        private readonly static HashSet<String> _SupportedBinaryOperators = new HashSet<String>
        { "&&", "==", "!=", ">=", "<=", "||", ">", "<", "&", "|","+","-","*","/","%",">>","<<","^"};
        private readonly static HashSet<Char> _BaseBinaryOperatorSymbols = new HashSet<Char>
        {'&','=','!','=','>','|','+','-','*','/','%'};
        private static HashSet<String> _SupportedUnaryOperators = new HashSet<String>
        {"^","++","--","~","!" };
        private readonly static Dictionary<String, Int32> _BinaryOperatorPriorityTable = new Dictionary<String, Int32>
        {
           { "/",3},{ "*",3},{ "%",3},
           { "+",4},{ "-",4},
           { "<<",5},{ ">>",5},
           { "<",6},{ ">",6},  { "<=",6},{ ">=",6},
           { "==",7},{ "!=",7},
           { "&",8},{ "^",9}, { "|",10},{ "&&",11},{ "||",12},
        };

        public Expression GetExpressionEx(
          String expStr,
          IDictionary<String, ExpressionParameter> parameters,
          String paraSymbol)
        {
            Expression expression = null;
            Stack<String> expressionStack = new Stack<String>();
            Stack<String> operatorStack = new Stack<String>();
            StringBuilder expressionContainer = new StringBuilder();
            for (Int32 i = 0; i < expStr.Length; ++i)
            {
                String c = expStr[i].ToString();
                switch (c)
                {
                    case "(":
                        {
                               
                        }
                        break;
                }
                if (this.IsBinaryOperator(c))
                {
                    operatorStack.Push(c);
                }
                else
                {
                    expressionContainer.Append(c);
                }

            }

            return expression;
        }



        //public Expression GetExpressionEx(
        //  String expStr,
        //  IDictionary<String, ExpressionParameter> parameters,
        //  String paraSymbol,
        //   out String errorMessage)
        //{
        //    Expression expression = null;
        //    errorMessage = null;
        //    ExpressionBuildErrorType errorType = ExpressionBuildErrorType.None;
        //    Boolean isConfirmBinaryOperator = false;
        //    Int32 lastBinaryOperatorIndex = -1;
        //    Expression lastExpression = null;

        //    Int32 currentLocation = 0;
        //    StringBuilder stringExpressionContainer = new StringBuilder();
        //    Int32 binaryOpVerifyMaxOffset = expStr.Length - 2;

        //    //优先级处理
        //    Stack<String> binaryOperatorStack = new Stack<String>();
        //    Stack<String> stringExpressionStack = new Stack<String>();
        //    Stack<BinaryExpression> binaryExpressionQueue = new Stack<BinaryExpression>();

        //    for (Int32 i = 0; i < expStr.Length; ++i)
        //    {
        //        currentLocation = i;
        //        var c = expStr[i];
        //        var cStr = c.ToString();
        //        String str = cStr;

        //        //如果尚未临界字符串末尾，并且当前字符是二元运算符基础构成符号但本身不是二元运算符
        //        //则判断当前字符与下一个字符是否构成二元运算符
        //        if (!this.IsBinaryOperator(cStr) && this.IsBaseBinaryOperatorSymbol(c) && i <= binaryOpVerifyMaxOffset)
        //        {
        //            var nextChar = expStr[i + 1];
        //            str = c.ToString() + nextChar;
        //        }

        //        //如果本身是二元操作符，并且和下一个符号也能组合成二元操作符
        //        if (this.IsBinaryOperator(cStr) && i <= binaryOpVerifyMaxOffset)
        //        {
        //            var nextChar = expStr[i + 1];
        //            var tempstr = c.ToString() + nextChar;
        //            if (this.IsBinaryOperator(tempstr))
        //            {
        //                str = tempstr;
        //            }
        //        }

        //        if (this.IsBinaryOperator(str))
        //        {
        //            //如果连续出现二元运算符，则错误
        //            if ((lastBinaryOperatorIndex + 1) == i)
        //            {
        //                errorType = ExpressionBuildErrorType.ContinuousBinaryOperator;
        //                goto RETRUN;
        //            }
        //            //如果二元运算符处于字符串开始处，则错误
        //            if (i == 0)
        //            {
        //                errorType = ExpressionBuildErrorType.IsNullBinaryOperateLeftObject;
        //                goto RETRUN;
        //            }
        //            //如果二元运算符处于字符串结束处，则错误
        //            if (i == binaryOpVerifyMaxOffset)
        //            {
        //                errorType = ExpressionBuildErrorType.IsNullBinaryOperateRightObject;
        //                goto RETRUN;
        //            }

        //            var stringExpression = stringExpressionContainer.ToString();
        //            stringExpressionStack.Push(stringExpression);
        //            stringExpressionContainer.Clear();

        //            i += (str.Length - 1);
        //            lastBinaryOperatorIndex = i;
        //            isConfirmBinaryOperator = true;

        //            var preOperator = binaryOperatorStack.Peek();
        //            //如果上一个二元操作符的优先级高于等于当前的，则构建一次表达式
        //            if (preOperator != null && this.BinaryOperatorPriority(preOperator, str))
        //            {
        //                binaryOperatorStack.Pop();
        //                //取出两个字符串表达式
        //                var rightExpressionStr = stringExpressionStack.Pop();
        //                var leftExpressionStr = stringExpressionStack.Pop();

        //                var leftBuildResult = this.GetUnaryExpression(leftExpressionStr, parameters, paraSymbol);
        //                var leftExpression = leftBuildResult.Item1;
        //                if (leftExpression == null)
        //                {
        //                    errorMessage = leftExpressionStr;
        //                    errorType = ExpressionBuildErrorType.InvalidUnaryExpression;
        //                    goto RETRUN;
        //                }

        //                var rightBuildResult = this.GetUnaryExpression(rightExpressionStr, parameters, paraSymbol);
        //                var rightExpression = rightBuildResult.Item1;
        //                if (rightExpression == null)
        //                {
        //                    errorMessage = rightExpressionStr;
        //                    errorType = ExpressionBuildErrorType.InvalidUnaryExpression;
        //                    goto RETRUN;
        //                }

        //                var binaryExpression = this.GetBinaryExpression(preOperator, leftExpression, rightExpression);
        //                binaryExpressionQueue.Push(binaryExpression);
        //            }
        //            binaryOperatorStack.Push(str);
        //        }
        //        else
        //        {
        //            stringExpressionContainer.Append(c);
        //        }

        //        if (i != (expStr.Length - 1)) continue;

        //        binaryOperatorContainer.Clear();
        //        stringExpressionContainer.Clear();
        //        rightUnaryExpressionContainer.Clear();
        //        isConfirmBinaryOperator = false;
        //        continue;
        //    }
        //RETRUN:
        //    if (errorType != ExpressionBuildErrorType.None)
        //    {
        //        errorMessage += this.GetBuildErrorDescription(errorType);
        //        errorMessage = this.BuildErrorMessage(errorMessage, currentLocation);
        //    }
        //    return expression;
        //}

        /// <summary>
        /// 比较两个二元操作符的优先级
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>若 L 高于或等于 R，返回 true，否则返回 false</returns>
        private Boolean BinaryOperatorPriority(String left, String right)
        {
            return _BinaryOperatorPriorityTable[left] <= _BinaryOperatorPriorityTable[right];
        }
        /// <summary>
        ///判断指定字符是否是一个构成二元运算符的基础符号
        /// </summary>
        private Boolean IsBaseBinaryOperatorSymbol(Char symbol)
        {
            return _BaseBinaryOperatorSymbols.Contains(symbol);
        }

        /// <summary>
        /// 获取表达式构建错误的描述
        /// </summary>
        /// <param name="errorType"></param>
        /// <returns></returns>
        private String GetBuildErrorDescription(ExpressionBuildErrorType errorType)
        {
            String description = null;
            switch (errorType)
            {
                case ExpressionBuildErrorType.IsNullBinaryOperateLeftObject:
                    {
                        description = "二元运算左运算对象为空";
                    }
                    break;
                case ExpressionBuildErrorType.IsNullBinaryOperateRightObject:
                    {
                        description = "二元运算右运算对象为空";
                    }
                    break;
                default:
                    {
                        description = errorType.ToString();
                    }
                    break;
            }
            return description;
        }
        /// <summary>
        /// 判断指定字符串是否是一个二元运算符
        /// </summary>
        private Boolean IsBinaryOperator(String binaryOperator)
        {
            return _SupportedBinaryOperators.Contains(binaryOperator);
        }
        private String BuildErrorMessage(String errorMessage, Int32 location = -1)
        {
            var message = "表达式构建错误！" + errorMessage;
            if (location > -1)
            {
                message += " 位置：" + location.ToString();
            }
            return message;
        }
#if NETSTANDARD2_0
        private (Expression expression, String errorMessage) GetUnaryExpression(String expStr, IDictionary<String, ExpressionParameter> parameters,
            String paraSymbol)
#else
              private Tuple<Expression, String> GetUnaryExpression(String expStr, IDictionary<String, ExpressionParameter> parameters,
            Char paraSymbol)
#endif
        {
            Expression expression = Expression.Constant(expStr, typeof(String));
            String errorMessage = null;
#if NETSTANDARD2_0
            return (expression, errorMessage);
#else
             return Tuple.Create<Expression, String>(expression, errorMessage);
#endif
        }
        private BinaryExpression GetBinaryExpression(String binaryOperator, Expression left, Expression right)
        {
            BinaryExpression expression = null;
            switch (binaryOperator)
            {
                case "&&": expression = Expression.AndAlso(left, right); break;
                case "||": expression = Expression.OrElse(left, right); break;
                case "&": expression = Expression.And(left, right); break;
                case "|": expression = Expression.Or(left, right); break;
                case ">=": expression = Expression.GreaterThanOrEqual(left, right); break;
                case ">": expression = Expression.GreaterThan(left, right); break;
                case "<=": expression = Expression.LessThanOrEqual(left, right); break;
                case "<": expression = Expression.LessThan(left, right); break;
                case "==": expression = Expression.Equal(left, right); break;
                case "!=": expression = Expression.NotEqual(left, right); break;
                case "+": expression = Expression.Add(left, right); break;
                case "-": expression = Expression.Subtract(left, right); break;
                case "*": expression = Expression.Multiply(left, right); break;
                case "/": expression = Expression.Divide(left, right); break;
                case "%": expression = Expression.Modulo(left, right); break;
                default:
                    {

                    }
                    break;
            }
            return expression;
        }
    }
    /// <summary>
    ///表达式构建错误类型
    /// </summary>
    public enum ExpressionBuildErrorType
    {
        /// <summary>
        /// 无错误
        /// </summary>
        None,
        /// <summary>
        /// 二元运算左运算对象为空
        /// </summary>
        IsNullBinaryOperateLeftObject,
        /// <summary>
        /// 二元运算右运算对象为空
        /// </summary>
        IsNullBinaryOperateRightObject,
        /// <summary>
        /// 无效的二元运算符
        /// </summary>
        InvalidBinaryOperator,
        /// <summary>
        /// 无效的一元表达式
        /// </summary>
        InvalidUnaryExpression,
        /// <summary>
        /// 连续出现二元运算符
        /// </summary>
        ContinuousBinaryOperator
    }
}


//rubbish
///// <summary>
/////  通过字符串构建一个 <see cref="Expression"/> 实例
///// </summary>
///// <param name="expStr">含有表达式的字符串</param>
///// <param name="parameters">表达式中的参数信息</param>
///// <param name="paraSymbol">参数符，被参数符包裹的字符串会被作为参数的名称，例如，表达式：$APL$==23 则 APL为参数名称</param>
//public Tuple<Expression, String> GetExpression(
//    String expStr,
//    IDictionary<String, ExpressionParameter> parameters,
//    Char paraSymbol)
//{

//    Expression expression = null;
//    String errorMessage = null;
//    //首先通过二元运算符构建表达式树
//    //Abs([APL])==32
//    //二元运算符分离，例如 
//    //[APL]=="321" && [DPL]=="45" =>  [APL]=="321"=>[APL]| "321" | [DPL]=="45"=> [DPL] | "45"
//    // 二叉树    A
//    //     B   C       D  E
//    //遍历顺序 B C A D E
//    //支持的二元运算符

//    //表示距离上个二元运算符的偏移量
//    //Int32 lastBinaryOperatorOffset = 0;
//    Boolean isConfirmBinaryOperator = false;
//    String confirmBinaryOperator = String.Empty;
//    Expression lastExpression = null;
//    StringBuilder binaryOperatorContainer = new StringBuilder();
//    StringBuilder leftUnaryExpressionContainer = new StringBuilder();
//    StringBuilder rightUnaryExpressionContainer = new StringBuilder();
//    for (Int32 i = 0; i < expStr.Length; ++i)
//    {
//        Char c = expStr[i];
//        String charStr = Char.ToString(c);
//        //如果当前符号是二元运算符中的，则需要判断其下一个字符是否也为二元运算符中的，
//        //防止例如 && 此类运算符被当作两个 & 运算符添加。
//        if (_SupportedBinaryOperators.Contains(charStr))
//        {
//            //如果当前二元运算符已经确定，则需要先构建确定的二元运算符表达式
//            //如果当前二元运算符已经确定，则表示构建前一个二元表达式的所有条件都已满足
//            if (isConfirmBinaryOperator)
//            {
//                var leftExpressionStr = leftUnaryExpressionContainer.ToString();
//                var rightExpressionStr = rightUnaryExpressionContainer.ToString();

//                var leftBuildResult = this.GetUnaryExpression(leftExpressionStr, parameters, paraSymbol);
//                //leftExpressionStr【 构建表达式错误】
//                var leftExpression = leftBuildResult.Item1;
//                if (leftExpression == null)
//                {
//                    errorMessage = this.BuildErrorMessage(leftExpressionStr + " " + leftBuildResult.Item2, i);
//                    return Tuple.Create<Expression, String>(null, errorMessage);
//                }

//                var rightBuildResult = this.GetUnaryExpression(rightExpressionStr, parameters, paraSymbol);
//                var rightExpression = rightBuildResult.Item1;
//                //rightExpressionStr【 构建表达式错误】
//                if (rightExpression == null)
//                {
//                    errorMessage = this.BuildErrorMessage(rightExpressionStr + " " + rightBuildResult.Item2, i);
//                    return Tuple.Create<Expression, String>(null, errorMessage);
//                }
//                var binaryExpression = this.GetBinaryExpression(confirmBinaryOperator, leftExpression, rightExpression);
//                //binaryOperator ,leftExpressionStr,rightExpressionStr【二元表达式构建错误】
//                if (binaryExpression == null)
//                {
//                    errorMessage = this.BuildErrorMessage("无效的二元运算符", i);
//                    return Tuple.Create<Expression, String>(null, errorMessage);
//                }

//                //为下一次构建准备
//                binaryOperatorContainer.Clear();
//                leftUnaryExpressionContainer.Clear();
//                rightUnaryExpressionContainer.Clear();
//                isConfirmBinaryOperator = false;
//                confirmBinaryOperator = String.Empty;
//                binaryOperatorContainer.Append(c);
//                continue;
//            }
//            //如果字符串首位为一个二元运算符，则表达式错误，【二元运算符没有左运算对象】
//            if (i == 0)
//            {
//                errorMessage = this.BuildErrorMessage("二元运算符没有左运算对象", i);
//                return Tuple.Create<Expression, String>(null, errorMessage);
//            }
//            //如果字符串末尾为一个二元运算符，则表达式错误，【二元运算符没有右运算对象】
//            if (i == (expStr.Length - 1))
//            {
//                errorMessage = this.BuildErrorMessage("二元运算符没有右运算对象", i);
//                return Tuple.Create<Expression, String>(null, errorMessage);
//            }
//            Char nextChar = expStr[i + 1];
//            var nextCharStr = nextChar.ToString();
//            //如果当前字符与下一个字符串合并构成二元运算符
//            var binaryOperator = c.ToString() + nextCharStr;
//            //如果下一个二元运算符为此类特殊的运算符，则开始下一次循环
//            if (_SupportedBinaryOperators.Contains(binaryOperator))
//            {
//                //如果当前已经确定了二元运算符，则表达式错误，【连续两个二元运算符】
//                if (isConfirmBinaryOperator)
//                {
//                    errorMessage = this.BuildErrorMessage("连续两个二元运算符", i);
//                    return Tuple.Create<Expression, String>(null, errorMessage);
//                }
//                binaryOperatorContainer.Append(c);
//                continue;
//            }
//            //如果下一个字符为其他二元运算符，则表达式错误，【连续两个二元运算符】
//            if (_SupportedBinaryOperators.Contains(nextCharStr))
//            {
//                errorMessage = this.BuildErrorMessage("连续两个二元运算符", i);
//                return Tuple.Create<Expression, String>(null, errorMessage);
//            }
//            //如果下一个字符不为二元运算符
//            else
//            {
//                if (false)
//                {
//                }
//                //确定二元运算符
//                else
//                {
//                    binaryOperatorContainer.Append(c);
//                    confirmBinaryOperator = binaryOperatorContainer.ToString();
//                    isConfirmBinaryOperator = true;
//                    binaryOperatorContainer.Clear();
//                }
//            }
//        }
//        else
//        {
//            //当前字符与其下一个字符共同构成二元运算符，若是则将其添加至二元运算符容器
//            if (i <= (expStr.Length - 2))
//            {
//                Char nextChar = expStr[i + 1];
//                var binaryOperator = String.Concat(c, nextChar);
//                if (_SupportedBinaryOperators.Contains(binaryOperator))
//                {
//                    binaryOperatorContainer.Append(c);
//                    continue;
//                }
//            }
//            //当前字符是否与二元运算符容器中的字符构成运算符，若是则将其添加至二元运算符容器
//            if (binaryOperatorContainer.Length > 0)
//            {
//                var binaryOperator = binaryOperatorContainer.ToString() + c;
//                if (_SupportedBinaryOperators.Contains(binaryOperator))
//                {
//                    confirmBinaryOperator = binaryOperator;
//                    isConfirmBinaryOperator = true;
//                    binaryOperatorContainer.Clear();
//                    continue;
//                }
//            }
//            //如果已经确定了二元运算符，则添加至右边的一元表达式，否则添加至左边的一元表达式
//            if (isConfirmBinaryOperator) rightUnaryExpressionContainer.Append(c);
//            else
//            {
//                //如果是第一次构建二元表达式则添加至左，否则还是添加至右
//                if (lastExpression == null)
//                {
//                    leftUnaryExpressionContainer.Append(c);
//                }
//                else
//                {
//                    rightUnaryExpressionContainer.Append(c);
//                }
//            }
//            //如果到了字符串末尾
//            if (i == expStr.Length - 1)
//            {
//                if (isConfirmBinaryOperator)
//                {
//                    //构建二元表达式
//                    Expression leftExpression = lastExpression;
//                    if (leftExpression == null)
//                    {
//                        var leftExpressionStr = leftUnaryExpressionContainer.ToString();
//                        var leftBuildResult = this.GetUnaryExpression(leftExpressionStr, parameters, paraSymbol);
//                        //leftExpressionStr【 构建表达式错误】
//                        leftExpression = leftBuildResult.Item1;
//                        if (leftExpression == null)
//                        {
//                            errorMessage = this.BuildErrorMessage(leftExpressionStr + " " + leftBuildResult.Item2, i);
//                            return Tuple.Create<Expression, String>(null, errorMessage);
//                        }
//                    }

//                    var rightExpressionStr = rightUnaryExpressionContainer.ToString();
//                    var rightBuildResult = this.GetUnaryExpression(rightExpressionStr, parameters, paraSymbol);
//                    var rightExpression = rightBuildResult.Item1;
//                    //rightExpressionStr【 构建表达式错误】
//                    if (rightExpression == null)
//                    {
//                        errorMessage = this.BuildErrorMessage(rightExpressionStr + " " + rightBuildResult.Item2, i);
//                        return Tuple.Create<Expression, String>(null, errorMessage);
//                    }
//                    expression = this.GetBinaryExpression(confirmBinaryOperator, leftExpression, rightExpression);
//                    if (expression == null)
//                    {
//                        errorMessage = this.BuildErrorMessage("无效的二元运算符", i);
//                    }
//                    lastExpression = expression;
//                }
//                else
//                {
//                    //构建一元表达式
//                    String leftUnaryExpressionStr = leftUnaryExpressionContainer.ToString();
//                    var buildResult = this.GetUnaryExpression(leftUnaryExpressionStr, parameters, paraSymbol);
//                    expression = buildResult.Item1;
//                    if (expression == null)
//                    {
//                        errorMessage = this.BuildErrorMessage(leftUnaryExpressionStr + buildResult.Item2);
//                    }
//                }
//            }
//        }
//    }

//    return Tuple.Create<Expression, String>(expression, errorMessage); ;
//}