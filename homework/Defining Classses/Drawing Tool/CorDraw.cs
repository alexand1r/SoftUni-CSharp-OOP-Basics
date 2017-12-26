using System;

class CorDraw
{
    static void Main(string[] args)
    {
        string type = Console.ReadLine();
        switch (type)
        {
            case "Rectangle":
                int width = int.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                Rectangle rect1 = new Rectangle(width, height);
                rect1.Draw();
                break;
            case "Square":
                int size = int.Parse(Console.ReadLine());
                Rectangle rect2 = new Rectangle(size);
                rect2.Draw();
                break;
        }
    }
}
