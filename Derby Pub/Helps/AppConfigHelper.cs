using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby_Pub.Helps
{
    class AppConfigHelper
    {
        public static double MenuDiscount = double.Parse(ConfigurationManager.AppSettings["MenuDiscount"]);
    }
}
