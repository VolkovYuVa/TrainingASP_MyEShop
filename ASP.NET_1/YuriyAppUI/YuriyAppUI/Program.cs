using MailKit;
using Microsoft.AspNetCore.HttpLogging;
using YuriyAppUI.Client.Pages;
using YuriyAppUI.Components;
using YuriyShop.Domain.Models;
using YuriyShop.Domain.Repository;
using YuriyShop.Domain.Services;
using YuriyShop.WebApi.Endpoints;
using YuriyShop.Domain.Models.Mail;
using YuriyShop.Domain.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpLogging(x=>x.LoggingFields = HttpLoggingFields.All);


builder.Services.AddSingleton<IProductRepository, RamProductRepository>();
builder.Services.AddSingleton<IClock, SystemClock>();
builder.Services.AddSingleton<ProductService>();
builder.Services.AddScoped<IEmailSender, SMTPEmailSender>();
builder.Services.AddScoped<MailService>();
 
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseHttpLogging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGet("/get_product", ProductEndpoints.GetProductEndpoint);
app.MapPost("/add_product", ProductEndpoints.AddProductEndpoint);
app.MapPost("/update_product", ProductEndpoints.UpdateProductEndpoint);
app.MapPost("/delete_product", ProductEndpoints.DeleteProductEndpoint);
app.MapPost("/clear_catalogue", ProductEndpoints.ClearCatalogueEndpoint);
app.MapGet("/get_catalogue", ProductEndpoints.GetCatalogueEndpoint);

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(YuriyAppUI.Client._Imports).Assembly);

app.Run();
