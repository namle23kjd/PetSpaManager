using System;
using System.Collections.Generic;

namespace Spa.Models;

public partial class Admin
{
    public Guid AdminId { get; set; }

    public Guid Id { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual AspNetUser IdNavigation { get; set; } = null!;
}
