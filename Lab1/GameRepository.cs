using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class GameRepository
    {
        private static List<Game> GameHistory = new List<Game>();

        public static void AddGame(Game game)
        {
            GameHistory.Add(game);
        }

        public static List<Game> GetHistory(string player)
        {
            return GameHistory
                    .Where(game => game.Winner == player || game.Loser == player)
                    .ToList();
        }

        public static string GetStats()
        {
            string result = "All Games:\n";
            result += "-----------------------------------------\n";
            result += $"|{"Winner",-12} | {"Loser",-8} | {"Rating",-6} | {"Id",-4}|\n";
            result += "-----------------------------------------\n";
            foreach (Game game in GameHistory)
            {

                result += $"|{game.Winner,-12} | {game.Loser} | {game.Rating,-6} | {game.Id,-4}|\n";
            };
            result += "-----------------------------------------\n";

            return result;
        }
    }
}
