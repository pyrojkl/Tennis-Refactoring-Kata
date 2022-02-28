using System;
using NUnit.Framework;

namespace Tennis
{
    public class TennisGameTest
    {
        /// <summary>
        /// Checks the <see cref="TennisGame"/> to see if it properly scores a list of test cases.
        /// </summary>
        /// <param name="player1Score">The player1 score.</param>
        /// <param name="player2Score">The player2 score.</param>
        /// <param name="expectedScore">The expected score.</param>
        [TestCase( 0,  0, "Love-All")]
        [TestCase( 1,  1, "Fifteen-All")]
        [TestCase( 2,  2, "Thirty-All")]
        [TestCase( 3,  3, "Deuce")]
        [TestCase( 4,  4, "Deuce")]
        [TestCase( 1,  0, "Fifteen-Love")]
        [TestCase( 0,  1, "Love-Fifteen")]
        [TestCase( 2,  0, "Thirty-Love")]
        [TestCase( 0,  2, "Love-Thirty")]
        [TestCase( 3,  0, "Forty-Love")]
        [TestCase( 0,  3, "Love-Forty")]
        [TestCase( 4,  0, "Win for player1")]
        [TestCase( 0,  4, "Win for player2")]
        [TestCase( 2,  1, "Thirty-Fifteen")]
        [TestCase( 1,  2, "Fifteen-Thirty")]
        [TestCase( 3,  1, "Forty-Fifteen")]
        [TestCase( 1,  3, "Fifteen-Forty")]
        [TestCase( 4,  1, "Win for player1")]
        [TestCase( 1,  4, "Win for player2")]
        [TestCase( 3,  2, "Forty-Thirty")]
        [TestCase( 2,  3, "Thirty-Forty")]
        [TestCase( 4,  2, "Win for player1")]
        [TestCase( 2,  4, "Win for player2")]
        [TestCase( 4,  3, "Advantage player1")]
        [TestCase( 3,  4, "Advantage player2")]
        [TestCase( 5,  4, "Advantage player1")]
        [TestCase( 4,  5, "Advantage player2")]
        [TestCase(15, 14, "Advantage player1")]
        [TestCase(14, 15, "Advantage player2")]
        [TestCase( 6,  4, "Win for player1")]
        [TestCase( 4,  6, "Win for player2")]
        [TestCase(16, 14, "Win for player1")]
        [TestCase(14, 16, "Win for player2")]
        public void CheckTennisGame(int player1Score, int player2Score, string expectedScore)
        {
            var game = new TennisGame("player1", "player2");

            var highestScore = Math.Max(player1Score, player2Score);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < player1Score)
                    game.WonPoint("player1");
                if (i < player2Score)
                    game.WonPoint("player2");
            }
            Assert.AreEqual(expectedScore, game.GetGameScore());
        }

        /// <summary>
        /// Validates the game score while simulating a real tennis game with predefined values.
        /// </summary>
        [Test]
        public void CheckRealisticGame()
        {
            var game = new TennisGame("player1", "player2");

            string[] points = { "player1", "player1", "player2", "player2", "player1", "player1" };
            string[] expectedScores = { "Fifteen-Love", "Thirty-Love", "Thirty-Fifteen", "Thirty-All", "Forty-Thirty", "Win for player1" };

            for (var i = 0; i < 6; i++)
            {
                game.WonPoint(points[i]);
                Assert.AreEqual(expectedScores[i], game.GetGameScore());
            }
        }

        /// <summary>
        /// Checks WonPoint method to ensure a playerName exists in order to win a point.
        /// </summary>
        [Test]
        public void CheckWonPointNameExistsException()
        {
            var game = new TennisGame("name1", "name2");
            Assert.Throws<Exception>(() => game.WonPoint(null));
        }

        /// <summary>
        /// Checks the list of test cases to ensure the expected exceptions occur when
        /// using the TennisGameValidator.
        /// </summary>
        /// <param name="name1">Player name1.</param>
        /// <param name="name2">Player name2.</param>
        /// <param name="exType">The Exception type.</param>
        [TestCase("name1", "name1", typeof(Exception))]
        [TestCase(null, "name2", typeof(ArgumentNullException))]
        [TestCase("name1", null, typeof(ArgumentNullException))]
        [TestCase("", "name2", typeof(ArgumentNullException))]
        [TestCase("   ", "name2", typeof(ArgumentNullException))]
        [TestCase("name1", "", typeof(ArgumentNullException))]
        [TestCase("name1", "   ", typeof(ArgumentNullException))]
        [Test]
        public void CheckTennisGameValidatorExceptions(string name1, string name2, Type exType)
        {
            var tennisGameValidator = new TennisGameValidator();
            Assert.Throws(exType, () => tennisGameValidator.ValidatePlayerNames(name1, name2));
        }
    }
}