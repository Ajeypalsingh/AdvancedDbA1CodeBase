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




// Got referenfce from AI for this endpoint (for HasValue)
app.MapGet("/laptops/search",(LaptopContext db, decimal? priceAbove, decimal? priceBelow, int? hasStock, LaptopCondition? condition, Guid? brandId, string? searchPhrase) =>
{
    try
    {
        HashSet<Laptop> laptops = db.Laptops.Include(l => l.Brand).ToHashSet();

        if (priceAbove.HasValue)
        {
            laptops = laptops.Where(l => l.Price >= priceAbove.Value).ToHashSet();
        }

        if (priceBelow.HasValue)
        {
            laptops = laptops.Where(l => l.Price <= priceBelow.Value).ToHashSet();
        }

        if (hasStock.HasValue)
        {
            laptops = laptops.Where(l => l.storeLaptops.Any(sl => sl.LaptopStock > 0)).ToHashSet();
        }

        if (condition.HasValue)
        {
            laptops = laptops.Where(l => l.Condition == condition.Value).ToHashSet();
        }

        if (brandId.HasValue)
        {
            laptops = laptops.Where(l => l.BrandId == brandId.Value).ToHashSet();
        }

        return Results.Ok(laptops);
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



// Searching laptops by store
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

// Average price of laptop by brand
app.MapGet("/brands/{brandId}/averagePrice", (LaptopContext db, Guid brandId) =>
{
    HashSet<Laptop> laptops = db.Laptops
        .Where(l => l.BrandId == brandId)
        .ToHashSet();

    if (laptops.Count == 0)
    {
        return Results.NotFound("No laptops found for the specified brand.");
    }

    int numberOfLaptop = laptops.Count;
    decimal averagePrice = laptops.Average(l => l.Price);

    return Results.Ok(new { NumberOfLaptop = numberOfLaptop, AveragePrice = averagePrice });
});

app.MapPost("/stores/{storeNumber}/{laptopNumber}/changeQuantity", (LaptopContext context, Guid storeNumber, Guid laptopNumber, int amount) =>
{
    StoreLaptop storeLaptop = context.StoreLaps
        .FirstOrDefault(sl => sl.StoreId == storeNumber && sl.LaptopId == laptopNumber);

    if (storeLaptop == null)
    {
        return Results.NotFound("Store or Laptop not found.");
    }

    storeLaptop.LaptopStock += amount;
    context.SaveChanges();

    return Results.Ok(storeLaptop);
});


// did this endpoint using AI
app.MapGet("/stores/groupedByProvince", (LaptopContext db) =>
{
    List<StoreLocation> storesByProvince = db.StoreLocations
        .Where(sl => sl.storeLaptops.Any()) 
        .ToList();

    Dictionary<CanadianProvince, List<StoreLocation>> provincesWithStores = storesByProvince
        .GroupBy(sl => sl.CanadianProvince)
        .ToDictionary(group => group.Key, group => group.ToList());

    return Results.Ok(provincesWithStores);
});

app.Run();


