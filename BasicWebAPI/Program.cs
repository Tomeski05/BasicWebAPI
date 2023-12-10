using BasicWebAPI.Automapper;
using BasicWebAPI.Domain.DBContext;
using BasicWebAPI.IoC;
using BasicWebAPI.Services.Interface;
using BasicWebAPI.Services.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration.GetSection("ConnectionStrings");
var connectionStrings = configuration.GetValue<string>("DefaultConnection");

// Add services to the container.
IocContainer.ConfigureIoCContainer(builder.Services, connectionStrings);

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Server=FILIP;Database=BasicWebAPIDb;Trusted_Connection=True");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
