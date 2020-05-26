using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby_Pub.Models.BusinessLayer
{
    class UserBLL
    {
        private readonly RestaurantModel restaurant = new RestaurantModel();
        public void RegisterUser(string firstName, string lastName, string email, string adress, string phone, string password)
        {
            restaurant.Users.Add(new User()
            {
                First_Name = firstName,
                Last_Name = lastName,
                Email = email,
                Adress = adress,
                Phone = phone,
                Password = password,
                Account_Type = 1
            });

            restaurant.SaveChanges();
        }
    }
}
