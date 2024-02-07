using Microsoft.AspNetCore.Mvc;
using YuriyShop.WebApi.Services;

namespace YuriyShop.WebApi;

public static class ProductEndpoints
{
    public static IResult GetProductEndpoint([FromServices] ProductService service, [FromQuery] int id)
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
}