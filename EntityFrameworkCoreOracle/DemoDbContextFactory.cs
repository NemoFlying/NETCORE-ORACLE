using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreOracle
{
    public class DemoDbContextFactory
    {
        [InReject]
        public IConfiguration _configuration { get; set; }
        //public DemoDbContextFactory(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public DbContext CreateDbContext()
        {
            //从配置文件中获取数据库连接字符串
            var connectString = _configuration["ConnectionStrings:Default"]; 
            return new DemoDbContext(connectString);
        }
    }
}
