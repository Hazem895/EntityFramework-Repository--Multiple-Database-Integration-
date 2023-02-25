namespace ProjectEF.Mongo_Infrasturcture
{
    public class ProjectEF_DbSettings
    {
        public string? MongoConnectionString { get; set; }
        public string? MongoDatabaseName { get; set; }
        public string? IdentityCollectionName { get; set; }
        public string? ChargeSchemeCollectionName { get; set; }
        public string? CategoriesCollectionName { get; set; }
    }
}