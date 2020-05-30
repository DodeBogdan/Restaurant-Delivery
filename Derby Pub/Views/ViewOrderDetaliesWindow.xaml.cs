using Derby_Pub.ViewModels;
using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for ViewOrderDetalies.xaml
    /// </summary>
    public partial class ViewOrderDetaliesWindow : Window
    {
        public ViewOrderDetaliesWindow(int orderCode)
        {
            InitializeComponent();
            ((ViewOrderDetaliesViewModel)this.DataContext).OrderCode = orderCode;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
