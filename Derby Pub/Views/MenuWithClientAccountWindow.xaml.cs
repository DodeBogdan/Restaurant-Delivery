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
        public MenuWithClientAccountWindow(User user)
        {
            InitializeComponent();
            ((MenuWithClientAccountViewModel)this.DataContext).ActualUser = user;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            StartUpPageWindow startUpPageWindow = new StartUpPageWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startUpPageWindow;
            App.Current.MainWindow.Show();
        }
    }
}
