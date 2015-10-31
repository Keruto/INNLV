namespace SnaekMezz
{
	//Position class to give all GameObjects positions.
	class Position
	{
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
