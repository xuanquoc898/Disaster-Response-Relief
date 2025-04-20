namespace D2R.Models;

public partial class DisasterLevel
{
    public int LevelId { get; set; }

    public int DisasterTypeId { get; set; }

    public string Level { get; set; } = null!;

    public virtual ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();

    public virtual DisasterType DisasterType { get; set; } = null!;
}
