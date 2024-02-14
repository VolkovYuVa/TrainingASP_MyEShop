using YuriyShop.Domain.Models;

namespace YuriyShop.Domain.Repository
{
    public class RamProductRepository : IProductRepository
    {
        public static List<Product> Products { get; set; } = new List<Product>();
        public Product GetProduct(int id)
        {
            return Products.Single(x => x.Id == id);
        }

        public Product? FindProduct(int id)
        {
            return Products.SingleOrDefault(x => x.Id == id);
        }

        public void CreateProduct(Product product)
        {
            Products.Add(product);
        }
        public void DeleteProduct(int id)
        {
            Products.Remove(Products.Where(x => x.Id == id).SingleOrDefault());
        }
        public void UpdateProduct(Product product)
        {
            Product FoundById = Products.Where(x => x.Id == product.Id).SingleOrDefault();
            Products[Products.IndexOf(FoundById)] = product;  
        }
        public void ClearCatalogue()
        {
            Products.Clear();
        }

        public IEnumerable<Product> GetCatalogue()
        {
            return Products;
        }

    }
}
