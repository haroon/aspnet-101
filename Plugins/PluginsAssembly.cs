using System.Reflection;

namespace mef.Plugins;

public sealed class PluginsAssembly
{
    public static readonly Assembly Value = typeof(PluginsAssembly).Assembly;
}
