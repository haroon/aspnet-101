using mef.Common.Abstract;
using System.Composition;

namespace mef.Plugins.Plugins;

[Export(typeof(AbstractPlugin))]
public class CollatzPlugin : AbstractPlugin
{
    public override string GetName() => "collatz";
    public override string GetDescription() => "Generate Collatz sequence for a number";
    public override int GetId() => 0;

    public override object DoTheThing(Dictionary<string, object> parameters)
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
