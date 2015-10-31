using System;
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

		public bool AteTheApple { get; private set; }
		public List<Position> SnakeElements = new List<Position>();
		public Position NewHeadPosition;
		public Position Tail => SnakeElements.First();
		public Position Head => SnakeElements.Last();

		public enum SnakeDirection
		{
			UP,
			RIGHT,
			DOWN,
			LEFT
		};
		public SnakeDirection Direction;

		public Snake()
		{
			Direction = SnakeDirection.DOWN;
			NewHeadPosition = new Position(10, 10);
			for (var i = 0; i < defaultSnakeLength; i++)
			{
				SnakeElements.Add(new Position (10, 10));
			}
		}

		public override void Draw()
		{
			//Tail eraser
			if (!AteTheApple)
			{
				Console.SetCursorPosition (Tail.X, Tail.Y);
				Console.Write (" ");
			}

			//Drawing body
			Console.ForegroundColor = Color;

			foreach (var part in SnakeElements)
			{
				Console.SetCursorPosition (part.X, part.Y);
				Console.Write ("0");
			}

			//Drawing head
			Console.SetCursorPosition (NewHeadPosition.X, NewHeadPosition.Y);
			Console.Write (_headLooks);

		}

		public void ChangeDirection (ConsoleKey moveKey)
		{

			//listeningForInput... "Controller" class maybe?
			if (moveKey == ConsoleKey.UpArrow && Direction != SnakeDirection.DOWN)
				Direction = SnakeDirection.UP;
			else if (moveKey == ConsoleKey.RightArrow && Direction != SnakeDirection.LEFT)
				Direction = SnakeDirection.RIGHT;
			else if (moveKey == ConsoleKey.DownArrow && Direction != SnakeDirection.UP)
				Direction = SnakeDirection.DOWN;
			else if (moveKey == ConsoleKey.LeftArrow && Direction != SnakeDirection.RIGHT)
				Direction = SnakeDirection.LEFT;
		}


		public void MoveSnake()
		{		
			NewHeadPosition = new Position(Head);

			switch (Direction)
			{
				case SnakeDirection.UP:
					NewHeadPosition.Y--;
					break;
				case SnakeDirection.RIGHT:
					NewHeadPosition.X++;
					break;
				case SnakeDirection.DOWN:
					NewHeadPosition.Y++;
					break;
				case SnakeDirection.LEFT:
					NewHeadPosition.X--;
					break;
				default:
					NewHeadPosition.Y += 1;
					break;
			}
			Draw();
		}

		public void CheckForCollision(Apple other)
		{
			//---game over criteria "IsGameOver"?---
			//Wall collision
			if (NewHeadPosition.X < 0 || NewHeadPosition.X >= Global.BoardWidth ||
			    NewHeadPosition.Y < 0 || NewHeadPosition.Y >= Global.BoardHeight)
			{
				Global.IsGameOver = true;
			}


			if (AteTheApple)
			{
				AteTheApple = false;
			}
		
			else
			{ 
				//removing the tail
				Console.SetCursorPosition(Tail.X, Tail.Y);
				Console.Write(" ");
				SnakeElements.RemoveAt (0);

				//doCollisionwith selfCheck
				foreach (var x in SnakeElements)
				{
					// Check for appleCollision
					if (x.X == other.X && x.Y == other.Y)
					{
						AteTheApple = true;
					}
					// Check for death by accidental self-cannibalism.
				/*	if (x.X != NewHeadPosition.X || x.Y != NewHeadPosition.Y) continue;
					Global.IsGameOver = true;
					break;*/
				}
			}


			// Check for appleCollision
			if (NewHeadPosition.X == other.X && NewHeadPosition.Y == other.Y)
			{
				if (SnakeElements.Count + 1 >= Global.BoardWidth * Global.BoardHeight)
					// No more room to place apples -- game over.
					Global.IsGameOver = true;

				else
				{
					AteTheApple = true;
					//other.ReplaceApple(NewHeadPosition, SnakeElements);
				}
			}

			SnakeElements.Add(NewHeadPosition);




		}
	}
}
