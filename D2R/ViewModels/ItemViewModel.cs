using D2R.Models;
using D2R.Services;
using System;
using System.Collections.Generic;

namespace D2R.ViewModels;

public class ItemViewModel
{
    private ItemService _service = new();

    public void AddItem(int donorId, string itemName, int quantity)
    {
        var item = new Item
        {
            DonorId = donorId,
            ItemName = itemName,
            Quantity = quantity,
            DateReceived = DateTime.Now
        };

        _service.AddItem(item);
    }

    public List<Item> GetItemsByDonor(int donorId)
    {
        return _service.GetItemsForDonor(donorId);
    }
}
