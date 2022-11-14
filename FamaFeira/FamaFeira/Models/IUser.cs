namespace FamaFeira.Models
{
    public interface IUser
    {
        List<User> GetAllUsers(String role);
        void addClient(string nome, string username, string telemovel, string password, string usertype);    
        Boolean ClientExists(String username);

        User GetUser(String username,String role);
    }
}
