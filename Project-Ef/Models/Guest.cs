using System;
using System.Collections.Generic;

namespace EF_Project.Models;

public partial class Guest
{
    public int GuestId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string Phone { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<HotelRanking> HotelRankings { get; set; } = new List<HotelRanking>();
}
