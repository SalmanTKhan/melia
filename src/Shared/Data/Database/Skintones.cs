using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Newtonsoft.Json.Linq;
using Yggdrasil.Data.JSON;

namespace Melia.Shared.Data.Database
{
	[Serializable]
	public class SkintoneData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ClassName { get; set; }
		public Color Color { get; set; }
		public bool IsAvailableInLodge { get; set; }
	}

	/// <summary>
	/// Skin tone database.
	/// </summary>
	public class SkintoneDb : DatabaseJsonIndexed<int, SkintoneData>
	{
		/// <summary>
		/// Returns the skintone with the given class name or null if there was no
		/// matching skintone.
		/// </summary>
		/// <param name="red"></param>
		/// <param name="green"></param>
		/// <param name="blue"></param>
		/// <param name="skinData"></param>
		/// <param name="alpha"></param>
		/// <returns></returns>
		public bool TryFind(byte red, byte green, byte blue, out SkintoneData skinData, byte alpha = 255)
		{
			skinData = this.Entries.Values.FirstOrDefault(a => a.Color.R == red && a.Color.G == green && a.Color.B == blue);

			return skinData != null;
		}

		/// <summary>
		/// Returns the skintone with the given class name or null if there was no
		/// matching skintone.
		/// </summary>
		/// <param name="color"></param>
		/// <param name="skinData"></param>
		/// <returns></returns>
		public bool TryFind(Color color, out SkintoneData skinData)
		{
			skinData = this.Entries.Values.FirstOrDefault(a => a.Color.Equals(color));

			return skinData != null;
		}

		/// <summary>
		/// Returns the skintone with the given index or null if there was no
		/// matching skintone.
		/// </summary>
		/// <param name="className"></param>
		/// <param name="skinData"></param>
		/// <param name="color"></param>
		/// <returns></returns>
		public bool TryFind(string className, out SkintoneData skinData, string color = "default")
		{
			skinData = this.Entries.Values.FirstOrDefault(a => a.ClassName.Equals(className, StringComparison.InvariantCultureIgnoreCase));

			return skinData != null;
		}

		/// <summary>
		/// Reads given entry and adds it to the database.
		/// </summary>
		/// <param name="entry"></param>
		protected override void ReadEntry(JObject entry)
		{
			entry.AssertNotMissing("id", "name", "className", "red", "green", "blue");

			var data = new SkintoneData();

			data.Id = entry.ReadInt("id");
			data.Name = entry.ReadString("name");
			data.ClassName = entry.ReadString("className");
			var red = entry.ReadByte("red");
			var green = entry.ReadByte("green");
			var blue = entry.ReadByte("blue");
			var alpha = entry.ReadByte("alpha", 255);
			data.Color = Color.FromArgb(alpha, red, green, blue);
			data.IsAvailableInLodge = entry.ReadBool("useableInLodge");

			this.Add(data.Id, data);
		}
	}
}
