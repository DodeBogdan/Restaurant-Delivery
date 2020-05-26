using Derby_Pub.Helps;
using Derby_Pub.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby_Pub.ViewModels
{
    class MenuViewModel : BaseVM
    {

        private readonly RestaurantModel restaurantModel = new RestaurantModel();

        private List<string> categoryList;

        private int categoryId;

        public int CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }


        public List<string> CategoryList
        {
            get
            {
                categoryList = restaurantModel.GetAllCategoryes().ToList();
                return categoryList;
            }
            set
            {
                categoryList = value;
                OnPropertyChanged("CategoryList");
            }
        }
    }
}
