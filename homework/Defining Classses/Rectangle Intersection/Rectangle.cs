public class Rectangle
{
    public string ID;
    public double width;
    public double height;

    public double x;
    public double y;

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.ID = id;
        this.width = width;
        this.height = height;
        this.x = x;
        this.y = y;
    }

    public bool HasIntersect(Rectangle another)
    {
        if ((another.x >= this.x - another.width && another.x <= this.x + this.width) &&
             (another.y >= this.y - another.height && another.y <= this.y + this.height))
        {
            return true;
        }

        return false;
    }
}
