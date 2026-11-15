using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class PartyUserDB : BaseDB<PartyUser>
    {
        protected override string GetPrimaryKeyName()
        {
            return "PartyID";
        }

        protected override string GetTableName()
        {
            return "PartyUser";
        }

        public async Task<List<PartyUser>> GetAllAsync()
        {
            return ((List<PartyUser>)await SelectAllWhereAsync("UserActive", 1));
        }

        protected override PartyUser CreateModel(object[] row)
        {
            PartyUser p = new PartyUser();
            p.PartyID = int.Parse(row[0].ToString());
            p.UserID = int.Parse(row[1].ToString());
           
            return p;
        }

        public async Task<int> InsertAsync(PartyUser PartyUser)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("PartyID", PartyUser.PartyID);
            fields.Add("UserID", PartyUser.UserID);

            return await InsertAsync(fields);
        }

        public async Task<int> UpdateAsync(PartyUser PartyUser)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("UserID", PartyUser.UserID);

            return await base.UpdateAsync(fields, PartyUser.UserID);
        }



    }
}
