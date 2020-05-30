using Derby_Pub.Helps;
using Derby_Pub.Models;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby_Pub.ViewModels
{
    class ViewOrderDetaliesViewModel : BaseVM
    {
        private readonly OrderRepository orderBll = new OrderRepository();

        private int orderCode;
        public int OrderCode
        {
            get { return orderCode; }
            set
            {
                orderCode = value;
                OrdersList = orderBll.GetOrdersDetalies(OrderCode);
                TotalPrice = orderBll.GetTotalPrice(OrderCode);
                TransportCost = orderBll.GetTransportCost(OrderCode);
                Discount = orderBll.GetDiscountCost(OrderCode);
            }
        }

        #region OrderList

        private ObservableCollection<OrderDetalies> ordersList = new ObservableCollection<OrderDetalies>();
        public ObservableCollection<OrderDetalies> OrdersList
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

        #endregion

        #region Cost

        private double totalPrice;

        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        private double transportCost;

        public double TransportCost
        {
            get { return transportCost; }
            set
            {
                transportCost = value;
                OnPropertyChanged("TransportCost");
            }
        }

        private double discount;

        public double Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                OnPropertyChanged("Discount");
            }
        }

        #endregion

    }
}
