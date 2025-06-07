namespace D2R.Models;

public partial class DisasterType
{
    public int DisasterTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DisasterLevel> DisasterLevels { get; set; } = new List<DisasterLevel>();
}
