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
    }
}
