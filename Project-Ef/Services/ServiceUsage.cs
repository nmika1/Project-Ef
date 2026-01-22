using EF_Project.Models;
using System;
using System.Collections.Generic;

namespace EF_Project.Services;

public partial class ServiceUsage
{
    public int UsageId { get; set; }

    public int BookingId { get; set; }

    public int ServiceId { get; set; }

    public DateTime? UsageDate { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
