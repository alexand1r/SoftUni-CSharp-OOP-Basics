using System.Collections.Generic;
using System.Linq;

public abstract class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    protected Nation()
    {
        this.Monuments = new List<Monument>();
        this.Benders = new List<Bender>();
    }

    public List<Monument> Monuments
    {
        get { return this.monuments; }
        protected set { this.monuments = value; }
    }

    public List<Bender> Benders
    {
        get { return this.benders; }
        protected set { this.benders = value; }
    }

    public double GetTotalPower()
    {
        var bendersTotalPower = this.Benders.Sum(x => x.GetTotalPower());
        var monumentsTotalAffinity = this.Monuments.Sum(x => x.GetAffinity());
        var increase = (bendersTotalPower / 100) * monumentsTotalAffinity;
        bendersTotalPower += increase;

        return bendersTotalPower;
    }
}
