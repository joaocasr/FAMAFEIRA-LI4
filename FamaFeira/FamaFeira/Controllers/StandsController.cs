using FamaFeira.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FamaFeira.Controllers
{
    public class StandsController : Controller
    {
        string connectionstring = @"Data Source = LAPTOP-8C5JF0N5; Initial Catalog = FamaFeiradb; Integrated Security = True;";

        [HttpGet("{tipo}")]
        public IActionResult Stands(string tipo)
        {
            List<Stand> allStands = getStandsFromFeira(tipo);
            return View(allStands);
        }

        [HttpPost]
        public List<Stand> getStandsFromFeira(string tipo)
        {
            List<Stand> allStands = new List<Stand>();
            String query = @"SELECT S.designacao,S.descricao,S.imagem,S.recomendacao,S.empresa FROM [FamaFeiradb].[dbo].[Feira] AS F
	INNER JOIN [FamaFeiradb].[dbo].[Stand] AS S ON F.idFeira=S.fk_idFeira WHERE F.tipo=" + "'"+tipo+"';";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Stand s = new Stand(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
                    allStands.Add(s);
                }
                rdr.Close();
            }
            return allStands;
        }

    }
}
