using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Application.Services;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Domain.Entities;
using Application.Models;
using Application.Models.Request;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = new SqliteConnection("Data source = DB-Liebre.db");
connection.Open();
using (var command = connection.CreateCommand())
{
    command.CommandText = "PRAGMA journal_mode = DELETE;";
    command.ExecuteNonQuery();
}


builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite (connection,b => b.MigrationsAssembly("Infrastructure")));

#region Services
builder.Services.AddScoped<ISysAdminServices, SysAdminServices>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ITransactionDetailService, TransactionDetailService>();
builder.Services.AddScoped<ITransactionService, TransactionService>(); 
#endregion

#region Repositories
builder.Services.AddScoped<ISysAdminRepository, SysAdminRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ITransactionDetailsRepository, TransactionDetailsRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
#endregion
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
