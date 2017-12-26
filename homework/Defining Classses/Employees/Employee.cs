using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    private static readonly List<Employee> Employees = new List<Employee>();
    private string name;
    private int age;
    private string position;
    private string department;
    private decimal salary;
    private string email;

    public Employee(string name, string position, string department, decimal salary, int age, string email)
    {
        this.name = name;
        this.age = age;
        this.position = position;
        this.department = department;
        this.salary = salary;
        this.email = email;

        Employees.Add(new Employee(name, age, position, department, email, salary));
    }

    private Employee(string name, int age, string position, string department, string email, decimal salary)
    {
        this.name = name;
        this.age = age;
        this.position = position;
        this.department = department;
        this.salary = salary;
        this.email = email;
    }

    public static void Print()
    {
        var departments = Employees.Select(e => e.department).Distinct();
        decimal maxAverageSalary = Decimal.MinValue;
        string targetDepartment = String.Empty;

        foreach (var dprmnt in departments)
        {
            decimal averageSalary = Employees
                .Where(e => e.department == dprmnt)
                .Select(e => e.salary)
                .Average();

            if (averageSalary > maxAverageSalary)
            {
                maxAverageSalary = averageSalary;
                targetDepartment = dprmnt;
            }
        }

        Console.WriteLine($"Highest Average Salary: {targetDepartment}");

        Employees.Where(e => e.department == targetDepartment)
            .OrderByDescending(e => e.salary)
            .ToList().
            ForEach(
                e => Console.WriteLine($"{e.name} {e.salary:F2} {e.email} {e.age}")
            );

    }
}
