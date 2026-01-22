using EF_Project;
using EF_Project.Models;
using Microsoft.EntityFrameworkCore;

///<summary>
/// main manager class for hotel operations
/// </summary>
public class HotelManager
{
    private readonly HotelSystemDbContext _db = new HotelSystemDbContext();

    ///<summary>
    /// view all guests with their latest room and services
    /// </summary>
    public void ViewGuests()
    {
        var data = _db.Guests
            .Include(g => g.Bookings!).ThenInclude(b => b.BookingRooms!).ThenInclude(br => br.Room)
            .Include(g => g.Bookings!).ThenInclude(b => b.ServiceUsages!).ThenInclude(su => su.Service)
            .ToList();

        ///<summary>
        /// show guest info
        /// </summary>
        Console.WriteLine("\nID | Name | Room | Services");
        foreach (var g in data)
        {
            var lastB = g.Bookings?.OrderByDescending(b => b.BookingId).FirstOrDefault();
            var roomNum = lastB?.BookingRooms?.FirstOrDefault()?.Room?.RoomNumber ?? "N/A";
            var services = lastB?.ServiceUsages?.Select(su => su.Service?.ServiceName).Where(n => n != null).ToList();
            string servicesText = (services != null && services.Any()) ? string.Join(", ", services) : "None";
            Console.WriteLine($"{g.GuestId,-3}  {g.FirstName + " " + g.LastName,-15}  {roomNum,-5}  {servicesText}");
        }
    }

    ///<summary>
    /// update guest info
    /// </summary>
    public void RegisterGuest()
    {
        string fn, ln, ph, em;
        do { Console.Write("First Name: "); fn = Console.ReadLine() ?? ""; } while (!Validator.IsValidName(fn));
        do { Console.Write("Last Name: "); ln = Console.ReadLine() ?? ""; } while (!Validator.IsValidName(ln));
        do { Console.Write("Phone: "); ph = Console.ReadLine() ?? ""; } while (!Validator.IsValidPhone(ph));
        do { Console.Write("Email: "); em = Console.ReadLine() ?? ""; } while (!Validator.IsValidEmail(em));

        var emps = _db.Employees.Take(5).ToList();
        foreach (var e in emps) Console.WriteLine($"{e.EmployeeId}. {e.FirstName}");
        Console.Write("Select Employee ID: ");
        if (!int.TryParse(Console.ReadLine(), out int empId)) return;
        ///<summary>
        /// available rooms
        /// </summary>
        var rooms = _db.Rooms.Include(r => r.RoomType).Where(r => r.Status == "Available").ToList();
        foreach (var r in rooms) Console.WriteLine($"{r.RoomId}. {r.RoomNumber}");
        Console.Write("Select Room ID: ");
        if (!int.TryParse(Console.ReadLine(), out int roomId)) return;

        var guest = new Guest { FirstName = fn, LastName = ln, Phone = ph, Email = em };
        _db.Guests.Add(guest); _db.SaveChanges();

        var booking = new Booking { GuestId = guest.GuestId, EmployeeId = empId, CheckInDate = DateOnly.FromDateTime(DateTime.Now), CheckOutDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)) };
        _db.Bookings.Add(booking); _db.SaveChanges();

        _db.BookingRooms.Add(new BookingRoom
        {
            BookingId = booking.BookingId,
            RoomId = roomId,
            AssignedEmployeeId = empId,
            AssignedEmployeeName = emps.FirstOrDefault(e => e.EmployeeId == empId)?.FirstName ?? "N/A"
        });
        ///<summary>
        /// payment for room
        /// </summary>
        var selRoom = _db.Rooms.Include(r => r.RoomType).FirstOrDefault(r => r.RoomId == roomId);
        if (selRoom != null)
        {
            _db.Payments.Add(new Payment
            {
                BookingId = booking.BookingId,
                Amount = selRoom.RoomType?.BasePrice ?? 0,
                PaymentDate = DateTime.Now,
                GuestFullName = $"{fn} {ln}",
                PaymentReason = "Room Charge"
            });
            selRoom.Status = "Occupied";
        }

        _db.SaveChanges();
        Console.WriteLine("\nDone.");
    }
    ///<summary>
    /// delete guest and all associated data
    /// </summary>
    public void DeleteGuest()
    {
        Console.Write("\nEnter Guest ID to DELETE: ");
        if (int.TryParse(Console.ReadLine(), out int gId))
        {
            var guest = _db.Guests
                .Include(g => g.Bookings!)
                    .ThenInclude(b => b.BookingRooms!)
                .Include(g => g.Bookings!)
                    .ThenInclude(b => b.Payments!)
                .Include(g => g.Bookings!)
                    .ThenInclude(b => b.ServiceUsages!)
                .FirstOrDefault(g => g.GuestId == gId);

            if (guest != null)
            {
                foreach (var b in guest.Bookings!)
                {
                    foreach (var br in b.BookingRooms!)
                    {
                        var r = _db.Rooms.Find(br.RoomId);
                        if (r != null) r.Status = "Available";
                    }
                    _db.Payments.RemoveRange(b.Payments!);
                    _db.ServiceUsages.RemoveRange(b.ServiceUsages!);
                    _db.BookingRooms.RemoveRange(b.BookingRooms!);
                }

                _db.Bookings.RemoveRange(guest.Bookings!);
                _db.Guests.Remove(guest);
                _db.SaveChanges();
                Console.WriteLine("Deleted successfully.");
            }
        }
    }
    ///<summary>
    ///  view all employees with their current status
    /// </summary>
    public void ViewEmployees()
    {
        var busyEmployees = _db.BookingRooms.Select(br => br.AssignedEmployeeId).Distinct().ToList();
        foreach (var e in _db.Employees.ToList())
        {
            string status = busyEmployees.Contains(e.EmployeeId) ? "BUSY" : "FREE";
            Console.WriteLine($"{e.EmployeeId}. {e.FirstName} {e.LastName} - {e.Position} [{status}]");
        }
    }
    ///<summary>
    /// view all services offered by the hotel
    /// </summary>
    public void ViewServices()
    {
        foreach (var s in _db.Services.ToList())
            Console.WriteLine($"{s.ServiceId}. {s.ServiceName} - {s.Price} GEL");
    }
    ///<summary>
    /// view hotel rankings and reviews
    /// </summary>
    public void ViewRankings()
    {
        var rankings = _db.HotelRankings.ToList();
        Console.WriteLine("\nGuest Name | Rating | Review");
        foreach (var r in rankings)
            Console.WriteLine($"{r.GuestFullName,-20} | {r.Rating,-6} | {r.Review}");
    }
    ///<summary>
    ///  total revenue generated by the hotel
    /// </summary>
    public void ViewRevenue()
    {
        var payments = _db.Payments.ToList();
        foreach (var p in payments)
            Console.WriteLine($"{p.GuestFullName,-15}  {p.Amount,-6} GEL  {p.PaymentDate:yyyy-MM-dd}");

        var total = _db.Payments.Sum(p => (decimal?)p.Amount) ?? 0;
        Console.WriteLine($"TOTAL REVENUE: {total} GEL");
    }
}