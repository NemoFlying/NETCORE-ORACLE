using DemoCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkCoreOracle.DbInitial
{
    public class DbInitailDemo
    {
        public static void  InitDb(DbContext dbContext)
        {
            var allMigrations = dbContext.Database.GetMigrations().ToList();
            var appliedMigrations = dbContext.Database.GetAppliedMigrations().ToList();

            if (allMigrations.Count() - appliedMigrations.Count() > 0)
            {
                dbContext.Database.Migrate();
                if (appliedMigrations.Count() == 0)
                {
                    var customer = new Customer()
                    {
                        CustomerId = 1,
                        Address = "aa",
                        FirstName = "bb",
                        LastName = "cc"
                    };
                    dbContext.Set<Customer>().Add(customer);
                    dbContext.SaveChanges();
                }

            }


            //if (dbContext.Database != null && dbContext.Database.EnsureCreated())
            //{
            //    var customer = new Customer()
            //    {
            //        CustomerId = 1,
            //        Address = "aa",
            //        FirstName = "bb",
            //        LastName = "cc"
            //    };
            //    dbContext.Set<Customer>().Add(customer);
            //    dbContext.SaveChanges();
            //}
        }
    }
}
