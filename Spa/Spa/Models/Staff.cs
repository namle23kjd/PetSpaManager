using System;
using System.Collections.Generic;

namespace Spa.Models;

public partial class Staff
{
    public Guid StaffId { get; set; }

    public Guid Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? Gender { get; set; }

    public string Job { get; set; } = null!;

    public Guid? ManagerManaId { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual AspNetUser IdNavigation { get; set; } = null!;

    public virtual Manager? ManagerMana { get; set; }
}
