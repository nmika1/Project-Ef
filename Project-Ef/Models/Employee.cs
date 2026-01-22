using System;
using System.Collections.Generic;

namespace EF_Project.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public decimal? Salary { get; set; }

    public virtual ICollection<BookingRoom> BookingRooms { get; set; } = new List<BookingRoom>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
