using System;
using System.Collections.Generic;

namespace WpfApp3.Models;

public partial class TipsBu
{
    public int Id { get; set; }

    public string? NameBus { get; set; }

    public string? Description { get; set; }

    public int? CapacityBus { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
