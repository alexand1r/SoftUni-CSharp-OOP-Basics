using System;
using System.Linq;

public class DateModifier
{
    public string startDate;
    public string endDate;

    public DateModifier(string startDate, string endDate)
    {
        this.startDate = startDate;
        this.endDate = endDate;
    }

    public double Difference()
    {
        int[] date1 = startDate.Split(' ').Select(int.Parse).ToArray();
        int[] date2 = endDate.Split(' ').Select(int.Parse).ToArray();

        DateTime d1 = new DateTime(date1[0], date1[1], date1[2]);
        DateTime d2 = new DateTime(date2[0], date2[1], date2[2]);

        return (d2 - d1).TotalDays;
    }
}
