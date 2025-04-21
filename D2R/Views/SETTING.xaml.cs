using System;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views
{
    /// <summary>
    /// Interaction logic for SimpleSettingsPage.xaml
    /// </summary>
    public partial class SimpleSettingsPage : UserControl
    {
        public SimpleSettingsPage()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Quay lại trang trước đó hoặc đóng
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý lưu cài đặt sẽ được thêm sau
            MessageBox.Show("Đã lưu cài đặt!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            // Quay lại trang trước đó
            
        }
    }
}