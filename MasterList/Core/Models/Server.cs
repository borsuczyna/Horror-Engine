using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MasterList.Core.Models;

/// <summary>
/// Represents a game server with various properties such as name, IP, port, version, level, and player information.
/// </summary>
[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class Server
{
    /// <summary>
    /// Gets or sets the name of the server.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the IP address of the server.
    /// </summary>
    public string Ip { get; set; }

    /// <summary>
    /// Gets or sets the port number of the server.
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// Gets or sets the list of players currently on the server.
    /// </summary>
    public List<string> Players { get; set; } = new();

    /// <summary>
    /// Gets or sets the maximum number of players allowed on the server.
    /// </summary>
    public int MaxPlayers { get; set; }

    /// <summary>
    /// Gets or sets the version of the server.
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    /// Gets or sets the level or map currently being played on the server.
    /// </summary>
    public string Level { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the server is password protected.
    /// </summary>
    public bool Password { get; set; }

    /// <summary>
    /// Gets the full address of the server in the format "IP:Port".
    /// </summary>
    public string Address => $"{Ip}:{Port}";

    /// <summary>
    /// Gets the last update time of the server.
    /// </summary>
    public DateTime LastUpdate { get; set; } = DateTime.Now;

    /// <summary>
    /// Initializes a new instance of the <see cref="Server"/> class with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the server.</param>
    /// <param name="ip">The IP address of the server.</param>
    /// <param name="port">The port number of the server.</param>
    /// <param name="version">The version of the server.</param>
    /// <param name="level">The level or map currently being played on the server.</param>
    /// <param name="password">A value indicating whether the server is password protected.</param>
    public Server(string name, string ip, int port, string version, string level, bool password, List<string> players, int maxPlayers)
    {
        Name = name;
        Ip = ip;
        Port = port;
        Version = version;
        Level = level;
        Password = password;
        Players = players;
        MaxPlayers = maxPlayers;
    }

    /// <summary>
    /// Updates the server information with the specified server object.
    /// </summary>
    /// <param name="server">The server object with updated information.</param>
    public void Update(Server server)
    {
        Name = server.Name;
        Ip = server.Ip;
        Port = server.Port;
        Version = server.Version;
        Level = server.Level;
        Password = server.Password;
        Players = server.Players;
        MaxPlayers = server.MaxPlayers;
        LastUpdate = DateTime.Now;
    }

    /// <summary>
    /// Determines whether the server is expired based on the specified timeout.
    /// </summary>
    public bool IsExpired(int timeout)
    {
        return DateTime.Now.Subtract(LastUpdate).TotalSeconds > timeout;
    }

    /// <summary>
    /// Returns a string that represents the current server.
    /// </summary>
    /// <returns>A string that represents the current server.</returns>
    public override string ToString()
    {
        return $"{Name} - {Address}";
    }

    /// <summary>
    /// Converts the current server object to its JSON representation.
    /// </summary>
    /// <returns>A JSON string representation of the current server object.</returns>
    public object ToJson()
    {
        return new {
            name = Name,
            ip = Ip,
            port = Port,
            version = Version,
            level = Level,
            password = Password,
            players = Players.Count,
            maxPlayers = MaxPlayers
        };
    }
}