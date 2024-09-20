using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class GameManager
    {
        public static void Play(GameAccount player1, GameAccount player2, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Rating cannot be negative.", nameof(rating));
            }

            Random random = new Random();
            bool player1Wins = random.Next(2) == 0;

            if (player1Wins)
            {
                GameRepository.AddGame(new Game(player2.Username, player1.Username, rating));
                player1.WinGame(player2.Username, rating);
                player2.LoseGame(player1.Username, rating);
                
            }
            else {
                GameRepository.AddGame(new Game(player1.Username, player2.Username, rating));
                player1.LoseGame(player2.Username, rating);
                player2.WinGame(player1.Username, rating); 
            }
        }

    }
}
