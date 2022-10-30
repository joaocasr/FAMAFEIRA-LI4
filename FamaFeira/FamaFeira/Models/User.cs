namespace FamaFeira.Models
{
    public class User
    {
        public String nome { get; set; }
        public string username{get;set;}
        public String password{ get; set; }
        public String telemovel { get; set; }
        public UserType usertype{get;set;}
    }

    public enum UserType
    {
        Administrador,
        Expositor,
        Cliente
    }
}
