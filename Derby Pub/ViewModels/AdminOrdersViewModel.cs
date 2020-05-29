using Derby_Pub.Helps;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Models.EntityLayer;
using Derby_Pub.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Derby_Pub.ViewModels
{
    class AdminOrdersViewModel : BaseVM
    {
        private readonly OrderBLL orderBll = new OrderBLL();

        private ObservableCollection<AdminViewOrders> activeOrdersList;
        public ObservableCollection<AdminViewOrders> ActiveOrdersList
        {
            get
            {
                activeOrdersList = orderBll.GetActiveOrders();
                return activeOrdersList;
            }
            set
            {
                activeOrdersList = value;
                OnPropertyChanged("ActiveOrdersList");
            }
        }

        private AdminViewOrders selectedOrder;

        public AdminViewOrders SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }



        private ObservableCollection<AdminViewOrders> ordersList;
        public ObservableCollection<AdminViewOrders> OrdersList
        {
            get
            {
                ordersList = orderBll.GetOrders();
                return ordersList;
            }
            set
            {
                ordersList = value;
                OnPropertyChanged("OrdersList");
            }
        }

        private ICommand changeStatusDetalies;
        public ICommand ChangeStatusDetalies
        {
            get
            {
                if (changeStatusDetalies == null)
                {
                    changeStatusDetalies = new RelayCommand(ChangeStatus);
                }
                return changeStatusDetalies;
            }
        }

        private void ChangeStatus(object obj)
        {
            if (SelectedOrder == null)
                return;

            var currentWindow = App.Current.MainWindow;

            ChangeOrderStatusWindow changeOrderStatusWindow = new ChangeOrderStatusWindow();
            App.Current.MainWindow = changeOrderStatusWindow;
            App.Current.MainWindow.ShowDialog();

            var status = changeOrderStatusWindow.GetStatus();
            if (status == "None")
                return;

            App.Current.MainWindow = currentWindow;

            orderBll.AdminChangeOrderStatus(SelectedOrder.OrderCode, status);

            ActiveOrdersList = orderBll.GetActiveOrders();
            OrdersList = orderBll.GetOrders();
        }
    }
}
