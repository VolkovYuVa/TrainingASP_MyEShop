
using YuriyShop.Domain.Models;

namespace YuriyShop.Domain.Services
{
    public class DiscountService
    {
        public DiscountService() { }

        public Product ApplyAllDiscounts(Product product)
        {
            product.Price *= MondayMultiplier;
            return product;
        }

        private double MondayMultiplier 
        {
            get
            {
                return DateTime.Today.DayOfWeek == DayOfWeek.Monday ? 0.75 : 1;
            }
        }
    }
}
