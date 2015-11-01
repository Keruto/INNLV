using System;
using System.Collections.Generic;
using System.Linq;

namespace SnaekMezz
{
	class Snake : GameObject
	{
		private const short DefaultSnakeLength = 4;						//Start size of the snake
		public const char HeadLooks = '@';								//Snake head Graphics
		public const char BodyLooks = '0';                              //Snake body Graphics
		private const ConsoleColor Color = ConsoleColor.Yellow;			//Snake color

		public bool AteTheApple { get; private set; }					//True if snake ate apple.
		public List<Position> SnakeElements = new List<Position>();		//List of all the snake parts
		public Position NewHeadPosition;								//Where head should move next
		public Position Tail => SnakeElements.First();					//To keep track of the snake's behind
		public Position Head => SnakeElements.Last();                   //To keep track of the current head position.

		//Enum for more understandable directions.
		public enum SnakeDirection
		{
			Up,
			Right,
			Down,
			Left
		};
		public SnakeDirection Direction;

		public Snake()
		{
			//Setting snake's start direction and placing all the snake parts
			Direction = SnakeDirection.Down;
			Position.X = 10;
			Position.Y = 10;
			NewHeadPosition = new Position(Position.X, Position.Y);
			for (var i = 0; i < DefaultSnakeLength; i++)
			{
				SnakeElements.Add(new Position (Position.X, Position.Y));
			}
		}

		public override void Draw()
		{
			//Tail eraser
			if (!AteTheApple)
			{
				Console.SetCursorPosition (Tail.X, Tail.Y);
				Console.Write (" ");
				SnakeElements.RemoveAt (0);
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
			Console.Write (HeadLooks);
		}

		//Based on user input, change the direction the snake should move. Cannot be backwards.
		public void ChangeDirection (ConsoleKey moveKey)
		{
			if (moveKey == ConsoleKey.UpArrow && Direction != SnakeDirection.Down)
				Direction = SnakeDirection.Up;
			else if (moveKey == ConsoleKey.RightArrow && Direction != SnakeDirection.Left)
				Direction = SnakeDirection.Right;
			else if (moveKey == ConsoleKey.DownArrow && Direction != SnakeDirection.Up)
				Direction = SnakeDirection.Down;
			else if (moveKey == ConsoleKey.LeftArrow && Direction != SnakeDirection.Right)
				Direction = SnakeDirection.Left;
		}

		//Move snake based on the chosen direction.
		public void MoveSnake()
		{		
			NewHeadPosition = new Position(Head);

			switch (Direction)
			{
				case SnakeDirection.Up:
					NewHeadPosition.Y--;
					break;
				case SnakeDirection.Right:
					NewHeadPosition.X++;
					break;
				case SnakeDirection.Down:
					NewHeadPosition.Y++;
					break;
				case SnakeDirection.Left:
					NewHeadPosition.X--;
					break;
				default:
					NewHeadPosition.Y++;
					break;
			}

			//Has snake moved out of bounds? If so, game is over.
			if (NewHeadPosition.X < 0 || NewHeadPosition.X >= Global.BoardWidth ||
				NewHeadPosition.Y < 0 || NewHeadPosition.Y >= Global.BoardHeight)
			{
				Global.IsGameOver = true;
				return;
			}
			Draw ();
		}

		public void CheckForCollision(Apple other)
		{
			//Reset bool if apple was eaten last frame.
			if (AteTheApple)
			{
				AteTheApple = false;
			}

			//Game over criteria "IsGameOver"?
			else
			{ 
				foreach (var x in SnakeElements)
				{
					// Check for appleCollision with body
					if (x.X == other.Position.X && x.Y == other.Position.Y)
					{
						AteTheApple = true;
					}
					// Check for death by accidental self-cannibalism.
					//Should not execute before NewHeadPosition has moved a space.
					if (x.X != NewHeadPosition.X || x.Y != NewHeadPosition.Y)
						continue;

					Global.IsGameOver = true;
					break;
				}
			}

			// Check for appleCollision with head
			if (NewHeadPosition.X == other.Position.X && NewHeadPosition.Y == other.Position.Y)
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
