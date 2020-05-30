using Derby_Pub.Helps;
using Derby_Pub.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;

namespace Derby_Pub.Models.BusinessLayer
{
    class OrderRepository
    {
        private readonly RestaurantModel restaurant = new RestaurantModel();

        internal void ChangeOrdersStatus()
        {
            var orderState = (from order in restaurant.Orders
                              where order.StateID != 1 && order.Estimated_Time < DateTime.Now
                              select order).FirstOrDefault();

            //var smt = restaurant.Orders
            //    .Where(x => x.StateID != 1 && x.Estimated_Time < DateTime.Now)
            //    .FirstOrDefault();

            if (orderState != null)
            {
                orderState.StateID = 4;
                restaurant.SaveChanges();
            }
        }

        internal ObservableCollection<AdminViewOrders> GetActiveOrders()
        {
            ObservableCollection<AdminViewOrders> list = new ObservableCollection<AdminViewOrders>();

            var query = (from order in restaurant.Orders
                         join status in restaurant.States on order.StateID equals status.StateID 
                         where status.StateID != 4 && status.StateID != 5
                         select new
                         {
                             order.Order_Time,
                             order.UniqueCode,
                             order.Total_Price,
                             order.Transport_Cost,
                             order.Discount,
                             order.Estimated_Time,
                             status.StateName
                         })
                         .OrderByDescending(x => x.Order_Time)
                         .ToList();
                        
            foreach (var product in query)
            {
                list.Add(new AdminViewOrders()
                {
                    OrderDate = product.Order_Time,
                    OrderCode = product.UniqueCode,
                    OrderEstimatedTime = product.Estimated_Time,
                    OrderPrice = product.Total_Price + product.Discount - product.Transport_Cost,
                    OrderTotalCost = product.Total_Price,
                    OrderDiscount = product.Discount,
                    OrderTransport = product.Transport_Cost,
                    OrderStatus = product.StateName
                }) ;
            }

            return list;
        }

        internal ClientDetalies GetClientDetalies(int orderCode)
        {
            var query = (from order in restaurant.Orders
                         join user in restaurant.Users on order.UserID equals user.UserID
                         where order.UniqueCode == orderCode
                         select user).FirstOrDefault();

            return new ClientDetalies()
            {
                LastName = query.Last_Name,
                FirstName = query.First_Name,
                Phone = query.Phone,
                Adress = query.Adress
            };
        }

        internal ObservableCollection<AdminViewOrders> GetOrders()
        {
            ObservableCollection<AdminViewOrders> list = new ObservableCollection<AdminViewOrders>();

            var query = (from order in restaurant.Orders
                         join status in restaurant.States on order.StateID equals status.StateID
                         select new
                         {
                             order.Order_Time,
                             order.UniqueCode,
                             order.Total_Price,
                             order.Transport_Cost,
                             order.Discount,
                             order.Estimated_Time,
                             status.StateName
                         })
                         .OrderByDescending(x => x.Order_Time)
                         .ToList();

            foreach (var product in query)
            {
                list.Add(new AdminViewOrders()
                {
                    OrderDate = product.Order_Time,
                    OrderCode = product.UniqueCode,
                    OrderEstimatedTime = product.Estimated_Time,
                    OrderPrice = product.Total_Price + product.Discount - product.Transport_Cost,
                    OrderTotalCost = product.Total_Price,
                    OrderDiscount = product.Discount,
                    OrderTransport = product.Transport_Cost,
                    OrderStatus = product.StateName
                });
            }

            return list;
        }

        internal Dictionary<string, int> GetDetaliesAboutOrder(int orderCode)
        {
            Dictionary<string, int> products = new Dictionary<string, int>();

            var x = restaurant.GetProductDetaliesAboutOrder(orderCode).ToList();
            var y = restaurant.GetMenuDetaliesAboutOrder(orderCode).ToList();

            foreach(var product in x)
            {
                products.Add(product.Name, (int)product.ProductCount);
            }
            foreach(var product in y)
            {
                products.Add(product.Name, (int)product.MenuCount);
            }

            return products;
        }

        internal double GetTotalPrice(int orderCode)
        {
            return (from order in restaurant.Orders
                    where order.UniqueCode == orderCode
                    select order.Total_Price).First();
        }

        internal void AdminChangeOrderStatus(int orderCode, string status)
        {
            var stateId = restaurant.States
                .Where(x => x.StateName.Contains(status))
                .Select(x => x.StateID)
                .FirstOrDefault();

            var currentOrder = restaurant.Orders
                .Where(x => x.UniqueCode == orderCode)
                .FirstOrDefault();

            currentOrder.StateID = stateId;
            restaurant.SaveChanges();
                
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
