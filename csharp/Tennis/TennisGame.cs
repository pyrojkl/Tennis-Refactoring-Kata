using System;
using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
    /// <summary>
    /// Main class for running a tennis game.
    /// </summary>
    /// <seealso cref="Tennis.ITennisGame" />
    class TennisGame : ITennisGame
    {

        readonly TennisPlayer _player1, _player2;

        /// <summary>
        /// Initializes a new instance of the <see cref="TennisGame"/> class.
        /// Validates the parameters using <see cref="TennisGameValidator"/> class.
        /// </summary>
        /// <param name="player1Name">Name of player1 used to create a new <see cref="TennisPlayer"/></param>
        /// <param name="player2Name">Name of player2 used to create a new <see cref="TennisPlayer"/></param>
        public TennisGame(string player1Name, string player2Name)
        {
            TennisGameValidator validator = new TennisGameValidator();
            validator.ValidatePlayerNames(player1Name, player2Name);
            _player1 = new TennisPlayer() { PlayerName = player1Name };
            _player2 = new TennisPlayer() { PlayerName = player2Name };
        }

        /// <summary>
        /// Adds a point to the player's score.
        /// </summary>
        /// <param name="playerName">Name of the player whose score will increase by 1</param>
        /// <exception cref="Exception">Player: {playerName} does not exist.</exception>
        public void WonPoint(string playerName)
        {
            if (_player1.PlayerName == playerName)
                _player1.Score++;
            else if (_player2.PlayerName == playerName)
                _player2.Score++;
            else
                throw new Exception($"Player: {playerName} does not exist.");
        }

        /// <summary>
        /// Gets the game score.
        /// Scoring Rules Overview:
        ///     Score is tied:
        ///         Returns "Deuce" or "{ScoreTerm}-All"
        ///     Score is 4+ points (and not tied)
        ///         "Advantage {winningPlayer}" or "Win for {winningPlayer}"
        ///     Default (Score is 3 or less and not tied)
        ///         Returns "{ScoreTerm}-{ScoreTerm}"   
        ///         <see cref="GetScoreTerms"/> for details.
        /// </summary>
        /// <returns>
        /// String representing the game score.
        /// </returns>
        public string GetGameScore()
        {
            // Score is tied
            //      3+ points is a "Deuce"
            //      0-2 points is "{ScoreTerm}-All"
            // Highest Score is 4+
            //      winningPlayer - select the playerName with the highest score
            //      score difference is 1 point
            //          "Advantage {winningPlayer}"
            //      score difference is 2+ points
            //          "Win for {winningPlayer}"
            // Default
            //       0-3 points and not tied is "{ScoreTerm}-{ScoreTerm}" 
            string score = "";
            if (_player1.Score == _player2.Score)
            {
                score = _player1.Score > 2 ? "Deuce" : $"{GetScoreTerms(_player1)}-All";
            }
            else if (Math.Max(_player1.Score, _player2.Score) >= 4)
            {
                var playerList = new List<TennisPlayer>() {_player1, _player2};
                string winningPlayer = playerList.OrderByDescending(p => p.Score).First().PlayerName;
                if (Math.Abs(_player1.Score - _player2.Score) == 1) score = $"Advantage {winningPlayer}";
                else if (Math.Abs(playerList.Sum(p => p.Score)) >= 2) score = $"Win for {winningPlayer}";
            }
            else
            {
                score = $"{GetScoreTerms(_player1)}-{GetScoreTerms(_player2)}";
            }

            return score;
        }

        /// <summary>
        /// Gets the score terms for a given TennisPlayer's score.
        /// Scoring Translation Rules:
        ///     0 points - "Love"
        ///     1 point  - "Fifteen"
        ///     2 points - "Thirty"
        ///     3 points - "Forty"
        ///     4+ points results should result in another type. <see cref="GetGameScore"/> for details.
        ///         This also results in an exception and GetScoreTerms should not be called
        ///         when the score is greater than 3.
        /// </summary>
        /// <param name="player">The TennisPlayer whose score is translated.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Invalid score for Player: {player.PlayerName}</exception>
        private string GetScoreTerms(TennisPlayer player)
        {
            switch (player.Score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    throw new Exception($"Invalid score for Player: {player.PlayerName}");
            }
        }
    }
}

