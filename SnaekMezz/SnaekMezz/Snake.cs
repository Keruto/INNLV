﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnaekMezz
{
	class Snake : GameObject
	{
		private const short defaultSnakeLength = 4;
		public const char _headLooks = '@';
		public const char _bodyLooks = '0';
		private const ConsoleColor Color = ConsoleColor.Yellow;
		public List<Position> SnakeElements = new List<Position>();
		public Position NewHeadPosition;
		public Position Tail;
		public Position Head;
        short direction = 2; // 0 = up, 1 = right, 2 = down, 3 = left
		short lastDirection;

		public Snake()
		{
			NewHeadPosition = new Position(10, 10);
			Tail = new Position(10, 10);
			Head = new Position(10, 10);
			var lastDirection = direction;
			for (var i = 0; i < defaultSnakeLength; i++)
			{
				SnakeElements.Add(new Position (10, 10));
			}
		}

		public override void Draw()
		{
			Console.ForegroundColor = Color;
			Console.SetCursorPosition (Position.X, Position.Y);
			Console.Write (_bodyLooks);

			if (Global.IsErasable)
			{
				Console.SetCursorPosition (Tail.X, Tail.Y);
				Console.Write (" ");
			}

			SnakeElements.Add (NewHeadPosition);
			Console.SetCursorPosition (NewHeadPosition.X, NewHeadPosition.Y);
			Console.Write (_headLooks);
			lastDirection = direction;

		}

		public void ListenForInput ()
		{

			//listeningForInput... "Controller" class maybe?

				if (Console.KeyAvailable)
				{
					var cki = Console.ReadKey (true);
					if (cki.Key == ConsoleKey.Escape)
						Global.IsGameOver = true;
					else if (cki.Key == ConsoleKey.Spacebar)
						Global.IsPaused = !Global.IsPaused;
					else if (cki.Key == ConsoleKey.UpArrow && lastDirection != 2)
						direction = 0;
					else if (cki.Key == ConsoleKey.RightArrow && lastDirection != 3)
						direction = 1;
					else if (cki.Key == ConsoleKey.DownArrow && lastDirection != 0)
						direction = 2;
					else if (cki.Key == ConsoleKey.LeftArrow && lastDirection != 1)
						direction = 3;
				}
		}


		public void MoveHead()
		{
			Tail = new Position (SnakeElements.First ());
			Head = new Position (SnakeElements.Last ());
			NewHeadPosition = new Position (Head);

			switch (direction)
			{
				case 0:
					NewHeadPosition.Y -= 1;
					break;
				case 1:
					NewHeadPosition.X += 1;
					break;
				case 2:
					NewHeadPosition.Y += 1;
					break;
				default:
					NewHeadPosition.X -= 1;
					break;
			}
		}

		public void CheckForCollision(Apple other)
		{
			//game over criteria "isGameOver"-function?
			if (NewHeadPosition.X < 0 || NewHeadPosition.X >= Global.BoardWidth)
				Global.IsGameOver = true;
			else if (NewHeadPosition.Y < 0 || NewHeadPosition.Y >= Global.BoardHeight)
				Global.IsGameOver = true;

			SnakeElements.RemoveAt(0);

			//doCollisionwith selfCheck
			foreach (Position x in SnakeElements)
			{
				if (x.X == NewHeadPosition.X && x.Y == NewHeadPosition.Y)
				{
					// Death by accidental self-cannibalism.
					Global.IsGameOver = true;
					break;
				}
			}



			if (NewHeadPosition.X == other.Position.X && NewHeadPosition.Y == other.Position.Y)
			{
				if (SnakeElements.Count + 1 >= Global.BoardWidth * Global.BoardHeight)
					// No more room to place apples -- game over.
					Global.IsGameOver = true;

				else
				{
						other.ReplaceApple(SnakeElements);
				}
			}




		}
	}
}