using System;
using System.Collections.Generic;

namespace WpfApp3.Models;

public partial class RoleUser
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
