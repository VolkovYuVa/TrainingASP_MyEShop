namespace ASP.NET_1.src.Common
{
    public interface IProductProcessor
    {
        public string? Message_AddProduct { get; set; }
        public string? Message_RemoveProduct { get; set; }
        public string? Message_UpdateProduct { get; set; }
        public string? Message_ClearCatalogue { get; set; }

        Product GetProduct(int id);
        void CreateProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
        void ClearCatalogue();
        public IEnumerable<Product> GetCatalogue();
    }
}
