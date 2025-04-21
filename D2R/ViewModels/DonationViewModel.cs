using D2R.Models;
using D2R.Services;
using D2R.Views.UserControls;

namespace D2R.ViewModels
{
    public class DonationViewModel
    {
        private readonly DonorService _donorService;
        private readonly ItemCategoryService _categoryService;
        private readonly WarehouseItemService _itemService;
        private readonly DonationTransactionService _transactionService;
        private readonly int _warehouseId;

        public Donor? SelectedDonor { get; private set; }

        public DonationViewModel(int warehouseId)
        {
            _warehouseId = warehouseId;
            _donorService = new DonorService();
            _categoryService = new ItemCategoryService();
            _itemService = new WarehouseItemService();
            _transactionService = new DonationTransactionService();
        }

        public List<Donor> GetDonors() => _donorService.GetAll();
        public void SetSelectedDonor(Donor donor) => SelectedDonor = donor;

        public bool ConfirmDonation(List<DonationCategoryGroupControl> groups)
        {
            if (SelectedDonor == null) return false;
            return _transactionService.ExecuteDonation(SelectedDonor, _warehouseId, groups);
        }

        public List<ItemCategory> GetCategories() => _categoryService.GetAll();

        public List<WarehouseItem> GetItemsByCategory(int categoryId)
        {
            return _itemService.GetAll().Where(i => i.CategoryId == categoryId).ToList();
        }

        public List<Donor> SearchDonors(string keyword)
        {
            return _donorService.GetAll()
                .Where(d => d.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }

    public class DonationItemEntry
    {
        public WarehouseItem Item { get; set; } = null!;
        public int Quantity { get; set; }
    }
}


