using System;
using System.Collections.Generic;

namespace D2R.Models;

public partial class DisasterType
{
    public int DisasterTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<DisasterLevel> DisasterLevels { get; set; } = new List<DisasterLevel>();
}
