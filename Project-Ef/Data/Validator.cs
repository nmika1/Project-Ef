using System.Linq;
/// <summary>   
/// set of static methods for validating guest information
/// <summary>
public static class Validator
{
    public static bool IsValidName(string name) =>
        !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter) && name.Length >= 2;

    public static bool IsValidPhone(string phone) =>
        phone?.Length == 9 && phone.All(char.IsDigit);

    public static bool IsValidEmail(string email) =>
        !string.IsNullOrWhiteSpace(email) && email.ToLower().EndsWith("@gmail.com");
}