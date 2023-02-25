using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEF.Mongo_Infrasturcture.EntityConfigurations
{
    public class IntIdentity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string CollectionName { get; set; }

        public int NextIdentity { get; set; }
    }
}
