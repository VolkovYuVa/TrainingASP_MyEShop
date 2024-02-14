using YuriyShop.Domain.Models;
namespace YuriyShop.Domain.Repository
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        Product? FindProduct(int id);
        void CreateProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
        void ClearCatalogue();
        public IEnumerable<Product> GetCatalogue();
    }
}
