using System.Reflection;

namespace mef.Common;

public sealed class CommonAssembly
{
    public static readonly Assembly Value = typeof(CommonAssembly).Assembly;
}
