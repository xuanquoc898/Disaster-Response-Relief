using D2R.Services;
using System.Collections.Generic;

namespace D2R.ViewModels
{
    public class DonorChartViewModel
    {
        private readonly DonorService _donorService;

        public DonorChartViewModel()
        {
            _donorService = new DonorService();
        }

        public List<int> GetAvailableYears()
        {
            return _donorService.GetAvailableYears();
        }

        public List<DonorRankingModel> GetTopDonors(int year, string criteria)
        {
            return _donorService.GetTopDonors(year, criteria);
        }
    }

    public class DonorRankingModel
    {
        public string FullName { get; set; }
        public string CCCD { get; set; }
        public int TotalDonations { get; set; }
        public int TotalQuantity { get; set; }
    }
}
