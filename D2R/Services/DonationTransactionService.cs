using D2R.Models;
using D2R.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2R.Services
{
    public class DonationTransactionService
    {
        private readonly DonationService _donationService;
        private readonly DonationItemService _donationItemService;
        private readonly WarehouseStockService _stockService;
        private readonly WarehouseItemService _warehouseItemService;


        public DonationTransactionService()
        {
            _donationService = new DonationService();
            _donationItemService = new DonationItemService();
            _stockService = new WarehouseStockService();
        }

        public bool ExecuteDonation(Donor donor, int warehouseId, List<DonationCategoryGroupControl> groups)
        {
            if (donor == null || groups == null || !groups.Any())
                return false;

            var donation = new Donation
            {
                DonorId = donor.DonorId,
                AreaId = 1
            };

            _donationService.Add(donation);

            foreach (var group in groups)
            {
                foreach (var entry in group.GetDonationItems())
                {
                    var item = new DonationItem
                    {
                        DonationId = donation.DonationId,
                        ItemId = entry.Item.ItemId,
                        Quantity = entry.Quantity,
                        Unit = entry.Item.Unit
                    };

                    _donationItemService.Add(item);
                    _stockService.AddOrUpdateStock(warehouseId, entry.Item.ItemId, entry.Quantity);
                }
            }


            return true;
        }
    }
}
