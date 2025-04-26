using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace D2R.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            // var LoginVM = new LoginViewModel();
            // this.DataContext = LoginVM;
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (DataContext is LoginViewModel vm && vm.LoginCommand.CanExecute(null))
                    vm.LoginCommand.Execute(null);
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length > 0)
                PasswordPlaceholder.Visibility = Visibility.Collapsed;
            else
                PasswordPlaceholder.Visibility = Visibility.Visible;

            if (DataContext is LoginViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}