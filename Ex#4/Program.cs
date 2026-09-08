using System;

public class BankAccount
{
    private decimal _balance;
    private string _pin;
    private int _failedAttempts;

    public string AccountHolder { get; }

    public bool IsLocked { get; private set; }

    public BankAccount(string accountHolder, decimal initialBalance, string initialPin)
    {
        AccountHolder = accountHolder;
        _balance = initialBalance > 0 ? initialBalance : 0;
        _pin = initialPin;
        _failedAttempts = 0;
        IsLocked = false;
    }

    public bool Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Error: Deposit amount must be positive!");
            return false;
        }

        _balance += amount;

        Console.WriteLine($"Deposit successful: {amount:C}");
        return true;
    }

    public bool Withdraw(decimal amount, string inputPin)
    {
        if (IsLocked)
        {
            Console.WriteLine("Error: Account is locked!");
            return false;
        }

        if (inputPin != _pin)
        {
            _failedAttempts++;

            Console.WriteLine("Error: Incorrect PIN!");

            if (_failedAttempts >= 3)
            {
                IsLocked = true;
                Console.WriteLine("Account locked after 3 failed attempts!");
            }

            return false;
        }

        _failedAttempts = 0;

        if (amount <= 0)
        {
            Console.WriteLine("Error: Withdrawal amount must be positive!");
            return false;
        }

        if (_balance < amount)
        {
            Console.WriteLine("Error: Insufficient balance!");
            return false;
        }

        _balance -= amount;

        Console.WriteLine($"Withdrawal successful: {amount:C}");
        return true;
    }

    public decimal GetBalance(string inputPin)
    {
        if (inputPin != _pin)
        {
            Console.WriteLine("Error: Incorrect PIN!");
            return -1m;
        }

        return _balance;
    }

    public bool ChangePin(string currentPin, string newPin)
    {
        if (currentPin != _pin)
        {
            Console.WriteLine("Error: Incorrect current PIN!");
            return false;
        }

        if (string.IsNullOrEmpty(newPin) ||
            newPin.Length != 4 ||
            !int.TryParse(newPin, out _))
        {
            Console.WriteLine("Error: New PIN must be exactly 4 digits!");
            return false;
        }

        _pin = newPin;

        Console.WriteLine("PIN changed successfully!");
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account =
            new BankAccount("John Doe", 500.00m, "1234");

        Console.WriteLine($"Account Holder: {account.AccountHolder}");

        Console.WriteLine("\n--- 1. Testing Deposit ---");

        account.Deposit(-50m);
        account.Deposit(200m);

        Console.WriteLine("\n--- 2. Testing Protected Balance View ---");

        account.GetBalance("9999");

        decimal currentBalance = account.GetBalance("1234");

        Console.WriteLine($"Verified Balance: {currentBalance:C}");

        Console.WriteLine("\n--- 3. Testing Lockout Mechanism ---");

        account.Withdraw(100m, "0000");
        account.Withdraw(100m, "1111");
        account.Withdraw(100m, "2222");

        account.Withdraw(100m, "1234");

        Console.WriteLine("\n--- 4. Account Lock Status ---");

        Console.WriteLine($"Is account locked? {account.IsLocked}");
    }
}
