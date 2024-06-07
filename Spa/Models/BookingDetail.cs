﻿using System;
using System.Collections.Generic;

namespace Spa.Models;

public partial class BookingDetail
{
    public Guid BookingDetailId { get; set; }

    public Guid BookingId { get; set; }

    public Guid PetId { get; set; }

    public Guid? ServiceId { get; set; }

    public Guid? ComboId { get; set; }

    public string ComboType { get; set; } = null!;

    public TimeOnly Duration { get; set; }

    public bool Status { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Combo? Combo { get; set; }

    public virtual Pet Pet { get; set; } = null!;

    public virtual Service? Service { get; set; }
}
