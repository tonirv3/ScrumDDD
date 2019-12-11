using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Domain.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        TEntity GetById(TKey id);
        TKey Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
