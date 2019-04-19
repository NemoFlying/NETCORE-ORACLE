using DemoCore.Entity;
using DemoCore.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EntityFrameworkCoreOracle.Repositories
{
    public class MyRepository : Repository<Invoice>, IMyRepository
    {
        public MyRepository(DbContext dbContext) :
            base(dbContext)
        {
        }
        public string test()
        {
            return "kkkkk";
        }
    }
}
