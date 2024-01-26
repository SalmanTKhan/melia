using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.Data.Database;

namespace Melia.Zone.World.Dungeons
{
	public class InstanceDungeon
	{
		public int Id { get; }
		public int MapId { get; set; }
		public int Level => this.Data.Level;

		InstanceDungeonData Data { get; set; }

		public InstanceDungeon(int id)
		{
			this.Id = id;
			this.LoadData();
		}

		private void LoadData()
		{
			if (this.Id == 0)
				throw new InvalidOperationException("Instance Dungeon id wasn't set before calling LoadData.");

			if (!ZoneServer.Instance.Data.InstanceDungeonDb.TryFind(this.Id, out var data))
				throw new NullReferenceException("No instance dungeon data found for '" + this.Id + "'.");

			this.Data = data;
		}
	}
}
