using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository
{

    public class UserProfileMongoRepository : IUserProfileRepository
    {
        private IMongoCollection<UserProfileMongo> _collection;

        public UserProfileMongoRepository(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("DB01");
            var col = db.GetCollection<UserProfileMongo>("Profile");

            this._collection = col;
        }

        public UserProfile GetProfile(string id)
        {  
            var filter = Builders<UserProfileMongo>.Filter.Eq("_id", id);
            var profile = _collection.Find(filter).FirstOrDefault();
         
            return new UserProfile
            {
                Id = profile._id,
                Visitas = profile.Visitas
            };
        }

        public void SetProfile(string id, UserProfile profile)
        {
            var filter = Builders<UserProfileMongo>.Filter.Eq("_id", id);

            var doc = new UserProfileMongo
            {
                _id = profile.Id,
                Visitas = profile.Visitas
            };

            _collection.ReplaceOne(filter, doc, new UpdateOptions { IsUpsert = true });
        }
    }
}