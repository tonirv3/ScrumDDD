using ScrumDDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Infrastructure.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    {
        public TKey Add(TEntity entity)
        {
            return default(TKey);
        }

        public void Delete(TEntity entity)
        {
            
        }

        public TEntity GetById(TKey id)
        {
            return default(TEntity);
        }

        public void Update(TEntity entity)
        {
            
        }
    }
}
