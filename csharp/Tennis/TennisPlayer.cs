namespace Tennis
{
    /// <summary>
    /// This is the TennisPlayer object used to create players for <see cref="TennisGame"/>.
    /// Stores a name and a score.
    /// </summary>
    public class TennisPlayer
    {
        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The player's score, defaults to 0.
        /// </value>
        public int Score { get; set; }
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        /// <value>
        /// The name of the player.
        /// </value>
        public string PlayerName { get; set; }
    }
}
