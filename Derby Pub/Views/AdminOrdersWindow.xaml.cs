using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for AdminOrdersWindow.xaml
    /// </summary>
    public partial class AdminOrdersWindow : Window
    {
        public AdminOrdersWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminAccountWindow adminAccountWindow = new AdminAccountWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = adminAccountWindow;
            App.Current.MainWindow.Show();
        }
    }
}
