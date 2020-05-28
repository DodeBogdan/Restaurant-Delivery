using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClientSignUpWindow clientSignUpWindow = new ClientSignUpWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = clientSignUpWindow;
            App.Current.MainWindow.Show();
        }
    }
}
