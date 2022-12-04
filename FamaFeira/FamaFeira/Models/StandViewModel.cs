namespace FamaFeira.Models
{
    public class StandViewModel
    {
        public List<Stand> allStands { get; set; }
        public String role { get; set; }

        public String username { get; set; }

        public StandViewModel(List<Stand> allStands, string role, string username)
        {
            this.allStands = allStands;
            this.role = role;
            this.username = username;
        }

            public List<Stand> getallStands()
            {
                return this.allStands;
            }

            public String getRole()
            {
                return this.role;
            }

            public String getUsername()
            {
                return this.username;
            }
    }

}


