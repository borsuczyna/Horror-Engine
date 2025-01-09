namespace MasterList.Core.Models;

/// <summary>
/// Represents a player in the game.
/// </summary>
public class Player
{
    /// <summary>
    /// Gets or sets the username of the player.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class with the specified username.
    /// </summary>
    /// <param name="username">The username of the player.</param>
    public Player(string username)
    {
        Username = username;
    }
}