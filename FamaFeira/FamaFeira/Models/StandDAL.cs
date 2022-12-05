using System.Data.SqlClient;

namespace FamaFeira.Models
{
    public class StandDAL:IStand
    {
        string connectionstring = @"Data Source = LAPTOP-8C5JF0N5; Initial Catalog = FamaFeiradb; Integrated Security = True;";

        public List<Stand> getStandsFromFeira(string designacao)
        {
            List<Stand> allStands = new List<Stand>();
            String query = @"SELECT S.designacao,S.descricao,S.imagem,S.recomendacao,S.empresa FROM [FamaFeiradb].[dbo].[Feira] AS F
	INNER JOIN [FamaFeiradb].[dbo].[Stand] AS S ON F.idFeira=S.fk_idFeira WHERE F.designacao=" + "'" + designacao + "';";
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

        public String getStandName(string username)
        {
            String nome = "";
            String query = @"SELECT S.designacao FROM [FamaFeiradb].[dbo].[Expositor] AS E
	INNER JOIN [FamaFeiradb].[dbo].[Stand] AS S ON E.idExpositor=S.fk_idExpositor WHERE E.username=" + "'" + username + "';";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    nome= rdr.GetString(0);
                }
                rdr.Close();
            }
            return nome;
        }


        public bool existeStand(string designacao)
        {

            bool found = false;
            String query = @"SELECT designacao FROM [dbo].[Stand]";
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

        public int adicionaStand(string designacao, string descricao, string imagem, string recomendacao, string empresa)
        {
            bool b = this.existeStand(designacao);
            int result = 1;
            if (b.Equals(true)) result = 0;
            if (result == 1)
            {
                String query = @"INSERT INTO [dbo].[Stand] ([designacao],[descricao],[imagem],[recomendacao],[empresa]) VALUES ('" + designacao + "','" + descricao + "','" + imagem + "','" + recomendacao + "','" + empresa + "','" + 1 + "');";
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

        public int removeStand(string designacao)
        {
            bool b = this.existeStand(designacao);
            int result = 1;
            if (b.Equals(true)) result = 0;
            if (result == 1)
            {

                String query = @"DELETE FROM [dbo].[Stand] WHERE [designacao] = " + designacao;
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
