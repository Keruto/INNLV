using System;
using System.Diagnostics;

namespace SnaekMezz
{

	internal class Game
	{


		private static void Main(string[] args)
		{
			//Sm.Maine();
			var timer = new Stopwatch ();
			var snake = new Snake();
			var apple = new Apple();
			Console.CursorVisible = false;
			Console.Title = "SNAKE";
			snake.Draw ();
			apple.ReplaceApple (snake.SnakeElements);

			while (true)
			{
				if (Global.IsGameOver)
				{
					return;
				}

				timer.Stop();
				timer.Start();

				snake.ListenForInput ();



				if (!Global.IsPaused)
				{

					if (timer.ElapsedMilliseconds < 100)
					{
						continue;
					}
					timer.Restart();

					snake.MoveHead();
					snake.CheckForCollision(apple);
					snake.Draw();

					if (!Global.IsErasable)
					{
						apple.Draw();
						Global.IsErasable = true;
					}
				}
			}
		}
	}
}
