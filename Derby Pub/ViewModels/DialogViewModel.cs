using Derby_Pub.Helps;
using System.Windows;
using System.Windows.Input;

namespace Derby_Pub.ViewModels
{
    class DialogViewModel : BaseVM
    {
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

            App.Current.MainWindow.Close();

        }
    }
}
