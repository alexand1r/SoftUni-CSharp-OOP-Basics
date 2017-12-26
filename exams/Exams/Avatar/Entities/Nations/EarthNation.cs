using System.Text;

public class EarthNation : Nation
{
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Earth Nation");
        
        if (base.Benders.Count == 0)
            sb.AppendLine("Benders: None");
        else
        {
            sb.AppendLine("Benders:");
            foreach (var bender in base.Benders)
            {
                sb.AppendLine($"###Earth Bender: {bender.Name}, Power: {bender.Power}" +
                                $", Ground Saturation: {(bender as EarthBender).GroundSaturation:F2}");
            }
        }
        
        if (base.Monuments.Count == 0)
            sb.AppendLine("Monuments: None");
        else
        {
            sb.AppendLine("Monuments:");
            foreach (var monument in this.Monuments)
            {
                sb.AppendLine($"###Earth Monument: {monument.Name}, Earth Affinity: {(monument as EarthMonument).EarthAffinity}");
            }
        }
        
        return sb.ToString();
    }
}
