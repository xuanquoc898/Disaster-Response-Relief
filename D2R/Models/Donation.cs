using System;
using System.Collections.Generic;

namespace D2R.Models;

public partial class Donation
{
    public int DonationId { get; set; }

    public int DonorId { get; set; }

    public int AreaId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Area Area { get; set; } = null!;

    public virtual ICollection<DonationItem> DonationItems { get; set; } = new List<DonationItem>();

    public virtual Donor Donor { get; set; } = null!;
}
