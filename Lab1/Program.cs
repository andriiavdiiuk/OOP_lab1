using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            GameAccount Player1 = new GameAccount("Player 1", 1000);
            GameAccount Player2 = new GameAccount("Player 2", 1000);
            GameAccount Player3 = new GameAccount("Player 3", 1000);
            Random rand = new Random();

            for (int i = 0; i < 20; i++) 
            {
                GameManager.Play(Player1, Player2, rand.Next(10, 100));
                GameManager.Play(Player1, Player3, rand.Next(10, 100));
                GameManager.Play(Player2, Player3, rand.Next(10, 100));
            }

            Console.WriteLine(Player1.GetStats());
            Console.WriteLine(Player2.GetStats());
            Console.WriteLine(Player3.GetStats());

            Console.WriteLine(GameRepository.GetStats());
        }
    }
}
