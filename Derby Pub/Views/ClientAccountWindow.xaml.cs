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
    /// Interaction logic for ClientAccountWindow.xaml
    /// </summary>
    public partial class ClientAccountWindow : Window
    {
        private User newUser;
        public ClientAccountWindow(User newUser)
        {
            InitializeComponent();
            this.newUser = newUser;
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            MenuWithClientAccountWindow menuWithClientAccount = new MenuWithClientAccountWindow(newUser);
            App.Current.MainWindow.Close();
            App.Current.MainWindow = menuWithClientAccount;
            App.Current.MainWindow.Show();
        }

        private void SeeOrdersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            StartUpPageWindow startUpPageWindow = new StartUpPageWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startUpPageWindow;
            App.Current.MainWindow.Show();
        }
    }
}
