using System;

public class UserAccount
{
    private string _password;
    private decimal _balance;

    // 1. AccountId - Init-Only Property
    public string AccountId { get; init; }

    // 2. Username - Auto-Implemented Property
    public string Username { get; set; }

    // 3. Password - Write-Only Property
    public string Password
    {
        set
        {
            _password = "[ENCRYPTED]_" + value;
        }
    }

    // 4. Balance - Full Property with Validation
    public decimal Balance
    {
        get
        {
            return _balance;
        }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error: Balance cannot be negative!");
            }
            else
            {
                _balance = value;
            }
        }
    }

    // 5. IsVIP - Computed Read-Only Property
    public bool IsVIP
    {
        get => Balance >= 10000m;
    }

    // 6. CreatedDate - Get-Only Auto Property
    public DateTime CreatedDate { get; }

    // Constructor
    public UserAccount()
    {
        CreatedDate = DateTime.Now;
    }
}

class Program
{
    static void Main(string[] args)
    {
        UserAccount user = new UserAccount
        {
            AccountId = "ACC-99201",
            Username = "Alice_Code",
            Password = "SuperSecretPassword123"
        };

        Console.WriteLine($"Account ID: {user.AccountId}");
        Console.WriteLine($"Username: {user.Username}");
        Console.WriteLine($"Account Created: {user.CreatedDate}");

        Console.WriteLine("\n--- Testing Balance Updates ---");

        user.Balance = 5000m;
        Console.WriteLine($"Current Balance: {user.Balance:C}");

        user.Balance = -200m;
        Console.WriteLine($"Current Balance after invalid attempt: {user.Balance:C}");

        Console.WriteLine($"\nIs VIP? {user.IsVIP}");

        user.Balance = 15000m;
        Console.WriteLine($"Updated Balance: {user.Balance:C}");

        Console.WriteLine($"Is VIP now? {user.IsVIP}");
    }
}

