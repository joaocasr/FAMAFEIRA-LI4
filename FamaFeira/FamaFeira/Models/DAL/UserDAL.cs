using System.Data.SqlClient;

namespace FamaFeira.Models.DAL
{
    public class UserDAL : IUser
    {
        string connectionstring = DALconfig.connectionstring;

        public List<User> GetAllUsers(string role)
        {
            List<User> users = new List<User>();
            if (role.Equals("Cliente"))
            {
                string query = @"SELECT * FROM [dbo].[Cliente];";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        User user = new User(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), "Cliente");
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public bool ClientExists(string username)
        {

            bool found = false;
            string query = @"SELECT username FROM [dbo].[Cliente]";
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

        public bool ExpositorExists(string username)
        {

            bool found = false;
            string query = @"SELECT username FROM [dbo].[Expositor]";
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

        public void addClient(string nome, string username, string telemovel, string password, string email, string morada, string usertype)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                string query = @"INSERT INTO [dbo].[Cliente]
               ([nome]
               ,[username]
               ,[telemovel]
               ,[password]
               ,[email]
               ,[morada])
             VALUES
                ('" + nome + "','" + username + "','" + telemovel + "','" + password + "','" + email + "','" + morada + "');";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();

                con.Close();

            }
        }

        public void addExpositor(string nome, string username, string password, string usertype)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                string query = @"INSERT INTO [dbo].[Expositor]
               ([nome]
               ,[username]
               ,[password])
             VALUES
                ('" + nome + "','" + username + "','" + password + "');";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public User GetUser(string username, string role)
        {
            if (role.Equals("Cliente"))
            {
                string query = @"SELECT * FROM [dbo].[Cliente] WHERE username = " + "'" + username + "'; ";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        return new User(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), "Cliente");
                    }
                    rdr.Close();
                }

            }
            if (role.Equals("Administrador"))
            {
                string query = @"SELECT username,password FROM [dbo].[Administrador] WHERE username = " + "'" + username + "'; "; ;
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        return new User(rdr.GetString(0), rdr.GetString(1), "Administrador");
                    }
                    rdr.Close();
                }

            }
            if (role.Equals("Expositor"))
            {
                string query = @"SELECT * FROM [dbo].[Expositor] WHERE username = " + "'" + username + "'; "; ;
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        return new User(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), "Expositor");
                    }
                    rdr.Close();
                }

            }
            return null;
        }
    }
}
