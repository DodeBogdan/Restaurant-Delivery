using Derby_Pub.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for OrderDetaliesByAdminWindow.xaml
    /// </summary>
    public partial class OrderDetaliesByAdminWindow : Window
    {
        public OrderDetaliesByAdminWindow(Dictionary<string, int> products)
        {
            InitializeComponent();
            ((OrderDetaliesByAdminViewModel)this.DataContext).Products = products;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
