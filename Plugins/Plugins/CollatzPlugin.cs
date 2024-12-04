using mef.Common.Interfaces;
using System.Composition;

namespace mef.Plugins.Plugins;

[Export(typeof(IPlugin))]
public class CollatzPlugin : IPlugin
{
    public string GetName() => "collatz";
    public int GetId() => 0;

    public object DoTheThing(Dictionary<string, object> parameters)
    {
        if (parameters.TryGetValue("num", out var numObj) &&
            int.TryParse(numObj?.ToString(), out var Num))
        {
            return DoTheThing(Num);
        }

        throw new ArgumentException("Invalid parameters for CollatzPlugin.");
    }

    private string DoTheThing(int Num)
    {
        string Nut = Num.ToString() + " ";
        while (Num > 1)
        {
            if (Num % 2 == 0)
            {
                Num /= 2;
            }
            else
            {
                Num = Num * 3 + 1;
            }
            Nut += Num.ToString() + " ";
        }
        return Nut;
    }
}
