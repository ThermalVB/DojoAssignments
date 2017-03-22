using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using bankaccounts;

namespace DbConnector
{
    public class DbConnector
    {
        private readonly IOptions<MySqlOptions> MySqlConfig;
 
        public DbConnector(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }
    }
}