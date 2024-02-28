using YuriyShop.Domain.Models;
using YuriyShop.Domain.Repository;

namespace YuriyShop.Domain.Services;

public class ProductService
{
    private IClock _clock;
    private IProductRepository ProductRepository { get; set; }

    public ProductService(IProductRepository productRepository,IClock clock)
    {
        ProductRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _clock = clock ?? throw new ArgumentNullException(nameof(clock));
    }

    private Product ApplyAllDiscounts(Product product)
    {
        if (product != null)
        {
            product.Price *= MondayMultiplier;//последовательность нарушена
            return product.Clone();
        }
        else return product;
    }
    private double MondayMultiplier
    {
        get
        {
            return _clock.Today.DayOfWeek == DayOfWeek.Monday ? 0.75 : 1;
        }
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
        return ApplyAllDiscounts(ProductRepository.FindProduct(id));
    }

    public void ClearCatalogue()
    {
        ProductRepository.ClearCatalogue();
    }

    public Catalogue GetCatalogue()
    {
        var catalogue = ProductRepository.GetCatalogue().ToList();
        if (catalogue != null)
        {
            catalogue = catalogue.ConvertAll(x => ApplyAllDiscounts(x));
        }
        else
        {
            catalogue = new List<Product> { };
        }

        return new Catalogue(catalogue);
    }
}