namespace FamaFeira.Models
{
    public class UserViewModel
    {

        public string username { get; set; }

        public UserViewModel(string username)
        {
            this.username = username;
        }

        public string getUsername() { return username; }
    }
}
