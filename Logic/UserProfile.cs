﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace SimpleBot
{
    public class UserProfile
    {   
        public string Id { get; set; }
        public int Visitas { get; set; }
    }
}