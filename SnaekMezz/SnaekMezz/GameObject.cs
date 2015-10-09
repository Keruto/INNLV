using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnaekMezz
{
	abstract class GameObject
	{
		public Position Position = new Position();
		public char Symbol;

		abstract public void Draw();
	}
}
