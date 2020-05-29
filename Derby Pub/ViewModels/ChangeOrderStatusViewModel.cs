using Derby_Pub.Helps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby_Pub.ViewModels
{
    class ChangeOrderStatusViewModel : BaseVM
    {
        private List<string> orderStatusList;

        public List<string> OrderStatusList
        {
            get
            {
                orderStatusList = new List<string>()
                {
                    new StringBuilder("None").ToString(),
                    new StringBuilder("Se pregateste").ToString(),
                    new StringBuilder("Preluata").ToString(),
                    new StringBuilder("Livrata").ToString(),
                    new StringBuilder("Anulata").ToString()
                };
                return orderStatusList;
            }
            set
            {
                orderStatusList = value;
                OnPropertyChanged(nameof(OrderStatusList));
            }
        }

        private string selectedStatus;

        public string SelectedStatus
        {
            get { return selectedStatus; }
            set
            {
                selectedStatus = value;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }
    }
}
