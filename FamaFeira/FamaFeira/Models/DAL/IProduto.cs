﻿namespace FamaFeira.Models.DAL
{
    public interface IProduto
    {
        public List<Produto> getProdutosStand(string standname);
        public int adicionaCompra(DateTime time, int quantidade, string cliente, string standdesignacao);
        public int getIDProduto(string codigo);
        public void adicionaCompraProduto(int fkidProduto, int fkidCompra, double valor);
        public double getPreco(string codigo);
        public List<Registo> consultaRegistos(string username);
        public bool existeProduto(string codigo);
        public int adicionaProduto(double preco, string nome, string imagem, string codigo, string expositor);
        public int removerProduto(string codigo);
        public List<String> getCodigos(string expositor);

    }
}
