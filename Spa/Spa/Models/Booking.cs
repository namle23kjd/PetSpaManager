using System;
using System.Collections.Generic;

namespace Spa.Models;

public partial class Booking
{
    public Guid BookingId { get; set; }

    public Guid CusId { get; set; }

    public Guid ManaId { get; set; }

    public bool Status { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? BookingSchedule { get; set; }

    public string? Feedback { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid? StaffId { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual Customer Cus { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Manager Mana { get; set; } = null!;

    public virtual Staff? Staff { get; set; }

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
