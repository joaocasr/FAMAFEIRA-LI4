using FamaFeira.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FamaFeira.Controllers
{
    public class RemoverProdutoController : Controller
    {
        private readonly IProduto iproduto;

        public RemoverProdutoController(IProduto interfaceproduto)
        {
            this.iproduto = interfaceproduto;
        }

        public IActionResult RemoverProduto()
        {
            return View();
        }

        public IActionResult delProduto(string codigo)
        {
            int r=-1;
            r=iproduto.removerProduto(codigo);
            if (r == 1) TempData["erroDelProduto"] = 1;
            return Redirect("/RemoverProduto/RemoverProduto");

        }
    }
}
