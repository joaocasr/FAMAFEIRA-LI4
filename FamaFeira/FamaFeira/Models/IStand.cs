namespace FamaFeira.Models
{
    public interface IStand
    {
        public List<Stand> getStandsFromFeira(string designacao);
        public String getStandName(string username);

        public bool existeStand(string designacao);

        public int adicionaStand(string designacao, string descricao, string imagem, string recomendacao, string empresa);

        public int removeStand(string designacao);


    }
}
