using Derby_Pub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for OrderDetaliesByAdminWindow.xaml
    /// </summary>
    public partial class OrderDetaliesByAdminWindow : Window
    {
        public OrderDetaliesByAdminWindow(Dictionary<string,int> products)
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
