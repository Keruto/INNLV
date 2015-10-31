using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnaekMezz
{
	class InputReader
	{
		private ConsoleKey _cki;

		public InputReader()
		{
			
		}

		public ConsoleKey GetInput()
		{
			ReadInput();
			return _cki;
		}

		private void ReadInput()
		{

			//listeningForInput... "Controller" class maybe?

			if (!Console.KeyAvailable) return;
			var cki = Console.ReadKey (true);
			switch (cki.Key)
			{
				case ConsoleKey.Escape:
					Global.IsGameOver = true;
					break;
				case ConsoleKey.Spacebar:
					Global.IsPaused = !Global.IsPaused;
					break;
				case ConsoleKey.UpArrow:
					_cki = cki.Key;
					break;
				case ConsoleKey.RightArrow:
					_cki = cki.Key;
					break;
				case ConsoleKey.DownArrow:
					_cki = cki.Key;
					break;
				case ConsoleKey.LeftArrow:
					_cki = cki.Key;
					break;
			}
		}
	}
}
