using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Game
    {
        private static int TotalIds = 0;
        public int Id { get; set; }
        public string Winner {  get; set; }
        public string Loser { get; set; }
        public int Rating { get; set; }

        public Game(string winner, string loser, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Rating cannot be negative.", nameof(rating));
            }

            Id = TotalIds;
            Winner = winner;
            Loser = loser;
            Rating = rating;

            TotalIds++;
        }
    }
}
