using Microsoft.EntityFrameworkCore;

using TareaSemana2.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cn = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<DBContext>(options =>
    options.UseMySql(cn, ServerVersion.AutoDetect(cn)));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
