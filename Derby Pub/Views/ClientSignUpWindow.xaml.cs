using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for ClientSignUpWindow.xaml
    /// </summary>
    public partial class ClientSignUpWindow : Window
    {
        public ClientSignUpWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = registerWindow;
            App.Current.MainWindow.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            StartUpPageWindow startUpPageWindow = new StartUpPageWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startUpPageWindow;
            App.Current.MainWindow.Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            AutentificationWindow autentificationWindow = new AutentificationWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = autentificationWindow;
            App.Current.MainWindow.Show();
        }
    }
}
