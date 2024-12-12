using Common.Types;
using mef.Common.Abstract;
using System.Composition;
using System.Numerics;

namespace mef.Plugins.Plugins;

[Export(typeof(AbstractPlugin))]
public class FactDigitSumPlugin : AbstractPlugin
{
    public FactDigitSumPlugin() : base(PluginType.factdigitsum)
    {
    }

    public override string GetDescription() => "Return the sum of all digits of factorial of a number";

    public override object DoTheThing(Dictionary<string, object> parameters)
    {
        if (parameters.TryGetValue("num", out var numObj) &&
            int.TryParse(numObj?.ToString(), out var Num))
        {
            return DoTheThing(Num);
        }

        throw new ArgumentException("Invalid parameters for FactDigitSumPlugin.");
    }

    private BigInteger GetFactorial(int Num)
    {
        BigInteger res = 1;
        while(Num > 0)
        {
            res *= Num--;
        }
        return res;
    }

    private string GetDigitSum(BigInteger Num)
    {
        BigInteger sum = 0;
        while (Num > 0)
        {
            sum += Num % 10;
            Num /= 10;
        }

        return sum.ToString();
    }

    private string DoTheThing(int Num)
    {
        return GetDigitSum(GetFactorial(Num));
    }
}
