namespace Tennis
{
    /// <summary>
    /// Wrapper for the class TennisGameValidator
    /// Used to abstract methods in future unit tests.
    /// </summary>
    public interface ITennisGameValidator
    {
        /// <summary>
        /// Validates the player names.
        /// Player names cannot match, be null or whitespace.
        /// </summary>
        void ValidatePlayerNames(string player1Name, string player2Name);
    }
}
