using System.Windows;
using System.Windows.Controls;

namespace D2R.Views
{
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng xuất báo cáo sẽ được thực hiện ở đây");
        }
    }
}