using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RandomList : ArrayList
{
    private Random rnd;
    private ArrayList data;
    public RandomList()
    {
        this.rnd = new Random();
        this.data = new ArrayList();
    }

    public string Last()
    {
        return (string)data[data.Count - 1];
    }
    public object RandomString()
    {
        int element = rnd.Next(0, data.Count - 1);
        string str = (string)data[element];
        data.Remove(str);
        return str;
    }
}
