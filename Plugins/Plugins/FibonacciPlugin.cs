using Common.Types;
using mef.Common.Abstract;
using System.Composition;

namespace mef.Plugins.Plugins;

[Export(typeof(AbstractPlugin))]
public class FibonacciPlugin : AbstractPlugin
{
    public FibonacciPlugin() : base(PluginType.fibonacci)
    {
    }

    public override string GetDescription() => "Generate Fibonacci sequence upto a number of terms";

    public override object DoTheThing(Dictionary<string, object> parameters)
    {
        if (parameters.TryGetValue("terms", out var numObj) &&
            int.TryParse(numObj?.ToString(), out var Num))
        {
            parameters.TryGetValue("last_term", out var lastTermObj);
            bool.TryParse(lastTermObj?.ToString(), out var lastTerm);
            return DoTheThing(Num, lastTerm);
        }

        throw new ArgumentException("Invalid parameters for FibonacciPlugin.");
    }

    private string DoTheThing(int Num, bool lastTerm)
    {
        string Nut = "0 1 ";

        int b = 0;
        int f = 1;
        int sum = 0;

        for (int i = 2; i < Num; ++i)
        {
            sum = b + f;
            b = f;
            f = sum;
            Nut += sum + " ";
        }

        return lastTerm ? sum.ToString() : Nut;
    }
}
