using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace D2R.Views
{
    public partial class QuanLyManhThuongQuanOptions : UserControl
    {
        public QuanLyManhThuongQuanOptions()
        {
            InitializeComponent();
        }

        private void ViewList_Click(object sender, RoutedEventArgs e)
        {
            // NavigationService?.Navigate(new Uri("/Views/QuanLyManhThuongQuan.xaml", UriKind.Relative));
        }

        private void AddDonor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Thêm nhà tài trợ đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EditDonor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Chỉnh sửa nhà tài trợ đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteDonor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Xóa nhà tài trợ đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Tiếp theo đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}