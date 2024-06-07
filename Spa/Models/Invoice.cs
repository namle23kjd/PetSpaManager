using System;
using System.Collections.Generic;

namespace Spa.Models;

public partial class Invoice
{
    public Guid InvoiceId { get; set; }

    public Guid BookingId { get; set; }

    public decimal Price { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
