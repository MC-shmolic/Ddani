using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Characters
    {
        public int CharacterID { get; set; }
        public int UserID { get; set; }
        public string CharacterName { get; set; }
        public int Lvl { get; set; }
        public string Class { get; set; }
        public int Money { get; set; }
        public float Multiplier { get; set; }

        public Characters() { }

        public Characters(int characterID, int userID, string characterName, int lvl, string @class, int money, float mulyiplier)
        {
            CharacterID = characterID;
            UserID = userID;
            CharacterName = characterName;
            Lvl = lvl;
            Class = @class;
            Money = money;
            Multiplier = mulyiplier;
        }
    }
}
