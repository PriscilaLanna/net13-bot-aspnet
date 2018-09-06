using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class UserProfile
    {
        MongoDB.Bson.ObjectId _id;

        public string Id { get; set; }
        public int Visitas { get; set; }
    }
}