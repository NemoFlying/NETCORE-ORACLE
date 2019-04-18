using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoWeb.Models;
using DemoCore.Entity;
using DemoCore.IRepositories;

namespace DemoWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepository<Customer> _tt;


        public HomeController(IRepository<Customer> tt)
        {
            tt = _tt;
        }
             
        public IActionResult Index()
        {
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
