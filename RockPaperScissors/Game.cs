using System;
namespace RockPaperScissors
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        private int _rounds;

        public Game(Player player1, Player player2, int rounds)
        {
            _player1 = player1;
            _player2 = player2;
            _rounds = rounds;
        }

        public void Start()
        {
            for (int i = 0; i < _rounds; i++)
            {
                Player roundWinner = null;
                do
                {
                    roundWinner = PlayRound();

                    if (roundWinner != null)
                    {
                        Console.WriteLine($"{roundWinner.Name} wins");
                        roundWinner.AddWin();
                    }
                }
                while (roundWinner == null);
            }

            if (_player1.Wins > _player2.Wins)
            {
                Console.WriteLine($"{_player1.Name} has won more games");
            }
            else if (_player2.Wins > _player1.Wins)
            {
                Console.WriteLine($"{_player2.Name} has won more games");
            }
            else
            {
                Console.WriteLine("They have won the same number of games");
            }
        }

        /// <summary>
        /// Play round, return the winner. If the round is a tie or invalid input is find, retur null
        /// </summary>
        /// <returns>The winner, null if there's no winner</returns>
        private Player PlayRound()
        {
            Play play1 = _player1.GetPlay();
            Play play2 = _player2.GetPlay();

            if (play1 == Play.Invalid || play2 == Play.Invalid)
            {
                Console.WriteLine("Invalid input");
                return null;
            }

            int winner = GetWinner(play1, play2);
            if (winner == 0)
            {
                Console.WriteLine("Nobody wins");
                return null;
            }
            else if (winner == -1)
            {
                return _player1;
            }
            else
            {
                return _player2;
            }
        }

        /// <summary>
        /// Gets the winner.
        /// </summary>
        /// <returns>-1 if play1 wins, 1 if play2 wins, 0 if a tie <returns>
        /// <param name="play1">Play1.</param>
        /// <param name="play2">Play2.</param>
        private int GetWinner(Play play1, Play play2)
        {
            if (play1 == play2)
            {
                return 0;
            }
            if (
                (play1 == Play.Rock && play2 == Play.Scissors)
                || (play1 == Play.Scissors && play2 == Play.Paper)
                || (play1 == Play.Paper && play2 == Play.Rock)
               )

            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
