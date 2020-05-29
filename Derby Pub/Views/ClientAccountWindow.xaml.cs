using Derby_Pub.Models;
using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for ClientAccountWindow.xaml
    /// </summary>
    public partial class ClientAccountWindow : Window
    {
        private readonly User newUser;
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
            ViewOrdersClientWindow viewOrdersClientWindow = new ViewOrdersClientWindow(newUser);
            App.Current.MainWindow.Close();
            App.Current.MainWindow = viewOrdersClientWindow;
            App.Current.MainWindow.Show();
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
