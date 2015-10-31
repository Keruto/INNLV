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


//<--------- put this somewhere else ------->
		/*public void ReplaceApple(Position snakeHead, List<Position> snakeBody)
		{
			while (true)
			{
				X = _applePlacementRange.Next(0, Global.BoardWidth);
				Y = _applePlacementRange.Next(0, Global.BoardHeight);
				var isSpotFree = true;

				//Check if any part of snake is on the appleSpawnSpot
				if (snakeHead.X == X && snakeHead.Y == Y)
				{
					isSpotFree = false;
				}

				foreach (var snakePart in snakeBody)
				{
					if (snakePart.X == X && snakePart.Y == Y)
					{
						isSpotFree = false;
						break;
					}

				}
			}
		}*/
	}
}
