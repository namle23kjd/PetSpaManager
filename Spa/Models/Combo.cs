﻿using System;
using System.Collections.Generic;

namespace Spa.Models;

public partial class Combo
{
    public Guid ComboId { get; set; }

    public string ComboType { get; set; } = null!;

    public decimal Price { get; set; }

    public TimeOnly Duration { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
