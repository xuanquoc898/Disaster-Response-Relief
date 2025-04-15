using D2R.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace D2R;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        new DonorView().ShowDialog();
        InitializeComponent();
        
    }

    private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void SignInButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void ForgotPassword_Click(object sender, RoutedEventArgs e)
    {

    }
    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        //string password = Password.Password; // Truy cập mật khẩu đã nhập
        // Ví dụ: Thực hiện một số thao tác với mật khẩu
        //Console.WriteLine(password); // Để hiển thị mật khẩu ra màn hình console
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {

    }
}