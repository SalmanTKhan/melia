using System.Collections.Generic;
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

		/// <summary>
		/// Parse Items
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		public static Dictionary<string, int> ParseItems(string items)
		{
			var itemDict = new Dictionary<string, int>();
			foreach (var itemString in items.Split(';'))
			{
				if (itemString.Length == 0)
				{
					continue;
				}
				var itemSplit = itemString.Split('/');
				var itemClassName = itemSplit[0];
				var itemAmount = 1;
				if (string.IsNullOrWhiteSpace(itemClassName))
					continue;
				if (itemSplit.Length > 1)
					int.TryParse(itemSplit[1], out itemAmount);
				itemDict.Add(itemClassName, itemAmount);
			}

			return itemDict;
		}
	}
}
