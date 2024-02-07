using YuriyShop.WebApi.src.Common;

namespace YuriyShop.WebApi.Services;

public class ProductService
{
    private IProductRepository ProductRepository { get; set; }

    public ProductService(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    public IResult CreateProduct(Product product)
    {
        string resultMessage;
        try
        {
            ProductRepository.CreateProduct(product);
            resultMessage = ProductRepository.Message_AddProduct;
        }
        catch (Exception ex)
        {
            resultMessage = ex.Message;
        }

        return Results.Text(content: resultMessage, statusCode: StatusCodes.Status201Created);
    }

    public IResult UpdateProduct(Product product)
    {
        string resultMessage;
        try
        {
            ProductRepository.UpdateProduct(product);
            resultMessage = ProductRepository.Message_UpdateProduct;
        }
        catch (Exception ex)
        {
            resultMessage = ex.Message;
        }

        return Results.Text(content: resultMessage, statusCode: StatusCodes.Status200OK);
    }

    public IResult DeleteProduct(int id)
    {
        string resultMessage;
        try
        {
            ProductRepository.DeleteProduct(id);
            resultMessage = ProductRepository.Message_RemoveProduct;
        }
        catch (Exception ex)
        {
            resultMessage = ex.Message;
        }

        return Results.Text(content: resultMessage, statusCode: StatusCodes.Status200OK);
    }

    public Product? FindProduct(int id)
    {
        return ProductRepository.FindProduct(id);
    }

    public IResult ClearCatalogue()
    {
        string resultMessage;
        try
        {
            ProductRepository.ClearCatalogue();
            resultMessage = ProductRepository.Message_ClearCatalogue;
        }
        catch (Exception ex)
        {
            resultMessage = ex.Message;
        }

        return Results.Text(content: resultMessage, statusCode: StatusCodes.Status200OK);
    }

    public IResult GetCatalogue()
    {
        //return ProductProcessor.GetCatalogue();
        string resultMessage;
        try
        {
            resultMessage = ProductRepository.GetCatalogue().ToString();
        }
        catch (Exception ex)
        {
            resultMessage = ex.Message;
        }


        return Results.Text(content: resultMessage, statusCode: StatusCodes.Status200OK);
    }
}