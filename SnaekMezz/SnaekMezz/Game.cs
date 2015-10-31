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

			var gameBoard = new GameBoard();				//Is responsible for placing and updating the game objects.
			var inputReader = new InputReader();			//reads the player's keyboard input.
			var timer = new Stopwatch ();					//Is used to keep the frame rate consistent.
			const int updateDelay = 100;					//Snake moves faster with lower numbers.

			ResetGlobals ();

			//snake.Draw ();



			timer.Start ();

			while (!Global.IsGameOver)
			{
				var moveKey = inputReader.GetInput();

				if (!Global.IsPaused)
				{
					if (timer.ElapsedMilliseconds < updateDelay)
					{
						continue;
					}

					timer.Restart();

					gameBoard.ChangeBoard(moveKey);
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
