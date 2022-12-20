namespace FamaFeira.Models.DAL
{
    public interface IStand
    {
        public List<Stand> getStandsFromFeira(string designacao);
        public string getStandName(string username);
        public int removeStand(string designacao);
        public bool existeStand(string designacao);
        public int adicionaStand(string designacao, string descricao, string imagem, string recomendacao, string empresa, string expositor, string feira);
        public int getIDExpositor(string username);
        public bool isExpositivo(string designacao);

    }
}
