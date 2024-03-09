using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yggdrasil.Data.JSON;

namespace Melia.Shared.Data.Database
{
	public enum InstanceDungeonGroup
	{
		None = 0,
		Indun = 1,
		Raid = 2,
	}

	[Serializable]
	public class InstanceDungeonData
	{
		public int Id { get; set; }
		public string ClassName { get; set; }
		public string Name { get; set; }
		public InstanceDungeonGroup Group { get; set; }
		public int Level { get; set; }
		public int MaxPlayers { get; set; }
	}

	/// <summary>
	/// Housing InstanceDungeon database.
	/// </summary>
	public class InstanceDungeonDb : DatabaseJsonIndexed<int, InstanceDungeonData>
	{
		/// <summary>
		/// Find a InstanceDungeon or null with a given class name.
		/// </summary>
		/// <param name="className"></param>
		/// <returns></returns>
		public bool TryGet(string className, out InstanceDungeonData data)
		{
			data = this.Entries.Values.FirstOrDefault(a => a.ClassName.ToLowerInvariant() == className.ToLowerInvariant());
			return data != null;
		}

		protected override void ReadEntry(JObject entry)
		{
			entry.AssertNotMissing("id", "className", "name", "level", "maxPlayers");

			var data = new InstanceDungeonData();

			data.Id = entry.ReadInt("id");
			data.ClassName = entry.ReadString("className");
			data.Name = entry.ReadString("name");
			data.Level = entry.ReadInt("level");
			data.MaxPlayers = entry.ReadInt("maxPlayers");

			this.Entries[data.Id] = data;
		}
	}
}
