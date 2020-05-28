using System.Linq;

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

        public bool EmailExistence(string email)
        {
            var user = restaurant.Users
                .Where((x) => x.Email == email).ToList();

            if (user.Count == 0)
                return false;

            return true;
        }

        public User Login(string email, string password)
        {
            if (!EmailExistence(email))
                return new User();

            var user = restaurant.Users
                .Where((x) => x.Email == email).First();

            if (user.Password.Trim() != password)
                return new User();

            return user;
        }
    }
}
