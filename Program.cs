using JwtAutorizacionAutenciacionEnRoles.Core.DbContext;
using JwtAutorizacionAutenciacionEnRoles.Core.Entities;
using JwtAutorizacionAutenciacionEnRoles.Core.Interfaces;
using JwtAutorizacionAutenciacionEnRoles.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar contexto de la bd que se utiliza para interactuar con la bd y gestionar usuarios y roles a traves de identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("local");
    options.UseSqlServer(connectionString);
});

// VERSION 1
// Agregar Identity que es un marco de trabajo que permite la gestion de usuarios, roles, autenticacion y autorizacion 
//builder.Services
//    .AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configurar Identity
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = false;
});

// Agregar autenticación y Jwt donde estamos usando JWT para la autenticacion basada en tokens ya que JWT es un estandar abierto (RFC 7519) que define de forma compacta y autonoma de transmitir info de forma segura entre dos partes como un objeto JSON
builder.Services
    .AddAuthentication(options => // Se configura la autenticacion JWT para que utilice un esquema de autenticacion basado en tokens
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true, // Especifica los parametros de validacion del token JWT, como la validacion del emisor, la audiencia y la clave de la firma, estos parametros se usan para validar y decodificar los tokens JWT enviados a los clientes
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });

// Inyeccion de dependencias
builder.Services.AddScoped<IAuthService, AuthService>();   


// Pipeline
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

