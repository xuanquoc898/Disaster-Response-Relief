using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace D2R.Views
{
    public partial class ViewReportPage : Page
    {
        public ViewReportPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Quay lại trang trước
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void LoadReportData()
        {
            // TODO: Thêm code tải dữ liệu báo cáo từ cơ sở dữ liệu hoặc service
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Thêm code xử lý xuất báo cáo
            MessageBox.Show("Chức năng xuất báo cáo sẽ được thực hiện ở đây");
        }
    }
}