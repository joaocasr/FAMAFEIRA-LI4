namespace FamaFeira.Models
{
    public class StandViewModel
    {
        public List<Stand> allStands { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public string feira { get; set; }

        public StandViewModel(List<Stand> allStands, string role, string username, string feira)
        {
            this.allStands = allStands;
            this.role = role;
            this.username = username;
            this.feira = feira;
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
    }

}


