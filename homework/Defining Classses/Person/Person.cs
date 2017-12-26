using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public static List<Person> Persons = new List<Person>();
    public string name;
    public int age;

    public Person()
    {
        this.name = "No name";
        this.age = 1;
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public Person(int age) : this("No name", age)
    {
        this.age = age;
    }

    public static void PrintPersonsOver30()
    {
        var filteredPersons = Persons.Where(p => p.age > 30).OrderBy(p => p.name);
        filteredPersons.ToList().ForEach(p => Console.WriteLine($"{p.name} - {p.age}"));
    }
}
