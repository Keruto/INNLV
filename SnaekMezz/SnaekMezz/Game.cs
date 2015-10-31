using System;
using System.Diagnostics;

namespace SnaekMezz
{

	internal class Game
	{


		private static void Main(string[] args)
		{

			Console.Title = "SNAKE";
			Console.CursorVisible = false;

			var gameBoard = new GameBoard();
			var inputReader = new InputReader();
			var timer = new Stopwatch ();
			int snakeSpeed = 100;
			ConsoleKey _moveKey;

			ResetGlobals ();

			//snake.Draw ();



			timer.Start ();

			while (!Global.IsGameOver)
			{

				//timer.Stop();


				_moveKey = inputReader.GetInput();



				if (!Global.IsPaused)
				{

					if (timer.ElapsedMilliseconds < snakeSpeed)
					{
						continue;
					}

					timer.Restart();

					gameBoard.ChangeBoard(_moveKey);

				/*	snake.MoveSnake();
					snake.CheckForCollision(apple);
					snake.Draw();*/

/*					if (!Global.IsErasable)
					{
						apple.Draw();
						Global.IsErasable = true;
					}*/
				}
			}
		}

		public static void ResetGlobals()
		{
			Global.IsGameOver = false;
			Global.IsPaused = false;
		}
	}
}
