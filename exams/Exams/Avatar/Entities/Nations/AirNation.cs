using System.Text;

public class AirNation : Nation
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Air Nation");
        
        if (base.Benders.Count == 0)
            sb.AppendLine("Benders: None");
        else
        {
            sb.AppendLine("Benders:");
            foreach (var bender in base.Benders)
            {
                sb.AppendLine($"###Air Bender: {bender.Name}, Power: {bender.Power}" +
                              $", Aerial Integrity: {(bender as AirBender).AerialIntegrity:F2}");
            }
        }
        
        if (base.Monuments.Count == 0)
            sb.AppendLine("Monuments: None");
        else
        {
            sb.AppendLine("Monuments:");
            foreach (var monument in this.Monuments)
            {
                sb.AppendLine($"###Air Monument: {monument.Name}, Air Affinity: {(monument as AirMonument).AirAffinity}");
            }
        }
        
        return sb.ToString();
    }
}
