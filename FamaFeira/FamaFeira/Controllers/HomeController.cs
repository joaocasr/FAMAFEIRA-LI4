using FamaFeira.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Xml.Linq;

namespace FamaFeira.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUser iuser;
        string connectionstring = @"Data Source = LAPTOP-8C5JF0N5; Initial Catalog = FamaFeiradb; Integrated Security = True;";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
        public void Register_click(string nome, string username, string telemovel, string password,string usertype)
        {
            if (usertype.Equals("Cliente") && !iuser.ClientExists(username))
            {
               
               iuser.addClient(nome, username, telemovel, password, usertype);    
               Response.Redirect("/Home/Index");
            }
        }
    }
}