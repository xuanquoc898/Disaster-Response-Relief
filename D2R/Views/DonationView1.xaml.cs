using System.Windows;
using System.Windows.Controls;

namespace D2R.Views
{
    public partial class DonationView1 : UserControl
    {
        public DonationView1()
        {
            InitializeComponent();
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