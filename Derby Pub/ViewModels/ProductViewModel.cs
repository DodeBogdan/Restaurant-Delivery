using Derby_Pub.Helps;
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
using System.Windows.Media.Imaging;

namespace Derby_Pub.ViewModels
{
    class ProductViewModel : BaseVM
    {

        private ProductsBLL products = new ProductsBLL();
        private string productName;
        public List<string> ImageList;
        int index = 0;

        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                AllergenList = new ObservableCollection<string>(products.GetAllergensByProductName(ProductName));
                ImageList = products.GetImagesFromProductName(ProductName);
                CurrentImage = new BitmapImage(new Uri(@"..\..\Assets\carnatirondele2.jpg",UriKind.Relative));
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

    }
}
