namespace FamaFeira.Models
{
    public interface IProduto
    {
        public List<Produto> getProdutosStand(string standname);
        public int adicionaCompra(DateTime time, int quantidade, string cliente, string standdesignacao);
        public int getIDProduto(string codigo);
        public void adicionaCompraProduto(int fkidProduto, int fkidCompra, double valor);
        public double getPreco(string codigo);
        public List<Registo> consultaRegistos(string username);

        public bool existeProduto(string nome);
        public int adicionaProduto(float preco, string nome, string imagem, string codigo);

        public int removeProduto(string nome);

    }
}
