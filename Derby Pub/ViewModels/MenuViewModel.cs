using Derby_Pub.Helps;
using Derby_Pub.Models;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Derby_Pub.ViewModels
{
    class MenuViewModel : BaseVM
    {

        private readonly RestaurantModel restaurantModel = new RestaurantModel();
        private readonly ProductsBLL productsBll = new ProductsBLL();
        private List<string> categoryList;
        public List<string> CategoryList
        {
            get
            {
                categoryList = restaurantModel.GetAllCategoryes().ToList();
                return categoryList;
            }
            set
            {
                categoryList = value;
                OnPropertyChanged("CategoryList");
            }
        }

        private string categorySelected;

        public string CategorySelected
        {
            get { return categorySelected; }
            set
            {
                categorySelected = value;
                ClientProductsList = new ObservableCollection<ClientProductsDisplay>(productsBll.GetProductsByCategory(categorySelected));
                OnPropertyChanged("CategorySelected");
            }
        }


        private List<string> searchList;

        public List<string> SearchList
        {
            get
            {
                searchList = new List<string>()
                {
                    new StringBuilder("Contin:").ToString(),
                    new StringBuilder("Nu contin:").ToString()
                };
                return searchList;
            }
            set
            {
                searchList = value;
                OnPropertyChanged("SearchList");
            }
        }

        private string searchSelected;

        public string SearchSelected
        {
            get { return searchSelected; }
            set
            {
                searchSelected = value;
                OnPropertyChanged("SearchSelected");
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

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }


        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(DisplayProducts);
                }
                return addCommand;
            }
        }

        private void DisplayProducts(object obj)
        {
            if (SearchText == null)
                return;

            switch (SearchSelected)
            {
                case "Contin:":
                    ClientProductsList = new ObservableCollection<ClientProductsDisplay>(productsBll.GetProductsContaining(categorySelected, SearchText));
                    break;
                default:
                    ClientProductsList = new ObservableCollection<ClientProductsDisplay>(productsBll.GetProductsWithoutAllergens(categorySelected, SearchText));
                    break;
            }
        }

    }
}
