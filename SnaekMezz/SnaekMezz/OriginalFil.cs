using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnaekMezz
{
	//Position class to give objects positions.
	class Pos
	{
		public const string Ok = "Ok"; //what does this do?
		public int X; public int Y;

		public Pos(int x = 0, int y = 0)
		{
			X = x;
			Y = y;
		}

		public Pos(Pos input)
		{
			X = input.X;
			Y = input.Y;
		}
	}

	class Sm
	{
		//public static void Main(string[] arguments)
		//Game.cs runs Sm.Maine()
        public static void Maine()
		{
			//Game and board setup
	        bool gameOver = false;
	        bool isPaused = false;
			bool inUse = false;
			short direction= 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = direction;
			int boardW = Console.WindowWidth, boardH = Console.WindowHeight;
			Random rng = new Random();
			Console.CursorVisible = false;
			Console.Title = "SNAKE";

			//CreateSnake()
			var snake = new List<Pos>();
			snake.Add(new Pos(10, 10));
			snake.Add(new Pos(10, 10));
			snake.Add(new Pos(10, 10));
			snake.Add(new Pos(10, 10));
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition (10, 10); Console.Write ("@");

			//SpawnApple()
			var apple = new Pos ();

			// Apple placement. Loop forever until "break;".
			while (true)
			{
				//part of spawnApple
				apple.X = rng.Next(0, boardW);
				apple.Y = rng.Next(0, boardH);
				bool isSpotFree = true;

				//Check if any part of snake is on the appleSpawnSpot
				foreach (Pos i in snake)
				{
					if (i.X == apple.X && i.Y == apple.Y)
					{
						isSpotFree = false;
						break;
					}
				}

				//place apple
				if (isSpotFree) {
					Console.ForegroundColor = ConsoleColor.Green;
					Console.SetCursorPosition(apple.X, apple.Y);
					Console.Write("$");
					break;
				}
			}

			//Start timer.
			Stopwatch timer = new Stopwatch();
			timer.Start();

			//listeningForInput... "Controller" class maybe?
			while (!gameOver) {
				if (Console.KeyAvailable) {
					var cki = Console.ReadKey(true);
					if (cki.Key == ConsoleKey.Escape)
						gameOver = true;
					else if (cki.Key == ConsoleKey.Spacebar)
						isPaused = !isPaused;
					else if (cki.Key == ConsoleKey.UpArrow && last != 2)
						direction = 0;
					else if (cki.Key == ConsoleKey.RightArrow && last != 3)
						direction = 1;
					else if (cki.Key == ConsoleKey.DownArrow && last != 0)
						direction = 2;
					else if (cki.Key == ConsoleKey.LeftArrow && last != 1)
						direction = 3;
				}
				if (!isPaused) {
					if (timer.ElapsedMilliseconds < 100)
						continue;
					timer.Restart();
					var tail = new Pos(snake.First());
					var head = new Pos(snake.Last());
					var newH = new Pos(head);
					switch (direction) {
						case 0:
							newH.Y -= 1;
							break;
						case 1:
							newH.X += 1;
							break;
						case 2:
							newH.Y += 1;
							break;
						default:
							newH.X -= 1;
							break;
					}

					//game over criteria "isGameOver"-function?
					if (newH.X < 0 || newH.X >= boardW)
						gameOver = true;
					else if (newH.Y < 0 || newH.Y >= boardH)
						gameOver = true;
					if (newH.X == apple.X && newH.Y == apple.Y)
					{
						if (snake.Count + 1 >= boardW * boardH)
							// No more room to place apples -- game over.
							gameOver = true;

						else {
							while (true)
							{
								//More apple placement
								apple.X = rng.Next(0, boardW); apple.Y = rng.Next(0, boardH);
								bool found = true;
								foreach (Pos i in snake)
									if (i.X == apple.X && i.Y == apple.Y)
									{
										found = false;
										break;
									}
								if (found)
								{
									inUse = true;
									break;
								}
							}
						}
					}
					//check if space is free for the snake
					if (!inUse) {
						snake.RemoveAt(0);

						//doCollisionwith selfCheck
						foreach (Pos x in snake)
						{
							if (x.X == newH.X && x.Y == newH.Y)
							{
								// Death by accidental self-cannibalism.
								gameOver = true;
								break;
							}
						}
					}
					//Draw new graphics
					if (!gameOver) {
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(head.X, head.Y);
						Console.Write("0");
						if (!inUse) {
							Console.SetCursorPosition(tail.X, tail.Y);
							Console.Write(" ");
						} else {
							Console.ForegroundColor = ConsoleColor.Green;
							Console.SetCursorPosition(apple.X, apple.Y);
							Console.Write("$");
							inUse = false;
						}
						snake.Add(newH);
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(newH.X, newH.Y);
						Console.Write("@");
						last = direction;
					}
				}
			}
		}
	}
}