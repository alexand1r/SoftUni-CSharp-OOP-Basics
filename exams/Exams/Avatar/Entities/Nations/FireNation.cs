using System.Linq;
using System.Text;

public class FireNation : Nation
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Fire Nation");
        
        if (base.Benders.Count == 0)
            sb.AppendLine("Benders: None");
        else
        {
            sb.AppendLine("Benders:");
            foreach (var bender in base.Benders)
            {
                sb.AppendLine($"###Fire Bender: {bender.Name}, Power: {bender.Power}" +
                              $", Heat Aggression: {(bender as FireBender).HeatAggression:F2}");
            }
        }

        if (base.Monuments.Count == 0)
            sb.AppendLine("Monuments: None");
        else
        {
            sb.AppendLine("Monuments:");
            foreach (var monument in this.Monuments)
            {
                sb.AppendLine($"###Fire Monument: {monument.Name}, Fire Affinity: {(monument as FireMonument).FireAffinity}");
            }
        }
        
        return sb.ToString();
    }
}
