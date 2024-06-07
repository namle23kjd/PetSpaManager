﻿using System;
using System.Collections.Generic;

namespace Spa.Models;

public partial class Voucher
{
    public Guid VoucherId { get; set; }

    public string Code { get; set; } = null!;

    public decimal Discount { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public Guid CusId { get; set; }

    public Guid ManaId { get; set; }

    public Guid BookingId { get; set; }

    public bool Status { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Customer Cus { get; set; } = null!;

    public virtual Manager Mana { get; set; } = null!;
}
