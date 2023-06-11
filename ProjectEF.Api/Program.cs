using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using ProjectEF.Domain.IRepository;
using ProjectEF.Domain.DomainModels;
using ProjectEF.ProjectEF.SQL_Infrastructure;
using ProjectEF.SQL_Infrastructure.Repository;
using ProjectEF.BL.Service.IService;
using ProjectEF.BL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();



#region DbContext Config - Only use one 

#region SQL Config
builder.Services.AddDbContext<ApplicationDbContext_SQL>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("EF_SQL_Db")));
//registered CRUD Interface and its Implementaion in Infrastructure project
builder.Services.AddScoped<IUserCommands, UserCommands>();
builder.Services.AddScoped<IPatientsCommand, PatientCrudCommands>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IPatientServices, PatientServices>();
#endregion



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
