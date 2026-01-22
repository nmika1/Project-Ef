using System;
using System.Collections.Generic;

namespace EF_Project.Models;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public decimal BasePrice { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
