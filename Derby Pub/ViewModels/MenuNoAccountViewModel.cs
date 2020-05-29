using Derby_Pub.Helps;
using Derby_Pub.Models;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Models.EntityLayer;
using Derby_Pub.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Derby_Pub.ViewModels
{
    class MenuNoAccountViewModel : BaseVM
    {

        private readonly RestaurantModel restaurantModel = new RestaurantModel();
        private readonly ProductsBLL productsBll = new ProductsBLL();

        #region CategorySelect

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
        #endregion

        #region SearchSection
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

        private List<string> typeList;

        public List<string> TypeList
        {
            get
            {
                typeList = new List<string>()
                {
                    new StringBuilder("Preparat:").ToString(),
                    new StringBuilder("Alergen:").ToString()
                };
                return typeList;
            }
            set
            {
                typeList = value;
                OnPropertyChanged("TypeList");
            }
        }

        private string typeSelected;

        public string TypeSelected
        {
            get { return typeSelected; }
            set
            {
                typeSelected = value;
                OnPropertyChanged("SearchSelected");
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

            AllergenList = null;
            if (ImageList != null)
                ImageList.Clear();

            switch (SearchSelected)
            {
                case "Contin:":
                    switch (TypeSelected)
                    {
                        case "Preparat:":
                            ClientProductsList = new ObservableCollection<ClientProductsDisplay>(productsBll.GetProductsContainingName(categorySelected, SearchText));
                            break;
                        default:
                            ClientProductsList = new ObservableCollection<ClientProductsDisplay>(productsBll.GetProductsContainingAllergen(categorySelected, SearchText));
                            break;
                    }
                    break;
                default:
                    switch (TypeSelected)
                    {
                        case "Preparat:":
                            ClientProductsList = new ObservableCollection<ClientProductsDisplay>(productsBll.GetProductsNotContainingName(categorySelected, SearchText));
                            break;
                        default:
                            ClientProductsList = new ObservableCollection<ClientProductsDisplay>(productsBll.GetProductsWithoutAllergens(categorySelected, SearchText));

                            break;
                    }
                    break;
            }
        }

        #endregion


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

        public List<byte[]> ImageList;
        int index = 0;

        private ClientProductsDisplay productSelected;

        public ClientProductsDisplay ProductSelected
        {
            get { return productSelected; }
            set
            {
                productSelected = value;
                OnPropertyChanged("ProductSelected");

                if (ProductSelected != null)
                {
                    AllergenList = new ObservableCollection<string>(productsBll.GetAllergensByProductName(ProductSelected.Name));
                    ImageList = productsBll.GetImagesFromProductName(ProductSelected.Name);
                }
                if (ImageList.Count != 0)
                    CurrentImage = ToImage(ImageList[0]);
                else
                    CurrentImage = null;
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

            if (ProductSelected.ProductType == "Meniu")
            {
                MenuWindow menuWindow = new MenuWindow(name);

                App.Current.MainWindow = menuWindow;
                App.Current.MainWindow.ShowDialog();
                App.Current.MainWindow = currentWondow;
            }
        }

        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }


        private ObservableCollection<string> allergenList;

        public ObservableCollection<string> AllergenList
        {
            get
            {
                return allergenList;
            }
            set
            {
                allergenList = value;
                OnPropertyChanged("AllergenList");
            }

        }

        private BitmapImage currentImage;

        public BitmapImage CurrentImage
        {
            get { return currentImage; }
            set
            {
                currentImage = value;
                OnPropertyChanged("CurrentImage");
            }
        }

        private ICommand nextPhotoCommand;
        public ICommand NextPhotoCommand
        {
            get
            {
                if (nextPhotoCommand == null)
                {
                    nextPhotoCommand = new RelayCommand(NextPhoto);
                }
                return nextPhotoCommand;
            }
        }

        private void NextPhoto(object obj)
        {
            if (ImageList.Count == 0)
                return;

            if (index + 1 >= ImageList.Count)
            {
                index = 0;
            }
            else index++;

            CurrentImage = ToImage(ImageList[index]);
        }

        private ICommand previousPhotoCommand;
        public ICommand PreviousPhotoCommand
        {
            get
            {
                if (previousPhotoCommand == null)
                {
                    previousPhotoCommand = new RelayCommand(PreviousPhoto);
                }
                return previousPhotoCommand;
            }
        }

        private void PreviousPhoto(object obj)
        {
            if (ImageList.Count == 0)
                return;

            if (index <= 0)
            {
                index = ImageList.Count - 1;
            }
            else
                index--;

            CurrentImage = ToImage(ImageList[index]);
        }

    }
}
