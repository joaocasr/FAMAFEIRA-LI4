namespace FamaFeira.Models
{
    public class Registo
    {

        public string data { get; set; }
        public string nome { get; set; }
        public int quantidade { get; set; }
        public double valor { get; set; }
        public string cliente { get; set; }
        public string email { get; set; }
        public string telemovel { get; set; }

        public Registo(string data, string nome,int quantidade, double valor, string cliente, string email, string telemovel)
        {
            this.data = data;
            this.nome = nome;
            this.quantidade = quantidade;
            this.valor = valor;
            this.cliente = cliente;
            this.email = email;
            this.telemovel = telemovel;
        }   
    }
}
