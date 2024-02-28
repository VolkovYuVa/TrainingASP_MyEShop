

namespace YuriyShop.Domain.Models
{
    public class Catalogue
    {
        public IEnumerable<Product> Products { get; set; }
        public Catalogue(IEnumerable<Product> products) 
        {
            Products = products;
        }
    }
}
