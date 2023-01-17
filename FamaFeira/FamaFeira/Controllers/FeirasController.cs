using FamaFeira.Models;
using FamaFeira.Models.DAL;
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
            if (usertype == null)
            {
                TempData["error"] = "Selecione o role que possui no sistema.";
                return Redirect("/Home/Index");
            }
            List<Feira> allFeiras = ifeira.getAllFeiras();
            if (iuser.GetUser(username, usertype) != null)
            {
                if (usertype.Equals("Expositor") && iuser.GetUser(username, usertype).getPassword().Equals(password))
                {
                    return Redirect("~/Produtos/Produtos/" + username + "/" + usertype);
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
            else
            {
                TempData["error"] = "O username ou a password estão incorretos.";
                return Redirect("/Home/Index");
            }
        }
      
    }


}