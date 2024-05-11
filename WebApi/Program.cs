using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DI
builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

// app.UseHttpsRedirection();

// Maps the Url specified as the first parameter to the async method that is the second parameter -
// the async method gets an instance of ApplicationDbContext through DI
app.MapGet("/api/toppings", async (ApplicationDbContext db) =>
{
    var toppings = await db.Toppings.ToListAsync();

    return Results.Ok(toppings); // Returns status code 200
});

app.MapPost("/api/toppings", async (Topping topping, ApplicationDbContext db) =>
{
    db.Toppings.Add(topping);
    await db.SaveChangesAsync();
});

app.Run(); // Runs conteniously in a loop waiting for a request to come in


