using EF_Project.Services;
using System;
using System.Collections.Generic;

namespace EF_Project.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int GuestId { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public virtual ICollection<BookingRoom> BookingRooms { get; set; } = new List<BookingRoom>();

    public virtual Employee Employee { get; set; } = null!;

    public virtual Guest Guest { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<ServiceUsage> ServiceUsages { get; set; } = new List<ServiceUsage>();
}
