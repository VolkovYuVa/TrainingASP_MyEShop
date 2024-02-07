using YuriyShop.WebApi.src.Common;
using Microsoft.AspNetCore.Mvc;
using YuriyShop.WebApi;
using YuriyShop.WebApi.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<JsonOptions>(options =>options.SerializerOptions.WriteIndented = true);
builder.Services.AddSingleton<IProductRepository, RamProductRepository>();
builder.Services.AddSingleton<ProductService>();

WebApplication app = builder.Build();

app.MapGet("/", () => "Main");

app.MapGet("/get_product", ProductEndpoints.GetProductEndpoint);
app.MapPost("/RPC/add_product", ([FromServices] ProductService service, Product product) => service.CreateProduct(product));
app.MapPost("/RPC/update_product", ([FromServices] ProductService service, Product product) => service.UpdateProduct(product));
app.MapPost("/RPC/delete_product", ([FromServices] ProductService service, [FromQuery] int id) => service.DeleteProduct(id));
app.MapPost("/RPC/clear_catalogue", ([FromServices] ProductService service) => service.ClearCatalogue());
app.MapGet("/RPC/get_catalogue", ([FromServices] ProductService service) => service.GetCatalogue());

// RPC != gRPC

app.Run();



