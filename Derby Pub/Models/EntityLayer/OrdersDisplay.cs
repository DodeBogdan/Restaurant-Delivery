using System;

namespace Derby_Pub.Models.EntityLayer
{
    class OrdersDisplay
    {
        public DateTime OrderDate { get; set; }
        public int OrderCode { get; set; }
        public double OrderPrice { get; set; }
        public DateTime OrderEstimatedTime { get; set; }
        public string OrderState { get; set; }
    }
}
