using Derby_Pub.Helps;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Models.EntityLayer;
using Derby_Pub.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Derby_Pub.ViewModels
{
    class AdminViewProductsViewModel : BaseVM
    {
        private readonly ProductRepository productRepository = new ProductRepository();

        private ObservableCollection<SelectedProduct> productList;

        public ObservableCollection<SelectedProduct> ProductList
        {
            get
            {
                productList = productRepository.GetProductsWithLowQuantity();
                return productList;
            }
            set
            {
                productList = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }

        private SelectedProduct selectedProduct;

        public SelectedProduct SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private ICommand addQuantityCommand;
        public ICommand AddQuantityCommand
        {
            get
            {
                if (addQuantityCommand == null)
                {
                    addQuantityCommand = new RelayCommand(AddQuantity);
                }
                return addQuantityCommand;
            }
        }

        private void AddQuantity(object obj)
        {
            if (SelectedProduct == null)
                return;

            var currentWindow = App.Current.MainWindow;

            DialogWindow dialogWindow = new DialogWindow(999999);
            App.Current.MainWindow = dialogWindow;
            App.Current.MainWindow.ShowDialog();

            var count = dialogWindow.GetNoProducts();

            App.Current.MainWindow = currentWindow;

            productRepository.AddQuantityToProduct(SelectedProduct.Name, count);
            ProductList = productRepository.GetProductsWithLowQuantity();
        }
    }
}
