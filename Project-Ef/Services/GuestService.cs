using EF_Project;
using EF_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

/// <summary>   
/// save all context changes to the database
/// <summary>
public class GuestService
{
    /// <summary>   
    /// save all context changes to the database
    /// <summary>
    private readonly HotelSystemDbContext _db;
    public GuestService(HotelSystemDbContext db) => _db = db;

    public List<Guest> GetAll() => _db.Guests.ToList();
    public Guest? GetById(int id) => _db.Guests.Find(id);

    /// <summary>   
    /// add a new guest to the database
    /// <summary>
    public void Add(Guest guest)
    {
        _db.Guests.Add(guest);
        _db.SaveChanges();
    }

    /// <summary>   
    /// update an existing guest in the database
    /// <summary>
    public void Update(Guest guest)
    {
        _db.Guests.Update(guest);
        _db.SaveChanges();
    }

    /// <summary>   
    /// delete a guest and all associated bookings, booking rooms, and payments from the database
    /// <summary>
    public void Delete(int id)
    {
        var guest = _db.Guests
            .Include(g => g.Bookings).ThenInclude(b => b.BookingRooms)
            .Include(g => g.Bookings).ThenInclude(b => b.Payments)
            .FirstOrDefault(g => g.GuestId == id);

        if (guest != null)
        {
            foreach (var booking in guest.Bookings)
            {
                foreach (var br in booking.BookingRooms)
                {
                    var room = _db.Rooms.Find(br.RoomId);
                    if (room != null) room.Status = "Available";
                }
                _db.Payments.RemoveRange(booking.Payments);
                _db.BookingRooms.RemoveRange(booking.BookingRooms);
            }
            _db.Bookings.RemoveRange(guest.Bookings);
            _db.Guests.Remove(guest);
            _db.SaveChanges();
        }
    }
}