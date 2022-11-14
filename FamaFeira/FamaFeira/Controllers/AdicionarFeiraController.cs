using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FamaFeira.Controllers
{
    public class AdicionarFeiraController : Controller
    {
        string connectionstring = @"Data Source = LAPTOP-8C5JF0N5; Initial Catalog = FamaFeiradb; Integrated Security = True;";

        public IActionResult AdicionarFeira()
        {
            return View();
        }

        public void AddFeira(string tipo, string localizacao, string imagem, string data)
        {
            int result;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {

                String query = @"INSERT INTO [dbo].[Feira] ([tipo],[localizacao],[imagem],[dataFeira],[fk_idAdmin]) VALUES ('" + tipo + "','" + localizacao + "','" + imagem + "','" + data + "','" + 1 + "');";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                result = cmd.ExecuteNonQuery();

                con.Close();
            }
            Response.Redirect("/AdicionarFeira/AdicionarFeira");

        }
    }
}