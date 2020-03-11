using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace LSport_HomeTask.Config
{
    //Giphy database configurtion.
    class GiphyDBConfig
    {
        MySqlConnectionStringBuilder connectionBuilder = new MySqlConnectionStringBuilder();
        string connectionString;
        public GiphyDBConfig()
        {
            connectionBuilder = new MySqlConnectionStringBuilder();
            connectionBuilder.Server = "localhost";
            connectionBuilder.Port = 3306;
            connectionBuilder.Database = "giphy";
            connectionBuilder.UserID = "root";
            connectionBuilder.Password = "1357";
            connectionBuilder.CharacterSet = "utf8";
            connectionString = connectionBuilder.ToString();
        }

        public string getConnectionString()
        {
            return connectionString;
        }
    }
}
