using FamaFeira.Models;
using FamaFeira.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FamaFeira.Controllers
{
    public class RegistoController : Controller
    {
        private readonly IProduto iproduto;

        public RegistoController(IProduto interfaceproduto)
        {
            this.iproduto = interfaceproduto;
        }
        public IActionResult RegistoView(RegistoViewModel rvm)
        {
            return View(rvm);
        }

        [HttpGet("{user}")]
        public IActionResult Registo(string user)
        {
            List<Registo> l = iproduto.consultaRegistos(user);
            return RegistoView(new RegistoViewModel(l, user));

        }
    }
}
