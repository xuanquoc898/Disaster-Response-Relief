using D2R.Models;
using D2R.Repositories;
using D2R.Views.Users;

namespace D2R.Services
{
    public class DonationTransactionService
    {
        private readonly WarehouseItemRepository _warehouseitemRepository = new();
        private readonly ItemCategoryRepository _itemcategoryRepository = new();
        private readonly DonationRepository _donationRepository = new();
        private readonly DonationItemRepository _donationitemRepository = new();
        private readonly WarehouseStockRepository _warehousestockRepository = new();

        public List<ItemCategory> GetCategories()
        {
            return _itemcategoryRepository.GetAll();
        }
        public List<WarehouseItem> GetByCategoryId(int categoryId)
        {
            return _warehouseitemRepository.GetById(categoryId);
        }
        
        // xu li donation 
        public bool ExecuteDonation(Donor donor, int warehouseId, List<DonationCategoryGroupControl> groups)
        {
            // .Any return true nếu có ít nhất 1 bản ghi data
            if (donor == null || groups == null || !groups.Any())
                return false;

            var allEntries = groups
                .SelectMany(group => group.GetDonationItems())
                .Where(entry => entry.Item != null && entry.Quantity > 0)
                .ToList();

            if (!allEntries.Any())
                return false;

            var donation = new Donation
            {
                DonorId = donor.DonorId,
                AreaId = 1, // bug
                Date = DateTime.Now
            };

            _donationRepository.Add(donation);

            foreach (var entry in allEntries)
            {
                var item = new DonationItem
                {
                    DonationId = donation.DonationId,
                    ItemId = entry.Item.ItemId,
                    Quantity = entry.Quantity,
                    Unit = entry.Item.Unit
                };

                _donationitemRepository.Add(item);
                AddOrUpdateStock(warehouseId, entry.Item.ItemId, entry.Quantity);
            }

            return true;
        }
        
        // quyêt  dinh add hay update ton kho LOCAL 
        public void AddOrUpdateStock(int? warehouseId, int itemId, int quantity)
        {
            var existing = _warehousestockRepository.GetByWarehouseIdItemId(warehouseId, itemId);

            if (existing != null)
            {
                existing.Quantity = (existing.Quantity ?? 0) + quantity;
                existing.LastUpdated = DateTime.Now;
                _warehousestockRepository.Update(existing);
            }
            else
            {
                var newStock = new WarehouseStock
                {
                    WarehouseId = warehouseId,
                    ItemId = itemId,
                    Quantity = quantity,
                    LastUpdated = DateTime.Now
                };
                _warehousestockRepository.Add(newStock);
            }
        }
    }
}
