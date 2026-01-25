using System;
using System.Dynamic;
using System.Linq.Expressions;
using Core.Interface;

namespace Core.Specifications;

public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria = null) : ISpecification<T>
{
    public Expression<Func<T, bool>>? Criteria { get; private set; } = criteria;

    public List<Expression<Func<T, object>>> Includes { get; } = [];

    public Expression<Func<T, object>>? OrderBy {get; private set;}
    public Expression<Func<T, object>>? OrderByDescending {get; private set;}

    public List<string> IncludeStrings {get;} = new List<string>();

    public bool IsDistinct { get; private set; }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }
    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }
    protected void AddCriteria(Expression<Func<T, bool>> criteriaExpression)
    {
        Criteria = criteriaExpression;
    }
    protected void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }
    protected void ApplyDistinct()
    {
        IsDistinct = true;
    }

}
public class BaseSpecification<T, TResult>(Expression<Func<T, bool>>? criteria = null)
: BaseSpecification<T>(criteria), ISpecification<T, TResult>
{
    public Expression<Func<T, TResult>>? Selector { get; private set; }

    protected void AddSelector(Expression<Func<T, TResult>> selectorExpression)
    {
        Selector = selectorExpression;
    }
}
