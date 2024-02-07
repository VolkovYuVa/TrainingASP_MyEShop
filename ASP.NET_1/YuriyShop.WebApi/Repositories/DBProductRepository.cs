using YuriyShop.WebApi.src.Common;

namespace YuriyShop.WebApi.Common
{
    public class DbProductRepository: IProductRepository
    {
        public string Message_AddProduct { get; set; } = "Product added to db";
        public string Message_RemoveProduct { get; set; } = "Product removed from db";
        public string Message_UpdateProduct { get; set; } = "Product updated in db";
        public string Message_ClearCatalogue { get; set; } = "Catalogue in db is cleared";

        public Product GetProduct(int id)
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
