using FamaFeira.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace FamaFeira.Controllers
{
    public class FeirasController : Controller
    {
        string connectionstring = @"Data Source = LAPTOP-8C5JF0N5; Initial Catalog = FamaFeiradb; Integrated Security = True;";
        private readonly IUser iuser;


        public FeirasController(IUser interfaceuser)
        {
            this.iuser = interfaceuser; 
        }

        [HttpPost]
        public IActionResult FeirasView(List<Feira> allFeiras, string username, string usertype)
        {

            return View(new FeiraViewModel(allFeiras, usertype, username));

        }

        [HttpPost]
        public IActionResult Feiras(string username, string password, string usertype)
        {
            List<Feira> allFeiras = getAllFeiras();
            if (iuser.GetUser(username,usertype).getPassword().Equals(password))
            {
     
                return FeirasView(allFeiras, username, usertype);
                               
            }
            TempData["error"] = "O username ou a password estão incorretos.";
            return Redirect("/Home/Index");

        }

        [HttpPost]
        public List<Feira> getAllFeiras()
        {
            List<Feira> allFeiras = new List<Feira>();
            String query = @"SELECT tipo,localizacao,imagem,dataFeira FROM [dbo].[Feira]";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Feira f = new Feira(rdr.GetString(0),rdr.GetString(1),rdr.GetString(2), rdr.GetString(3));
                    allFeiras.Add(f);
                }
                rdr.Close();
            }
            return allFeiras;
        }
    }


}