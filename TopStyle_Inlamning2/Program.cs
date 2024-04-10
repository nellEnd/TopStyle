using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TopStyle_Inlamning2.Core.Interfaces;
using TopStyle_Inlamning2.Core.Services;
using TopStyle_Inlamning2.Data;
using TopStyle_Inlamning2.Data.Interfaces;
using TopStyle_Inlamning2.Data.Repos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:5157/",
            ValidAudience = "http://localhost:5157/",
            IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretKey12345!#123456789101112"))
        };
    });

builder.Services.AddDbContext<TopStyleContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"))
    );

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => {  endpoints.MapControllers(); });


app.Run();
