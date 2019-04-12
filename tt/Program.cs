using DemoCore.Entity;
using DemoCore.IRepositories;
using EntityFrameworkCoreOracle.Repositories;
using System;

namespace tt
{
    class Program
    {
        public static IRepository<Customer> t = new Repository<Customer>();
        static void Main(string[] args)
        {
            t.Add(new Customer()
            {
                Address = "aaa",
                CustomerId = 1,
                FirstName = "bb",
                LastName = "cc"
            });
            Console.WriteLine("Hello World!");

        }
    }
}
