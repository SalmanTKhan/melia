using Melia.Shared.World;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;

namespace Melia.Zone.Scripting
{
	public static partial class Shortcuts
	{
		/// <summary>
		/// Checks the distance and sends a system message
		/// </summary>
		/// <remarks>
		/// Used in certain items (Guild Tower, Summon Monster Albums)
		/// </remarks>
		/// <param name="character"></param>
		/// <param name="position"></param>
		/// <param name="distance"></param>
		/// <returns></returns>
		public static bool CheckIfNearNPC(this Character character, Position position, float distance)
		{
			if (character.Map.GetActorsIn<Npc>(new Circle(position, distance)).Count > 0)
				return true;
			character.SystemMessage("TooNearFromNPC");
			return false;
		}
	}
}
