namespace FamaFeira.Models
{
    public class StandViewModel
    {
        public List<Stand> allStands { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public string feira { get; set; }

        public bool expositivo { get; set; }    

        public StandViewModel(List<Stand> allStands, string role, string username, string feira, bool expositivo)
        {
            this.allStands = allStands;
            this.role = role;
            this.username = username;
            this.feira = feira;
            this.expositivo = expositivo;
        }

        public List<Stand> getallStands()
        {
            return allStands;
        }

        public string getRole()
        {
            return role;
        }

        public string getUsername()
        {
            return username;
        }

        public string getFeira()
        {
            return feira;
        }

        public bool isExp()
        {
            return this.expositivo;
        }
    }

}


