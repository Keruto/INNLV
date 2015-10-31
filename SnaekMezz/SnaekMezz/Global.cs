using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
