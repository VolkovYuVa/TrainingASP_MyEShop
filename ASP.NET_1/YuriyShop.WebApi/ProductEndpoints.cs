using Microsoft.AspNetCore.Mvc;
using YuriyShop.Domain.Services;
using YuriyShop.Domain.Models;

namespace YuriyShop.WebApi;

public static class ProductEndpoints
{
    public static IResult GetProductEndpoint([FromServices] ProductService service, [FromServices] DiscountService discountService, [FromQuery] int id)
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
        product = discountService.ApplyAllDiscounts(product);
        return Results.Ok(product);

        // Альтернативы эксепшенам: Железнодорожно-орентированное программирование
    }


    public static IResult AddProductEndpoint([FromServices] ProductService service, [FromQuery] Product product)
    {
        if (product is null)
        {
            return Results.BadRequest("Продукт не инициализирован");
        }

        service.CreateProduct(product);
        return Results.Created("Продукт успешно создан", product);
    }

    public static IResult UpdateProductEndpoint([FromServices] ProductService service, [FromQuery] Product product)
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
        List<Product> Catalogue = service.GetCatalogue().ToList();
        if (Catalogue.Count == 0)
        {
           return Results.Ok("Каталог продуктов пуст");
        }

        var CatalogueString = string.Join("\n-----------\n", Catalogue);
        return Results.Ok(CatalogueString);
    }

}