//All visible objects in the game are GameObjects
namespace SnaekMezz
{
	abstract class GameObject
	{
		internal Position Position = new Position();
		public char Symbol;

		//Every GameObject must have a means to show itself in the console window.
		abstract public void Draw();
	}
}
