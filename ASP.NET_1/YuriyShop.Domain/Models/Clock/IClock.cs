
namespace YuriyShop.Domain.Models
{
    public interface IClock
    {
        public DateTime Now { get; }
        public DateTime Today { get; }
    }
}
