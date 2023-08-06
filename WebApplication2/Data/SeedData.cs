using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            LaptopContext db = new LaptopContext(serviceProvider.GetRequiredService<DbContextOptions<LaptopContext>>());

            db.Database.EnsureDeleted();
            db.Database.Migrate();

            // Brand Seeding
            Brand brandOne = new Brand { Name = "Dell" };
            Brand brandTwo = new Brand { Name = "Apple" };
            Brand brandThree = new Brand { Name = "Lenovo" };

            if (!db.Brands.Any())
            {
                db.Brands.Add(brandOne);
                db.Brands.Add(brandTwo);
                db.Brands.Add(brandThree);
                db.SaveChanges();
            }

            // Laptop seeding
            Laptop laptopOne = new Laptop { Model = "XPS", Brand = brandOne, Condition = LaptopCondition.New, Price = 800 };
            Laptop laptopTwo = new Laptop { Model = "Latitude", Brand = brandOne, Condition = LaptopCondition.Rental, Price = 400 };
            Laptop laptopThree = new Laptop { Model = "Mac Pro", Brand = brandTwo, Condition = LaptopCondition.New, Price = 900 };
            Laptop laptopFour = new Laptop { Model = "MacBook", Brand = brandTwo, Condition = LaptopCondition.Refurbished, Price = 1100 };
            Laptop laptopFive = new Laptop { Model = "IdeaPad", Brand = brandThree, Condition = LaptopCondition.Rental, Price = 500 };
            Laptop laptopSix = new Laptop { Model = "ThinkPad", Brand = brandThree, Condition = LaptopCondition.New, Price = 600 };

            if (!db.Laptops.Any())
            {
                db.Laptops.Add(laptopOne);
                db.Laptops.Add(laptopTwo);
                db.Laptops.Add(laptopThree);
                db.Laptops.Add(laptopFour);
                db.Laptops.Add(laptopFive);
                db.Laptops.Add(laptopSix);
                db.SaveChanges();
            }

            // Seed Store Locations
            StoreLocation locationOne = new StoreLocation { StreetNameNumber = "759 Ebby street", CanadianProvince = CanadianProvince.Manitoba };
            StoreLocation locationTwo = new StoreLocation { StreetNameNumber = "59 Chancellor Dr", CanadianProvince = CanadianProvince.Ontario };
            StoreLocation locationThree = new StoreLocation { StreetNameNumber = "74 Jack Avenue", CanadianProvince = CanadianProvince.BritishColumbia };
            StoreLocation locationFour = new StoreLocation { StreetNameNumber = "54 Henlow Street", CanadianProvince = CanadianProvince.Alberta };  

            if (!db.StoreLocations.Any())
            {
                db.StoreLocations.Add(locationOne);
                db.StoreLocations.Add(locationTwo);
                db.StoreLocations.Add(locationThree);
                db.StoreLocations.Add(locationFour);
                db.SaveChanges();
            }

            // Store Laptop seeding Many to many
            StoreLaptop stOne = new StoreLaptop { Laptop = laptopOne, Store = locationOne, LaptopStock = 5 };
            StoreLaptop stTwo = new StoreLaptop { Laptop = laptopOne, Store = locationTwo, LaptopStock = 7 };
            StoreLaptop stThree = new StoreLaptop { Laptop = laptopTwo, Store = locationThree, LaptopStock = 4 };
            StoreLaptop stFour = new StoreLaptop { Laptop = laptopThree, Store = locationFour, LaptopStock = 8 };
            StoreLaptop stFive = new StoreLaptop { Laptop = laptopThree, Store = locationOne, LaptopStock = 3 };
            StoreLaptop stSix = new StoreLaptop { Laptop = laptopFour, Store = locationTwo, LaptopStock = 2 };
            StoreLaptop stSeven = new StoreLaptop { Laptop = laptopSix, Store = locationThree, LaptopStock = 4 };
            StoreLaptop stEight = new StoreLaptop { Laptop = laptopFive, Store = locationTwo, LaptopStock = 5 };
            StoreLaptop stNine = new StoreLaptop { Laptop = laptopTwo, Store = locationOne, LaptopStock = 4 };
            StoreLaptop stTen = new StoreLaptop { Laptop = laptopFive, Store = locationFour, LaptopStock = 3 };

            if (!db.StoreLaps.Any())
            {
                db.StoreLaps.Add(stOne);
                db.StoreLaps.Add(stTwo);
                db.StoreLaps.Add(stThree);
                db.StoreLaps.Add(stFour);
                db.StoreLaps.Add(stFive);
                db.StoreLaps.Add(stSix);
                db.StoreLaps.Add(stSeven);
                db.StoreLaps.Add(stEight);
                db.StoreLaps.Add(stNine);
                db.StoreLaps.Add(stTen);
                db.SaveChanges();
            }
        }
    }
}
