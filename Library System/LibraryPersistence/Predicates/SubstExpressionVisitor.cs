using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LibraryPersistence.Predicates
{
    internal class SubstExpressionVisitor : ExpressionVisitor
    {
        public Dictionary<Expression, Expression> subst = new Dictionary<Expression, Expression>();

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (subst.TryGetValue(node, out Expression newValue))
            {
                return newValue;
            }

            return node;
        }
    }
}
