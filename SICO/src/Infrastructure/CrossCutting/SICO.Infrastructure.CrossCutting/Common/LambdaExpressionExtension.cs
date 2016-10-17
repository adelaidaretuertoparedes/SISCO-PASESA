using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SICO.Infrastructure.CrossCutting.Common
{
    public static class LambdaExpressionExtension
    {
        public static string GetPropertyName<T>(Expression<Func<T, object>> property)
        {
            LambdaExpression lambda = property;
            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                UnaryExpression unaryExpression = (UnaryExpression)(lambda.Body);
                memberExpression = (MemberExpression)(unaryExpression.Operand);
            }
            else
            {
                memberExpression = (MemberExpression)(lambda.Body);
            }
            return ((PropertyInfo)memberExpression.Member).Name;
        }
        public static string GetExpressionText(LambdaExpression expression)
        {
            var stack = new Stack<string>();
            Expression expression1 = expression.Body;
            while (expression1 != null)
            {
                if (expression1.NodeType == ExpressionType.Call)
                {
                    var methodCallExpression = (MethodCallExpression)expression1;
                    if (IsSingleArgumentIndexer(methodCallExpression))
                    {
                        stack.Push(GetIndexerInvocation((methodCallExpression.Arguments).Single(), (expression.Parameters).ToArray()));
                        expression1 = methodCallExpression.Object;
                    }
                    else
                        break;
                }
                else if (expression1.NodeType == ExpressionType.ArrayIndex)
                {
                    var binaryExpression = (BinaryExpression)expression1;
                    stack.Push(GetIndexerInvocation(binaryExpression.Right, (expression.Parameters).ToArray()));
                    expression1 = binaryExpression.Left;
                }
                else if (expression1.NodeType == ExpressionType.MemberAccess)
                {
                    var memberExpression = (MemberExpression)expression1;
                    stack.Push("." + memberExpression.Member.Name);
                    expression1 = memberExpression.Expression;
                }
                else if (expression1.NodeType == ExpressionType.Parameter)
                {
                    stack.Push(string.Empty);
                    expression1 = null;
                }
                else if (expression1.NodeType == ExpressionType.Convert || expression1.NodeType == ExpressionType.ConvertChecked)
                {
                    var ue = expression1 as UnaryExpression;
                    var memberExpression = ((ue != null) ? ue.Operand : null) as MemberExpression;
                    if (memberExpression != null)
                    {
                        stack.Push(memberExpression.Member.Name);
                        expression1 = memberExpression.Expression;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                    break;
            }
            if (stack.Count > 0 && string.Equals(stack.Peek(), ".model", StringComparison.OrdinalIgnoreCase))
                stack.Pop();
            if (stack.Count <= 0)
                return string.Empty;
            return (stack).Aggregate(((left, right) => left + right)).TrimStart(new char[1] { '.' });
        }

        public static string GetMemberName<T>(this T instance, Expression<Action<T>> expression)
        {
            return GetExpressionText(expression);
        }
        private static bool IsSingleArgumentIndexer(Expression expression)
        {
            var methodExpression = expression as MethodCallExpression;
            if (methodExpression == null || methodExpression.Arguments.Count != 1)
                return false;
            return methodExpression.Method.DeclaringType != null && (methodExpression.Method.DeclaringType.GetDefaultMembers()).OfType<PropertyInfo>().Any((p => p.GetGetMethod() == methodExpression.Method));
        }
        private static string GetIndexerInvocation(Expression expression, ParameterExpression[] parameters)
        {
            return "";
        }
    }
}
