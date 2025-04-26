using System.Windows;
using System.Windows.Controls;

namespace D2R.Views
{
    public partial class CreateReportView : UserControl
    {
        public CreateReportView()
        {
            InitializeComponent();
            LoadDefaultReportSettings();
        }

        private void LoadDefaultReportSettings()
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PreviewReport()
        {

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