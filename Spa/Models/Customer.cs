using System;
using System.Collections.Generic;

namespace Spa.Models;

public partial class Customer
{
    public Guid CusId { get; set; }

    public Guid Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string CusRank { get; set; } = null!;

    public Guid AdminId { get; set; }

    public bool Status { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual AspNetUser IdNavigation { get; set; } = null!;

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
