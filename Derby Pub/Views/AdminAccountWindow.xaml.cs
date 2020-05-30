using Derby_Pub.Models;
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
    /// Interaction logic for AdminAccountWindow.xaml
    /// </summary>
    public partial class AdminAccountWindow : Window
    {
        public AdminAccountWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            StartUpPageWindow startUpPageWindow = new StartUpPageWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startUpPageWindow;
            App.Current.MainWindow.Show();
        }

        private void SeeOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            AdminOrdersWindow adminOrdersWindow = new AdminOrdersWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = adminOrdersWindow;
            App.Current.MainWindow.Show();
        }

        private void SeeProductsButton_Click(object sender, RoutedEventArgs e)
        {
            AdminViewProductsWindow adminViewProductsWindow = new AdminViewProductsWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = adminViewProductsWindow;
            App.Current.MainWindow.Show();
        }
    }
}
