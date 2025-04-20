using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace D2R.Views
{
    /// <summary>
    /// Interaction logic for QuanLyTaiKhoanNguoiDungOptions.xaml
    /// </summary>
    public partial class QuanLyTaiKhoanNguoiDungOptions : Page
    {
        public QuanLyTaiKhoanNguoiDungOptions()
        {
            InitializeComponent();
        }

        private void ViewList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("/Views/QuanLyTaiKhoanNguoiDung.xaml", UriKind.Relative));
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Thêm tài khoản đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Chỉnh sửa tài khoản đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Xóa tài khoản đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Tiếp theo đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}