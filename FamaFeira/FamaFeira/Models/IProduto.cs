namespace FamaFeira.Models
{
    public interface IProduto
    {
        public List<Produto> getProdutosStand(string standname);
        public int adicionaCompra(DateTime time, int quantidade, string cliente, string standdesignacao);
        public int getIDProduto(string codigo);
        public void adicionaCompraProduto(int fkidProduto, int fkidCompra, double valor);
        public double getPreco(string codigo);


    }
}
