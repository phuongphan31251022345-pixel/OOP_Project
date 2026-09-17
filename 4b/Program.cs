using System;

// Lớp cha Employee
public abstract class Employee
{
    protected string firstName;
    protected string lastName;
    protected string socialSecurityNumber;

    public Employee()
    {
    }

    public Employee(string firstName, string lastName, string socialSecurityNumber)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.socialSecurityNumber = socialSecurityNumber;
    }

    public string GetFirstName()
    {
        return firstName;
    }

    public void SetFirstName(string firstName)
    {
        this.firstName = firstName;
    }

    public string GetLastName()
    {
        return lastName;
    }

    public void SetLastName(string lastName)
    {
        this.lastName = lastName;
    }

    public string GetSocialSecurityNumber()
    {
        return socialSecurityNumber;
    }

    public void SetSocialSecurityNumber(string socialSecurityNumber)
    {
        this.socialSecurityNumber = socialSecurityNumber;
    }

    // Phương thức abstract
    public abstract double Earnings();

    public override string ToString()
    {
        return "Họ tên: " + firstName + " " + lastName
            + ", SSN: " + socialSecurityNumber;
    }
}

// Nhân viên hưởng lương theo tuần
public class SalariedEmployee : Employee
{
    private double weeklySalary;

    public SalariedEmployee()
    {
    }

    public SalariedEmployee(
        string firstName,
        string lastName,
        string socialSecurityNumber,
        double weeklySalary)
        : base(firstName, lastName, socialSecurityNumber)
    {
        this.weeklySalary = weeklySalary;
    }

    public double GetWeeklySalary()
    {
        return weeklySalary;
    }

    public void SetWeeklySalary(double weeklySalary)
    {
        this.weeklySalary = weeklySalary;
    }

    public override double Earnings()
    {
        return weeklySalary;
    }

    public override string ToString()
    {
        return "SalariedEmployee - "
            + base.ToString()
            + ", Lương tuần: " + weeklySalary;
    }
}

// Nhân viên hưởng lương theo giờ
public class HourlyEmployee : Employee
{
    private double wage;
    private double hours;

    public HourlyEmployee()
    {
    }

    public HourlyEmployee(
        string firstName,
        string lastName,
        string socialSecurityNumber,
        double wage,
        double hours)
        : base(firstName, lastName, socialSecurityNumber)
    {
        this.wage = wage;
        this.hours = hours;
    }

    public double GetWage()
    {
        return wage;
    }

    public void SetWage(double wage)
    {
        this.wage = wage;
    }

    public double GetHours()
    {
        return hours;
    }

    public void SetHours(double hours)
    {
        this.hours = hours;
    }

    public override double Earnings()
    {
        if (hours <= 40)
        {
            return wage * hours;
        }
        else
        {
            return 40 * wage
                + (hours - 40) * wage * 1.5;
        }
    }

    public override string ToString()
    {
        return "HourlyEmployee - "
            + base.ToString()
            + ", Lương/giờ: " + wage
            + ", Số giờ: " + hours;
    }
}

// Nhân viên hưởng hoa hồng
public class CommissionEmployee : Employee
{
    private double grossSales;
    private double commissionRate;

    public CommissionEmployee()
    {
    }

    public CommissionEmployee(
        string firstName,
        string lastName,
        string socialSecurityNumber,
        double grossSales,
        double commissionRate)
        : base(firstName, lastName, socialSecurityNumber)
    {
        this.grossSales = grossSales;
        this.commissionRate = commissionRate;
    }

    public double GetGrossSales()
    {
        return grossSales;
    }

    public void SetGrossSales(double grossSales)
    {
        this.grossSales = grossSales;
    }

    public double GetCommissionRate()
    {
        return commissionRate;
    }

    public void SetCommissionRate(double commissionRate)
    {
        this.commissionRate = commissionRate;
    }

    public override double Earnings()
    {
        return grossSales * commissionRate;
    }

    public override string ToString()
    {
        return "CommissionEmployee - "
            + base.ToString()
            + ", Doanh số: " + grossSales
            + ", Tỷ lệ hoa hồng: " + commissionRate;
    }
}

// Nhân viên hưởng hoa hồng + lương cơ bản
public class BasePlusCommissionEmployee : CommissionEmployee
{
    private double baseSalary;

    public BasePlusCommissionEmployee()
    {
    }

    public BasePlusCommissionEmployee(
        string firstName,
        string lastName,
        string socialSecurityNumber,
        double grossSales,
        double commissionRate,
        double baseSalary)
        : base(
            firstName,
            lastName,
            socialSecurityNumber,
            grossSales,
            commissionRate)
    {
        this.baseSalary = baseSalary;
    }

    public double GetBaseSalary()
    {
        return baseSalary;
    }

    public void SetBaseSalary(double baseSalary)
    {
        this.baseSalary = baseSalary;
    }

    public override double Earnings()
    {
        return base.Earnings() + baseSalary;
    }

    public override string ToString()
    {
        return "BasePlusCommissionEmployee - "
            + base.ToString()
            + ", Lương cơ bản: " + baseSalary;
    }
}

// Chương trình chính
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Tạo mảng Employee gồm đủ 4 loại nhân viên
        Employee[] employees = new Employee[4];

        // 1. SalariedEmployee
        employees[0] = new SalariedEmployee(
            "Nguyễn",
            "An",
            "111-11-1111",
            5000000
        );

        // 2. HourlyEmployee
        employees[1] = new HourlyEmployee(
            "Trần",
            "Bình",
            "222-22-2222",
            100000,
            45
        );

        // 3. CommissionEmployee
        employees[2] = new CommissionEmployee(
            "Lê",
            "Cường",
            "333-33-3333",
            20000000,
            0.10
        );

        // 4. BasePlusCommissionEmployee
        employees[3] = new BasePlusCommissionEmployee(
            "Phạm",
            "Dũng",
            "444-44-4444",
            30000000,
            0.08,
            5000000
        );

        // Xuất bảng lương
        Console.WriteLine("======================================================");
        Console.WriteLine("                  BẢNG LƯƠNG NHÂN VIÊN                ");
        Console.WriteLine("======================================================");

        double tongLuong = 0;

        foreach (Employee employee in employees)
        {
            Console.WriteLine(employee);
            Console.WriteLine("Tiền lương: " + employee.Earnings());
            Console.WriteLine("======================================================");

            tongLuong += employee.Earnings();
        }

        Console.WriteLine();
        Console.WriteLine("TỔNG LƯƠNG CÔNG TY: " + tongLuong);

        Console.ReadKey();
    }
}
