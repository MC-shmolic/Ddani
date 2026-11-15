using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PartyUser
    {
        public int PartyID { get; set; }
        public int UserID { get; set; }

        public PartyUser(int partyID, int userID)
        {
            PartyID = partyID;
            UserID = userID;
        }

        public PartyUser() { }
    }
}
