using E02.EFCoreApp.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Action Func Predicate

// x=>x.Id == Id
// Add services to the container.



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

app.UseAuthorization();

app.MapControllers();

app.Run();


void GetDbContextOptions(DbContextOptionsBuilder builder)
{
    builder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=YazilimKoyuDb; integrated security=true;");
}