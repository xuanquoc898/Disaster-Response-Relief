﻿using D2R.Services;
using LiveCharts;
using LiveCharts.Wpf;

namespace D2R.ViewModels
{
    public class CampaignPieChartViewModel
    {
        private readonly CampaignService _service;

        public CampaignPieChartViewModel()
        {
            _service = new CampaignService();
        }
        
        /// Trả về dữ liệu biểu đồ Pie theo tháng/năm
        public SeriesCollection GetPieSeries(int month, int year)
        {
            var data = _service.GetCampaignStatusCount(month, year);
            var series = new SeriesCollection();

            foreach (var item in data)
            {
                series.Add(new PieSeries
                {
                    Title = item.Key,
                    Values = new ChartValues<int> { item.Value },
                    DataLabels = true,
                    LabelPoint = chartPoint => $"{item.Key}: {chartPoint.Participation:P1}"
                });
            }

            return series;
        }
        
        /// Trả về Dictionary trạng thái và số lượng
        public Dictionary<string, int> GetCampaignStatusCount(int month, int year)
        {
            return _service.GetCampaignStatusCount(month, year);
        }

    }
}
