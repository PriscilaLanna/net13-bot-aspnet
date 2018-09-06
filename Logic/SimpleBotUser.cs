using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        public static string Reply(Message message)
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var profile = GetProfile(message.Id);

            profile.Visitas += 1;

            SetProfile(message.Id, profile);

          
            var doc = new BsonDocument()
            {
                {"id", message.Id },
                {"texto", message.Text },
                {"app", "teste" }
            };

            var db = client.GetDatabase("config");
            var col = db.GetCollection<BsonDocument>("Tabela1");

            col.InsertOne(doc);

            return $"{message.User} disse '{message.Text}'";
        }

        public static UserProfile GetProfile(string id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("config");
            var col = db.GetCollection<UserProfile>("Tabela1");

            var filtro = Builders<UserProfile>.Filter.Eq("id", id);

            return col.Find(filtro).FirstOrDefault();
        }

        public static void SetProfile(string id, UserProfile profile)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("config");
            var col = db.GetCollection<UserProfile>("Tabela1");

            var filtro = Builders<UserProfile>.Filter.Eq("id", id);

            col.ReplaceOne(filtro, profile);
        }
    }
}