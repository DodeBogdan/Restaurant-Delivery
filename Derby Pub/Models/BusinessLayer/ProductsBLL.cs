using Derby_Pub.Helps;
using Derby_Pub.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Derby_Pub.Models.BusinessLayer
{
    class ProductsBLL
    {
        private readonly RestaurantModel restaurant = new RestaurantModel();
        internal double GetPriceOfMenu(string name)
        {
            return (double)restaurant.GetPriceOfMenu(name).First();
        }
        internal double GetPriceOfProduct(string key)
        {
            return restaurant.Products.Where((x) => x.Name == key)
                .Select((x) => x.Price).FirstOrDefault();
        }
        internal List<string> GetAllCategoryes()
        {
            return restaurant.GetAllCategoryes().ToList();
        }
        internal List<byte[]> GetImagesFromProductName(string productName)
        {
            List<byte[]> images = restaurant.GetImagesByProductName(productName).ToList();

            return images;
        }
        internal List<string> GetAllergensByProductName(string productName)
        {
            return restaurant.GetAllergenFromProductName(productName).ToList();
        }
        public List<ClientProductsDisplay> GetProductsByCategory(string category)
        {
            List<ClientProductsDisplay> productsDisplays = new List<ClientProductsDisplay>();

            var products = restaurant.GetProductByCategory(category).ToList();

            foreach (var product in products)
            {
                productsDisplays.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = $"{product.Price}RON",
                    Quantity = $"{product.Quantity}grams",
                    ProductType = "Preparat"
                });
            }

            var menuProducts = restaurant.GetMenuByCategory(category).ToList();

            foreach (var product in menuProducts)
            {
                productsDisplays.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = $"{product.Price - (AppConfigHelper.MenuDiscount / 100 * product.Price)}RON",
                    Quantity = "Vezi la detalii",
                    ProductType = "Meniu"
                });
            }

            productsDisplays.Sort((x, y) => x.Name.CompareTo(y.Name));
            return productsDisplays;
        }
        public List<ClientProductsDisplay> GetProductsContainingName(string category, string name)
        {
            var products = restaurant.GetProductByCategory(category)
                .Where((x) => x.Name.ToLower().Contains(name.ToLower())).ToList();

            var menus = restaurant.GetMenuByCategory(category)
                .Where((x) => x.Name.ToLower().Contains(name.ToLower())).ToList();

            List<ClientProductsDisplay> productsList = new List<ClientProductsDisplay>();

            foreach (var product in products)
            {
                productsList.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = $"{product.Price}RON",
                    Quantity = $"{product.Quantity}grams",
                    ProductType = "Preparat"
                });
            }

            foreach (var product in menus)
            {
                productsList.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = $"{product.Price - (AppConfigHelper.MenuDiscount / 100 * product.Price)}RON",
                    Quantity = $"Vezi Detalii",
                    ProductType = "Preparat"
                });
            }

            productsList.Sort((x, y) => x.Name.CompareTo(y.Name));
            return productsList;
        }

        private List<ClientProductsDisplay> GetListWithoutDoubles(List<ClientProductsDisplay> list)
        {
            if (list.Count == 0)
                return new List<ClientProductsDisplay>();

            List<ClientProductsDisplay> newList = new List<ClientProductsDisplay>();
            newList.Add(list[0]);

            for (int index = 0; index < list.Count; index++)
            {
                bool exist = false;

                for (int index1 = 0; index1 < newList.Count; index1++)
                {
                    if (list[index].Name == newList[index1].Name)
                        exist = true;
                }

                if (exist == false)
                {
                    newList.Add(list[index]);
                }
            }

            return newList;

        }

        public List<ClientProductsDisplay> GetProductsContainingAllergen(string category, string name)
        {
            var products = restaurant.GetAllProductWithAnAllergenBasedOnCategory(category, name);

            var menus = restaurant.GetAllMenusBasedOnAllergen(category, name);

            List<ClientProductsDisplay> productsList = new List<ClientProductsDisplay>();

            foreach (var product in products)
            {
                productsList.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = $"{product.Price}RON",
                    Quantity = $"{product.Quantity}grams",
                    ProductType = "Preparat"
                });
            }

            foreach (var product in menus)
            {
                productsList.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = $"{product.Price - (AppConfigHelper.MenuDiscount / 100 * product.Price)}RON",
                    Quantity = $"Vezi Detalii",
                    ProductType = "Preparat"
                });
            }

            productsList = GetListWithoutDoubles(productsList);

            productsList.Sort((x, y) => x.Name.CompareTo(y.Name));
            return productsList;
        }

        public List<ClientProductsDisplay> GetProductsNotContainingName(string category, string name)
        {
            var products = restaurant.GetProductByCategory(category)
                .Where((x) => !x.Name.ToLower().Contains(name.ToLower())).ToList();

            var menus = restaurant.GetMenuByCategory(category)
                .Where((x) => !x.Name.ToLower().Contains(name.ToLower())).ToList();

            List<ClientProductsDisplay> productsList = new List<ClientProductsDisplay>();

            foreach (var product in products)
            {
                productsList.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = $"{product.Price}RON",
                    Quantity = $"{product.Quantity}grams",
                    ProductType = "Preparat"
                });
            }

            foreach (var product in menus)
            {
                productsList.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = $"{product.Price - (AppConfigHelper.MenuDiscount / 100 * product.Price)}RON",
                    Quantity = $"Vezi Detalii",
                    ProductType = "Preparat"
                });
            }

            productsList.Sort((x, y) => x.Name.CompareTo(y.Name));
            return productsList;
        }

        internal List<ClientProductsDisplay> GetUnique(List<ClientProductsDisplay> list1, List<ClientProductsDisplay> list2)
        {
            List<ClientProductsDisplay> newList = new List<ClientProductsDisplay>();

            for (int index = 0; index < list1.Count; index++)
            {
                bool contain = false;
                for (int index1 = 0; index1 < list2.Count; index1++)
                {
                    if (list1[index].Name == list2[index1].Name)
                        contain = true;
                }

                if (!contain)
                    newList.Add(list1[index]);
            }

            return newList;
        }

        internal List<ClientProductsDisplay> GetProductsWithoutAllergens(string categorySelected, string searchText)
        {
            var productsFromCategory = restaurant.GetProductByCategory(categorySelected).ToList();
            var productsWithAllergens = restaurant.GetAllProductWithAnAllergenBasedOnCategory(categorySelected, searchText);

            List<ClientProductsDisplay> productList = new List<ClientProductsDisplay>();
            List<ClientProductsDisplay> productListWithAllergen = new List<ClientProductsDisplay>();

            foreach (var product in productsFromCategory)
            {
                productList.Add(
                    new ClientProductsDisplay()
                    {
                        Name = product.Name,
                        Price = $"{product.Price}RON",
                        Quantity = $"{product.Quantity}grams",
                        ProductType = "Preparat"
                    });
            }

            foreach (var product in productsWithAllergens)
            {
                productListWithAllergen.Add(
                    new ClientProductsDisplay()
                    {
                        Name = product.Name,
                        Price = $"{product.Price}RON",
                        Quantity = $"{product.Quantity}grams",
                        ProductType = "Preparat"
                    });
            }

            productList = GetUnique(productList, productListWithAllergen);

            var menuFromCategory = restaurant.GetMenuByCategory(categorySelected);
            var menuWithAllergens = restaurant.GetAllMenusBasedOnAllergen(categorySelected, searchText);

            List<ClientProductsDisplay> menuList = new List<ClientProductsDisplay>();
            List<ClientProductsDisplay> menuListWithAllergen = new List<ClientProductsDisplay>();

            foreach (var product in menuFromCategory)
            {
                menuList.Add(
                    new ClientProductsDisplay()
                    {
                        Name = product.Name,
                        Price = $"{product.Price}RON",
                        Quantity = $"Vezi la detalii",
                        ProductType = "Preparat"
                    });
            }

            foreach (var product in menuWithAllergens)
            {
                menuListWithAllergen.Add(
                    new ClientProductsDisplay()
                    {
                        Name = product.Name,
                        Price = $"{product.Price}RON",
                        Quantity = $"Vezi la detalii",
                        ProductType = "Preparat"
                    });
            }

            menuList = GetUnique(menuList, menuListWithAllergen);
            foreach (var product in menuList)
            {
                productList.Add(product);
            }

            return productList;
        }

        public List<ClientProductsDisplay> GetProductsByMenuName(string name)
        {
            var products = restaurant.GetProductsByMenuName(name);

            List<ClientProductsDisplay> productsDisplays = new List<ClientProductsDisplay>();

            foreach (var product in products)
            {
                productsDisplays.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = $"{product.Price}RON",
                    Quantity = product.Quantity.ToString() + "grams",
                    ProductType = "Preparat"
                });
            }

            return productsDisplays;
        }
        private void AddOrderProduct(int userId, List<ProductDetalies> productDetalies)
        {
            foreach (var d in productDetalies)
            {
                if (d.Type == "Preparat")
                {
                    for (int index = 0; index < d.Quantity; index++)
                    {
                        int productId = (from product in restaurant.Products where product.Name.Contains(d.Name) select product.ProductID).First();
                        int orderId = (from order in restaurant.Orders where order.UserID == userId select order.OrderID).First();
                        restaurant.InsertIntoOrder_Product(orderId, productId);
                    }
                }
                else
                {
                    for(int index = 0; index < d.Quantity; index++)
                    {
                        int menuId = (from menu in restaurant.Menus where menu.Name.Contains(d.Name) select menu.MenuID).First();
                        int orderId = (from order in restaurant.Orders where order.UserID == userId select order.OrderID).First();
                        restaurant.InsertIntoOrder_Menu(orderId, menuId);
                    }
                }
            }
        }
        public void BuyProducts(int userId, double transport_cost, double discount, double total_price, List<ProductDetalies> productDetalies)
        {
            Random rnd = new Random();
            int random = rnd.Next(999, 100000);
            var uniqueCode = (from order in restaurant.Orders where order.UniqueCode == random select order.UniqueCode).ToList();

            while (uniqueCode.Count != 0)
            {
                random = rnd.Next(999, 100000);
                uniqueCode = (from order in restaurant.Orders where order.UniqueCode == random select order.UniqueCode).ToList();
            }

            restaurant.Orders.Add(new Order()
            {
                UserID = userId,
                StateID = 1,
                UniqueCode = random,
                Order_Time = DateTime.Now,
                Estimated_Time = DateTime.Now.AddMinutes(45),
                Transport_Cost = (float)transport_cost,
                Discount = (float)discount,
                Total_Price = (float)total_price,
            });

            restaurant.SaveChanges();

            AddOrderProduct(userId, productDetalies);
        }

    }
}
