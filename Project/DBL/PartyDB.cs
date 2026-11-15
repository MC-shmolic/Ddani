using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class PartyDB : BaseDB<Party>
    {
        protected override string GetPrimaryKeyName()
        {
            return "PartyID";
        }

        protected override string GetTableName()
        {
            return "Party";
        }

        public async Task<List<Party>> GetAllAsync()
        {
            return ((List<Party>)await SelectAllWhereAsync("Available", 1));
        }

        protected override Party CreateModel(object[] row)
        {
            Party p = new Party();
            p.PartyID = int.Parse(row[0].ToString());
            p.AdminID = int.Parse(row[1].ToString());
            p.PartyName = row[2].ToString();
            p.Available = Convert.ToBoolean(Convert.ToInt32(row[3]));

            return p;
        }

        public async Task<int> InsertAsync(Party Party)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("PartyID", Party.PartyID);
            fields.Add("AdminID", Party.AdminID);
            fields.Add("PartyName", Party.PartyName);
            fields.Add("Available", Party.Available);


            return await InsertAsync(fields);
        }

        public async Task<int> UpdateAsync(Party Party)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("AdminID", Party.AdminID);
            fields.Add("PartyName", Party.PartyName);
            fields.Add("Available", Party.Available);


            return await base.UpdateAsync(fields, Party.PartyID);
        }


        public async Task<int> UpdateAsyncDead(int id)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("Available", 1);


            return await base.UpdateAsync(fields, id);
        }
    }
}
