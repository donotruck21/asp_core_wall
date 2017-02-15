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

        // -- ADD USER -- //
        public void AddUser(User user){
            using(IDbConnection dbConnection = Connection){
                string Query = "INSERT into users (FirstName, LastName, Email, Password, CreatedAt, UpdatedAt) VALUES (@FirstName, @LastName, @Email, @Password, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(Query, user);
            }
        }

        // -- GET LAST USER -- //
        public User GetLastUser(){
            using(IDbConnection dbConnection = Connection){
                string Query = "SELECT * FROM users ORDER BY UserId DESC LIMIT 1";
                dbConnection.Open();
                return dbConnection.QuerySingleOrDefault<User>(Query);
            }
        }

        public User FindByUserId(int UserId){
            using(IDbConnection dbConnection = Connection){
                string Query = $"SELECT * FROM users WHERE UserId = {UserId}";
                dbConnection.Open();
                return dbConnection.QuerySingleOrDefault<User>(Query);
            }
        }



    }
}
