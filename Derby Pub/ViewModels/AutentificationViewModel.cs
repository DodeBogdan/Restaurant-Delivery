using Derby_Pub.Helps;
using Derby_Pub.Models;
using Derby_Pub.Models.BusinessLayer;
using Derby_Pub.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Derby_Pub.ViewModels
{
    class AutentificationViewModel : BaseVM
    {
        readonly UserBLL user = new UserBLL();

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


        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand(LogIn);
                }
                return loginCommand;
            }
        }

        private void LogIn(object param)
        {
            if (Email == null)
                return;

            var password = (param as PasswordBox).Password;

            if (password.Length < 6)
            {
                MessageBox.Show("Parola incorecta. Va rugam reincercati!");
                return;
            }

            User newUser = user.Login(email, password);

            if (newUser.First_Name == null)
            {
                MessageBox.Show("Email-ul sau parola nu corespund.\nIncercati din nou.");
                return;
            }



            MenuWithClientAccountWindow menuWithClientAccount = new MenuWithClientAccountWindow(newUser);
            App.Current.MainWindow.Close();
            App.Current.MainWindow = menuWithClientAccount;
            App.Current.MainWindow.Show();

        }

    }
}
