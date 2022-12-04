using System.Data;
using System.Data.SqlClient;

namespace FamaFeira.Models
{
    public class ProdutoDAL:IProduto
    {
        string connectionstring = @"Data Source = LAPTOP-8C5JF0N5; Initial Catalog = FamaFeiradb; Integrated Security = True;";
        public List<Produto> getProdutosStand(string standname)
        {
            List<Produto> allProdutos = new List<Produto>();
            String query = @"SELECT P.nome,P.imagem,P.codigo,P.preco FROM [FamaFeiradb].[dbo].[Stand] AS S
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

        public int adicionaCompra(DateTime time, int quantidade,string cliente,string standdesignacao)
        {
            String query1 = @"SELECT fk_idExpositor FROM [FamaFeiradb].[dbo].[Stand] WHERE designacao=" + "'" + standdesignacao + "';";
            int fkidExpositor = 0;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fkidExpositor=rdr.GetInt32(0);
                }
                rdr.Close();
            }
            int fkidCliente=0;
            String query2 = @"SELECT idCliente FROM [FamaFeiradb].[dbo].[Cliente] WHERE username=" + "'" + cliente + "';";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fkidCliente = rdr.GetInt32(0);
                }
                rdr.Close();
            }
            String query3 = @"INSERT INTO [FamaFeiradb].[dbo].[Compra] ([data_compra],[quantidade],[fk_idCliente],[fk_idExpositor]) VALUES ('" + time.ToString() + "','" + quantidade + "','" + fkidCliente + "','" + fkidExpositor + "');";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query3, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            String query4 = @"SELECT TOP 1 idCompra FROM [FamaFeiradb].[dbo].[Compra] ORDER BY idCompra DESC;";
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
            String query= @"SELECT idProduto FROM [FamaFeiradb].[dbo].[Produto] WHERE codigo=" + "'" + codigo + "';";
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
            String query = @"SELECT preco FROM [FamaFeiradb].[dbo].[Produto] WHERE codigo=" + "'" + codigo + "';";
            double preco=0;
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
            String query1 = @"INSERT INTO [FamaFeiradb].[dbo].[CompraProduto] ([valor],[produto_idProduto],[compra_idCompra]) VALUES ('" + valor + "','" + fkidProduto + "','" + fkidCompra + "');";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }


    }
}
