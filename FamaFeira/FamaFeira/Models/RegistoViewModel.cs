namespace FamaFeira.Models
{
    public class RegistoViewModel
    {
        public List<Registo> allRegistos { get; set; }
        public String username { get; set; }

        public RegistoViewModel(List<Registo> allRegistos, string username)
        {
            this.allRegistos = allRegistos;
            this.username = username;
        }   

        public string getUsername()
        {
            return this.username;
        }

        public List<Registo> getAllRegistos()
        {
            return this.allRegistos;
        }
    }
}
