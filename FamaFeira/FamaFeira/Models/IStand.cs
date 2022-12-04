namespace FamaFeira.Models
{
    public interface IStand
    {
        public List<Stand> getStandsFromFeira(string designacao);
        public String getStandName(string username);

    }
}
