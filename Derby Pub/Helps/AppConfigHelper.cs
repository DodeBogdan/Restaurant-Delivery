using System.Configuration;

namespace Derby_Pub.Helps
{
    class AppConfigHelper
    {
        public static double MenuDiscount = double.Parse(ConfigurationManager.AppSettings["MenuDiscount"]);
    }
}
