using Derby_Pub.Helps;
using Derby_Pub.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Derby_Pub.Models.BusinessLayer
{
    class ProductsBLL
    {
        private readonly RestaurantModel restaurant = new RestaurantModel();


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

            var menuProducts = restaurant.GetMenuDetails("Casa Derby").ToList();

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

        internal List<byte[]> GetImagesFromProductName(string productName)
        {
            List<byte[]> images = restaurant.GetImagesByProductName(productName).ToList();

            return images;
        }

        internal List<string> GetAllergensByProductName(string productName)
        {
            return restaurant.GetAllergenFromProductName(productName).ToList();
        }

        public List<ClientProductsDisplay> GetProductsContaining(string category, string name)
        {
            var products = restaurant.GetProductByCategory(category)
                .Where((x) => x.Name.ToLower().Contains(name.ToLower())).ToList();


            List<ClientProductsDisplay> productsDisplays = new List<ClientProductsDisplay>();

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

            var menuProducts = restaurant.GetMenuDetails("Casa Derby").ToList();

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

            var menuProducts = restaurant.GetMenuDetails("Casa Derby").ToList();

            foreach (var product in menuProducts)
            {
                productsDisplays.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = $"{product.Price - (AppConfigHelper.MenuDiscount/100 * product.Price)}RON",
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
    }
}
