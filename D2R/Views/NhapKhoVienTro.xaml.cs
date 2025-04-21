using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using D2R.ViewModels;

namespace D2R.Views
{
    public partial class NhapKhoVienTro : UserControl
    {
        public NhapKhoVienTro()
        {
            InitializeComponent();
            // Gán ViewModel làm DataContext
            DataContext = new NhapKhoVienTro();
        }

        // Sự kiện điều hướng về trang trước
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
        }

        // Sự kiện nút "Tiếp theo" (placeholder)
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Thêm logic điều hướng hoặc xử lý tiếp theo
            MessageBox.Show("Chức năng Tiếp theo đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}