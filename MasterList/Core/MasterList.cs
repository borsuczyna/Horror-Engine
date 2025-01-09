using MasterList.Core.Models;
using Newtonsoft.Json;

namespace MasterList.Core;

/// <summary>
/// Provides management functionalities for a list of servers.
/// </summary>
public static class MasterListManager
{
    /// <summary>
    /// The interval in seconds after which a server is considered expired.
    /// </summary>
    private const int _timeoutInterval = 120;

    /// <summary>
    /// Gets or sets the list of servers.
    /// </summary>
    private static List<Server> _servers { get; set; } = new();

    private static readonly object _lock = new();

    /// <summary>
    /// Retrieves a server by its address.
    /// </summary>
    /// <param name="address">The address of the server to retrieve.</param>
    /// <returns>The server with the specified address, or null if not found.</returns>
    public static Server? GetServer(string address)
    {
        lock (_lock)
        {
            return _servers.FirstOrDefault(s => s.Address == address);
        }
    }

    /// <summary>
    /// Adds a new server to the list if it does not already exist.
    /// </summary>
    /// <param name="server">The server to add.</param>
    public static bool AddServer(Server server)
    {
        lock (_lock)
        {
            if (GetServer(server.Address) != null)
            {
                return false;
            }

            _servers.Add(server);
            return true;
        }
    }

    /// <summary>
    /// Removes a server from the list.
    /// </summary>
    /// <param name="server">The server to remove.</param>
    public static void RemoveServer(Server server)
    {
        lock (_lock)
        {
            _servers.Remove(server);
        }
    }

    /// <summary>
    /// Updates the player information of an existing server.
    /// </summary>
    /// <param name="server">The server with updated information.</param>
    public static Server? UpdateServer(Server server)
    {
        lock (_lock)
        {
            if (GetServer(server.Address) == null)
            {
                AddServer(server);
            }

            var existingServer = GetServer(server.Address);
            if (existingServer == null)
            {
                return null;
            }

            existingServer.Update(server);
            return existingServer;
        }
    }

    /// <summary>
    /// Updates the list of servers by removing expired servers.
    /// </summary>
    public static void UpdateExpiredServers()
    {
        lock (_lock)
        {
            var expiredServers = _servers.Where(s => s.IsExpired(_timeoutInterval)).ToList();
            foreach (var server in expiredServers)
            {
                _servers.Remove(server);
            }
        }
    }

    /// <summary>
    /// Gets the list of servers in JSON format.
    /// </summary>
    /// <returns>A JSON string representing the list of servers.</returns>
    public static string GetServersJson()
    {
        lock (_lock)
        {
            UpdateExpiredServers();
            return JsonConvert.SerializeObject(_servers.Select(s => s.ToJson()));
        }
    }
}