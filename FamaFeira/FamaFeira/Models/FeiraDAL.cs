using System.Data.SqlClient;

namespace FamaFeira.Models
{
    public class FeiraDAL:IFeira
    {
        string connectionstring = @"Data Source = LAPTOP-8C5JF0N5; Initial Catalog = FamaFeiradb; Integrated Security = True;";

        public List<Feira> getAllFeiras()
        {
            List<Feira> allFeiras = new List<Feira>();
            String query = @"SELECT tipo,designacao,localizacao,imagem,dataFeira FROM [dbo].[Feira]";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Feira f = new Feira(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
                    allFeiras.Add(f);
                }
                rdr.Close();
            }
            return allFeiras;
        }

        public bool existeFeira(string designacao)
        {

            bool found = false;
            String query = @"SELECT designacao FROM [dbo].[Feira]";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(0).Equals(designacao)) found = true;
                }
                rdr.Close();
            }
            return found;
        }

        public int adicionaFeira(string tipo, string designacao,string localizacao,string imagem,string data) {
            bool b = this.existeFeira(designacao);
            int result = 1;
            if(b.Equals(true)) result = 0;
            if (result == 1)
            {
                String query = @"INSERT INTO [dbo].[Feira] ([tipo],[designacao],[localizacao],[imagem],[dataFeira],[fk_idAdmin]) VALUES ('" + tipo + "','" + designacao + "','" + localizacao + "','" + imagem + "','" + data + "','" + 1 + "');";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return result;
        }
    }
}
