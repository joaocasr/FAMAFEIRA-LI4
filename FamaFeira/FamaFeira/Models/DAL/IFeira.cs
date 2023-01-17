namespace FamaFeira.Models.DAL
{
    public interface IFeira
    {
        public List<Feira> getAllFeiras();
        public int adicionaFeira(string tipo, string designacao, string localizacao, string imagem, string data);

        public bool existeFeira(string designacao);
        public int removeFeira(string designacao);
        public void removeStandsFeira(int fkidFeira);
        public string getTipoFeira(string designacao);

    }
}
