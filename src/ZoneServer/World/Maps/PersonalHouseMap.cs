using Melia.Shared.Game.Const;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Houses;

namespace Melia.Zone.World.Maps
{
	public class PersonalHouseMap : DynamicMap
	{
		public PersonalHouse House { get; set; }

		public PersonalHouseMap(PersonalHouse house) : base(house.MapId)
		{
			this.House = house;
			this.Load();
		}

		/// <summary>
		/// Loads the map's data.
		/// </summary>
		private void Load()
		{
			foreach (var prop in this.House.Props)
			{
				var monster = new Mob(prop.MonsterId, MonsterType.NPC);
				monster.Position = prop.Position;
				monster.Direction = prop.Direction;
				monster.IsProp = true;
				this.AddMonster(monster);
				prop.Handle = monster.Handle;
			}
		}
	}
}
