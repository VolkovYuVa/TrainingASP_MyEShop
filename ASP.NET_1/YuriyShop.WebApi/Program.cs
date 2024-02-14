using YuriyShop.Domain.Repository;
using YuriyShop.Domain.Services;
using YuriyShop.WebApi;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<JsonOptions>(options =>options.SerializerOptions.WriteIndented = true);
builder.Services.AddSingleton<IProductRepository, RamProductRepository>();
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<DiscountService>();

WebApplication app = builder.Build();

app.MapGet("/", () => "Main");

app.MapGet("/get_product", ProductEndpoints.GetProductEndpoint);
app.MapPost("/add_product", ProductEndpoints.AddProductEndpoint);
app.MapPost("/update_product", ProductEndpoints.UpdateProductEndpoint);
app.MapPost("/delete_product", ProductEndpoints.DeleteProductEndpoint);
app.MapPost("/clear_catalogue", ProductEndpoints.ClearCatalogueEndpoint);
app.MapGet("/get_catalogue", ProductEndpoints.GetCatalogueEndpoint);

// RPC != gRPC

app.Run();
