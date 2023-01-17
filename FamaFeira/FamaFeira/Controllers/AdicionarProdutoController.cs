using FamaFeira.Models;
using FamaFeira.Models.DAL;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace FamaFeira.Controllers
{
    public class AdicionarProdutoController : Controller
    {
        private readonly IProduto iproduto;


        public AdicionarProdutoController(IProduto interfaceproduto)
        {
            this.iproduto = interfaceproduto;
        }

        public IActionResult AdicionarProduto(String user)
        {
            List<Produto> produtos = new List<Produto>();  
            return View(new ProdutoViewModel(produtos,"",user,"",""));
        }

        public IActionResult adicionaVendaProduto(string codigo, string nome, string imagem, string preco,string user)
        {

            int r = -1;
            double valor = double.Parse(preco, CultureInfo.InvariantCulture);
            r =this.iproduto.adicionaProduto(valor, nome, imagem, codigo, user);
            if (r == 1) TempData["erroAddProduto"] = 1;
            else TempData["erroSuccProduto"] = 1;
            return Redirect("/AdicionarProduto/AdicionarProduto?user="+user);

        }
    }
}
