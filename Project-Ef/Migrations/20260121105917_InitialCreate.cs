using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04FF1D6C33FAF", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Guests__0C423C32ED60EC17", x => x.GuestID);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    RoomTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RoomType__BCC896112EFD5BD4", x => x.RoomTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Services__C51BB0EAD6805C0A", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CheckOutDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bookings__73951ACD85B40559", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK__Bookings__Employ__5AEE82B9",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__Bookings__GuestI__59FA5E80",
                        column: x => x.GuestID,
                        principalTable: "Guests",
                        principalColumn: "GuestID");
                });

            migrationBuilder.CreateTable(
                name: "HotelRanking",
                columns: table => new
                {
                    RankingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestID = table.Column<int>(type: "int", nullable: false),
                    GuestFullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Review = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HotelRan__018A6AF9D54B72A0", x => x.RankingID);
                    table.ForeignKey(
                        name: "FK__HotelRank__Guest__6A30C649",
                        column: x => x.GuestID,
                        principalTable: "Guests",
                        principalColumn: "GuestID");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RoomTypeID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Available")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rooms__32863919C7009B3E", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK__Rooms__RoomTypeI__5165187F",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    GuestFullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaymentReason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments__9B556A58AAE12E4B", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK__Payments__Bookin__6E01572D",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID");
                });

            migrationBuilder.CreateTable(
                name: "ServiceUsage",
                columns: table => new
                {
                    UsageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    UsageDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServiceU__29B197C0075821DD", x => x.UsageID);
                    table.ForeignKey(
                        name: "FK__ServiceUs__Booki__656C112C",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID");
                    table.ForeignKey(
                        name: "FK__ServiceUs__Servi__66603565",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ServiceID");
                });

            migrationBuilder.CreateTable(
                name: "BookingRooms",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    AssignedEmployeeID = table.Column<int>(type: "int", nullable: false),
                    AssignedEmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BookingR__F0BD795C253AD10F", x => new { x.BookingID, x.RoomID });
                    table.ForeignKey(
                        name: "FK__BookingRo__Assig__5FB337D6",
                        column: x => x.AssignedEmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__BookingRo__Booki__5DCAEF64",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID");
                    table.ForeignKey(
                        name: "FK__BookingRo__RoomI__5EBF139D",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRooms_AssignedEmployeeID",
                table: "BookingRooms",
                column: "AssignedEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRooms_RoomID",
                table: "BookingRooms",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EmployeeID",
                table: "Bookings",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestID",
                table: "Bookings",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "UQ__Guests__A9D10534409D4D96",
                table: "Guests",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRanking_GuestID",
                table: "HotelRanking",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingID",
                table: "Payments",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeID",
                table: "Rooms",
                column: "RoomTypeID");

            migrationBuilder.CreateIndex(
                name: "UQ__Rooms__AE10E07A16E4CDC7",
                table: "Rooms",
                column: "RoomNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__RoomType__D4E7DFA83681CFA0",
                table: "RoomTypes",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsage_BookingID",
                table: "ServiceUsage",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsage_ServiceID",
                table: "ServiceUsage",
                column: "ServiceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRooms");

            migrationBuilder.DropTable(
                name: "HotelRanking");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ServiceUsage");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Guests");
        }
    }
}
