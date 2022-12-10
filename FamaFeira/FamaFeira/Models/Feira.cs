namespace FamaFeira.Models
{
    public class Feira
    {

        public Feira(string tipo,string designacao, string localizacao, string imagem, string data)
        {
            this.tipo = tipo;
            this.designacao = designacao;   
            this.localizacao = localizacao;
            this.imagem = imagem;
            this.data = data;

        }

        public string tipo { get; set; }
        public string designacao { get; set; }
        public string localizacao { get; set; }
        public string imagem { get; set; }
        public string data { get; set; }

        public String getTipo()
        {
            return this.tipo;
        }

    }
}