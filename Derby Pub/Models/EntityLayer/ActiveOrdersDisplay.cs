using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby_Pub.Models.EntityLayer
{
    class ActiveOrdersDisplay
    {
        public DateTime ActiveOrderDate { get; set; }
        public int ActiveOrderCode { get; set; }
        public double ActiveOrderPrice { get; set; }
        public DateTime ActiveOrderEstimatedTime { get; set; }
    }
}
