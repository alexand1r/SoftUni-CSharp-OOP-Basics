using System.Linq;
using System.Text;

public class WaterNation : Nation
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Water Nation");
        
        if (base.Benders.Count == 0)
            sb.AppendLine("Benders: None");
        else
        {
            sb.AppendLine("Benders:");
            foreach (var bender in base.Benders)
            {
                sb.AppendLine($"###Water Bender: {bender.Name}, Power: {bender.Power}" +
                              $", Water Clarity: {(bender as WaterBender).WaterClarity:F2}");
            }
        }
        
        if (base.Monuments.Count == 0)
            sb.AppendLine("Monuments: None");
        else
        {
            sb.AppendLine("Monuments:");
            foreach (var monument in this.Monuments)
            {
                sb.AppendLine($"###Water Monument: {monument.Name}, Water Affinity: {(monument as WaterMonument).WaterAffinity}");
            }
        }
        
        return sb.ToString();
    }
}
