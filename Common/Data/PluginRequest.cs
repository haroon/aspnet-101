namespace mef.Common.Data;

public class PluginRequest
{
    public int PluginId { get; set; }
    public string PluginName { get; set; } = string.Empty;
    public string PluginDescription { get; set; } = string.Empty;
    public Dictionary<string, object> Parameters { get; set; }
}
