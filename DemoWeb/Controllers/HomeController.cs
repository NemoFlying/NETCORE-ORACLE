using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoWeb.Models;
using DemoCore.Entity;
using DemoCore.IRepositories;
using EntityFrameworkCoreOracle.Repositories;
using EntityFrameworkCoreOracle;
using Microsoft.Extensions.Configuration;

namespace DemoWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepository<Customer> _tt;
        //private readonly IMyRepository _my;

        public HomeController(
            IRepository<Customer> my,
            IConfiguration configuration
            )
        {
            //_tt = tt;
            _tt = my;
            //var kk = new DemoDbContextFactory(configuration).CreateDbContext();
        }
             
        public IActionResult Index()
        {
            var kk = _tt.GetAll(con => con.CustomerId == 1).ToList();
            //var kk = _my.test();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
