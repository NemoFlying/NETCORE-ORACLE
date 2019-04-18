using DemoCore.Entity;
using DemoCore.IRepositories;
using EntityFrameworkCoreOracle.Repositories;
using System;

namespace tt
{
    class Program
    {
        public readonly IRepository<Customer> _t;

        public Program(IRepository<Customer> t)
        {
            _t = t;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Read();

        }
    }
}
