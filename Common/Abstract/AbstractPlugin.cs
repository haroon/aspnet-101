using mef.Common.Interfaces;

namespace mef.Common.Abstract;

public abstract class AbstractPlugin : IPlugin
{
    public override string ToString()
    {
        return GetName() + " (" + GetId() + "): " + GetDescription() + "";
    }
    public abstract string GetName();
    public abstract string GetDescription();
    public abstract int GetId();
    public abstract object DoTheThing(Dictionary<string, object> parameters);
}
