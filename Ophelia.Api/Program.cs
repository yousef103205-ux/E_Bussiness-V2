using Microsoft.EntityFrameworkCore;
using Ophelia.Api.Data;
using Ophelia.Api.Services;

var builder = WebApplication.CreateBuilder(args);

const string CorsPolicy = "FrontendPolicy";

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicy, policy => policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin());
});

builder.Services.AddDbContext<OpheliaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(CorsPolicy);
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<OpheliaDbContext>();
        await DbInitializer.SeedAsync(db);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Database initialization failed. Check SQL Server and the DefaultConnection string.");
    }
}

app.Run();


