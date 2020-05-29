﻿using Derby_Pub.Helps;
using Derby_Pub.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;

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

        internal double GetTotalPrice(int orderCode)
        {
            return (from order in restaurant.Orders
                    where order.UniqueCode == orderCode
                    select order.Total_Price).First();
        }

        internal double GetDiscountCost(int orderCode)
        {
            return (from order in restaurant.Orders
                    where order.UniqueCode == orderCode
                    select order.Discount).First();
        }

        internal double GetTransportCost(int orderCode)
        {
            return (from order in restaurant.Orders
                    where order.UniqueCode == orderCode
                    select order.Transport_Cost).First();
        }

        internal ObservableCollection<OrderDetalies> GetOrdersDetalies(int orderCode)
        {
            ObservableCollection<OrderDetalies> list = new ObservableCollection<OrderDetalies>();

            var x = restaurant.GetProductDetaliesAboutOrder(orderCode).ToList();
            var y = restaurant.GetMenuDetaliesAboutOrder(orderCode).ToList();

            foreach (var product in x)
            {
                list.Add(new OrderDetalies()
                {
                    Name = product.Name,
                    Quantity = (int)product.ProductCount
                });
            }

            foreach (var product in y)
            {
                list.Add(new OrderDetalies()
                {
                    Name = product.Name,
                    Quantity = (int)product.MenuCount
                });
            }

            return list;
        }

        internal ObservableCollection<ActiveOrdersDisplay> GetActiveOrdersFromUser(int userID)
        {
            ObservableCollection<ActiveOrdersDisplay> orders = new ObservableCollection<ActiveOrdersDisplay>();

            var list = (from order in restaurant.Orders where order.UserID == userID && order.StateID != 4 && order.StateID != 5 select order).ToList();

            foreach (var product in list)
            {
                orders.Add(new ActiveOrdersDisplay()
                {
                    ActiveOrderDate = product.Order_Time,
                    ActiveOrderCode = product.UniqueCode,
                    ActiveOrderEstimatedTime = product.Estimated_Time,
                    ActiveOrderPrice = product.Total_Price
                });
            }

            return orders;
        }

        internal ObservableCollection<OrdersDisplay> GetOrdersFromUser(int userID)
        {
            ObservableCollection<OrdersDisplay> orders = new ObservableCollection<OrdersDisplay>();

            var list = restaurant.GetOrdersFromUser(userID);

            foreach (var product in list)
            {
                orders.Add(new OrdersDisplay()
                {
                    OrderState = product.StateName,
                    OrderDate = product.Order_Time,
                    OrderCode = product.UniqueCode,
                    OrderEstimatedTime = product.Estimated_Time,
                    OrderPrice = product.Total_Price
                });
            }

            return orders;
        }

        internal int GetNoOrdersOfUser(int userID)
        {
            DateTime dateTime = DateTime.Now;
            DateTime newDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day - 7, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

            var x = (from order in restaurant.Orders
                     where order.Order_Time > newDate && order.UserID == userID
                     select order).Count();

            return x;
        }

        internal void CancelOrder(int orderCode)
        {
            var x = (from order in restaurant.Orders
                     where order.UniqueCode == orderCode
                     select order).FirstOrDefault();

            x.StateID = 5;

            restaurant.SaveChanges();
        }
    }
}
