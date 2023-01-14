using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;

namespace FamaFeira.Models.DAL
{
    public class ProdutoDAL : IProduto
    {
        string connectionstring = DALconfig.connectionstring;
        public List<Produto> getProdutosStand(string standname)
        {
            List<Produto> allProdutos = new List<Produto>();
            string query = @"SELECT P.nome,P.imagem,P.codigo,P.preco FROM [FamaFeiradb].[dbo].[Stand] AS S
	INNER JOIN [FamaFeiradb].[dbo].[Produto] AS P ON S.fk_idExpositor=P.fk_idExpositor WHERE S.designacao=" + "'" + standname + "';";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Produto p = new Produto(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDouble(3));
                    allProdutos.Add(p);
                }
                rdr.Close();
            }
            return allProdutos;
        }

        public int adicionaCompra(DateTime time, int quantidade, string cliente, string standdesignacao)
        {
            string query1 = @"SELECT fk_idExpositor FROM [FamaFeiradb].[dbo].[Stand] WHERE designacao=" + "'" + standdesignacao + "';";
            int fkidExpositor = 0;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fkidExpositor = rdr.GetInt32(0);
                }
                rdr.Close();
            }
            int fkidCliente = 0;
            string query2 = @"SELECT idCliente FROM [FamaFeiradb].[dbo].[Cliente] WHERE username=" + "'" + cliente + "';";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query2, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fkidCliente = rdr.GetInt32(0);
                }
                rdr.Close();
            }
            string query3 = @"INSERT INTO [FamaFeiradb].[dbo].[Compra] ([data_compra],[quantidade],[fk_idCliente],[fk_idExpositor]) VALUES ('" + time.ToString() + "','" + quantidade + "','" + fkidCliente + "','" + fkidExpositor + "');";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query3, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            string query4 = @"SELECT TOP 1 idCompra FROM [FamaFeiradb].[dbo].[Compra] ORDER BY idCompra DESC;";
            int r = -1;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query4, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    r = rdr.GetInt32(0);
                }
                rdr.Close();
            }
            return r;
        }

        public int getIDProduto(string codigo)
        {
            string query = @"SELECT idProduto FROM [FamaFeiradb].[dbo].[Produto] WHERE codigo=" + "'" + codigo + "';";
            int id = 0;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    id = rdr.GetInt32(0);
                }
                rdr.Close();
            }
            return id;
        }

        public double getPreco(string codigo)
        {
            string query = @"SELECT preco FROM [FamaFeiradb].[dbo].[Produto] WHERE codigo=" + "'" + codigo + "';";
            double preco = 0;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    preco = rdr.GetDouble(0);
                }
                rdr.Close();
            }
            return preco;
        }

        public void adicionaCompraProduto(int fkidCompra, int fkidProduto, double valor)
        {
            string query1 = @"INSERT INTO [FamaFeiradb].[dbo].[CompraProduto] ([valor],[produto_idProduto],[compra_idCompra]) VALUES ('" + valor + "','" + fkidProduto + "','" + fkidCompra + "');";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public int getIDExpositor(string username)
        {
            string query = @"SELECT idExpositor FROM [FamaFeiradb].[dbo].[Expositor] WHERE username=" + "'" + username + "';";
            int id = 0;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    id = rdr.GetInt32(0);
                }
                rdr.Close();
            }
            return id;

        }

        public List<Registo> consultaRegistos(string username)
        {
            int id = getIDExpositor(username);
            List<Registo> registos = new List<Registo>();
            string query = @" SELECT C.data_compra,P.nome,C.quantidade,CP.valor,CL.nome,CL.email,CL.telemovel FROM [FamaFeiradb].[dbo].[Compra] AS C
INNER JOIN [FamaFeiradb].[dbo].[CompraProduto] AS CP ON C.idCompra=CP.compra_idCompra INNER JOIN [FamaFeiradb].[dbo].[Cliente] AS CL ON CL.idCliente=C.fk_idCliente
INNER JOIN [FamaFeiradb].[dbo].[Produto] AS P ON  CP.produto_idProduto=P.idProduto
WHERE C.fk_idExpositor=" + "'" + id + "' ORDER BY C.data_compra DESC;";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Registo r = new Registo(rdr.GetString(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetDouble(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6));
                    registos.Add(r);
                }
                rdr.Close();
            }
            return registos;


        }

        public bool existeProduto(string codigo)
        {

            bool found = false;
            string query = @"SELECT codigo FROM [FamaFeiradb].[dbo].[Produto]";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(0).Equals(codigo)) found = true;
                }
                rdr.Close();
            }
            return found;
        }

        public int adicionaProduto(double preco, string nome, string imagem, string codigo, string expositor)
        {
            int r = 1;
            if (!existeProduto(codigo))
            {
                r = 0;
                int idExpositor = getIDExpositor(expositor);
                string query1 = @"INSERT INTO [FamaFeiradb].[dbo].[Produto] ([preco],[nome],[imagem],[codigo],[fk_idExpositor]) VALUES (" + (float)preco + ",'" + nome + "','" + imagem + "','" + codigo + "'," + idExpositor + ");";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query1, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return r;

        }

        public int removerProduto(string codigo)
        {
            int id = -1;
            int r = 1;
            if (existeProduto(codigo))
            {
                r = 0;
                id = getIDProduto(codigo);
                string query1 = @"DELETE  FROM [FamaFeiradb].[dbo].[CompraProduto] WHERE produto_idProduto=" + "'" + id + "';";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query1, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string query2 = @"DELETE  FROM [FamaFeiradb].[dbo].[Produto] WHERE idProduto=" + "'" + id + "';";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query2, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return r;
        }


    }
}
