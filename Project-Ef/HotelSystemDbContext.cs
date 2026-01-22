using EF_Project.Models;
using EF_Project.Services;
using Microsoft.EntityFrameworkCore;

public partial class HotelSystemDbContext : DbContext
{
    public HotelSystemDbContext() { }

    public HotelSystemDbContext(DbContextOptions<HotelSystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<BookingRoom> BookingRooms { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Guest> Guests { get; set; }
    public virtual DbSet<HotelRanking> HotelRankings { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<RoomType> RoomTypes { get; set; }
    public virtual DbSet<Service> Services { get; set; }
    public virtual DbSet<ServiceUsage> ServiceUsages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HotelSystemDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Bookings");
            entity.HasKey(e => e.BookingId);
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.HasOne(d => d.Employee).WithMany(p => p.Bookings).HasForeignKey(d => d.EmployeeId);
            entity.HasOne(d => d.Guest).WithMany(p => p.Bookings).HasForeignKey(d => d.GuestId);
        });

        modelBuilder.Entity<BookingRoom>(entity =>
        {
            entity.ToTable("BookingRooms");
            entity.HasKey(e => new { e.BookingId, e.RoomId });
            entity.HasOne(d => d.Booking).WithMany(p => p.BookingRooms).HasForeignKey(d => d.BookingId);
            entity.HasOne(d => d.Room).WithMany(p => p.BookingRooms).HasForeignKey(d => d.RoomId);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employees");
            entity.HasKey(e => e.EmployeeId);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.ToTable("Guests");
            entity.HasKey(e => e.GuestId);
            entity.HasIndex(e => e.Email).IsUnique();
        });

        modelBuilder.Entity<HotelRanking>(entity =>
        {
            entity.ToTable("HotelRanking");
            entity.HasKey(e => e.RankingId);
            entity.Property(e => e.RankingId).HasColumnName("RankingID");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payments");
            entity.HasKey(e => e.PaymentId);
            entity.HasOne(d => d.Booking).WithMany(p => p.Payments).HasForeignKey(d => d.BookingId);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Rooms");
            entity.HasKey(e => e.RoomId);
            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms).HasForeignKey(d => d.RoomTypeId);
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.ToTable("RoomTypes");
            entity.HasKey(e => e.RoomTypeId);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Services");
            entity.HasKey(e => e.ServiceId);
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
        });

        modelBuilder.Entity<ServiceUsage>(entity =>
        {
            entity.ToTable("ServiceUsage");
            entity.HasKey(e => e.UsageId);
            entity.Property(e => e.UsageId).HasColumnName("UsageID");
            entity.HasOne(d => d.Booking).WithMany(p => p.ServiceUsages).HasForeignKey(d => d.BookingId);
            entity.HasOne(d => d.Service).WithMany(p => p.ServiceUsages).HasForeignKey(d => d.ServiceId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override string ToString() => "Hotel System Database Context (EF Core)";
}