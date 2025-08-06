using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.EndPoints;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connString = builder.Configuration.GetConnectionString("Eventss");
builder.Services.AddSqlite<GameStoreContext>(connString);
builder.Services.AddAuthorization();

builder.Services.AddScoped<GameStore.API.TokenService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var config = builder.Configuration.GetSection("jwt");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["Issuer"],
        ValidAudience = config["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["Key"]))
    };
});


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
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI();
app.MapEventsEndpoints();
app.MigrateDb();
app.Run();
