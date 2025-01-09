namespace MasterList.Controllers.Models;

/// <summary>
/// Represents the body of a host server with its properties and configuration.
/// </summary>
public class HostServerBody
{
    /// <summary>
    /// Gets or sets the name of the host server.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the port number on which the host server is running.
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// Gets or sets the version of the host server.
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    /// Gets or sets the level or map that the host server is running.
    /// </summary>
    public string Level { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the host server is password protected.
    /// </summary>
    public bool Password { get; set; }

    /// <summary>
    /// Gets or sets the list of players currently connected to the host server.
    /// </summary>
    public List<string> Players { get; set; } = new();

    /// <summary>
    /// Gets or sets the maximum number of players that can connect to the host server.
    /// </summary>
    public int MaxPlayers { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HostServerBody"/> class with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the host server.</param>
    /// <param name="port">The port number on which the host server is running.</param>
    /// <param name="version">The version of the host server.</param>
    /// <param name="level">The level or map that the host server is running.</param>
    /// <param name="password">A value indicating whether the host server is password protected.</param>
    public HostServerBody(string name, int port, string version, string level, bool password)
    {
        Name = name;
        Port = port;
        Version = version;
        Level = level;
        Password = password;
    }
}