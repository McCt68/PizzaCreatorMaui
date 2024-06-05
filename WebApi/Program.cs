using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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

// Routes
// Maps the Url specified as the first parameter to the async method that is the second parameter -
// the async method gets an instance of ApplicationDbContext through DI
// When this url is requested with a httpClient get method this method will be called.
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

app.MapDelete("/api/toppings/{id}", async (int id, ApplicationDbContext db) =>
{
    var toppingToDelete = await db.Toppings.FindAsync(id);
    if (toppingToDelete != null)
    {
        db.Toppings.Remove(toppingToDelete);
        await db.SaveChangesAsync();
        return Results.Ok(toppingToDelete);
    }
    return Results.NotFound(); // 404
});

// Update
app.MapPut("/api/toppings/{id}", async (int id, Topping topping, ApplicationDbContext db) =>
{
    var toppingToUpdate = await db.Toppings.FindAsync(id);
    if (toppingToUpdate is null) return Results.NotFound();
    
    toppingToUpdate.ToppingName = topping.ToppingName;
    toppingToUpdate.ToppingPrice = topping.ToppingPrice;
    toppingToUpdate.ToppingImage = topping.ToppingImage;
    toppingToUpdate.ToppingImageString = topping.ToppingImageString;
    toppingToUpdate.ToppingImageHexColor = topping.ToppingImageHexColor;
    
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run(); // Kører hele tiden i et loop og venter på incomming request.


