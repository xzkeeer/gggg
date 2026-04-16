using System;
using System.Collections.Generic;

namespace WpfApp3.Models;

public partial class StatusRequest
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
