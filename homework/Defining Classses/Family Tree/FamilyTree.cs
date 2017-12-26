using System.Collections.Generic;
using System.Text;

public class FamilyTree
{
    public HashSet<Person> Parents { get; set; }
    public HashSet<Person> Children { get; set; }

    public FamilyTree()
    {
        this.Parents = new HashSet<Person>();
        this.Children = new HashSet<Person>();
    }

    public void AddChild(Person child)
    {
        this.Children.Add(child);
    }

    public void AddParent(Person parent)
    {
        this.Parents.Add(parent);
    }

    public override string ToString()
    {
        var output = new StringBuilder("Parents:\n");

        output.Append(string.Join("\n", this.Parents));
        output.Append("\nChildren:\n");
        output.Append(string.Join("\n", this.Children));

        return output.ToString();
    }
}
