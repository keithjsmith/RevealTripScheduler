using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DomainRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Cancel(int Id);
    }
}
