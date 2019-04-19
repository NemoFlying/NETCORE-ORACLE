using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DemoCore.IRepositories
{
    public interface IRepository<TEntity> : ITransientDependency where TEntity : class
    {
        void Add(TEntity entity);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> whereLambda);
    }
}
