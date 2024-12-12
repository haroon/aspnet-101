using mef.Common.Abstract;
using System.Composition;

namespace mef.Plugins.Plugins;

[Export(typeof(AbstractPlugin))]
public class BitPrintPlugin : AbstractPlugin
{
    public override string GetName() => "bitprint";
    public override string GetDescription() => "Convert an integer to bits";
    public override int GetId() => 4;

    public override object DoTheThing(Dictionary<string, object> parameters)
    {
        if (parameters.TryGetValue("num", out var numObj) &&
            uint.TryParse(numObj?.ToString(), out var Num))
        {
            return DoTheThing(Num);
        }

        throw new ArgumentException("Invalid parameters for BitPrintPlugin.");
    }

    private string DoTheThing(uint Num)
    {
        string bits = "";

        for (int i = (sizeof(int) * 8) - 1; i > -1; --i)
        {
            if ((i + 1) % 4 == 0) bits += " ";
            bits += (Num & (1 << i)) > 0 ? "1" : "0";
        }

        return bits;
    }
}
