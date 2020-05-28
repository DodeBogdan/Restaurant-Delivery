using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for MenuNoAccountWindow.xaml
    /// </summary>
    public partial class MenuNoAccountWindow : Window
    {
        public MenuNoAccountWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            StartUpPageWindow startUpPageWindow = new StartUpPageWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startUpPageWindow;
            App.Current.MainWindow.Show();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = registerWindow;
            App.Current.MainWindow.Show();
        }
    }
}
