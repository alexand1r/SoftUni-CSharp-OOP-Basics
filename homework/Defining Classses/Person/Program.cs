using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //// Problem 1
        //Type personType = typeof(Person);
        //FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        //Console.WriteLine(fields.Length);

        //Type personType = typeof(Person);
        //ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
        //ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
        //ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });
        //bool swapped = false;
        //if (nameAgeCtor == null)
        //{
        //    nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });
        //    swapped = true;
        //}

        //// Problem 2
        //string name = Console.ReadLine();
        //int age = int.Parse(Console.ReadLine());

        //Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
        //Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });
        //Person personWithAgeAndName = swapped ? (Person)nameAgeCtor.Invoke(new object[] { age, name }) : (Person)nameAgeCtor.Invoke(new object[] { name, age });

        //Console.WriteLine("{0} {1}", basePerson.name, basePerson.age);
        //Console.WriteLine("{0} {1}", personWithAge.name, personWithAge.age);
        //Console.WriteLine("{0} {1}", personWithAgeAndName.name, personWithAgeAndName.age);

        //// Problem 3
        //MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        //MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        //if (oldestMemberMethod == null || addMemberMethod == null)
        //{
        //    throw new Exception();
        //}

        //Family family = new Family();
        //int n = int.Parse(Console.ReadLine());
        //for (int i = 0; i < n; i++)
        //{
        //    string[] data = Console.ReadLine().Split(' ');
        //    string name = data[0];
        //    int age = int.Parse(data[1]);
        //    family.AddMember(new Person(name, age));
        //}
        //Console.WriteLine(family.GetOldestMember().name + " " + family.GetOldestMember().age);

        //// Problem 4
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);
            Person.Persons.Add(person);
        }

        Person.PrintPersonsOver30();
    }
}
