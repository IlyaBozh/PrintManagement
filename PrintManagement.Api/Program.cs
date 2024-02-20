using PrintManagement.Api.Infrastructure;
using System.Data.SqlClient;
using System.Data;
using PrintManagement.Api.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var dbConfig = new DbConfig();
builder.Configuration.Bind(dbConfig);

builder.Services.AddScoped<IDbConnection>(c => new SqlConnection(dbConfig.CONNECTION_STRING));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();

builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
