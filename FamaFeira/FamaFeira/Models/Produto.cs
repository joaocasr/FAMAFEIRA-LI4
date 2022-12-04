namespace FamaFeira.Models
{
    public class Produto
    {
        public String nome { get; set; }
        public String imagem { get; set; }
        public String codigo { get; set; }
        public double preco { get; set; }

        public Produto(string nome, string imagem, string codigo, double preco)
        {
            this.nome = nome;
            this.imagem = imagem;
            this.codigo = codigo;
            this.preco = preco;
        }   
    }
}
