using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using D2R.ViewModels;

namespace D2R.Views
{
    public partial class QuanLyTaiKhoanNguoiDung : Page
    {
        public QuanLyTaiKhoanNguoiDung()
        {
            InitializeComponent();
            DataContext = new QuanLyTaiKhoanNguoiDung();
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