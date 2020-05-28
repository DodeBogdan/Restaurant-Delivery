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

        #region GetProductsByCategory
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
        #endregion

        public List<ClientProductsDisplay> GetProductsContaining(string category, string name)
        {
            var products = restaurant.GetProductByCategory(category)
                .Where((x) => x.Name.ToLower().Contains(name.ToLower())).ToList();

            var productAllergen = restaurant.GetProductBasedOnAllergens(category, name).ToList();

            List<ClientProductsDisplay> productsList = new List<ClientProductsDisplay>();
            List<ClientProductsDisplay> allergensList = new List<ClientProductsDisplay>();

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

            foreach (var product in productAllergen)
            {
                allergensList.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = $"{product.Price}RON",
                    Quantity = $"{product.Quantity}grams",
                    ProductType = "Preparat"
                });
            }

            productsList = Intersect(productsList, allergensList);

            productsList.Sort((x, y) => x.Name.CompareTo(y.Name));
            return productsList;
        }

        private List<ClientProductsDisplay> Intersect(List<ClientProductsDisplay> productsList, List<ClientProductsDisplay> allergensList)
        {
            List<ClientProductsDisplay> productsDisplays = productsList;

            for (int index = 0; index < allergensList.Count; index++)
            {
                bool este = true;

                for (int index1 = 0; index1 < productsList.Count; index1++)
                {
                    if (allergensList[index].Name == productsList[index1].Name)
                        este = false;
                }

                if (este == true)
                    productsDisplays.Add(allergensList[index]);
            }

            return productsDisplays;
        }

        internal List<ClientProductsDisplay> GetProductsWithoutAllergens(string categorySelected, string searchText)
        {
            var productsFromCategory = restaurant.GetProductByCategory(categorySelected).ToList();
            var productsWithAllegen = restaurant.GetAllProductWithAnAllergenBasedOnCategory(categorySelected, searchText).ToList();

            List<ClientProductsDisplay> productsDisplays = new List<ClientProductsDisplay>();


            foreach (var product in productsFromCategory)
            {
                if (!productsWithAllegen.Contains(product.Name))
                {
                    productsDisplays.Add(new ClientProductsDisplay()
                    {
                        Name = product.Name,
                        Price = $"{product.Price}RON",
                        Quantity = $"{product.Quantity}grams",
                        ProductType = "Preparat"
                    });
                }
            }

            var menuProducts = restaurant.GetMenuByCategory(categorySelected).ToList();

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

            return productsDisplays;
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
        private void AddOrderProduct(int userId, Dictionary<string, int> dictionary)
        {
            foreach(var d in dictionary)
            {
                for(int index = 0; index < d.Value; index++)
                {
                    int productId = (from product in restaurant.Products where product.Name.Contains(d.Key) select product.ProductID).First();
                    int orderId = (from order in restaurant.Orders where order.UserID == userId select order.OrderID).First();
                    restaurant.InsertIntoOrder_Product(orderId, productId);
                }
            }
        }
        public void BuyProducts(int userId,double transport_cost, double discount, double total_price, Dictionary<string, int> dictionary)
        {
            Random rnd = new Random();
            int random = rnd.Next(999, 100000);
            var uniqueCode = (from order in restaurant.Orders where order.UniqueCode == random select order.UniqueCode).ToList();

            while(uniqueCode.Count !=0)
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

            AddOrderProduct(userId,dictionary);
        }

    }
}
