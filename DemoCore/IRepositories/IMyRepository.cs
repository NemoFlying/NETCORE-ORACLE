using DemoCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.IRepositories
{
    public interface IMyRepository : IRepository<Invoice>
    {
        string test();
    }
}
