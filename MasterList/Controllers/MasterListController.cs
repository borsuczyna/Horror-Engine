using MasterList.Controllers.Models;
using MasterList.Core;
using MasterList.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterList.Controllers;

/// <summary>
/// Controller for managing the master list of servers.
/// </summary>
[ApiController]
[Route("/api/master")]
public class MasterListController : Controller
{
    private readonly ILogger<MasterListController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="MasterListController"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    public MasterListController(ILogger<MasterListController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets the list of servers in JSON format.
    /// </summary>
    /// <returns>A JSON string representing the list of servers.</returns>
    [HttpGet]
    public string Get()
    {
        return MasterListManager.GetServersJson();
    }

    /// <summary>
    /// Hosts a new server.
    /// </summary>
    /// <param name="body">The body containing server details.</param>
    [HttpPost("host")]
    public IActionResult Host([FromBody] HostServerBody body)
    {
        var ipAddr = HttpContext.Connection.RemoteIpAddress;
        if (ipAddr == null)
        {
            _logger.LogError("Failed to get remote IP address");
            return new JsonResult(new { status = "error", message = "Failed to get remote IP address" });
        }

        var server = new Server(
            body.Name,
            ipAddr.ToString(),
            body.Port,
            body.Version,
            body.Level,
            body.Password,
            body.Players.Distinct().Take(body.MaxPlayers).ToList(),
            body.MaxPlayers
        );

        var success = MasterListManager.UpdateServer(server);

        if (success == null)
        {
            _logger.LogWarning("Failed to update server: {0}", server.Address);
        }
        else
        {
            _logger.LogInformation("Server updated: {0}", server.Address);
        }

        
        return new JsonResult(new { status = server != null ? "success" : "error" });
    }
}