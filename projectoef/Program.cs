using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<TareasContext>("Data Source=DESKTOP-KBG54GH\\MSSQLSERVER2019;Initial Catalog= TareasDb;Trusted_Connection=True; Integrated Security=True;TrustServerCertificate=True");


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: "+ dbContext.Database.IsInMemory());
});

app.Run();
