using System.Configuration;

namespace Derby_Pub.Helps
{
    class AppConfigHelper
    {
        public static double MenuDiscount = double.Parse(ConfigurationManager.AppSettings["MenuDiscount"]);

        public static double Discount = double.Parse(ConfigurationManager.AppSettings["Discount"]);

        public static double PriceHighterThan = double.Parse(ConfigurationManager.AppSettings["PriceHighterThan"]);

        public static double PriceLowerThan = double.Parse(ConfigurationManager.AppSettings["PriceLowerThan"]);

        public static double Transport = double.Parse(ConfigurationManager.AppSettings["Transport"]);
    }
}
