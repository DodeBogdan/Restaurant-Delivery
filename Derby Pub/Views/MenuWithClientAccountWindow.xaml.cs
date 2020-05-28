using Derby_Pub.Models;
using Derby_Pub.ViewModels;
using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for MenuWithClientAccountWindow.xaml
    /// </summary>
    public partial class MenuWithClientAccountWindow : Window
    {
        private User user;
        public MenuWithClientAccountWindow(User user)
        {
            InitializeComponent();
            ((MenuWithClientAccountViewModel)this.DataContext).ActualUser = user;
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
