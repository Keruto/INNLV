using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnaekMezz
{
	//Position class to give objects positions.
	class Position
	{
		public const string Ok = "Ok"; //what does this do?
		public int X { get; set; }
		public int Y { get; set; }

		public Position (int x = 0, int y = 0)
		{
			X = x;
			Y = y;
		}

		public Position (Position input)
		{
			X = input.X;
			Y = input.Y;
		}
	}
}
