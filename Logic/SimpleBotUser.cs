using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Repository;

namespace SimpleBot
{
    public static class SimpleBotUser
    {
        static IUserProfileRepository _userProfile;

        static SimpleBotUser()
        {
            _userProfile = new UserProfileMongoRepository("mongodb://127.0.0.1");
        }

        public static string Reply(Message message)
        {
            try
            {
                var id = message.Id;

                var profile = _userProfile.GetProfile(id);

                profile.Visitas += 1;

                _userProfile.SetProfile(id, profile);

                return $"{message.User} disse '{message.Text} e mandou {profile.Visitas} mensagens'";
            }catch(Exception ex) { return string.Empty; }
        }       
    }
}