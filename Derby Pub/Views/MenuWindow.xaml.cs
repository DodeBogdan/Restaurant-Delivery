using Derby_Pub.ViewModels;
using System.Windows;

namespace Derby_Pub.Views
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow(string menuName)
        {
            InitializeComponent();
            ((MenuViewModel)this.DataContext).MenuName = menuName;
        }
    }
}
