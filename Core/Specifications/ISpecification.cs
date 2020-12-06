using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        //Like where statements
        Expression<Func<T, bool>> Criteria { get; }
        //List of Includes statements
        List<Expression<Func<T, object>>> Includes { get; }
        //Order by sorting
        Expression<Func<T, object>> OrderBy { get; }
        //Order by sorting descending
        Expression<Func<T, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}