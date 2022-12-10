using FamaFeira.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FamaFeira.Controllers
{
    public class RemoverStandController : Controller
    {
        private readonly IStand istand;

        public RemoverStandController(IStand interfacestand)
        {
            this.istand = interfacestand;
        }
        public IActionResult RemoverStand()
        {
            return View();
        }

        public IActionResult delStand(string designacao)
        {
            int r = -1;
            r=istand.removeStand(designacao);
            if (r == 1) TempData["remStandError"] = 1;
            return Redirect("/RemoverStand/RemoverStand");
        }
    }
}
