using Derby_Pub.Helps;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Views;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Derby_Pub.ViewModels
{
    class RegisterViewModel : BaseVM
    {

        private readonly UserBLL user = new UserBLL();

        private bool firstNameValidation = false;
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                Regex regex = new Regex(@"[A-Za-z]+");
                if (regex.Match(firstName) == Match.Empty || firstName.Length < 3)
                {
                    MessageBox.Show("Please enter a valid name");
                    firstNameValidation = false;
                    canExecute = false;
                }
                else
                    firstNameValidation = true;
                OnPropertyChanged("LastName");
            }
        }
        private bool lastNameValidation = false;
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                Regex regex = new Regex(@"[A-Za-z]+");
                if (regex.Match(lastName) == Match.Empty || lastName.Length < 3)
                {
                    MessageBox.Show("Please enter a valid name");
                    lastNameValidation = false;
                    canExecute = false;
                }
                else lastNameValidation = true;
                OnPropertyChanged("LastName");
            }
        }
        private bool emailValidation = false;
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                Regex regex = new Regex(@"[A-Za-z\s@.-0-9]+");
                if (regex.Match(email) == Match.Empty || email.Length < 4)
                {
                    MessageBox.Show("Please enter a valid name");
                    emailValidation = false;
                    canExecute = false;
                }
                else emailValidation = true;
                OnPropertyChanged("Email");

            }
        }
        private bool phoneValidation = false;
        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                Regex regex = new Regex(@"^0[0-9]{9}");
                if (regex.Match(phone) == Match.Empty || phone.Length != 10)
                {
                    MessageBox.Show("Please enter a valid phone");
                    phoneValidation = false;
                    canExecute = false;
                }
                else phoneValidation = true;
                OnPropertyChanged("Phone");
            }
        }
        private bool aressValidation = false;
        private string adress;

        public string Adress
        {
            get { return adress; }
            set
            {
                adress = value;
                Regex regex = new Regex(@"[A-Za-z-., 0-9]+");
                if (regex.Match(adress) == Match.Empty || adress.Length < 10)
                {
                    MessageBox.Show("Please enter a valid adress");
                    aressValidation = false;
                    canExecute = false;
                }
                else
                {
                    aressValidation = true;
                    if (firstNameValidation && lastNameValidation && emailValidation && phoneValidation && aressValidation)
                    {
                        canExecute = true;
                    }
                }
                OnPropertyChanged("Adress");
            }
        }


        private bool canExecute = false;
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddUser, param => canExecute);
                }
                return addCommand;
            }
        }

        private void BackToClient()
        {
            ClientSignUpWindow clientSignUpWindow = new ClientSignUpWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = clientSignUpWindow;
            App.Current.MainWindow.Show();
        }

        private void AddUser(object param)
        {

            var email = user.EmailExistence(Email);

            if (email)
            {
                MessageBox.Show("Email-ul este deja folosit.\nIntroduceti un alt email.");
                return;
            }

            var password = (param as PasswordBox).Password;

            if (password.Length < 6)
                MessageBox.Show("Introduceti un password valid.");
            else
            {
                user.RegisterUser(FirstName, LastName, Email, Adress, Phone, password);
                BackToClient();
            }
        }
    }
}
