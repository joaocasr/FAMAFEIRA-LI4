using FamaFeira.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace FamaFeira.Controllers
{
    public class FeirasController : Controller
    {
        private readonly IUser iuser;
        private readonly IFeira ifeira;


        public FeirasController(IUser interfaceuser,IFeira interfacefeira)
        {
            this.iuser = interfaceuser; 
            this.ifeira = interfacefeira;
        }

        [HttpPost]
        public IActionResult FeirasView(List<Feira> allFeiras, string username, string usertype)
        {

            return View(new FeiraViewModel(allFeiras, usertype, username));

        }

        [HttpPost]
        public IActionResult Feiras(string username, string password, string usertype)
        {
            List<Feira> allFeiras = ifeira.getAllFeiras();
            if (usertype.Equals("Expositor") && iuser.GetUser(username, usertype).getPassword().Equals(password))
            {
                return Redirect("~/Produtos/Produtos/"+username+"/"+usertype);
            }
            else if (!usertype.Equals("Expositor") && iuser.GetUser(username, usertype).getPassword().Equals(password))
            {

                return FeirasView(allFeiras, username, usertype);

            }
            else
            {
                TempData["error"] = "O username ou a password estão incorretos.";
                return Redirect("/Home/Index");
            }
        }
      
    }


}