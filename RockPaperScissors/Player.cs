using System;
namespace RockPaperScissors
{
    public class Player
    {
        public string Name { get; }

        private int _wins;
        public int Wins 
        { 
            get
            {
                return _wins;
            } 
        }

        public Player(string name)
        {
            Name = name;
            _wins = 0;
        }

        public Play GetPlay()
        {
            string textInput = Prompt($"{this.Name} enter 1 for Rock, 2 for Paper, 3 for Scissors");

            if (!Int32.TryParse(textInput, out int number))
            {
                return Play.Invalid;
            }

            if (number < 1 || number > 3)
            {
                return Play.Invalid;
            }

            return (Play)number;
        }

        public void AddWin()
        {
            _wins++;
        }

		private string Prompt(string text)
		{
			Console.WriteLine(text);
			return Console.ReadLine();
		}
    }
}
