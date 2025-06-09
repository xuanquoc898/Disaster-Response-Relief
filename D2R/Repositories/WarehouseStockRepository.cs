using D2R.Models;
using D2R.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class WarehouseStockRepository
    {
        private readonly DisasterReliefContext _context;

        public WarehouseStockRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<WarehouseStock> GetAll()
        {
            return _context.WarehouseStocks.ToList();
        }

        public WarehouseStock? GetByWarehouseIdItemId(int? warehouseId, int? itemId)
        {
            return GetAll()
                .FirstOrDefault(s => (!warehouseId.HasValue || s.WarehouseId == warehouseId) &&
                                     (!itemId.HasValue || s.ItemId == itemId));
        }

        public WarehouseStock? GetCentralStockByItemId(int itemId)
        {
            return _context.WarehouseStocks.FirstOrDefault(ws => ws.ItemId == itemId && ws.WarehouseId == 1);
        }

        public List<WarehouseStock> GetStockById(int warehouseId)
        {
            return _context.WarehouseStocks.Where(s => s.WarehouseId == warehouseId).ToList();

        }

        public void Add(WarehouseStock entity)
        {
            _context.WarehouseStocks.Add(entity);
            _context.SaveChanges();
        }

        public void Update(WarehouseStock entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.WarehouseStocks.Find(id);
            if (entity != null)
            {
                _context.WarehouseStocks.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<WarehouseStock> GetStocksByWarehouse(int? warehouseId)
        {
            return _context.WarehouseStocks.Where(s => s.WarehouseId == warehouseId).ToList();
        }
        public List<WarehouseItem> GetWarehouseItems()
        {
            return _context.WarehouseItems.ToList();
        }
        public List<ItemCategory> GetItemCategories()
        {
            return _context.ItemCategories.ToList();
        }


        public WarehouseChartStats GetDailyStockStats(int year, int month)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            var inbound = new int[daysInMonth];
            var outbound = new int[daysInMonth];
            var total = new int[daysInMonth];
            //Xác định ngày đầu và cuối tháng trước
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DateTime lastDayPrevMonth = firstDayOfMonth.AddDays(-1);

            // Lấy tồn kho cuối ngày cuối tháng trc
            int startingStock = GetStockAtDate(lastDayPrevMonth);

            // Lấy data nhập trong tháng
            var syncs = _context.SyncLogs
                                .Where(x => x.SyncDate.HasValue && x.SyncDate.Value.Year == year && x.SyncDate.Value.Month == month)
                                .Include(x => x.SyncLogItems)
                                    .ThenInclude(i => i.Item)
                                        .ThenInclude(it => it.Category)
                                .ToList();

            foreach (var log in syncs)
            {
                int day = log.SyncDate.Value.Day - 1;

                inbound[day] += log.SyncLogItems
                    .Where(i =>
                        i.Item != null &&
                        i.Item.Name != "Tiền mặt" &&
                        (i.Item.Category == null || i.Item.Category.CategoryName != "Khác"))
                    .Sum(i => i.Quantity ?? 0);
            }
            //Tăng inbound[ngày] lên bằng tổng số lượng hợp lệ nhập vào ngày đó.



            // Lấy data xuất trong tháng
            var dists = _context.DistributionLogs
                .Where(x => x.DistributionDate.HasValue && x.DistributionDate.Value.Year == year && x.DistributionDate.Value.Month == month)
                .Include(x => x.Item)
                    .ThenInclude(it => it.Category)
                .ToList();

            foreach (var log in dists)
            {
                if (log.Item == null ||
                    log.Item.Name == "Tiền mặt" ||
                    (log.Item.Category != null && log.Item.Category.CategoryName == "Khác"))
                    continue;

                int day = log.DistributionDate.Value.Day - 1;
                outbound[day] += log.Quantity ?? 0;
            }


            // Tính tồn kho tích lũy ngày cuối thangs trc
            int runningTotal = startingStock;
            for (int i = 0; i < daysInMonth; i++)
            {
                runningTotal += inbound[i] - outbound[i];
                //Mỗi ngày: tồn kho = tồn hôm trước +nhập - xuất
                total[i] = runningTotal;
            }

            return new WarehouseChartStats
            {
                Inbound = inbound.ToList(),
                Outbound = outbound.ToList(),
                TotalStock = total.ToList(),
                Labels = Enumerable.Range(1, daysInMonth).Select(d => d.ToString()).ToList()
            };
        }



//Duyệt tất cả bản ghi nhập kho đến ngày date
//Lọc ra các mặt hàng không phải tiền mặt và không nằm trong danh mục "Khác"
//Tính tổng số lượng
        public int GetStockAtDate(DateTime date)
        {
            int totalInbound = _context.SyncLogs
                .Where(x => x.SyncDate.HasValue && x.SyncDate.Value.Date <= date.Date)
                .SelectMany(x => x.SyncLogItems)
                .Where(i =>
                    i.Item != null &&
                    i.Item.Name != "Tiền mặt" &&
                    (i.Item.Category == null || i.Item.Category.CategoryName != "Khác"))
                .Sum(i => (int?)i.Quantity) ?? 0;

            int totalOutbound = _context.DistributionLogs
                .Where(x => x.DistributionDate.HasValue && x.DistributionDate.Value.Date <= date.Date)
                .Where(x =>
                    x.Item != null &&
                    x.Item.Name != "Tiền mặt" &&
                    (x.Item.Category == null || x.Item.Category.CategoryName != "Khác"))
                .Sum(x => (int?)x.Quantity) ?? 0;

            return totalInbound - totalOutbound;
            //trả kết quả tồn kho 
        }
    }
}
