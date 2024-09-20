using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class GameAccount
    {
        private int _currentRating = 1;
        public string Username { get; private set; }
        public int CurrentRating 
        { 
            get
            {
                return _currentRating;
            }
            private set
            {
                if (value < 1)
                {
                    _currentRating = 1;
                }
                else
                {
                    _currentRating = value;
                }
            }
        }
        public int GamesCount 
        {
            get 
            {
                return GameRepository.GetHistory(Username).Count;
            }
        }

        public GameAccount(string username, int baseRating)
        {
            Username = username;
            CurrentRating = baseRating;
        }

        public void WinGame(string opponentName, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Rating cannot be negative.", nameof(rating));
            }
            CurrentRating += rating;
        }

        public void LoseGame(string opponentName, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Rating cannot be negative.", nameof(rating));
            }

            CurrentRating -= rating;
        }
        public string GetStats()
        {
            string result = $"{Username}\n";
            result += $"Current Rating: {CurrentRating}\n";
            result += $"Games Count: {GamesCount}\n";
            result += "-------------------------------------------\n";
            result += $"|{"Opponent",-12} | {"Win/Lost",-10} | {"Rating",-6} | {"Id",-4}|\n";
            result += "-------------------------------------------\n";
            string opponent = "";
            string winLost = "";
            List<Game> history = GameRepository.GetHistory(Username);
            foreach (Game game in history) 
            {
                if (game.Winner == Username)
                {
                    opponent = game.Loser;
                    winLost = "Win";
                }
                else
                {
                    opponent = game.Winner;
                    winLost = "Lost";
                }

                result += $"|{opponent,-12} | {winLost,-10} | {game.Rating,-6} | {game.Id,-4}|\n";
            };
            result += "-------------------------------------------\n";

            return result;
        }
    }
}
