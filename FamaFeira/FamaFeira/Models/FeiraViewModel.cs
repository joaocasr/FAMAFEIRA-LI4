namespace FamaFeira.Models
{
    public class FeiraViewModel
    {
        public List<Feira> allFeiras { get; set; }
        public String role { get; set; }

        public String username { get; set; }

        public FeiraViewModel(List<Feira> allFeiras, string role, string username)
        {
            this.allFeiras = allFeiras;
            this.role = role;
            this.username = username;
        }

        public List<Feira> getallFeiras()
        {
            return this.allFeiras;
        }

        public String getRole()
        {
            return this.role;
        }

        public String getUsername()
        {
            return this.username;
        }
    }
}