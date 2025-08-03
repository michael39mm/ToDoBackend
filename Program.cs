using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.EndPoints;
using Swashbuckle.AspNetCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connString = builder.Configuration.GetConnectionString("Eventss");
builder.Services.AddSqlite<GameStoreContext>(connString);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
var app = builder.Build();
app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI();
app.MapEventsEndpoints();
app.MigrateDb();
app.Run();
