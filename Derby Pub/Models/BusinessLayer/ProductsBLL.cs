using Derby_Pub.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby_Pub.Models.BusinessLayer
{
    class ProductsBLL
    {
        private readonly RestaurantModel restaurant = new RestaurantModel();

        public List<ClientProductsDisplay> GetProductsByCategory(string category)
        {
            var products = restaurant.GetProductByCategory(category);

            List<ClientProductsDisplay> productsDisplays = new List<ClientProductsDisplay>();

            foreach(var product in products)
            {
                productsDisplays.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = product.Price.ToString() + "RON",
                    Quantity = product.Quantity.ToString() + "grams"
                }) ;
            }

            return productsDisplays;
        }

        public List<ClientProductsDisplay> GetProductsContaining(string category,string name)
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
            var productsWithAllegen = restaurant.GetAllProductWithAnAllergenBasedOnCategory(categorySelected, searchText);

            List<ClientProductsDisplay> productsDisplays = new List<ClientProductsDisplay>();

            foreach (var product in productsFromCategory)
            {
                foreach(var p in productsWithAllegen)
                {
                    if(p.Name == product.Name)
                    {
                        productsFromCategory.Remove(product);
                        continue;
                    }
                }

                
            }

            foreach (var product in productsFromCategory)
                productsDisplays.Add(new ClientProductsDisplay()
                {
                    Name = product.Name,
                    Price = product.Price.ToString() + "RON",
                    Quantity = product.Quantity.ToString() + "grams"
                });

            return productsDisplays;
        }
    }
}
