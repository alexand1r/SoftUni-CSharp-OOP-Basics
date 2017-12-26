public class WaterBender : Bender
{
    private double waterClarity ;

    public WaterBender(string name, int power, double waterClarity )
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity 
    {
        get { return this.waterClarity; }
        set { this.waterClarity = value; }
    }

    public override double GetTotalPower()
    {
        var totalPower = this.Power * this.WaterClarity;

        return totalPower;
    }
}
