using System;
using System.Linq.Expressions;

namespace Core.Interface;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get;  }
    Expression<Func<T, object>>? OrderBy { get;  }
    Expression<Func<T, object>>? OrderByDescending { get;  }
    List<Expression<Func<T, object>>> Includes { get;  }
    List<string> IncludeStrings { get;  }

}