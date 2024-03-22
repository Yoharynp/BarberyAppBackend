using BappDominio.Repositorios;
using BappInfraestructura;
using BarberyApp.Infraestructura;
using BarberyApp.ServiciosAplicacion;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContextoBarberyApp>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BarberyApp")));
builder.Services.AddScoped<IBarberoRepositorio, BarberoRepositorio>();
builder.Services.AddScoped<IEstiloCorteRepositorio, EstiloCorteRepositorio>();
builder.Services.AddScoped<IClienteRespositorio, ClienteRepositorio>();
builder.Services.AddScoped<ServicioBarbero>();
builder.Services.AddScoped<ServicioCliente>();
builder.Services.AddScoped<ServicioCita>();
builder.Services.AddScoped<ServicioLocalBarbero>();
builder.Services.AddScoped<ServicioEstiloCorte>();
builder.Services.AddScoped<ILocalbarbero, LocalBarberoRepositorio>();
builder.Services.AddScoped<ICitaRepositorio, CitaRepositorio>();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});

builder.Services.AddScoped<IAutorizacionServicio, AutorizacionServicio>();
var key = builder.Configuration.GetValue<string>("JwtConfiguracion:Secret");
var keyBytes = Encoding.ASCII.GetBytes(key);


builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
