using System;
using System.Linq;
using Melia.Shared.Tos.Const;
using Newtonsoft.Json.Linq;
using Yggdrasil.Data.JSON;

namespace Melia.Shared.Data.Database
{
	[Serializable]
	public class HairTypeData
	{
		public int Id { get; set; }
		public int Index { get; set; }
		public Gender Gender { get; set; }
		public string Name { get; set; }
		public string ClassName { get; set; }
		public string Color { get; set; }
	}

	/// <summary>
	/// Hair type database.
	/// </summary>
	public class HairTypeDb : DatabaseJsonIndexed<int, HairTypeData>
	{


		/// <summary>
		/// Returns the hair with the given class name or null if there was no
		/// matching hair.
		/// </summary>
		/// <param name="gender"></param>
		/// <param name="name"></param>
		/// <param name="hairData"></param>
		/// <param name="color"></param>
		/// <returns></returns>
		public bool TryFind(Gender gender, string name, out HairTypeData hairData, string color = "default")
		{
			name = name.ToLower();
			hairData = this.Entries.Values.FirstOrDefault(a => a.Gender == gender && a.ClassName.ToLower() == name && a.Color == color);

			return hairData != null;
		}

		/// <summary>
		/// Reads given entry and adds it to the database.
		/// </summary>
		/// <param name="entry"></param>
		protected override void ReadEntry(JObject entry)
		{
			entry.AssertNotMissing("id", "index", "gender", "name", "className", "color");

			var data = new HairTypeData();

			data.Id = entry.ReadInt("id");
			data.Index = entry.ReadInt("index");
			data.Gender = entry.ReadEnum<Gender>("gender");
			data.Name = entry.ReadString("name");
			data.ClassName = entry.ReadString("className");
			data.Color = entry.ReadString("color");

			this.Add(data.Id, data);
		}
	}
}
