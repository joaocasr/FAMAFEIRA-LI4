using FamaFeira.Models;
using FamaFeira.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FamaFeira.Controllers
{
    public class RemoverFeiraController : Controller
    {
        private readonly IFeira ifeira;

        public RemoverFeiraController(IFeira interfacefeira)
        {
            this.ifeira = interfacefeira;
        }
        public IActionResult RemoverFeira()
        {
            return View();
        }
        public IActionResult DelFeira(string designacao)
        {
            int r = this.ifeira.removeFeira(designacao);
            if (r == 0) TempData["feiranexiste"] = 1;// "A feira que digitou não existe.";
            else TempData["feiraremovida"] = 1;// "A feira foi removida com sucesso.";
            return Redirect("/RemoverFeira/RemoverFeira");
        }
    }
}
