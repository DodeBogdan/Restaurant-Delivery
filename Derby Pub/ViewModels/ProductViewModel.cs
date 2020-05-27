using Derby_Pub.Helps;
using Derby_Pub.Models;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Derby_Pub.ViewModels
{
    class ProductViewModel : BaseVM
    {

        private ProductsBLL products = new ProductsBLL();
        private string productName;
        public List<byte[]> ImageList;
        int index = 0;

        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                AllergenList = new ObservableCollection<string>(products.GetAllergensByProductName(ProductName));
                ImageList = products.GetImagesFromProductName(ProductName);
                if(ImageList.Count != 0)
                    CurrentImage = ToImage(ImageList[0]);
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
            if (index+1 >= ImageList.Count)
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
