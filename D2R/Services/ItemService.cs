using D2R.Models;
using D2R.Repositories;
using System.Collections.Generic;

namespace D2R.Services;

public class ItemService
{
    private ItemRepository _repo = new();

    public void AddItem(Item item)
    {
        if (item.Quantity <= 0)
            throw new ArgumentException("Số lượng phải lớn hơn 0.");

        if (string.IsNullOrWhiteSpace(item.ItemName))
            throw new ArgumentException("Tên mặt hàng không được để trống.");

        _repo.Add(item);
    }

    public List<Item> GetItemsForDonor(int donorId)
    {
        return _repo.GetItemsByDonor(donorId);
    }
}
