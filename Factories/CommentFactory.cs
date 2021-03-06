using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Wall.Models;
using Microsoft.Extensions.Options;
using Wall.Factory;

namespace Wall.Factory{
    public class CommentFactory : IFactory<Message>{
        private readonly IOptions<MySqlOptions> mysqlConfig;

        public CommentFactory(IOptions<MySqlOptions> conf) {
            mysqlConfig = conf;
        }

        internal IDbConnection Connection {
            get {
                return new MySqlConnection(mysqlConfig.Value.ConnectionString);
            }
        }



        // ---------- METHODS ----------- //


        public void AddComment(string CContent, int MessageId, int UserId){
            using(IDbConnection dbConnection = Connection){
                string Query = $"INSERT into comments (CContent, CreatedAt, UpdatedAt, UserId, MessageId) VALUES ('{CContent}', NOW(), NOW(), {UserId}, {MessageId})";
                dbConnection.Open();
                dbConnection.Execute(Query);
            }
        }

        public IEnumerable<Comment> GetAll(){
            using(IDbConnection dbConnection = Connection){
                var query = "SELECT * FROM comments JOIN users ON comments.UserId = users.UserId";
                dbConnection.Open();

                var myComments = dbConnection.Query<Comment, User, Comment>(query, (comment, user) => { 
                    comment.user = user; 
                    return comment; 
                }, splitOn : "UserId");

                return myComments;
            }
        }







    }

}