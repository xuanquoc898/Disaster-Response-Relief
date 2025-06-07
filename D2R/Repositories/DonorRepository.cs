using D2R.Models;
using D2R.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class DonorRepository
    {
        private readonly DisasterReliefContext _context;

        public DonorRepository()
        {
            _context = new DisasterReliefContext();
        }
        public List<Donor> GetAll()
        {
            return _context.Donors.ToList();
        }
        public List<Donor> GetAllByKey(string keyword)
        {
            return _context.Donors.ToList().Where(d => d.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public void Add(Donor entity)
        {
            var tracked = _context.ChangeTracker.Entries<Donor>()
                .FirstOrDefault(e => e.Entity.DonorId == entity.DonorId);

            if (tracked != null)
            {
                _context.Entry(tracked.Entity).State = EntityState.Detached;
            }
            _context.Donors.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Lấy danh sách năm có dữ liệu Donation để bind combobox
        /// </summary>
        public List<int> GetAvailableYears()
        {
            return _context.Donations
                .Where(d => d.Date.HasValue)
                .Select(d => d.Date.Value.Year)
                .Distinct()
                .OrderByDescending(y => y)
                .ToList();
        }


        /// <summary>
        /// Lấy danh sách mạnh thường quân theo năm và tiêu chí
        /// trả về các trường cần thiết cho biểu đồ
        /// </summary>
        public List<DonorRankingModel> GetTopDonorsByYearAndCriteria(int year, string criteria)
        {
            var query = from donor in _context.Donors
                        join donation in _context.Donations on donor.DonorId equals donation.DonorId
                        where donation.Date.HasValue && donation.Date.Value.Year == year
                        join item in _context.DonationItems on donation.DonationId equals item.DonationId
                        join warehouseItem in _context.WarehouseItems on item.ItemId equals warehouseItem.ItemId
                        join category in _context.ItemCategories on warehouseItem.CategoryId equals category.CategoryId
                        select new
                        {
                            donor.FullName,
                            donor.Cccd,
                            donation.DonationId,
                            donation.Date,
                            item.Quantity,
                            ItemName = warehouseItem.Name,
                            CategoryName = category.CategoryName
                        };

            IEnumerable<DonorRankingModel> grouped;

            if (criteria == "Tổng tiền mặt")
            {
                grouped = query
                    .Where(x => x.ItemName == "Tiền mặt" && x.CategoryName == "Khác")
                    .GroupBy(x => new { x.FullName, x.Cccd })
                    .Select(g => new DonorRankingModel
                    {
                        FullName = g.Key.FullName,
                        CCCD = g.Key.Cccd,
                        TotalDonations = g.Select(x => x.DonationId).Distinct().Count(),
                        TotalQuantity = g.Sum(x => x.Quantity ?? 0)
                    })
                    .OrderByDescending(d => d.TotalQuantity);
            }
            else
            {
                var generalQuery = query.GroupBy(x => new { x.FullName, x.Cccd })
                    .Select(g => new DonorRankingModel
                    {
                        FullName = g.Key.FullName,
                        CCCD = g.Key.Cccd,
                        TotalDonations = g.Select(x => x.DonationId).Distinct().Count(),
                        TotalQuantity = g.Sum(x => x.Quantity ?? 0)
                    });

                grouped = criteria == "Số lần đóng góp"
                    ? generalQuery.OrderByDescending(d => d.TotalDonations)
                    : generalQuery.OrderByDescending(d => d.TotalQuantity);
            }


            return grouped.ToList();
        }






    }
}
