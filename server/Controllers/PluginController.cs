using System.Composition.Hosting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using mef.Common.Interfaces;
using mef.Common.Data;
using System.Composition;

namespace mef.server.Controllers;

[ApiController]
[Route("[controller]")]
public class PluginController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly CompositionHost _compositionHost;
    public PluginController(IMediator mediator, CompositionHost compositionHost)
    {
        _mediator = mediator;
        _compositionHost = compositionHost;
    }

    [HttpGet("getall")]
    public IActionResult GetPlugins()
    {
        return Ok(_compositionHost.GetExports<IPlugin>().Select(p => p.GetName() + " : " + p.GetId()));
    }

    [HttpPost("byid")]
    public IActionResult ExecutePluginById([FromBody] PluginRequest request)
    {
        var plugin = _compositionHost.GetExports<IPlugin>().FirstOrDefault(p => p.GetId() == request.PluginId);
        if (plugin == null)
        {
            return NotFound($"Plugin '{request.PluginId}' not found.");
        }

        return RunPlugin(plugin, request.Parameters);
    }

    [HttpPost("byname")]
    public IActionResult ExecutePluginByName([FromBody] PluginRequest request)
    {
        var plugin = _compositionHost.GetExports<IPlugin>().FirstOrDefault(p => p.GetName().ToLower() == request.PluginName.ToLower());
        if (plugin == null)
        {
            return NotFound($"Plugin '{request.PluginName}' not found.");
        }

        return RunPlugin(plugin, request.Parameters);
    }

    private IActionResult RunPlugin(IPlugin? plugin, Dictionary<string, object> parameters)
    {
        try
        {
            var result = plugin?.DoTheThing(parameters);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
