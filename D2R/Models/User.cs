﻿using System.ComponentModel.DataAnnotations;

namespace D2R.Models;

public partial class User
{
    public int UserId { get; set; }

    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public int RoleId { get; set; }

    public int? AreaId { get; set; }

    public int? WarehouseId { get; set; }

    public virtual Area? Area { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Warehouse? Warehouse { get; set; }
}
