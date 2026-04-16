using System;
using System.Collections.Generic;

namespace WpfApp3.Models;

public partial class Request
{
    public int Id { get; set; }

    public int? ToursId { get; set; }

    public int? UsersId { get; set; }

    public DateOnly? DateStart { get; set; }

    public int? StatusrRequestId { get; set; }

    public int? NumbersOfPeople { get; set; }

    public int? Cost { get; set; }

    public string? Comment { get; set; }

    public virtual StatusRequest? StatusrRequest { get; set; }

    public virtual Tour? Tours { get; set; }

    public virtual User? Users { get; set; }
}
