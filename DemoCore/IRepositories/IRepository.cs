using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
    }
}
