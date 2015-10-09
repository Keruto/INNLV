using System;
using System.Diagnostics;

namespace SnaekMezz
{

	internal class Game
	{


		private static void Main(string[] args)
		{
			//Sm.Maine();

			var snake = new Snake();
			var apple = new Apple();
			Console.CursorVisible = false;
			Console.Title = "SNAKE";


			while (true)
			{
				snake.Draw();
				if (Global.IsGameOver)
				{
					return;
				}
				apple.ReplaceApple(snake.SnakeElements);

				var timer = new Stopwatch();
				timer.Start();

				snake.ListenForInput();

				if (Global.IsPaused)
				{
					continue;
				}
				if (timer.ElapsedMilliseconds < 100)
				{
					continue;
				}
				timer.Restart ();


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
