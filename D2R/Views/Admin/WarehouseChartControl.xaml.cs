using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using D2R.ViewModels;

namespace D2R.Views.Admin
{
    public partial class WarehouseChartControl : UserControl
    {
        private readonly WarehouseChartViewModel _viewModel;
        private WarehouseChartStats _stats;

        public WarehouseChartControl()
        {
            InitializeComponent();
            _viewModel = new WarehouseChartViewModel();

            InitializeMonthYearSelectors();
            LoadAndRenderChart(DateTime.Now.Year, DateTime.Now.Month);
        }

        private void InitializeMonthYearSelectors()
        {
            YearComboBox.ItemsSource = Enumerable.Range(DateTime.Now.Year - 2, 5).ToList();
            MonthComboBox.ItemsSource = Enumerable.Range(1, 12).ToList();
            YearComboBox.SelectedItem = DateTime.Now.Year;
            MonthComboBox.SelectedItem = DateTime.Now.Month;
        }

        private void LoadAndRenderChart(int year, int month)
        {
            _stats = _viewModel.GetChartStats(year, month);
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var series = new SeriesCollection();

            if (InboundCheckBox.IsChecked == true)
            {
                series.Add(new LineSeries
                {
                    Title = "Nhập",
                    Values = new ChartValues<int>(_stats.Inbound),
                    Stroke = Brushes.SteelBlue,
                    PointGeometry = DefaultGeometries.Circle,
                    LineSmoothness = 0.5
                });
            }

            if (OutboundCheckBox.IsChecked == true)
            {
                series.Add(new LineSeries
                {
                    Title = "Xuất",
                    Values = new ChartValues<int>(_stats.Outbound),
                    Stroke = Brushes.OrangeRed,
                    PointGeometry = DefaultGeometries.Circle,
                    LineSmoothness = 0.5
                });
            }

            if (StockCheckBox.IsChecked == true)
            {
                series.Add(new LineSeries
                {
                    Title = "Tồn kho",
                    Values = new ChartValues<int>(_stats.TotalStock),
                    Stroke = Brushes.Green,
                    PointGeometry = DefaultGeometries.Circle,
                    LineSmoothness = 0.5
                });
            }
            WarehouseChart.DisableAnimations = false;
            WarehouseChart.Series = series;
            WarehouseChart.AxisX[0].Labels = _stats.Labels;
        }


        private void OnFilterChanged(object sender, RoutedEventArgs e)
        {
            if (YearComboBox.SelectedItem is int year &&
                MonthComboBox.SelectedItem is int month)
            {
                LoadAndRenderChart(year, month);
            }
        }
    }
}
