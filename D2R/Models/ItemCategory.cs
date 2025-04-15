using System;
using System.Collections.Generic;

namespace D2R.Models;

public partial class ItemCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<WarehouseItem> WarehouseItems { get; set; } = new List<WarehouseItem>();
}
