using E02.EFCoreApp;
using E02.EFCoreApp.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Action Func Predicate

// x=>x.Id == Id
// Add services to the container.

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("All", opt =>
    {
        opt.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();

        //opt.WithOrigins("http://nursin.com", "http://yavuzsamet.com").WithMethods("GET").AllowAnyHeader();
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = JwtInfo.Issuer,
        ValidAudience = JwtInfo.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.Key)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
    };
});

builder.Services.AddDbContext<YazilimKoyuContext>(opt =>
{
    opt.UseSqlServer("server=(localdb)\\mssqllocaldb; database=YazilimKoyuDb; integrated security=true;");
});

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddControllers();
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

app.UseCors("All");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


void GetDbContextOptions(DbContextOptionsBuilder builder)
{
    builder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=YazilimKoyuDb; integrated security=true;");
}