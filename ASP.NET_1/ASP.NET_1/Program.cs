using ASP.NET_1.src.Common;
using ASP.NET_1.src.Task1;
using ASP.NET_1.src.Task2;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using System;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


//builder.Services.Configure<JsonOptions>(options =>options.SerializerOptions.WriteIndented = true);
builder.Services.AddSingleton<IProductProcessor,RAMProductProcessor>();
builder.Services.AddSingleton<ProductService>();

WebApplication app = builder.Build();

app.MapGet("/", () => "Main");



app.MapGet("/RPC/get_product", ([FromServices] ProductService service,[FromQuery] int id) => service.GetProduct(id));//
app.MapPost("/RPC/add_product", ([FromServices] ProductService service, Product product) => service.CreateProduct(product));
app.MapPost("/RPC/update_product", ([FromServices] ProductService service, Product product) => service.UpdateProduct(product));
app.MapPost("/RPC/delete_product", ([FromServices] ProductService service, [FromQuery] int id) => service.DeleteProduct(id));
app.MapPost("/RPC/clear_catalogue", ([FromServices] ProductService service) => service.ClearCatalogue());
app.MapGet("/RPC/get_catalogue", ([FromServices] ProductService service) => service.GetCatalogue());


app.MapGet("/REST/products/{productId}", ([FromServices] ProductService service) => service.GetProduct);//
app.MapPost("/REST/products", ([FromServices] ProductService service) => service.CreateProduct);
app.MapPut("/REST/products", ([FromServices] ProductService service) => service.UpdateProduct);
app.MapDelete("/REST/products/{productId}", ([FromServices] ProductService service) => service.DeleteProduct);//




app.Run();

//app.MapGet("/2/RPC/get_product", (long ID) => CRUD.GetProduct(ID).ToString());//
//app.MapPost("/2/RPC/add_product", AddProduct);
//app.MapPost("/2/RPC/update_product", (Product product) => CRUD.UpdateProduct(product));
//app.MapPost("/2/RPC/delete_product", (long ID) => CRUD.DeleteProduct(ID));
//app.MapPost("/2/RPC/clear_catalogue", CRUD.ClearCatalogue);
//app.MapGet("/2/RPC/get_catalogue", CRUD.GetCatalogue);


//app.MapGet("/2/REST/products/{productId}", (long productId) => CRUD.GetProduct(productId).ToString());//
//app.MapPost("/2/REST/products", (Product product) => CRUD.AddProduct(product));
//app.MapPut("/2/REST/products", (Product product) => CRUD.UpdateProduct(product));
//app.MapDelete("/2/REST/products/{productId}", (long productId) => CRUD.DeleteProduct(productId));//
