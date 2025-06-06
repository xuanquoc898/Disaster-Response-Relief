using D2R.Services;

namespace D2R.ViewModels
{
    public class WarehouseChartViewModel
    {
        private readonly WarehouseStockService _service = new();

        public WarehouseChartStats GetChartStats(int year, int month)
        {
            return _service.GetDailyStockStats(year, month);
        }
    }

    public class WarehouseChartStats
    {
        public List<int> Inbound { get; set; } = new();
        public List<int> Outbound { get; set; } = new();
        public List<int> TotalStock { get; set; } = new();
        public List<string> Labels { get; set; } = new();
    }
}
