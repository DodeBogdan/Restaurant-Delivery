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
            var products = restaurant.GetProductByCategory(category);

            List<ClientProductsDisplay> productsDisplays = new List<ClientProductsDisplay>();

            foreach (var product in products)
            {
                productsDisplays.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = product.Price.ToString() + "RON",
                    Quantity = product.Quantity.ToString() + "grams"
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
                .Where((x) => x.Name.ToLower().Contains(name.ToLower()));


            List<ClientProductsDisplay> productsDisplays = new List<ClientProductsDisplay>();

            foreach (var product in products)
            {
                productsDisplays.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = product.Price.ToString() + "RON",
                    Quantity = product.Quantity.ToString() + "grams"
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
                        Price = product.Price.ToString() + "RON",
                        Quantity = product.Quantity.ToString() + "grams"
                    });
                }
            }


            return productsDisplays;
        }
    }
}
