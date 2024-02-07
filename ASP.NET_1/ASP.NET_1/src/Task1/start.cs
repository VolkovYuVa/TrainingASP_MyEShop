using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace ASP.NET_1.src.Task1
{
    public static class start
    {
        public static string CustomPrice(double price)
        {
            double Fee;
            Fee = price > 200 ? (price-200)*0.15: 0;
            return $"Размер таможенной пошлины: {Fee}";
        }

        public static string LanguageDatetime(string lang)
        {
            return DateTime.Now.ToString("dddd,dd MMMM yyyy", new CultureInfo(lang));
        }
    }
}
