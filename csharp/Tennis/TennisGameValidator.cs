using System;

namespace Tennis
{
    /// <summary>
    /// This is a validator to ensure a valid TennisGame is created.
    /// </summary>
    /// <seealso cref="Tennis.ITennisGameValidator" />
    public class TennisGameValidator : ITennisGameValidator
    {
        /// <summary>
        /// Validates the player names.
        /// Player names cannot match, be null or whitespace.
        /// </summary>
        /// <param name="player1Name"></param>
        /// <param name="player2Name"></param>
        /// <exception cref="Exception">Player names must not match.</exception>
        /// <exception cref="ArgumentNullException">
        /// player1Name must not be null or whitespace or
        /// player2Name must not be null or whitespace
        /// </exception>
        public void ValidatePlayerNames(string player1Name, string player2Name)
        {
            if (player1Name == player2Name) throw new Exception("Player names must not match.");
            if (String.IsNullOrWhiteSpace(player1Name)) throw new ArgumentNullException();
            if (String.IsNullOrWhiteSpace(player2Name)) throw new ArgumentNullException();
        }
    }
}
