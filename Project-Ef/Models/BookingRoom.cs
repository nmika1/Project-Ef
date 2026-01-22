

namespace EF_Project.Models;

public partial class BookingRoom
{
    public int BookingId { get; set; }

    public int RoomId { get; set; }

    public int AssignedEmployeeId { get; set; }

    public string AssignedEmployeeName { get; set; } = null!;

    public virtual Employee AssignedEmployee { get; set; } = null!;

    public virtual Booking Booking { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
