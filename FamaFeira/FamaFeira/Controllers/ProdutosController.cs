using FamaFeira.Models;
using FamaFeira.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Policy;

namespace FamaFeira.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProduto iproduto;
        private readonly IStand istand;
        private readonly IFeira ifeira;


        public ProdutosController(IProduto interfaceproduto, IStand istand,IFeira ifeira)
        {
            this.iproduto = interfaceproduto;
            this.istand = istand;   
            this.ifeira = ifeira;   
        }

        public IActionResult ProdutosView(List<Produto> l, string role, string user,string designacao,string feira)
        {
            TempData["username"] = user;
            TempData["role"] = role;
            TempData["designacao"] = designacao;
            string tipo = ifeira.getTipoFeira(feira);
            return View(new ProdutoViewModel(l, role, user,feira,tipo));  
        }

        [HttpGet("{controller}/{action}/{user}/{role}/")]
        public IActionResult Produtos(string user,string role)
        {
            String standname = istand.getStandName(user);
            List<Produto> l = iproduto.getProdutosStand(standname);
          
            if (l.Count==0) TempData["produtoerro"] = "username:"+user+";role="+role;
            return ProdutosView(l,role,user,standname,"");
        }

        [HttpGet("{controller}/{action}/{user}/{role}/{designacao}/{feira}")]
        public IActionResult Produtos(string user, string role,string designacao,string feira)
        {
            List<Produto> l = iproduto.getProdutosStand(designacao);
            return ProdutosView(l, role, user,designacao,feira);
        }

        public ActionResult addCompra(string quantidade,string username, string role,string designacao,string feira)
        {
            DateTime dateTime = DateTime.Now;
            string codigo = quantidade.Split(";")[1];
            int num = Int32.Parse(quantidade.Split(";")[0]);

            int fkidCompra=iproduto.adicionaCompra(dateTime,num, username, designacao);
            int fkidProduto=iproduto.getIDProduto(codigo);
            double preco = iproduto.getPreco(codigo);
            double valor = num * preco;
            iproduto.adicionaCompraProduto(fkidCompra, fkidProduto,valor);

            if (fkidCompra > 0) TempData["successBuy"] = "A compra foi efetuada com sucesso!";
            return Redirect("/Produtos/Produtos/"+username+"/"+role+"/"+designacao+"/"+feira);
            
        }
    }
}
