USE HotelSystemDB;
GO

--  Adding staff for various departments.
INSERT INTO Employees (FirstName, LastName, Position, Salary) VALUES 
('Lasha', 'Kevkhishvili', 'Receptionist', 1200), ('Maka', 'Sandroshvili', 'Manager', 2500),
('Dato', 'Gevorkyan', 'Cleaner', 800), ('Nino', 'Abuladze', 'Chef', 1800),
('Giga', 'Lomidze', 'Security', 1000), ('Sopo', 'Vashadze', 'Receptionist', 1200),
('Zura', 'Japaridze', 'Technician', 1300), ('Eka', 'Tsereteli', 'Cleaner', 800),
('Beka', 'Gorgadze', 'Receptionist', 1200), ('Tika', 'Mgeladze', 'Spa Therapist', 1500),
('Gia', 'Nozadze', 'Security', 1000), ('Ani', 'Lomidze', 'Chef', 1800),
('Davit', 'Abashidze', 'Manager', 2500), ('Tatia', 'Gorgadze', 'Cleaner', 800),
('Irakli', 'Kvirikadze', 'Technician', 1300), ('Salome', 'Makharadze', 'Receptionist', 1200),
('Bacho', 'Gelashvili', 'Security', 1000), ('Natia', 'Khizanishvili', 'Chef', 1800),
('Zaza', 'Pachulia', 'Spa Therapist', 1500), ('Luka', 'Modric', 'Receptionist', 1200);

--  Adding hotel services with their respective prices.
INSERT INTO Services (ServiceName, Price) VALUES 
('Breakfast', 25.00), ('Gym Access', 15.00), ('Spa Treatment', 50.00), ('Laundry', 10.00), ('Mini Bar', 40.00);

--  Categorizing rooms by level and price.
INSERT INTO RoomTypes (TypeName, BasePrice) VALUES 
('Standard', 45.50), ('Deluxe', 95.00), ('Suite', 185.00)

--Adding 25 rooms 
INSERT INTO Rooms (RoomNumber, RoomTypeID, Status) VALUES 
('101', 1, 'Available'), ('102', 2, 'Available'), ('103', 3, 'Available'), ('201', 1, 'Available'), ('202', 2, 'Available'),
('203', 3, 'Available'), ('301', 1, 'Available'), ('302', 2, 'Available'), ('303', 3, 'Available'), ('401', 1, 'Available'),
('402', 2, 'Available'), ('403', 3, 'Available'), ('404', 1, 'Available'), ('405', 2, 'Available'), ('406', 3, 'Available'),
('501', 1, 'Available'), ('502', 2, 'Available'), ('503', 3, 'Available'), ('504', 1, 'Available'), ('505', 2, 'Available'),
('506', 3, 'Available'), ('601', 1, 'Available'), ('602', 2, 'Available'), ('603', 3, 'Available'), ('604', 1, 'Available');

--  Adding 20 initial customers.
INSERT INTO Guests (FirstName, LastName, Phone, Email) VALUES 
('Nika', 'Beridze', '555111', 'guest1@hotel.com'), ('Lana', 'Gach', '555222', 'guest2@hotel.com'), 
('Sandro', 'Kap', '555333', 'guest3@hotel.com'), ('Mariam', 'Dol', '555444', 'guest4@hotel.com'), 
('Luka', 'Mgel', '555555', 'guest5@hotel.com'), ('Eka', 'Tser', '555666', 'guest6@hotel.com'), 
('Gia', 'Noz', '555777', 'guest7@hotel.com'), ('Ani', 'Lom', '555888', 'guest8@hotel.com'), 
('Davit', 'Abash', '555999', 'guest9@hotel.com'), ('Tatia', 'Gorg', '555000', 'guest10@hotel.com'), 
('Irakli', 'Kvir', '555123', 'guest11@hotel.com'), ('Salome', 'Makh', '555654', 'guest12@hotel.com'), 
('Bacho', 'Gel', '555112', 'guest13@hotel.com'), ('Natia', 'Khiz', '555445', 'guest14@hotel.com'), 
('Zura', 'Jap', '555778', 'guest15@hotel.com'), ('Tamuna', 'San', '555009', 'guest16@hotel.com'), 
('Levan', 'Gvr', '555223', 'guest17@hotel.com'), ('Sophie', 'Vash', '555556', 'guest18@hotel.com'), 
('Vano', 'Tab', '555889', 'guest19@hotel.com'), ('Lika', 'Ted', '555334', 'guest20@hotel.com');

-- adds Ranking of Guest
INSERT INTO HotelRanking (GuestId, GuestFullName, Rating, Review) VALUES
(1, 'Nika Beridze', 5, 'Excellent service and very clean rooms.'),
(2, 'Lana Gach', 4, 'Great stay, but the breakfast could be better.'),
(3, 'Sandro Kap', 5, 'Loved the spa treatments, highly recommended!'),
(4, 'Mariam Dol', 3, 'Average experience, the room was a bit small.'),
(5, 'Luka Mgel', 2, 'The noise from the street was too loud at night.'),
(6, 'Eka Tser', 5, 'Perfect location and very friendly staff.'),
(7, 'Gia Noz', 4, 'Comfortable bed and good gym facilities.'),
(8, 'Ani Lom', 1, 'Very disappointed with the room service.'),
(9, 'Davit Abash', 5, 'Best hotel in the city, will come back again.'),
(10, 'Tatia Gorg', 4, 'Modern interior and nice view from the window.'),
(11, 'Irakli Kvir', 5, 'Professional staff and quick check-in process.'),
(12, 'Salome Makh', 3, 'Good location but the Wi-Fi was unstable.'),
(13, 'Bacho Gel', 4, 'Clean and cozy, very good value for money.'),
(14, 'Natia Khiz', 5, 'Absolutely loved the breakfast variety.'),
(15, 'Zura Jap', 2, 'The air conditioning was too noisy.'),
(16, 'Tamuna San', 4, 'Friendly reception and helpful managers.'),
(17, 'Levan Gvr', 5, 'The suite was amazing, worth every penny.'),
(18, 'Sophie Vash', 3, 'Everything was okay, but nothing special.'),
(19, 'Vano Tab', 4, 'Great security and felt very safe during stay.'),
(20, 'Lika Ted', 5, 'Highly professional cleaners and tidy rooms.');

-- Creating a 2-day booking for every guest in the database.
INSERT INTO Bookings (GuestId, EmployeeId, CheckInDate, CheckOutDate)
SELECT GuestId, (GuestId % 20) + 1, GETDATE(), DATEADD(day, 2, GETDATE()) FROM Guests;

--  Mapping bookings to rooms and assigning staff to those rooms.
INSERT INTO BookingRooms (BookingId, RoomId, AssignedEmployeeId, AssignedEmployeeName)
SELECT b.BookingId, r.RoomId, e.EmployeeId, e.FirstName + ' ' + e.LastName
FROM (SELECT BookingId, ROW_NUMBER() OVER(ORDER BY BookingId) as rn FROM Bookings) b
JOIN (SELECT RoomId, ROW_NUMBER() OVER(ORDER BY RoomId) as rn FROM Rooms) r ON b.rn = r.rn
JOIN Employees e ON (b.rn % 20 + 1) = e.EmployeeId;

-- Set room status to 'Occupied' for all rooms that were just assigned.
UPDATE Rooms SET Status = 'Occupied' WHERE RoomId IN (SELECT RoomId FROM BookingRooms);

-- Assigning one service usage to every booking for billing variety.
INSERT INTO ServiceUsage (BookingId, ServiceId, UsageDate)
SELECT b.BookingId, (b.BookingId % 5) + 1, GETDATE() FROM Bookings b;

--Complex query to calculate total amount (Room Price * 2 days + Service Price).
INSERT INTO Payments (BookingId, Amount, PaymentDate, PaymentReason, GuestFullName)
SELECT b.BookingId, (rt.BasePrice * 2) + s.Price, GETDATE(), 'Room + ' + s.ServiceName, g.FirstName + ' ' + g.LastName
FROM Bookings b 
JOIN Guests g ON b.GuestId = g.GuestId 
JOIN BookingRooms br ON b.BookingId = br.BookingId
JOIN Rooms r ON br.RoomId = r.RoomId
JOIN RoomTypes rt ON r.RoomTypeId = rt.RoomTypeId
JOIN ServiceUsage su ON b.BookingId = su.BookingId
JOIN Services s ON su.ServiceId = s.ServiceId;
