

namespace YuriyShop.Domain.Models.Clock
{
    public class StaticClock:IClock
    {
        public DateTime Now { get { return new DateTime(2008, 09, 3, 9, 6, 13);}}

        public DateTime Today { get { return new DateTime(Now.Year, Now.Month, Now.Day); } }
    }
}
