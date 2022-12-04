namespace FamaFeira.Models
{
    public class ProdutoViewModel
    {
        public List<Produto> allProdutos { get; set; }
        public string role { get; set; }

        public string username { get; set; }

        public ProdutoViewModel(List<Produto> allProdutos, string role, string username)
        {
            this.allProdutos = allProdutos;
            this.role = role;
            this.username = username;
        }

        public List<Produto> getallProdutos()
        {
            return this.allProdutos;
        }

        public string getRole()
        {
            return this.role;
        }
        public string getUsername()
        {
            return this.username;
        }
    }
}
