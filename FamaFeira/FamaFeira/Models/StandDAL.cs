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

    }
}
