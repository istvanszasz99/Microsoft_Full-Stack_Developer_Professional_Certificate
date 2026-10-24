using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add memory cache service
builder.Services.AddMemoryCache();

// Add CORS service
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

// Inject IMemoryCache
app.MapGet("/api/productlist", (IMemoryCache cache) =>
{
    // Try to get products from cache
    if (!cache.TryGetValue("products", out object products))
    {
        products = new[]
        {
            new
            {
                Id = 1,
                Name = "Laptop",
                Price = 1200.50,
                Stock = 25,
                Category = new { Id = 101, Name = "Electronics" }
            },
            new
            {
                Id = 2,
                Name = "Headphones",
                Price = 50.00,
                Stock = 100,
                Category = new { Id = 102, Name = "Accessories" }
            }
        };
        // Set cache for 5 minutes
        cache.Set("products", products, TimeSpan.FromMinutes(5));
    }
    return products;
});

app.Run();