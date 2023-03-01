using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEF.Mongo_Infrasturcture.EntityConfigurations;
using ProjectEF.Domain.DomainModels;

namespace ProjectEF.Mongo_Infrasturcture
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public ProjectEF_DbSettings Settings { get; private set; }

        public MongoDbContext(ProjectEF_DbSettings settings)
        {
            Settings = settings;
            IntIdGenerator.Instance = new IntIdGenerator(Settings.MongoConnectionString, Settings.MongoDatabaseName, Settings.IdentityCollectionName);
            var client = new MongoClient(Settings.MongoConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(Settings.MongoDatabaseName);
            }
        }

        public IMongoCollection<Category> Categories
        {
            get
            {
                return _database.GetCollection<Category>(Settings.CategoriesCollectionName);
            }
        }

        public object AddEntity(object entity)
        {
            var type = entity.GetType();
            _database.GetCollection<object>(type.Name).InsertOne(entity);
            return entity;
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public async ValueTask<TEntity> FindEntityAsync<TEntity>(params object[] keyValues) where TEntity : class
        {
            var type = typeof(TEntity);
            var classMap = BsonClassMap.LookupClassMap(type);
            var id = classMap.IdMemberMap;
            var filter = Builders<TEntity>.Filter.Eq(id.ElementName, keyValues[0]);
            return await _database.GetCollection<TEntity>(type.Name).Find<TEntity>(filter).FirstOrDefaultAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(1);
        }

        public Task<string> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult("");
        }


    }
}
