using System;
using System.Linq.Expressions;

namespace LibraryPersistence.Predicates
{
    public static class PredicateBuilderExtension
    {
        public static Expression<Func<TSource, bool>> And<TSource>(
            this Expression<Func<TSource, bool>> initial,
            Expression<Func<TSource, bool>> agregate
            )
        {
            ParameterExpression param = initial.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.subst[agregate.Parameters[0]] = param;

            Expression body = Expression.AndAlso(initial.Body, visitor.Visit(agregate.Body));

            return Expression.Lambda<Func<TSource, bool>>(body, param);
        }

        public static Expression<Func<TSource, bool>> Or<TSource>(
            this Expression<Func<TSource, bool>> initial,
            Expression<Func<TSource, bool>> agregate
            )
        {
            ParameterExpression param = initial.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.subst[agregate.Parameters[0]] = param;

            Expression body = Expression.OrElse(initial.Body, visitor.Visit(agregate.Body));

            return Expression.Lambda<Func<TSource, bool>>(body, param);
        }

        public static Expression<Func<TSource, bool>> Not<TSource>(this Expression<Func<TSource, bool>> initial)
        {
            Expression body = Expression.Not(initial.Body);

            return Expression.Lambda<Func<TSource, bool>>(body, initial.Parameters);
        }
    }
}
