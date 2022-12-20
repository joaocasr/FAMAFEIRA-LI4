using System.Data.SqlClient;

namespace FamaFeira.Models.DAL
{
    public class FeiraDAL : IFeira
    {
        string connectionstring = DALconfig.connectionstring;

        public List<Feira> getAllFeiras()
        {
            List<Feira> allFeiras = new List<Feira>();
            string query = @"SELECT tipo,designacao,localizacao,imagem,dataFeira FROM [FamaFeiradb].[dbo].[Feira]";
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
            string query = @"SELECT designacao FROM [dbo].[Feira]";
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

        public int adicionaFeira(string tipo, string designacao, string localizacao, string imagem, string data)
        {
            bool b = existeFeira(designacao);
            int result = 1;
            if (b==true) result = 0;
            if (result == 1)
            {
                string query = @"INSERT INTO [FamaFeiradb].[dbo].[Feira] ([tipo],[designacao],[localizacao],[imagem],[dataFeira],[fk_idAdmin]) VALUES ('" + tipo + "','" + designacao + "','" + localizacao + "','" + imagem + "','" + data + "','" + 1 + "');";
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
        public void removeStandsFeira(int fkidFeira)
        {
            string query = @"DELETE FROM [FamaFeiradb].[dbo].[Stand] WHERE fk_idFeira=" + "'" + fkidFeira + "';";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public int removeFeira(string designacao)
        {
            int r = 1;
            if (!existeFeira(designacao)) r = 0;
            else
            {
                int id = -1;
                string query1 = @"SELECT idFeira FROM [FamaFeiradb].[dbo].[Feira] WHERE designacao=" + "'" + designacao + "';";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query1, con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        id = rdr.GetInt32(0);
                    }
                    rdr.Close();
                }
                removeStandsFeira(id);
            }
            string query2 = @"DELETE FROM [FamaFeiradb].[dbo].[Feira] WHERE designacao=" + "'" + designacao + "';";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query2, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return r;
        }

        public string getTipoFeira(string designacao)
        {
            string query1 = @"SELECT tipo FROM [FamaFeiradb].[dbo].[Feira] WHERE designacao=" + "'" + designacao + "';";
            string tipo = "";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tipo = rdr.GetString(0);
                }
                rdr.Close();
            }
            return tipo;
        }

    }
}
