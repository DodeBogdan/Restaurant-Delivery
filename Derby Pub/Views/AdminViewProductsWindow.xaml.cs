using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for AdminViewProducts.xaml
    /// </summary>
    public partial class AdminViewProductsWindow : Window
    {
        public AdminViewProductsWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            AdminAccountWindow adminAccountWindow = new AdminAccountWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = adminAccountWindow;
            App.Current.MainWindow.Show();
        }
    }
}
