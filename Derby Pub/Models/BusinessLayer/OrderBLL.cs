﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby_Pub.Models.BusinessLayer
{
    class OrderBLL
    {
        private readonly RestaurantModel restaurant = new RestaurantModel();

        public void ChangeOrdersStatus()
        {
            var orderState = (from order in restaurant.Orders
                              where order.StateID != 1 && order.Estimated_Time < DateTime.Now
                              select order).FirstOrDefault();

            if (orderState != null)
            {
                orderState.StateID = 4;
                restaurant.SaveChanges();
            }
        }

    }
}