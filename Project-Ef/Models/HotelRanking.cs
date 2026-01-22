using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Project.Models;

public partial class HotelRanking
{
    [Key]
    public int RankingId { get; set; }

    public int GuestId { get; set; }

    public string GuestFullName { get; set; } = null!;

    public int? Rating { get; set; }

    public string? Review { get; set; }

    public virtual Guest Guest { get; set; } = null!;
}
