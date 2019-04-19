using DemoCore.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EntityFrameworkCoreOracle.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //protected Repositories(IUnitOfWork)
        protected DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> whereLambda)
        {
            return _dbContext.Set<TEntity>().Where(whereLambda);
        }
    }
}
