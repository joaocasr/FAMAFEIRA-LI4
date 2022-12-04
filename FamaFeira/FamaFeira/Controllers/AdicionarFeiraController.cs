using FamaFeira.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FamaFeira.Controllers
{
    public class AdicionarFeiraController : Controller
    {
        private readonly IFeira ifeira;


        public AdicionarFeiraController(IFeira interfacefeira)
        {
            this.ifeira = interfacefeira;
        }
        public IActionResult AdicionarFeira()
        {
            return View();
        }

        public IActionResult AddFeira(string tipo, string designacao,string localizacao, string imagem, string data)
        {
            int r=this.ifeira.adicionaFeira(tipo,designacao,localizacao,imagem,data);
            if (r == 0) TempData["errorfeira"] = "Uma feira com a mesma designação já existe no sistema.";
            else TempData["rightfeira"] = "A Feira foi adicionada com sucesso.";
            return Redirect("/AdicionarFeira/AdicionarFeira");
        }
    }
}