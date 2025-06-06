using D2R.Models;
using D2R.Services;
using D2R.Views.Users;

namespace D2R.ViewModels
{
    public class DonationViewModel
    {
        private readonly DonorService _donorService;
        private readonly DonationTransactionService _transactionService;
        private readonly int _warehouseId;


        public Donor? SelectedDonor { get; private set; }

        public DonationViewModel(int warehouseId)
        {
            _warehouseId = warehouseId;
            _donorService = new DonorService();
            _transactionService = new DonationTransactionService();
        }

        public void SetSelectedDonor(Donor donor) => SelectedDonor = donor;

        public bool ConfirmDonation(List<DonationCategoryGroupControl> groups)
        {
            if (SelectedDonor == null || groups == null || !groups.Any())
                return false;

            if (!HasValidDonation(groups))
                return false;

            return _transactionService.ExecuteDonation(SelectedDonor, _warehouseId, groups);
        }


        public List<ItemCategory> GetCategories()
        {
            return _transactionService.GetCategories();
        }

        public List<WarehouseItem> GetItemsByCategory(int categoryId)
        {
            return _transactionService.GetByCategoryId(categoryId);
        }

        public List<Donor> SearchDonors(string keyword)
        {
            return _donorService.GetAllByKey(keyword);
        }

        public bool HasValidDonation(List<DonationCategoryGroupControl> groups)
        {
            foreach (var group in groups)
            {
                foreach (var entry in group.GetDonationItems())
                {
                    if (entry == null || entry.Item == null || entry.Quantity <= 0)
                        return false;
                }
            }
            return true;
        }

    }

    public class DonationItemEntry
    {
        public WarehouseItem Item { get; set; } = null!;
        public int Quantity { get; set; }
    }
}


