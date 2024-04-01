using System;
using System.Collections.Generic;

namespace Task_manager.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public byte[] Hide { get; set; } = null!;

    public virtual ICollection<DetailProjecet> DetailProjecets { get; set; } = new List<DetailProjecet>();
}
