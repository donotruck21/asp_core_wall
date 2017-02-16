using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Wall.Models;
using Microsoft.Extensions.Options;
using Wall.Factory;

namespace Wall.Factory{
    public class MessageFactory : IFactory<Message>{
        private readonly IOptions<MySqlOptions> mysqlConfig;

        public MessageFactory(IOptions<MySqlOptions> conf) {
            mysqlConfig = conf;
        }

        internal IDbConnection Connection {
            get {
                return new MySqlConnection(mysqlConfig.Value.ConnectionString);
            }
        }



        // ---------- METHODS ----------- //


        public void AddMessage(string MContent, int UserId){
            using(IDbConnection dbConnection = Connection){
                string Query = $"INSERT into messages (MContent, CreatedAt, UpdatedAt, UserId) VALUES ('{MContent}', NOW(), NOW(), {UserId})";
                dbConnection.Open();
                dbConnection.Execute(Query);
            }
        }

        public IEnumerable<Message> GetAll(){
            using(IDbConnection dbConnection = Connection){
                var query = "SELECT * FROM messages JOIN users ON messages.UserId = users.UserId";
                dbConnection.Open();

                var myMessages = dbConnection.Query<Message, User, Message>(query, (message, user) => { 
                    message.user = user; 
                    return message; 
                }, splitOn : "UserId");

                return myMessages;
            }
        }








    }
}