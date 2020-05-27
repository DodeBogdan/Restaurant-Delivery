using Derby_Pub.Helps;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Models.EntityLayer;
using Derby_Pub.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Derby_Pub.ViewModels
{
    class MenuProductViewModel : BaseVM
    {
        private readonly ProductsBLL productsBll = new ProductsBLL();

        private string menuName;

        public string MenuName
        {
            get { return menuName; }
            set
            {
                menuName = value;
                ClientProductsList = new ObservableCollection<ClientProductsDisplay>(productsBll.GetProductsByMenuName(MenuName));
            }
        }

        private ObservableCollection<ClientProductsDisplay> clientProductsList = new ObservableCollection<ClientProductsDisplay>();
        public ObservableCollection<ClientProductsDisplay> ClientProductsList
        {
            get
            {
                return clientProductsList;
            }
            set
            {
                clientProductsList = value;
                OnPropertyChanged("ClientProductsList");
            }
        }

        private ClientProductsDisplay productSelected;

        public ClientProductsDisplay ProductSelected
        {
            get { return productSelected; }
            set
            {
                productSelected = value;
                OnPropertyChanged("ProductSelected");
            }
        }

        private ICommand seeDetails;
        public ICommand SeeDetails
        {
            get
            {
                if (seeDetails == null)
                {
                    seeDetails = new RelayCommand(ProductDetails);
                }
                return seeDetails;
            }
        }

        private void ProductDetails(object obj)
        {

            if (ProductSelected == null)
                return;

            string name = ProductSelected.Name.Trim();
            var currentWondow = App.Current.MainWindow;

            ProductWindow productWindow = new ProductWindow(name);

            App.Current.MainWindow = productWindow;
            App.Current.MainWindow.ShowDialog();
            App.Current.MainWindow = currentWondow;


        }

    }
}
