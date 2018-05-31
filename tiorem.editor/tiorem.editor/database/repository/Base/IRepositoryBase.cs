using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace tiorem.editor.database.repository.Base
{
    public interface IRepositoryBase<T> where T:class, new()
    {
        T Get(Expression<Func<T, bool>> filter = null, List<string> includes = null);
        T Get(Expression<Func<T, bool>> filter = null, bool isNullControl = false);
        T Get(Expression<Func<T, bool>> filter = null, List<string> includes = null, bool isNullControl = false);
        List<T> GetList(Expression<Func<T, bool>> filter = null, List<string> includes = null);
        T Add(T entity); 
        T Update(T entity);
        T Delete(T entity);

    }
}
