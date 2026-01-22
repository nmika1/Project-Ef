using EF_Project;

var manager = new HotelManager();
///<summary>
/// Main Menu Loop
/// </summary>
while (true)
{
    Console.Clear();
    Console.WriteLine("HOTEL SYSTEM ");
    Console.WriteLine("1. View Guests, Rooms & Services");
    Console.WriteLine("2. Register New Guest");
    Console.WriteLine("3. Delete Guest");
    Console.WriteLine("4. Employee List");
    Console.WriteLine("5. Service Price List");
    Console.WriteLine("6. View Hotel Rankings");
    Console.WriteLine("7. Total Revenue");
    Console.WriteLine("8. Exit");
    Console.Write("\nSelect Option: ");

    var choice = Console.ReadLine();

    ///<summary>
    /// call methods based on user choice
    /// </summary>
    if (choice == "1") manager.ViewGuests();
    else if (choice == "2") manager.RegisterGuest();
    else if (choice == "3") manager.DeleteGuest();
    else if (choice == "4") manager.ViewEmployees();
    else if (choice == "5") manager.ViewServices();
    else if (choice == "6") manager.ViewRankings();
    else if (choice == "7") manager.ViewRevenue();
    else if (choice == "8") break;

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}