using Derby_Pub.Helps;
using System.Windows;
using System.Windows.Input;

namespace Derby_Pub.ViewModels
{
    class DialogViewModel : BaseVM
    {
        private int numberOfProducts;

        public int NumberOfProducts
        {
            get { return numberOfProducts; }
            set
            {
                numberOfProducts = value;
                NumberOfProductsText = $"/{NumberOfProducts}";
            }
        }
        private string numberOfProductsString;

        public string NumberOfProductsText
        {
            get { return numberOfProductsString; }
            set
            {
                numberOfProductsString = value;
                OnPropertyChanged(nameof(NumberOfProductsText));
            }
        }


        private string noProducts;
        public string NoProducts
        {
            get { return noProducts; }
            set
            {
                noProducts = value;
                OnPropertyChanged("NoProducts");
            }
        }

        public int Number;

        private ICommand okButtonCommand;
        public ICommand OkButtonCommand
        {
            get
            {
                if (okButtonCommand == null)
                {
                    okButtonCommand = new RelayCommand(CheckTheInput);
                }
                return okButtonCommand;
            }
        }

        private void CheckTheInput(object obj)
        {
            if (NoProducts == null)
            {
                MessageBox.Show("Introduceti un numar.");
                return;
            }

            if (!int.TryParse(NoProducts, out Number))
            {
                MessageBox.Show("Introduceti un numar valid.");
                return;
            }

            if (Number > NumberOfProducts)
            {
                MessageBox.Show("Introduceti o valoare mai mica!");
                return;
            }
            App.Current.MainWindow.Close();

        }
    }
}
