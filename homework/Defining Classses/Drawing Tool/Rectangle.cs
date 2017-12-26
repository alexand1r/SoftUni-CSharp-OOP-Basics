using System;
using System.Runtime.InteropServices;
using System.Text;

class Rectangle
{
    public int width;
    public int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public Rectangle(int size)
    {
        this.width = size;
        this.height = size;
    }

    public void Draw()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < height; i++)
        {
            if (i == 0 || i == height - 1)
            {
                sb.AppendLine($"|{new string('-', width)}|");
            }
            else
            {
                sb.AppendLine($"|{new string(' ', width)}|");
            }
        }
        Console.WriteLine(sb.ToString());
    }
}
