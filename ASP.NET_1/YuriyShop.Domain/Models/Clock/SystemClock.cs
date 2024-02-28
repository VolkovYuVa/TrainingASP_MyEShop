
namespace YuriyShop.Domain.Models
{
    public class SystemClock: IClock
    {
        public DateTime Now { get { return DateTime.Now; } }

        public DateTime Today { get { return DateTime.Today; } }

    }
}
