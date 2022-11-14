namespace FamaFeira.Models
{
    public class User
    {
        public User(String nome, String username, String telemovel, String password, String userType)
        {
            this.nome = nome;
            this.username = username;   
            this.password = password;   
            this.telemovel = telemovel;
            this.usertype = UserType.Cliente;

        }
        public User(String username,String password,String role)
        {
            this.username=username;
            this.password=password;
            this.usertype = UserType.Administrador;
        }

        public String nome { get; set; }
        public string username{get;set;}
        public String password{ get; set; }
        public String telemovel { get; set; }

        public String getPassword()
        {
            return this.password;
        }
        public UserType usertype{get;set;}
    }

    public enum UserType
    {
        Administrador,
        Expositor,
        Cliente
    }

}
