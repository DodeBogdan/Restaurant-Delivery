using Derby_Pub.ViewModels;
using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow(int numberOfProducts)
        {
            InitializeComponent();
            ((DialogViewModel)this.DataContext).NumberOfProducts = numberOfProducts;
        }

        public int GetNoProducts()
        {
            return ((DialogViewModel)this.DataContext).Number;
        }

    }
}
