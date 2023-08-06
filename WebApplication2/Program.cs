using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication2.Data;
using WebApplication2.Migrations;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddDbContext<LaptopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LaptopConnectionString"));
});

builder.Services.Configure<JsonOptions>(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider serviceProvider = scope.ServiceProvider;

    await SeedData.Initialize(serviceProvider);
}

app.MapGet("/stores/laptop/{number}", (LaptopContext db, Guid number) =>
{
    try
    {
        HashSet<StoreLaptop> laptopInStore = db.StoreLaps.Where(ls => ls.StoreId == number)
        .Include(ls => ls.Laptop)
        .ThenInclude(ls => ls.Brand).ToHashSet();

        return Results.Ok(laptopInStore.ToHashSet()); 
    }
    catch (InvalidOperationException ex)
    {
        return Results.NotFound(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});



app.Run();
