using Derby_Pub.Views;
using System.Windows;

namespace Derby_Pub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartUpPageWindow : Window
    {
        public StartUpPageWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void NoAccountButton_Click(object sender, RoutedEventArgs e)
        {
            MenuNoAccountWindow menuNoAccountWindow = new MenuNoAccountWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = menuNoAccountWindow;
            App.Current.MainWindow.Show();
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            ClientSignUpWindow clientSignUpWindow = new ClientSignUpWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = clientSignUpWindow;
            App.Current.MainWindow.Show();
        }
    }
}
