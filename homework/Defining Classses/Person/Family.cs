using System.Collections.Generic;
using System.Linq;

public class Family
{
    public static List<Person> people = new List<Person>();

    public void AddMember(Person member)
    {
        people.Add(member);
    }

    public Person GetOldestMember()
    {
        return people.OrderByDescending(x => x.age).First();
    }
}
