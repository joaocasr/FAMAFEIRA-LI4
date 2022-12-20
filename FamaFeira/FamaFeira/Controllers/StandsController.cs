using FamaFeira.Models;
using FamaFeira.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FamaFeira.Controllers
{
    public class StandsController : Controller
    {
        private readonly IUser iuser;
        private readonly IStand istand;

        public StandsController(IUser interfaceuser,IStand interfacestand)
        {
            this.iuser = interfaceuser;
            this.istand = interfacestand;
        }

        [HttpGet("{user}/{role}/{designacao}")]
        public IActionResult Stands(string user,string role,string designacao)
        {
            
            List<Stand> allStands = istand.getStandsFromFeira(designacao);
            bool isExpositivo = istand.isExpositivo(designacao);
            return View(new StandViewModel(allStands, role, user,designacao,isExpositivo));
        }        

    }
}
