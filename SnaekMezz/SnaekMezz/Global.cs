//This class keeps track of the static variables.
using System;

namespace SnaekMezz
{
	public static class Global
	{
		public static readonly int BoardWidth = Console.WindowWidth;
		public static readonly int BoardHeight = Console.WindowHeight;
		public static bool IsGameOver = false;
		public static bool IsPaused = false;
	}
}
