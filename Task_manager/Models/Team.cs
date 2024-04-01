using System;
using System.Collections.Generic;

namespace Task_manager.Models;

public partial class Team
{
    public int IdTeam { get; set; }

    public int IdUser { get; set; }

    public int IdProject { get; set; }

    public virtual DetailProjecet DetailProjecet { get; set; } = null!;
}
