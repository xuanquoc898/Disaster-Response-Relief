using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MaterialDesignThemes.Wpf;

namespace D2R.Views.UserControls
{
    public partial class LoginView : UserControl
    {
        private bool _isPasswordVisible = false;
        public LoginView()
        {
            InitializeComponent();
        }

        private void TogglePasswordVisibilityButton_Click(object sender, RoutedEventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;

            if (_isPasswordVisible)
            {
                VisiblePasswordBox.Text = PasswordBox.Password;
                VisiblePasswordBox.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Collapsed;
                PasswordVisibilityIcon.Kind = PackIconKind.EyeOff;
            }
            else
            {
                PasswordBox.Password = VisiblePasswordBox.Text;
                VisiblePasswordBox.Visibility = Visibility.Collapsed;
                PasswordBox.Visibility = Visibility.Visible;
                PasswordVisibilityIcon.Kind = PackIconKind.Eye;
            }
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