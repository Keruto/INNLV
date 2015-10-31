using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnaekMezz
{
	class GameBoard
	{
		private Snake _snake;
		private Apple _apple;

		public GameBoard()
		{
			_snake = new Snake();
			_apple = new Apple();
		}


		public void ReplaceApple()
		{
			if (_snake.AteTheApple)
			{
				_apple = new Apple();
			}
		}

		public void ChangeBoard(ConsoleKey moveKey)
		{
			_snake.ChangeDirection(moveKey);
			_snake.MoveSnake ();
			_snake.CheckForCollision(_apple);
			ReplaceApple();
		}
	}
}
