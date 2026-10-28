using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBL
{
    public abstract class DB
    {

        private const string MySqlConnSTR = @"server=localhost;
                                    user id=root;
                                    password=josh17rog;                                 
                                    database=schoolproject";

        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataReader reader;

        protected DB()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(MySqlConnSTR);
            }
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            reader = null;
        }
    }
}


