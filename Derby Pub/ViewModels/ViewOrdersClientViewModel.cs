using Derby_Pub.Helps;
using Derby_Pub.Models;
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
    class ViewOrdersClientViewModel : BaseVM
    {
        private User actualUser;
        private readonly OrderBLL orderBll = new OrderBLL();
        public User ActualUser
        {
            get { return actualUser; }
            set
            {
                actualUser = value;
                ActiveOrdersList = orderBll.GetActiveOrdersFromUser(ActualUser.UserID);
                OrdersList = orderBll.GetOrdersFromUser(ActualUser.UserID);
            }
        }
        #region ActiveOrders

        private ObservableCollection<ActiveOrdersDisplay> activeOrdersList = new ObservableCollection<ActiveOrdersDisplay>();
        public ObservableCollection<ActiveOrdersDisplay> ActiveOrdersList
        {
            get
            {
                return activeOrdersList;
            }
            set
            {
                activeOrdersList = value;
                OnPropertyChanged("ActiveOrdersList");
            }
        }
        private ActiveOrdersDisplay selectedActiveOrder;

        public ActiveOrdersDisplay SelectedActiveOrder
        {
            get { return selectedActiveOrder; }
            set
            {
                selectedActiveOrder = value;
                OnPropertyChanged("SelectedActiveOrder");
            }
        }

        #endregion
        #region OrdersList
        private ObservableCollection<OrdersDisplay> ordersList = new ObservableCollection<OrdersDisplay>();
        public ObservableCollection<OrdersDisplay> OrdersList
        {
            get
            {
                return ordersList;
            }
            set
            {
                ordersList = value;
                OnPropertyChanged("OrdersList");
            }
        }
        private ActiveOrdersDisplay selectedOrder;

        public ActiveOrdersDisplay SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }
        #endregion

        #region CancelOrder

        private ICommand cancelOrderCommand;

        public ICommand CancelOrderCommand
        {
            get
            {
                if (cancelOrderCommand == null)
                {
                    cancelOrderCommand = new RelayCommand(CancelOrder);
                }
                return cancelOrderCommand;
            }
        }

        private void CancelOrder(object obj)
        {
            if (SelectedActiveOrder == null)
                return;

            orderBll.CancelOrder(SelectedActiveOrder.ActiveOrderCode);

            ActiveOrdersList = orderBll.GetActiveOrdersFromUser(ActualUser.UserID);
            OrdersList = orderBll.GetOrdersFromUser(ActualUser.UserID);
        }
        #endregion

        private ICommand seeDetaliesAboutCommand;

        public ICommand SeeDetaliesAboutCommand
        {
            get
            {
                if (seeDetaliesAboutCommand == null)
                {
                    seeDetaliesAboutCommand = new RelayCommand(SeeDetalies);
                }
                return seeDetaliesAboutCommand;
            }
        }

        private void SeeDetalies(object obj)
        {
            if (SelectedActiveOrder == null)
                return;

            var currentWindow = App.Current.MainWindow;
            ViewOrderDetaliesWindow viewOrderDetaliesWindow = new ViewOrderDetaliesWindow(SelectedActiveOrder.ActiveOrderCode);
            App.Current.MainWindow = viewOrderDetaliesWindow;
            App.Current.MainWindow.ShowDialog();

            App.Current.MainWindow = currentWindow;

        }
    }
}
