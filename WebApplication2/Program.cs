using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication2.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<LaptopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LaptopConnectionString"));
});

builder.Services.Configure<JsonOptions>(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


var app = builder.Build();

app.Run();
