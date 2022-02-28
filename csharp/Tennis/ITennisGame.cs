namespace Tennis
{
    /// <summary>
    /// Wrapper for the class TennisGame
    /// Used to abstract methods in future unit tests.
    /// </summary>
    public interface ITennisGame
    {
        /// <summary>
        /// Adds a point to the player's score
        /// </summary>
        /// <param name="playerName">Name of the player.</param>
        void WonPoint(string playerName);
        /// <summary>
        /// Gets the game score.
        /// </summary>
        /// <returns>String representing the game score</returns>
        string GetGameScore();
    }
}

