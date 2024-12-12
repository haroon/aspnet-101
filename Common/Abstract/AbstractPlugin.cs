using Common.Types;
using mef.Common.Interfaces;

namespace mef.Common.Abstract;

public abstract class AbstractPlugin : IPlugin
{
    protected AbstractPlugin(PluginType pluginType)
    {
        if (!UsedIds.Add((int)pluginType))
        {
            throw new InvalidOperationException($"Duplicate ID detected for plugin: {pluginType.ToString()} ID: {pluginType}");
        }
        _PluginType = pluginType;
    }

    // Implemented IPlugin method
    public override string ToString()
    {
        return GetName() + " (" + GetId() + "): " + GetDescription() + "";
    }

    public string GetName() => _PluginType.ToString();
    public int GetId() => (int) _PluginType;

    // Abstract methods
    public abstract string GetDescription();
    public abstract object DoTheThing(Dictionary<string, object> parameters);

    // Properties
    private readonly PluginType _PluginType;
    private readonly HashSet<int> UsedIds = new HashSet<int>();
}
