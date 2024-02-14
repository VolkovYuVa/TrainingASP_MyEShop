using YuriyShop.Domain.Models;
using YuriyShop.Domain.Repository;

namespace YuriyShop.Domain.Services;

public class ProductService
{
    private IProductRepository ProductRepository { get; set; }

    public ProductService(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    public void CreateProduct(Product product)
    {
        ProductRepository.CreateProduct(product);
    }

    public void UpdateProduct(Product product)
    {
        ProductRepository.UpdateProduct(product);
    }

    public void DeleteProduct(int id)
    {
        ProductRepository.DeleteProduct(id);
    }

    public Product? FindProduct(int id)
    {
        return ProductRepository.FindProduct(id);
    }

    public void ClearCatalogue()
    {
        ProductRepository.ClearCatalogue();
    }

    public IEnumerable<Product> GetCatalogue()
    {
        return ProductRepository.GetCatalogue();
    }
}