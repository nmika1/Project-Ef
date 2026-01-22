
-- Create the Database
CREATE DATABASE HotelSystemDB;
GO
USE HotelSystemDB;
GO

--Defines categories like Standard, Deluxe, etc.
CREATE TABLE RoomTypes (
    RoomTypeID INT PRIMARY KEY IDENTITY(1,1),
    TypeName NVARCHAR(50) NOT NULL UNIQUE,
    BasePrice DECIMAL(10, 2) NOT NULL CHECK (BasePrice > 0)
);

--  Stores individual room data linked to a specific type.
CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomNumber NVARCHAR(10) NOT NULL UNIQUE,
    RoomTypeID INT NOT NULL,
    Status NVARCHAR(20) DEFAULT 'Available',
    FOREIGN KEY (RoomTypeID) REFERENCES RoomTypes(RoomTypeID)
);

-- Stores personal contact information for customers.
CREATE TABLE Guests (
    GuestID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) UNIQUE,
    Phone NVARCHAR(20) NOT NULL
);

-- Stores staff details, positions, and payroll constraints.
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Position NVARCHAR(50) NOT NULL,
    Salary DECIMAL(10, 2) CHECK (Salary > 500)
);

-- Tracks the main reservation period and the primary guest/staff contact.
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    GuestID INT NOT NULL,
    EmployeeID INT NOT NULL,
    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL,
    FOREIGN KEY (GuestID) REFERENCES Guests(GuestID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

-- It also tracks which specific employee is assigned to manage that specific room.
CREATE TABLE BookingRooms (
    BookingID INT NOT NULL,
    RoomID INT NOT NULL,
    AssignedEmployeeID INT NOT NULL,
    AssignedEmployeeName NVARCHAR(100) NOT NULL,
    PRIMARY KEY (BookingID, RoomID),
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID),
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID),
    FOREIGN KEY (AssignedEmployeeID) REFERENCES Employees(EmployeeID)
);

-- Catalog of extra amenities like Breakfast or Spa.
CREATE TABLE Services (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
    ServiceName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);

-- Records which bookings consumed which extra services.
CREATE TABLE ServiceUsage (
    UsageID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT NOT NULL,
    ServiceID INT NOT NULL,
    UsageDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID),
    FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID)
);

-- Stores guest reviews and star ratings (1 to 5).
CREATE TABLE HotelRanking (
    RankingID INT PRIMARY KEY IDENTITY(1,1),
    GuestID INT NOT NULL,
    GuestFullName NVARCHAR(100) NOT NULL,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Review TEXT,
    FOREIGN KEY (GuestID) REFERENCES Guests(GuestID)
);

-- Tracks financial transactions based on total booking costs.
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT NOT NULL,
    GuestFullName NVARCHAR(100) NOT NULL,
    PaymentReason NVARCHAR(100) NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL CHECK (Amount >= 0),
    PaymentDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
);
GO
