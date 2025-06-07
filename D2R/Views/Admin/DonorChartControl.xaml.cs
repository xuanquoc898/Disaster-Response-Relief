using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using D2R.ViewModels;
namespace D2R.Views.Admin
{
    public partial class DonorChartControl : UserControl
    {
        private readonly DonorChartViewModel _viewModel;

        public DonorChartControl()
        {
            InitializeComponent();
            _viewModel = new DonorChartViewModel();

            InitFilters();
            LoadChartData();
        }

        private void InitFilters()
        {
            int currentYear = DateTime.Now.Year;
            var years = Enumerable.Range(2024, currentYear - 2024 + 1 + 2).ToList();
            YearComboBox.ItemsSource = years;
            YearComboBox.SelectedItem = currentYear;

            CriteriaComboBox.ItemsSource = new List<string> { "Số lần đóng góp", "Tổng tiền mặt" };
            CriteriaComboBox.SelectedItem = "Số lần đóng góp";
        }

     
        private void LoadChartData()
        {
            if (YearComboBox.SelectedItem is int year && CriteriaComboBox.SelectedItem is string criteria)
            {
                var donors = _viewModel.GetTopDonors(year, criteria);
                var top5 = donors.Take(5).ToList();

                var values = new ChartValues<double>(
                    top5.Select(d => criteria == "Số lần đóng góp"
                        ? (double)d.TotalDonations
                        : (double)d.TotalQuantity)
                );

                var labels = top5.Select(d => d.FullName ?? "").ToArray();

                DonorChart.Series = new SeriesCollection
        {
            new ColumnSeries
            {
                Title = criteria,
                Values = values,
                Stroke = System.Windows.Media.Brushes.SteelBlue
            }
        };

                DonorChart.AxisX[0].Labels = labels;

                // Hiển thị danh sách Top 10
                DonorListView.ItemsSource = donors.Take(10);

                if (criteria == "Tổng tiền mặt")
                {
                    DynamicValueColumn.Header = "Tổng tiền (VNĐ)";
                    DynamicValueColumn.Binding = new System.Windows.Data.Binding("TotalQuantity")
                    {
                        StringFormat = "N0"
                    };
                }
                else
                {
                    DynamicValueColumn.Header = "Số lần quyên góp";
                    DynamicValueColumn.Binding = new System.Windows.Data.Binding("TotalDonations");
                }
            }
        }


        private void OnFilterChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadChartData();
        }
    }
}
