using Derby_Pub.Helps;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby_Pub.ViewModels
{
    class OrderDetaliesByAdminViewModel : BaseVM
    {
        private Dictionary<string, int> products;

        public Dictionary<string, int> Products
        {
            get { return products; }
            set
            {
                products = value;
                foreach(var d in Products)
                {
                    ProductList.Add(new SelectedProduct()
                    {
                        Name = d.Key,
                        Quantity = d.Value
                    });
                }
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
    }
}
