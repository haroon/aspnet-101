namespace mef.Common.Interfaces;

public interface IPlugin
{
    string ToString();
    string GetName();
    string GetDescription();
    int GetId();
    object DoTheThing(Dictionary<string, object> parameters);
}
