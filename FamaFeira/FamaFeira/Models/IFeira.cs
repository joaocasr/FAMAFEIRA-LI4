namespace FamaFeira.Models
{
    public interface IFeira
    {
        public List<Feira> getAllFeiras();
        public int adicionaFeira(string tipo, string designacao, string localizacao, string imagem, string data);

        public bool existeFeira(string designacao);

        public int removeFeira(string designacao);




    }
}
