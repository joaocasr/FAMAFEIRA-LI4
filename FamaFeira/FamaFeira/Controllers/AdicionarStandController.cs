using FamaFeira.Models.DAL;
using FamaFeira.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamaFeira.Controllers
{
    public class AdicionarStandController : Controller
    {
        private readonly IStand istand;

        public AdicionarStandController(IStand interfacestand)
        {
            this.istand = interfacestand;
        }

        public IActionResult AdicionarStand(string feira,string exp)
        {
            return View(new Expositivo(exp));
        }

        public IActionResult AddStand(string designacao,string descricao,string imagem,string empresa,string expositor,string feira,string expositivo, string recomendacao)
        {
            istand.adicionaStand(designacao, descricao, imagem, recomendacao, empresa, expositor, feira);
            return Redirect("/admin/Administrador/" + feira);
        }
    }
}
