using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace D2R.Views
{
    public partial class YeuCauCuuTroOptions : UserControl
    {
        public YeuCauCuuTroOptions()
        {
            InitializeComponent();
        }

        private void ViewList_Click(object sender, RoutedEventArgs e)
        {
            // NavigationService?.Navigate(new Uri("/Views/YeuCauCuuTro.xaml", UriKind.Relative));
        }

        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Thêm yêu cầu đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EditRequest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Chỉnh sửa yêu cầu đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Xóa yêu cầu đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
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