using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Party
    {
        public int PartyID { get; set; }
        public int AdminID { get; set; }
        public string PartyName { get; set; }
        public bool Available { get; set; }

        public Party() { }

        public Party(int partyID, int adminID, string partyName, bool available)
        {
            this.PartyID = partyID;
            AdminID = adminID;
            PartyName = partyName;
            Available = available;
        }

    }
}
