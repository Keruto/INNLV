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
			var inputReader = new InputReader();			//Reads the player's keyboard input.
			var timer = new Stopwatch ();					//Is used to keep the frame rate consistent.
			const int updateDelay = 100;					//Snake moves faster with lower numbers.

			//Reset static global variables. 
			ResetGlobals ();

			//Start counting for the first frame.
			timer.Start ();


			//Start game loop
			while (!Global.IsGameOver)
			{
				var moveKey = inputReader.GetInput();

				//Skips over this section if game is paused with spacebar.
				if (!Global.IsPaused)
				{
					if (timer.ElapsedMilliseconds < updateDelay)
					{
						continue;
					}

					//Recalculate and redraw snake and apple positions
					gameBoard.ChangeBoard(moveKey);

					//reset timer for next frame.
					timer.Restart ();
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
