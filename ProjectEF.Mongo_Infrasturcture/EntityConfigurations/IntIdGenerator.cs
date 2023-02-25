using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEF.Mongo_Infrasturcture.EntityConfigurations
{
    public class IntIdGenerator : IIdGenerator
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly string _identityCollection;

        public IntIdGenerator(string connectionString, string databaseName, string identityCollectionName)
        {
            var client = new MongoClient(connectionString);
            if (client != null)
            {
                _client = client;
                _database = client.GetDatabase(databaseName);
                _identityCollection = identityCollectionName;
            }
        }

        public static IntIdGenerator Instance { get; set; }

        public object GenerateId(object container, object document)
        {
            var collectionNamespace = container.GetType().GetProperty("CollectionNamespace").GetValue(container);
            var collectionName = collectionNamespace.GetType().GetProperty("CollectionName").GetValue(collectionNamespace).ToString();

            return GenerateCustomId(collectionName); ;
        }

        public int GenerateCustomId(string collectionName)
        {
            int id;
            var identity = _database.GetCollection<IntIdentity>(_identityCollection).Find(i => i.CollectionName == collectionName).FirstOrDefault();
            if (identity == null)
            {
                id = 1;
                identity = new IntIdentity() { CollectionName = collectionName, NextIdentity = id + 1, Id = ObjectId.GenerateNewId() };
            }
            else
            {
                id = identity.NextIdentity;
                identity.NextIdentity++;
            }
            _database.GetCollection<IntIdentity>(_identityCollection)
                .ReplaceOne(i => i.CollectionName == collectionName, identity, new ReplaceOptions() { IsUpsert = true });

            return id;
        }

        public void ResetSequence(string collectionName, int maxSequence)
        {
            var identity = _database.GetCollection<IntIdentity>(_identityCollection).Find(i => i.CollectionName == collectionName).FirstOrDefault();
            if (identity == null)
            {
                identity = new IntIdentity() { CollectionName = collectionName, NextIdentity = maxSequence + 1, Id = ObjectId.GenerateNewId() };
            }
            else
            {
                identity.NextIdentity = maxSequence + 1;
            }

            _database.GetCollection<IntIdentity>(_identityCollection)
               .ReplaceOne(i => i.CollectionName == collectionName, identity, new ReplaceOptions() { IsUpsert = true });
        }

        public bool IsEmpty(object id)
        {
            return int.Parse(id.ToString()) == default;
        }
    }
}
