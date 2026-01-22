using System;
using System.Collections.Generic;

namespace EF_Project.Services;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<ServiceUsage> ServiceUsages { get; set; } = new List<ServiceUsage>();
}
