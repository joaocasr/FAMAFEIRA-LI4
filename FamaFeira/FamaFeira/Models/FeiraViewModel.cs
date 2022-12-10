namespace FamaFeira.Models
{
    public class FeiraViewModel
    {
        public List<Feira> allFeiras { get; set; }
        public string role { get; set; }

        public string username { get; set; }

        public FeiraViewModel(List<Feira> allFeiras, string role, string username)
        {
            this.allFeiras = allFeiras;
            this.role = role;
            this.username = username;
        }

        public List<Feira> getallFeiras()
        {
            return allFeiras;
        }

        public string getRole()
        {
            return role;
        }

        public string getUsername()
        {
            return username;
        }
    }
}