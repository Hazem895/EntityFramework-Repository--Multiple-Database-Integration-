using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using ProjectEF.Domain.IRepository;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Api.Services.CategoriesServices;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();



#region DbContext Config - Only use one 

#region SQL Config
builder.Services.AddDbContext<ProjectEF.ProjectEF.SQL_Infrastructure.ApplicationDbContext_SQL>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("EF_SQL_Db")));
//registered CRUD Interface and its Implementaion in Infrastructure project
builder.Services.AddScoped<ICrudCommands<Category>, ProjectEF.SQL_Infrastructure.Repository.CategoryCrudCommands>();
builder.Services.AddScoped<IItemsCommand, ProjectEF.SQL_Infrastructure.Repository.ItemCrudCommands>();
#endregion

#region PostgreSQL Congif
//builder.Services.AddDbContext<ProjectEF.postgreSQL_Infrastructure.ApplicationDbContext_PG>(options =>
//          options.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db")));

////registered CRUD Interface and its Implementaion in Infrastructure project
//builder.Services.AddScoped<ICommands<Item>, ProjectEF.postgreSQL_Infrastructure.Repository.ItemCommands>();
#endregion

#region MongoDb Config
//var settings = new ProjectEF.Mongo_Infrasturcture.ProjectEF_DbSettings()
//{
//    MongoConnectionString = builder.Configuration.GetSection("MongoDbSettings").GetSection("MongoConnectionString").Value,
//    MongoDatabaseName = builder.Configuration.GetSection("MongoDbSettings").GetSection("MongoDatabaseName").Value,
//    IdentityCollectionName = builder.Configuration.GetSection("MongoDbSettings").GetSection("IdentityCollectionName").Value,
//    ChargeSchemeCollectionName = builder.Configuration.GetSection("MongoDbSettings").GetSection("ChargeSchemeCollectionName").Value,
//    CategoriesCollectionName = builder.Configuration.GetSection("MongoDbSettings").GetSection("CategoriesCollectionName").Value
//};

//builder.Services.AddSingleton<ProjectEF.Mongo_Infrasturcture.ProjectEF_DbSettings>(settings);
//builder.Services.AddSingleton<ProjectEF.Mongo_Infrasturcture.MongoDbContext>(new ProjectEF.Mongo_Infrasturcture.MongoDbContext(settings));

////registered CRUD Interface and its Implementaion in Infrastructure project
//builder.Services.AddScoped<ICommands<Item>, ProjectEF.Mongo_Infrasturcture.Repository.ItemCommands>();

#endregion


builder.Services.AddHttpClient<ICategoriesServices, CategoriesServices>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("ServicesURL").GetSection("CategoriesServices").Value);
});


#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






//builder.Services.AddSingleton<ICommands>(sp => new CategoryCommands(new ApplicationDbContext()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
