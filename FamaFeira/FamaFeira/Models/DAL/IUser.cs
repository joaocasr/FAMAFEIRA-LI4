namespace FamaFeira.Models.DAL
{
    public interface IUser
    {
        List<User> GetAllUsers(string role);
        void addClient(string nome, string username, string telemovel, string password, string email, string morada, string usertype);
        bool ClientExists(string username);
        public bool ExpositorExists(string username);
        User GetUser(string username, string role);
        public void addExpositor(string nome, string username, string password, string usertype);
    }
}
