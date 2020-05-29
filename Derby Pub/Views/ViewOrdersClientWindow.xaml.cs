using Derby_Pub.Models;
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
    /// Interaction logic for ViewOrdersClientWindow.xaml
    /// </summary>
    public partial class ViewOrdersClientWindow : Window
    {
        private User user;
        public ViewOrdersClientWindow(User user)
        {
            InitializeComponent();
            ((ViewOrdersClientViewModel)this.DataContext).ActualUser = user;
            this.user = user;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ClientAccountWindow clientAccountWindow = new ClientAccountWindow(user);
            App.Current.MainWindow.Close();
            App.Current.MainWindow = clientAccountWindow;
            App.Current.MainWindow.Show();
        }
    }
}
