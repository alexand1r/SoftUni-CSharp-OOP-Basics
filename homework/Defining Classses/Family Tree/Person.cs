public class Person
{
    public string Birthday { get; }
    public string Name => this.FirstName + " " + this.LastName;
    public string FirstName { get; }
    public string LastName { get; }
    public FamilyTree FamilyTree { get; }

    public Person(string firstName, string lastName, string birthday)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Birthday = birthday;
        this.FamilyTree = new FamilyTree();
    }

    public override string ToString()
    {
        return this.Name + " " + this.Birthday;
    }
}
