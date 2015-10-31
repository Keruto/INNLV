using System;

namespace SnaekMezz
{
	internal class Apple : GameObject
	{
		private readonly Random _applePlacementRange = new Random();
		private const ConsoleColor Color = ConsoleColor.Green;

		//The apple (re)places itself whenever the GameBoard spawns a new one.
		public Apple()
		{
			X = _applePlacementRange.Next (0, Global.BoardWidth);
			Y = _applePlacementRange.Next (0, Global.BoardHeight);
			Symbol = '$';
			Draw();
		}

		public override sealed void Draw()
		{
			Console.ForegroundColor = Color;
			Console.SetCursorPosition(X, Y);
			Console.Write(Symbol);
		}
	}
}
