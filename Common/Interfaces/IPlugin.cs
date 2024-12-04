namespace mef.Common.Interfaces;

public interface IPlugin
{
    string GetName();
    int GetId();
    object DoTheThing(Dictionary<string, object> parameters);
}
