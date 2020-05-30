using Derby_Pub.ViewModels;
using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for ChangeOrderStatusWindow.xaml
    /// </summary>
    public partial class ChangeOrderStatusWindow : Window
    {
        public ChangeOrderStatusWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }

        public string GetStatus()
        {
            return ((ChangeOrderStatusViewModel)this.DataContext).SelectedStatus;
        }
    }
}
