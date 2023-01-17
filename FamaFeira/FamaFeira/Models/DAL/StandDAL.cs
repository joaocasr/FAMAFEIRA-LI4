using System.Data.SqlClient;

namespace FamaFeira.Models.DAL
{
    public class StandDAL : IStand
    {
        string connectionstring = DALconfig.connectionstring;

        public List<Stand> getStandsFromFeira(string designacao)
        {
            List<Stand> allStands = new List<Stand>();
            string query = @"SELECT S.designacao,S.descricao,S.imagem,S.recomendacao,S.empresa FROM [FamaFeiradb].[dbo].[Feira] AS F
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

        public string getStandName(string username)
        {
            string nome = "";
            string query = @"SELECT S.designacao FROM [FamaFeiradb].[dbo].[Expositor] AS E
	INNER JOIN [FamaFeiradb].[dbo].[Stand] AS S ON E.idExpositor=S.fk_idExpositor WHERE E.username=" + "'" + username + "';";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    nome = rdr.GetString(0);
                }
                rdr.Close();
            }
            return nome;
        }


        public bool existeStand(string designacao)
        {

            bool found = false;
            string query = @"SELECT designacao FROM [FamaFeiradb].[dbo].[Stand]";
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

        public int getIDExpositor(string username)
        {
            string query1 = @"SELECT idExpositor FROM [FamaFeiradb].[dbo].[Expositor] WHERE username=" + "'" + username + "';";
            int idExpositor = -1;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    idExpositor = rdr.GetInt32(0);
                }
                rdr.Close();
            }
            return idExpositor;
        }

        public bool expositorHasStand(int idexpositor)
        {
            string query = @"SELECT COUNT(idStand) FROM [FamaFeiradb].[dbo].[Stand] WHERE fk_idExpositor=" + "'" + idexpositor + "';";
            int n = -1;
            bool b = true;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    n = rdr.GetInt32(0);
                }
                rdr.Close();
            }
            if (n == 0) b = false;
            return b;
        }

        public int adicionaStand(string designacao, string descricao, string imagem, string recomendacao, string empresa, string expositor, string feira)
        {
            string query1 = @"SELECT idFeira FROM [FamaFeiradb].[dbo].[Feira] WHERE designacao=" + "'" + feira + "';";
            int idfeira = -1;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    idfeira = rdr.GetInt32(0);
                }
                rdr.Close();
            }
            int fk_idExpositor = getIDExpositor(expositor);
            bool b = existeStand(designacao);
            bool c = expositorHasStand(fk_idExpositor);
            int result = 1;
            if (b.Equals(true) || c.Equals(true)) result = 0;
            if (result == 1)
            {
                string query2 = @"INSERT INTO [FamaFeiradb].[dbo].[Stand] ([designacao],[descricao],[imagem],[recomendacao],[empresa],[fk_idExpositor],[fk_idAdmin],[fk_idFeira]) VALUES ('" + designacao + "','" + descricao + "','" + imagem + "','" + recomendacao + "','" + empresa + "','" + fk_idExpositor + "','" + 1 + "','" + idfeira + "');";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query2, con);
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return result;
        }

        public int removeStand(string designacao)
        {
            bool b = existeStand(designacao);
            int result = 1;
            if (b==true) result = 0;
            if (result == 0)
            {

                string query = @"DELETE FROM [FamaFeiradb].[dbo].[Stand] WHERE [designacao]=" + "'" + designacao + "';";
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

        public bool isExpositivo(string designacao)
        {
            string query = @"SELECT tipo FROM [FamaFeiradb].[dbo].[Feira] WHERE designacao=" + "'" + designacao + "';";
            bool b = false;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(0).Equals("Feira de Empreendedorismo") || rdr.GetString(0).Equals("Feira de Negócios") || rdr.GetString(0).Equals("Feira Empresarial")) b = true;
                }
                rdr.Close();
            }
            return b;
        }

    }
}
