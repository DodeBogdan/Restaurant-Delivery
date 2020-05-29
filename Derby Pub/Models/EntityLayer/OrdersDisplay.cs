using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
