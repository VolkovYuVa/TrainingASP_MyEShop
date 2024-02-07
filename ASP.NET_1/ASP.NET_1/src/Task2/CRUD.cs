using ASP.NET_1.src.Common;

namespace ASP.NET_1.src.Task2
{
    public static class CRUD
    {
        public static List<Product> Products {  get; set; } = new List<Product>();

        public static Product GetProduct(long id)
        {
            return new Product(id, $"TestProduct{id}", $"This is a test product number {id}", "ForTest", 999);
        }

        public static void AddProduct(Product PRD)
        {
            //Console.WriteLine("New product added:\r" + PRD.ToString());
            //return "New product added:\r" + PRD.ToString();
            Products.Add(PRD);
        }

        public static void UpdateProduct(Product PRD)
        {
            //return "Product updated:\r" + PRD.ToString();
        }
        public static void DeleteProduct(long id) 
        {
            //return "Product deleted:\r" + PRD.ToString();
        }

        public static void ClearCatalogue()
        {
            //return "The catalogue is cleared";
        }

        public static List<Product> GetCatalogue()
        {
            //return string.Join("\n", Products); 
            return Products;
        }
    }
}
