using System;

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
