using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using D2R.ViewModels;

namespace D2R.Views
{
    public partial class DistributionManagementView : Page
    {
        public DistributionManagementView()
        {
            InitializeComponent();
            DataContext = new DistributionManagementView();
        }

        private void CreateDistribution_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Thêm logic để tạo đợt phân phối mới
            MessageBox.Show("Tạo đợt phân phối mới!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Thêm logic để xem chi tiết bản ghi phân phối
            MessageBox.Show("Xem chi tiết bản ghi phân phối!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdateStatus_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Thêm logic để cập nhật trạng thái phân phối
            MessageBox.Show("Cập nhật trạng thái phân phối!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExportForDistribution_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Thêm logic để xuất kho cho phân phối
            MessageBox.Show("Xuất kho cho phân phối!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddRecipient_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Thêm logic để thêm hộ nhận
            MessageBox.Show("Thêm hộ nhận!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void PrintDistributionForm_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Thêm logic để in phiếu phân phối
            MessageBox.Show("In phiếu phân phối!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Thêm logic để tạo báo cáo phân phối
            MessageBox.Show("Tạo báo cáo phân phối!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Thêm logic điều hướng hoặc xử lý tiếp theo
            MessageBox.Show("Chức năng Tiếp theo đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}