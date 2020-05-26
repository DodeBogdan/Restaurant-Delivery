using Derby_Pub.Helps;
using Derby_Pub.Models;
using Derby_Pub.Models.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Derby_Pub.ViewModels
{
    class RegisterViewModel : BaseVM
    {

        private readonly UserBLL user = new UserBLL();

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private string adress;

        public string Adress
        {
            get { return adress; }
            set
            {
                adress = value;
                OnPropertyChanged("Adress");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddUser);
                }
                return addCommand;
            }
        }

        private void AddUser(object obj)
        {
            MessageBox.Show($"{FirstName},{LastName},{Email},{Adress},{Phone},{Password},");
            user.RegisterUser(FirstName, LastName, Email, Adress, Phone, Password);
        }
    }
}
