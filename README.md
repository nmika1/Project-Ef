Hotel Management System (EF Core Project) This is a C# Console Application that manages hotel operations using Entity Framework Core and SQL Server. It allows for guest registration, room management, employee tracking, and financial reporting.

How to Launch the Project To run this application on your local machine, follow these steps:

1)Clone the Repository: Download the project files to your local machine.

2)Open in Visual Studio: Launch Visual Studio and open the .sln (Solution) file.

3)Restore Packages: The system should automatically restore the required NuGet packages. If not, right-click the Solution and select Restore NuGet Packages.

Prepare the Database:

4)Ensure you have run the provided SQL script in your SQL Server Management Studio (SSMS) to create the database schema

the App click the Start button in Visual Studio to launch the console interface.
Connection String Setup Instructions Before running the application, you must link it to your local SQL Server instance.

1)Locate the HotelSystemDbContext.cs file (or your configuration file where OnConfiguring is defined).

2)Find the connection string variable. It usually looks like this: "Server=YOUR_SERVER_NAME;Database=HotelSystemDB;Trusted_Connection=True;TrustServerCertificate=True;"

3)Replace YOUR_SERVER_NAME with your actual SQL Server Instance name (e.g., DESKTOP-12345 or . for local default).

4)Save the file before rebuilding the project.

List of Functions Implemented The application provides a menu-driven interface with the following capabilities:

View Guests, Rooms & Services: Displays a list of all guests, their currently assigned room number, and any services they have used.

Register New Guest: A comprehensive workflow to add a new guest, validate their input, assign an available room, link an employee to the booking, and generate an initial payment record.

Delete Guest: Removes a guest from the system. This function includes cascade-style logic to free up the room status to "Available" and remove associated booking and payment records.

Employee List: Displays all staff members and identifies whether they are "BUSY" (assigned to a room) or "FREE."

Service Price List: Shows a catalog of all hotel amenities (Breakfast, Spa, etc.) and their current prices in GEL.

View Hotel Rankings: Fetches and displays guest feedback directly from the database, including the guest's full name, star rating (1-5), and a text review.

Total Revenue: Displays all individual payments and calculates the total hotel revenue by executing a Stored Procedure from the SQL database.

Migration Files The project includes an Migrations/ folder containing the C# metadata files. These files represent the version history of the database schema.

InitialCreate: Sets up the base tables (Rooms, Guests, Employees, etc.).

AddHotelRanking: Adds the ranking and review system to the existing schema.
