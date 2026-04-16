using System;
using System.Collections.Generic;

namespace WpfApp3.Models;

public partial class Tour
{
    public int Id { get; set; }

    public string? NameTour { get; set; }

    public int? CountryId { get; set; }

    public int? Duration { get; set; }

    public DateOnly? StartDate { get; set; }

    public int? Cost { get; set; }

    public int? TipsBusId { get; set; }

    public int? CapacityTour { get; set; }

    public int? FreeSeats { get; set; }

    public string? Image { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual TipsBu? TipsBus { get; set; }
}
