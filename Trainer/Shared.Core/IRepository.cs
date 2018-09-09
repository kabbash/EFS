using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Core
{
    public abstract class IRepository<T, Y>

    {

        public abstract T GetById(Y id);

        public abstract IQueryable<T> GetAll();

        public abstract void Edit(T entity);

        public abstract void Insert(T entity);

        public abstract void Delete(T entity);

    }
}
