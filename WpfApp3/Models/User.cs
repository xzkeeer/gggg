using System;
using System.Collections.Generic;

namespace WpfApp3.Models;

public partial class User
{
    public int Id { get; set; }

    public int? RoleUsersId { get; set; }

    public string? FullNameUsers { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual RoleUser? RoleUsers { get; set; }
}
