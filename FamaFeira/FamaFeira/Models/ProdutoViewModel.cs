namespace FamaFeira.Models
{
    public class ProdutoViewModel
    {
        public List<Produto> allProdutos { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public string feira { get; set; }
        public string tipo { get; set; }

        public ProdutoViewModel(List<Produto> allProdutos, string role, string username, string feira, string tipo)
        {
            this.allProdutos = allProdutos;
            this.role = role;
            this.username = username;
            this.feira = feira;
            this.tipo = tipo;
        }

        public List<Produto> getallProdutos()
        {
            return allProdutos;
        }

        public string getRole()
        {
            return role;
        }
        public string getUsername()
        {
            return username;
        }

        public string getFeira()
        {
            return feira;
        }

        public string getTipo()
        {
            return tipo;
        }
    }
}
