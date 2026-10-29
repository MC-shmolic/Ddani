using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class UsersDB : BaseDB<Users>
    {
        protected override string GetPrimaryKeyName()
        {
            return "UserID";
        }

        protected override string GetTableName()
        {
            return "Users";
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return ((List<Users>)await SelectAllAsync());
        }

        protected override Users CreateModel(object[] row)
        {
            Users p = new Users();
            p.UserID = int.Parse(row[0].ToString());
            p.UserName = row[1].ToString();
            p.UserPassword = row[2].ToString();
            p.UserEmail = row[3].ToString();
            p.UserRole = row[4].ToString();


            return p;
        }

        public async Task<int> InsertAsync(Users Users)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("UserName", Users.UserName);
            fields.Add("UserPassword", Users.UserPassword);
            fields.Add("UserEmail", Users.UserEmail);
            fields.Add("UserRole", Users.UserRole);


            return await InsertAsync(fields);
        }

        public async Task<int> UpdateAsync(Users Users)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("UsersName", Users.UserName);
            fields.Add("UsersPassword", Users.UserPassword);
            fields.Add("UserEmail", Users.UserEmail);
            fields.Add("UserRole", Users.UserRole);


            return await base.UpdateAsync(fields, Users.UserID);
        }
    }
}
