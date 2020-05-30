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
        private readonly OrderRepository orderRepository = new OrderRepository();

        private ObservableCollection<AdminViewOrders> activeOrdersList;
        public ObservableCollection<AdminViewOrders> ActiveOrdersList
        {
            get
            {
                activeOrdersList = orderRepository.GetActiveOrders();
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
                if (SelectedOrder == null)
                {
                    LastName = FirstName = Phone = Adress = null;
                    return;
                }
                ClientDetalies clientDetalies = orderRepository.GetClientDetalies(SelectedOrder.OrderCode);
                LastName = clientDetalies.LastName;
                FirstName = clientDetalies.FirstName;
                Phone = clientDetalies.Phone;
                Adress = clientDetalies.Adress;
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        private string adress;

        public string Adress
        {
            get { return adress; }
            set
            {
                adress = value;
                OnPropertyChanged(nameof(Adress));
            }
        }



        private ObservableCollection<AdminViewOrders> ordersList;
        public ObservableCollection<AdminViewOrders> OrdersList
        {
            get
            {
                ordersList = orderRepository.GetOrders();
                return ordersList;
            }
            set
            {
                ordersList = value;
                OnPropertyChanged("OrdersList");
            }
        }

        #region orderStatus

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

            orderRepository.AdminChangeOrderStatus(SelectedOrder.OrderCode, status);

            ActiveOrdersList = orderRepository.GetActiveOrders();
            OrdersList = orderRepository.GetOrders();
        }

        #endregion

        #region OrderDetalies

        private ICommand seeDetaliesAboutCommand;
        public ICommand SeeDetaliesAboutCommand
        {
            get
            {
                if (seeDetaliesAboutCommand == null)
                {
                    seeDetaliesAboutCommand = new RelayCommand(SeeDetaliesAbout);
                }
                return seeDetaliesAboutCommand;
            }
        }

        private void SeeDetaliesAbout(object obj)
        {
            if (SelectedOrder == null)
                return;

            Dictionary<string, int> products = orderRepository.GetDetaliesAboutOrder(SelectedOrder.OrderCode);

            var currentWindow = App.Current.MainWindow;

            OrderDetaliesByAdminWindow orderDetaliesByAdminWindow = new OrderDetaliesByAdminWindow(products);
            App.Current.MainWindow = orderDetaliesByAdminWindow;
            App.Current.MainWindow.ShowDialog();

            App.Current.MainWindow = currentWindow;
        }

        #endregion
    }
}
