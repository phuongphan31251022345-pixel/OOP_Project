using System;

public class Student
{
    private string name;
    private double score;
    private static int totalStudents = 0;

    public Student(string name, double score)
    {
        this.name = name;
        this.score = score;
        totalStudents++;
    }

    public string GetName()
    {
        return this.name;
    }

    public double GetScore()
    {
        return this.score;
    }

    public bool IsPassed()
    {
        return this.score >= 5.0;
    }

    public string GetClassification()
    {
        if (this.score >= 8.0)
        {
            return "Excellent";
        }
        else if (this.score >= 6.5)
        {
            return "Good";
        }
        else if (this.score >= 5.0)
        {
            return "Average";
        }
        else
        {
            return "Weak";
        }
    }

    public static int GetTotalStudents()
    {
        return totalStudents;
    }

    public static Student FindTopStudent(Student[] students)
    {
        if (students == null || students.Length == 0)
        {
            return null;
        }

        Student topStudent = students[0];

        for (int i = 1; i < students.Length; i++)
        {
            if (students[i].score > topStudent.score)
            {
                topStudent = students[i];
            }
        }

        return topStudent;
    }

    public static double CalculateAverageScore(Student[] students)
    {
        if (students == null || students.Length == 0)
        {
            return 0.0;
        }

        double totalScore = 0;

        for (int i = 0; i < students.Length; i++)
        {
            totalScore += students[i].score;
        }

        return totalScore / students.Length;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student[] students =
        {
            new Student("An", 8.5),
            new Student("Binh", 6.8),
            new Student("Chi", 4.5),
            new Student("Dung", 7.2),
            new Student("Em", 9.0)
        };

        Console.WriteLine("Total students: " +
                          Student.GetTotalStudents());

        Console.WriteLine();

        Console.WriteLine("Student List:");

        foreach (Student student in students)
        {
            Console.WriteLine(
                $"Name: {student.GetName()}, " +
                $"Score: {student.GetScore():F1}, " +
                $"Classification: {student.GetClassification()}, " +
                $"Status: {(student.IsPassed() ? "Passed" : "Failed")}"
            );
        }

        Console.WriteLine();

        Student topStudent = Student.FindTopStudent(students);

        Console.WriteLine("Top Student:");
        Console.WriteLine(
            $"Name: {topStudent.GetName()}, " +
            $"Score: {topStudent.GetScore():F1}, " +
            $"Classification: {topStudent.GetClassification()}"
        );

        Console.WriteLine();

        double average = Student.CalculateAverageScore(students);

        Console.WriteLine($"Class Average Score: {average:F2}");
    }
}


