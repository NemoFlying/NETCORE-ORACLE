using DemoCore.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreOracle.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //protected Repositories(IUnitOfWork)
        private DemoContext dbContext = new DemoContext();
        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }
    }
}
