using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class CharactersDB : BaseDB<Characters>
    {
        protected override string GetPrimaryKeyName()
        {
            return "CharacterID";
        }

        protected override string GetTableName()
        {
            return "Characters";
        }

        public async Task<List<Characters>> GetAllAsync()
        {
            return ((List<Characters>)await SelectAllAsync());
        }

        protected override Characters CreateModel(object[] row)
        {
            Characters p = new Characters();
            p.CharacterID = int.Parse(row[0].ToString());
            p.UserID = int.Parse(row[0].ToString());
            p.CharacterName = row[1].ToString();
            p.Lvl = int.Parse(row[2].ToString());
            p.Class = row[3].ToString();
            p.Money = int.Parse(row[4].ToString());
            p.Multyplier = int.Parse((row[5].ToString()) );


            return p;
        }

        public async Task<int> InsertAsync(Characters Characters)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("UserID", Characters.UserID);
            fields.Add("CharacterName", Characters.CharacterName);
            fields.Add("Lvl", Characters.Lvl);
            fields.Add("class", Characters.Class);
            fields.Add("Money", Characters.Money);
            fields.Add("Multyplier", Characters.Multyplier);


            return await InsertAsync(fields);
        }

        public async Task<int> UpdateAsync(Characters Characters)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("UserID", Characters.UserID);
            fields.Add("CharacterName", Characters.CharacterName);
            fields.Add("Lvl", Characters.Lvl);
            fields.Add("class", Characters.Class);
            fields.Add("Money", Characters.Money);
            fields.Add("Multyplier", Characters.Multyplier);


            return await base.UpdateAsync(fields, Characters.UserID);
        }
    }
}
