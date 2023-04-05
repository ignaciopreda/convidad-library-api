using System;
using System.Linq.Expressions;

namespace LibraryPersistence.Mappers
{
    public interface IExpressionMapperPersistence<TPersistence, TFilter> 
        where TPersistence : class
        where TFilter : class
    {
        Expression<Func<TPersistence, bool>> CreateExpression(TFilter filter);
    }
}
