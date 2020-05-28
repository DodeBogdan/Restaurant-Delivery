using Derby_Pub.Helps;
using Derby_Pub.Models;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Derby_Pub.ViewModels
{
    class OrderViewModel : BaseVM
    {
        private double sum;
        readonly ProductsBLL productsBLL = new ProductsBLL();

        public User ActualUser;
        private Dictionary<string, int> productDictionaryList;

        public Dictionary<string, int> ProductDictionaryList
        {
            get { return productDictionaryList; }
            set
            {
                productDictionaryList = value;
                foreach (var product in ProductDictionaryList)
                {
                    ProductList.Add(new SelectedProduct()
                    {
                        Name = product.Key,
                        Quantity = product.Value
                    });

                    sum += product.Value * productsBLL.GetPriceOfProduct(product.Key);

                }
                Price = sum;
                if (sum < AppConfigHelper.PriceHighterThan)
                    Discount = 0;
                else
                {
                    Discount = AppConfigHelper.Discount / 100 * sum;
                    sum -= Discount;
                }

                if (sum < AppConfigHelper.PriceLowerThan)
                {
                    Transport = AppConfigHelper.Transport;
                    sum += Transport;
                }
                else
                    Transport = 0;

                FullPrice = sum;
            }
        }


        private ObservableCollection<SelectedProduct> productList = new ObservableCollection<SelectedProduct>();
        public ObservableCollection<SelectedProduct> ProductList
        {
            get
            {
                return productList;
            }
            set
            {
                productList = value;
                OnPropertyChanged("productList");
            }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private double discount;
        public double Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                OnPropertyChanged("Discount");
            }
        }

        private double transport;
        public double Transport
        {
            get { return transport; }
            set
            {
                transport = value;
                OnPropertyChanged("Transport");
            }
        }

        private double fullPrice;
        public double FullPrice
        {
            get { return fullPrice; }
            set
            {
                fullPrice = value;
                OnPropertyChanged("FullPrice");
            }
        }

        private ICommand buyProductsCommand;
        public ICommand BuyProductsCommand
        {
            get
            {
                if (buyProductsCommand == null)
                {
                    buyProductsCommand = new RelayCommand(BuyProducts);
                }
                return buyProductsCommand;
            }

        }

        private void BuyProducts(object obj)
        {
            MessageBox.Show("BUY");
            productsBLL.BuyProducts(ActualUser.UserID, Transport, Discount, sum, productDictionaryList);
        }
    }
}
