using Microsoft.AspNetCore.Mvc;
using YuriyShop.Domain.Services;
using YuriyShop.Domain.Models;
using System.Text.Json; 

namespace YuriyShop.WebApi.Endpoints;

public static class ProductEndpoints
{
    public static IResult GetProductEndpoint([FromServices] ProductService service,  [FromQuery]  int id)
    {
        if (id < 1)
        {
            return Results.BadRequest("Некорректный Id");
        }

        var product = service.FindProduct(id);
        if (product is null)
        {
            return Results.NotFound("Товар не найден");
        }
        return Results.Ok(product);

        // Альтернативы эксепшенам: Железнодорожно-орентированное программирование
    }


    public static IResult AddProductEndpoint([FromServices] ProductService service, [FromBody] Product product)
    {
        if (product is null)
        {
            return Results.BadRequest("Продукт не инициализирован");
        }

        service.CreateProduct(product);
        return Results.Created();
    }

    public static IResult UpdateProductEndpoint([FromServices] ProductService service, [FromBody] Product product)
    {
        if (product is null)
        {
            return Results.BadRequest("Продукт не инициализирован");
        }

        var FoundProduct = service.FindProduct(product.Id);
        if (FoundProduct is null)
        {
            return Results.BadRequest("Продукт с таким ID не найден");
        }    

        service.UpdateProduct(product);

        return Results.Ok("Продукт успешно обновлен");
    }

    public static IResult DeleteProductEndpoint([FromServices] ProductService service, [FromQuery] int id)
    {
        if (id < 1)
        {
            return Results.BadRequest("Некорректный Id");
        }
        service.DeleteProduct(id);
        return Results.Ok("Продукт успешно удален");
    }

    public static IResult ClearCatalogueEndpoint([FromServices] ProductService service)
    {
        service.ClearCatalogue();
        return Results.Ok("Каталог продуктов очищен");
    }

    public static IResult GetCatalogueEndpoint([FromServices] ProductService service)
    {
        Catalogue catalogue = new Catalogue( service.GetCatalogue().Products.ToList());
        //if (!catalogue.Products.Any())
        //{
        //   return Results.Ok("Каталог продуктов пуст");
        //}

        //var CatalogueString = JsonSerializer.Serialize(Catalogue);

        return Results.Ok(catalogue);
    }

}