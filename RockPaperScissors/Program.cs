using System;

namespace RockPaperScissors
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Player jack = new Player("Jack");
            Player jill = new Player("Jill");

            Console.WriteLine("Number of Games:");
            int rounds = Int32.Parse(Console.ReadLine());

            Game game = new Game(jack, jill, rounds);
            game.Start();
        }
    }
}
