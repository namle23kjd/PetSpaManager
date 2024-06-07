using System;
using System.Collections.Generic;

namespace Spa.Models;

public partial class Manager
{
    public Guid ManaId { get; set; }

    public Guid Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public Guid BookingId { get; set; }

    public Guid AdminId { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual AspNetUser IdNavigation { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
