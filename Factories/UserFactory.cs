using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Wall.Models;
using Microsoft.Extensions.Options;
using Wall.Factory;

namespace Wall.Factory{
    public class UserFactory : IFactory<User>{

        private readonly IOptions<MySqlOptions> mysqlConfig;

        public UserFactory(IOptions<MySqlOptions> conf) {
            mysqlConfig = conf;
        }

        internal IDbConnection Connection {
            get {
                return new MySqlConnection(mysqlConfig.Value.ConnectionString);
            }
        }
        



        // ---------- METHODS ----------- //

    }
}
