using System;
using System.Collections.Generic;

namespace WpfApp3.Models;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
