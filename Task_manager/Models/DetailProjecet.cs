using System;
using System.Collections.Generic;

namespace Task_manager.Models;

public partial class DetailProjecet
{
    public int IdUser { get; set; }

    public int IdProject { get; set; }

    public virtual Project IdProjectNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
