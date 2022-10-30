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

            public bool UserExists(string username) {

            bool found = false;
            String query = @"SELECT username FROM [dbo].[Cliente]";
            using(SqlConnection con = new SqlConnection(connectionstring)){
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(0).Equals(username)) found = true;
                }
                rdr.Close();
            }
            return found;
        }
        public void Register_click(string nome, string username, string telemovel, string password,string usertype)
        {
            if (usertype.Equals("Cliente") && !UserExists(username))
            {
               
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    string query = @"INSERT INTO [dbo].[Cliente]
               ([nome]
               ,[username]
               ,[telemovel]
               ,[password])
             VALUES
                ('" + nome + "','" + username + "','" + telemovel + "','" + password + "');";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.ExecuteNonQuery();

                    con.Close();

                }
                Response.Redirect("/Home/Index");
            }
        }
    }
}