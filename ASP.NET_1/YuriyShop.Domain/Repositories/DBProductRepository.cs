using YuriyShop.Domain.Models;

namespace YuriyShop.Domain.Repository
{
    public class DbProductRepository: IProductRepository
    {
        public Product GetProduct(int id)
        {
            return null;
        }

        public Product? FindProduct(int id)
        {
            return null;
        }

        public void CreateProduct(Product product)
        {
            Console.WriteLine("Create Product: DB");
        }
        public void DeleteProduct(int id)
        {
            Console.WriteLine("Delete Product: DB");
        }
        public void UpdateProduct(Product product)
        {
            Console.WriteLine("Update Product: DB");
        }

        public void ClearCatalogue()
        {
            Console.WriteLine("Clear Catalogue: DB");
        }

        public IEnumerable<Product> GetCatalogue()
        {
            return null;
        }

    }
}
