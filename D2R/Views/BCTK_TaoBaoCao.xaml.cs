using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace D2R.Views
{
    public partial class CreateReportPage : UserControl
    {
        public CreateReportPage()
        {
            InitializeComponent();
            LoadDefaultReportSettings();
        }

        private void LoadDefaultReportSettings()
        {
            // TODO: Tải các thiết lập mặc định hoặc từ lần tạo trước
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Thêm code xử lý tạo báo cáo mới
            // Validate dữ liệu đầu vào
           

            // Lưu báo cáo và hiển thị kết quả
            

            
        }

        private void PreviewReport()
        {
            // TODO: Thêm code xử lý xem trước báo cáo
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