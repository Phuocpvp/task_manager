using System;
using System.Collections.Generic;

namespace Task_manager.Models;

public partial class Task
{
    public int IdTask { get; set; }

    public int IdProject { get; set; }

    public string? NameTask { get; set; }

    public string? Descreption { get; set; }

    public string? Status { get; set; }

    public DateTime? DayCreate { get; set; }

    public DateTime? DayReceive { get; set; }

    public byte[] Hide { get; set; } = null!;

    public virtual Project IdProjectNavigation { get; set; } = null!;
}
