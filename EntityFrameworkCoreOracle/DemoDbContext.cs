using DemoCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreOracle
{
    public class DemoDbContext:DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            :base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Invoice> Invoice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("NETCORE");
            base.OnModelCreating(modelBuilder);
        }
    }
}
