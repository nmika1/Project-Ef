using System;
using System.Collections.Generic;

namespace EF_Project.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public int RoomTypeId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<BookingRoom> BookingRooms { get; set; } = new List<BookingRoom>();

    public virtual RoomType RoomType { get; set; } = null!;
}
