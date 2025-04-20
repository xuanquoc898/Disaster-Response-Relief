using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views
{
    public partial class ThongKeBaoCao : Page
    {
        // Define the Report model class
        public class Report
        {
            public string ReportCode { get; set; }
            public string Title { get; set; }
            public DateTime CreatedDate { get; set; }
            public string Type { get; set; }
        }

        // ObservableCollection for DataGrid binding
        public ObservableCollection<Report> Reports { get; set; }

        public ThongKeBaoCao()
        {
            InitializeComponent();

            // Initialize the Reports collection
            Reports = new ObservableCollection<Report>();

            // Sample data for testing
            LoadSampleData();

            // Set the DataContext
            DataContext = this;
        }

        private void LoadSampleData()
        {
            // Add sample reports
            Reports.Add(new Report
            {
                ReportCode = "BC001",
                Title = "Báo cáo doanh thu tháng 10",
                CreatedDate = new DateTime(2025, 10, 15),
                Type = "Doanh thu"
            });
            Reports.Add(new Report
            {
                ReportCode = "BC002",
                Title = "Báo cáo kho hàng",
                CreatedDate = new DateTime(2025, 10, 20),
                Type = "Tồn kho"
            });
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle back button click
            if (NavigationService?.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle next button click
            // Add navigation logic here when needed
            MessageBox.Show("Chuyển đến trang tiếp theo");
        }
    }
}