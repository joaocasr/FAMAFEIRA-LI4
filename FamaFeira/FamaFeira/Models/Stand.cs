namespace FamaFeira.Models
{
    public class Stand
    {
        public Stand(string designacao, string descricao, string imagem)
        {
            this.designacao = designacao;
            this.descricao = descricao;
            this.imagem = imagem;

        }

        public Stand(string designacao, string descricao, string imagem, string recomendacao, string empresa)
        {
            this.designacao = designacao;
            this.descricao = descricao;
            this.imagem = imagem;
            this.recomendacao = recomendacao;
            this.empresa = empresa;
        }

        public String designacao { get; set; }
        public String descricao { get; set; }
        public String imagem { get; set; }
        public String recomendacao { get; set; }
        public String empresa { get; set; }

    }
}
