namespace FamaFeira.Models
{
    public interface IUser
    {
        List<User> GetAllUsers(String role);
        void addClient(string nome, string username, string telemovel, string password,string email,string morada, string usertype);
        bool ClientExists(String username);
        public bool ExpositorExists(string username);
        User GetUser(String username,String role);
        public void addExpositor(string nome, string username, string password, string usertype);
    }
}
