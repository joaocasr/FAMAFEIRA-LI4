using FamaFeira.Models.DAL;
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

        public IActionResult AdicionarStand()
        {
            return View();
        }

        public IActionResult AddStand(string designacao,string descricao,string imagem,string recomendacao,string empresa,string expositor,string feira)
        {
            istand.adicionaStand(designacao, descricao, imagem, recomendacao, empresa, expositor, feira);
            return Redirect("/AdicionarStand/AdicionarStand");
        }
    }
}
