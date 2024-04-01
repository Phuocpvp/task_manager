using System;
using System.Collections.Generic;

namespace Task_manager.Models;

public partial class Project
{
    public int IdProject { get; set; }

    public int? IdLeader { get; set; }

    public string? Status { get; set; }

    public DateTime? DayCreate { get; set; }

    public byte[]? Assignee { get; set; }

    public string? Image { get; set; }

    public byte[] Hide { get; set; } = null!;

    public virtual ICollection<DetailProjecet> DetailProjecets { get; set; } = new List<DetailProjecet>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
