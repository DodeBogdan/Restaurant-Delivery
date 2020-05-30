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
        readonly UserRepository userBll = new UserRepository();
        readonly OrderRepository orderBll = new OrderRepository();

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

            if (password.Length < 1)
            {
                MessageBox.Show("Parola incorecta. Va rugam reincercati!");
                return;
            }

            User newUser = userBll.Login(email, password);

            if (newUser.First_Name == null)
            {
                MessageBox.Show("Email-ul sau parola nu corespund.\nIncercati din nou.");
                return;
            }


            if (newUser.AccountType.AccountTypeID == 1)
            {
                orderBll.ChangeOrdersStatus();

                ClientAccountWindow clientAccountWindow = new ClientAccountWindow(newUser);
                App.Current.MainWindow.Close();
                App.Current.MainWindow = clientAccountWindow;
                App.Current.MainWindow.Show();
            }
            else
            {
                AdminAccountWindow adminAccountWindow = new AdminAccountWindow();
                App.Current.MainWindow.Close();
                App.Current.MainWindow = adminAccountWindow;
                App.Current.MainWindow.Show();
            }
        }

    }
}
