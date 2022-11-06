using CodeFirstEFExercise.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MainDbContext>(opt =>
{
    opt
    .LogTo(Console.WriteLine)
    .UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s20192;Integrated Security=True");
});

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
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
