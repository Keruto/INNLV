using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnaekMezz
{
	internal class Apple : GameObject
	{
		private readonly Random _applePlacementRange = new Random();
		private const ConsoleColor Color = ConsoleColor.Green;


		public Apple()
		{
			Symbol = '$';
		}

		public override void Draw()
		{
			Console.ForegroundColor = Color;
			Console.SetCursorPosition(Position.X, Position.Y);
			Console.Write(Symbol);
		}

		public void ReplaceApple(List<Position> snake)
		{
			while (true)
			{
				Position.X = _applePlacementRange.Next(0, Global.BoardWidth);
				Position.Y = _applePlacementRange.Next(0, Global.BoardHeight);
				var isSpotFree = true;

				//Check if any part of snake is on the appleSpawnSpot
				foreach (var snakePart in snake)
				{
					if (snakePart.X == Position.X && snakePart.Y == Position.Y)
					{
						isSpotFree = false;
						break;
					}

				}
				//place apple
				if (isSpotFree)
				{
					Draw();
					Global.IsErasable = false;
					break;
				}
			}
		}
	}
}
