using System.Data.SqlClient;

namespace FamaFeira.Models
{
    public class UserDAL :IUser
    {
        string connectionstring = @"Data Source = LAPTOP-8C5JF0N5; Initial Catalog = FamaFeiradb; Integrated Security = True;";

        public List<User> GetAllUsers(String role)
        {
            List<User> users = new List<User>();
            if (role.Equals("Cliente"))
            {
                String query = @"SELECT * FROM [dbo].[Cliente];";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        User user = new User(rdr.GetString(1),rdr.GetString(2), rdr.GetString(3), rdr.GetString(4),"Cliente");
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public bool ClientExists(string username)
        {

            bool found = false;
            String query = @"SELECT username FROM [dbo].[Cliente]";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(0).Equals(username)) found = true;
                }
                rdr.Close();
            }
            return found;
        }

        public void addClient(string nome, string username, string telemovel, string password, string usertype)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                string query = @"INSERT INTO [dbo].[Cliente]
               ([nome]
               ,[username]
               ,[telemovel]
               ,[password])
             VALUES
                ('" + nome + "','" + username + "','" + telemovel + "','" + password + "');";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();

                con.Close();

            }
        }
        public User GetUser(String username, String role)
        {
            if (role.Equals("Cliente"))
            {
                String query = @"SELECT * FROM [dbo].[Cliente] WHERE username = " + "'" + username + "'; "; ;
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        return new User(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), "Cliente");
                    }
                    rdr.Close();
                }

            }
            if (role.Equals("Administrador"))
            {
                String query = @"SELECT * FROM [dbo].[Administrador] WHERE username = " + "'" + username + "'; "; ;
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        return new User(rdr.GetString(1), rdr.GetString(2), "Administrador");
                    }
                    rdr.Close();
                }

            }
            return null;
        }
    }
}
