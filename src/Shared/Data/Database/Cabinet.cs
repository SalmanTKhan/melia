using System;
using System.Linq;
using Melia.Shared.Game.Const;
using Newtonsoft.Json.Linq;
using Yggdrasil.Data.JSON;

namespace Melia.Shared.Data.Database
{
	[Serializable]
	public class CabinetData
	{
		public int Id { get; set; }
		public string ClassName { get; set; }
		public string Name { get; set; }
		public CabinetType Category { get; set; }
		public int Upgrade { get; set; }
		public int MakeCostSilver { get; set; }
		public int MaxUpgrade { get; set; }
		public bool IsBasic { get; set; }
		public string GetItemFunc { get; set; }
		public string RegisterFunc { get; set; }
		public string EnchantFunc { get; set; }
		public string AccountProperty { get; set; }
		public string UpgradeAccountProperty { get; set; }
		public string TabGroup { get; set; }
		public string GetUpgradeItemFunc { get; set; }
	}

	public enum CabinetType
	{
		Accessory,
		Ark,
		Armor,
		Artefact,
		Relicgem,
		Skillgem,
		Weapon,
	}

	/// <summary>
	/// Buff database, indexed by buff id.
	/// </summary>
	public class CabinetDb : DatabaseJsonIndexed<string, CabinetData>
	{

		/// <summary>
		/// Returns the cabinet with the given class name or null if there was no
		/// matching buff.
		/// </summary>
		/// <param name="name">Class name of the buff</param>
		/// <returns></returns>
		public bool TryFind(CabinetType type, int classId, out CabinetData cabinetData)
		{
			cabinetData = this.Entries.Values.FirstOrDefault(a => a.Category == type && a.Id == classId);

			return cabinetData != null;
		}

		/// <summary>
		/// Reads given entry and adds it to the database.
		/// </summary>
		/// <param name="entry"></param>
		protected override void ReadEntry(JObject entry)
		{
			entry.AssertNotMissing("id", "className", "name", "category");

			var data = new CabinetData();

			data.Id = entry.ReadInt("id");
			data.ClassName = entry.ReadString("className");
			data.Name = entry.ReadString("name");
			data.Upgrade = entry.ReadInt("upgrade");
			data.MakeCostSilver = entry.ReadInt("makeCostSilver");
			data.MaxUpgrade = entry.ReadInt("maxUpgrade");
			data.IsBasic = entry.ReadBool("basic");
			data.Category = entry.ReadEnum<CabinetType>("category");
			data.GetItemFunc = entry.ReadString("getItemFunc");
			data.RegisterFunc = entry.ReadString("registerFunc");
			data.AccountProperty = entry.ReadString("accountProperty");
			data.UpgradeAccountProperty = entry.ReadString("upgradeAccountProperty");
			data.EnchantFunc = entry.ReadString("enchantFunc");
			data.TabGroup = entry.ReadString("tabGroup");
			data.GetUpgradeItemFunc = entry.ReadString("getUpgradeItemFunc");

			this.AddOrReplace(data.ClassName, data);
		}
	}
}
