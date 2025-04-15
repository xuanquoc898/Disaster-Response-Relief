using System;
using System.Collections.Generic;

namespace D2R.Models;

public partial class Donor
{
    public int DonorId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Cccd { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
}
