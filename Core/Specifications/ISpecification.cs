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
    }
}