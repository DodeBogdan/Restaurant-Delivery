using Derby_Pub.Helps;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Models.EntityLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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

                ImageList = productsBll.GetImagesFromProductName(ProductSelected.Name);

                if (ImageList.Count != 0)
                    CurrentImage = ToImage(ImageList[0]);
                else
                    CurrentImage = null;
                AllergenList = new ObservableCollection<string>(productsBll.GetAllergensByProductName(ProductSelected.Name));
            }
        }

        public List<byte[]> ImageList;
        int index = 0;

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
