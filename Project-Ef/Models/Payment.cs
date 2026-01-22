using System;
using System.Collections.Generic;

namespace EF_Project.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int BookingId { get; set; }

    public string GuestFullName { get; set; } = null!;

    public string PaymentReason { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
