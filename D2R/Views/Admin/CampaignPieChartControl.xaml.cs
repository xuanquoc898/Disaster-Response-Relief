using D2R.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

namespace D2R.Views.Admin
{
    public partial class CampaignPieChartControl : UserControl
    {
        private readonly CampaignPieChartViewModel _viewModel;

        public CampaignPieChartControl()
        {
            InitializeComponent();
            _viewModel = new CampaignPieChartViewModel();

            InitializeMonthYearSelectors();
            LoadPieChart(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void InitializeMonthYearSelectors()
        {
            MonthComboBox.ItemsSource = Enumerable.Range(1, 12);
            MonthComboBox.SelectedItem = DateTime.Now.Month;

            int currentYear = DateTime.Now.Year;
            YearComboBox.ItemsSource = Enumerable.Range(currentYear - 5, 6).ToList();
            YearComboBox.SelectedItem = currentYear;
        }


        //Gọi GetCampaignStatusCount(...) để lấy Dictionary<string, int>
        //Mỗi cặp(status, count) tạo một PieSeries
        //DataLabels = true để hiển thị nhãn
        //chartPoint.Participation để tính tỷ lệ phần trăm(%)
        private void LoadPieChart(int month, int year)
        {
            // Lấy dữ liệu PieChart
            var pieSeries = _viewModel.GetPieSeries(month, year);
            PieChartControl.Series = pieSeries;

            // Lấy dữ liệu thống kê trạng thái
            var statusCounts = _viewModel.GetCampaignStatusCount(month, year);

            // Tổng số
            int total = statusCounts.Values.Sum();
            TotalCountTextBlock.Text = $"Tổng số chiến dịch trong tháng: {total}";

            // Gán legend màu + nhãn + số lượng
            var colorPalette = new SolidColorBrush[]
            {
                Brushes.SteelBlue, Brushes.Orange, Brushes.MediumSeaGreen,
                Brushes.IndianRed, Brushes.MediumPurple, Brushes.Gray
            };

            var legendData = statusCounts.Select((entry, index) => new LegendItem
            {
                Label = $"{entry.Key}: {entry.Value}",
                Color = colorPalette[index % colorPalette.Length]
            }).ToList();

            LegendItemsControl.ItemsSource = legendData;

            // Áp dụng màu vào PieSeries tương ứng
            for (int i = 0; i < pieSeries.Count; i++)
            {
                if (pieSeries[i] is PieSeries pie)
                {
                    pie.Fill = legendData[i % legendData.Count].Color;
                }
            }

        }

        private void MonthOrYearChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MonthComboBox.SelectedItem is int month &&
                YearComboBox.SelectedItem is int year)
            {
                LoadPieChart(month, year);
            }
        }
    }
//tạo một danh sách LegendItem để hiển thị danh sách trạng thái bên cạnh biểu đồ, giúp người dùng dễ hiểu và dễ phân biệt màu sắc.
    public class LegendItem
    {
        public string Label { get; set; }
        public SolidColorBrush Color { get; set; }
    }
}
