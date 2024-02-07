using System;
using System.Collections.Generic;
using System.Linq;
using Melia.Shared.Tos.Const;
using Newtonsoft.Json.Linq;
using Yggdrasil.Data.JSON;

namespace Melia.Shared.Data.Database
{
	[Serializable]
	public class ItemData
	{
		public int Id { get; set; }

		public string ClassName { get; set; }
		public string Name { get; set; }

		public ItemType Type { get; set; }
		public ItemGroup Group { get; set; }
		public InventoryCategory Category { get; set; }

		public float Weight { get; set; }
		public int MaxStack { get; set; }
		public int Price { get; set; }
		public int SellPrice { get; set; }

		public EquipType EquipType1 { get; set; }
		public EquipType EquipType2 { get; set; }
		public int Grade { get; set; }
		public int MinLevel { get; set; }
		public int Durability { get; set; }
		public int MaxDurability { get; set; }

		public float MinAtk { get; set; }
		public float MaxAtk { get; set; }
		public float PAtk { get; set; }
		public float MAtk { get; set; }
		public float AddMinAtk { get; set; }
		public float AddMaxAtk { get; set; }
		public float AddMAtk { get; set; }
		public float Def { get; set; }
		public float MDef { get; set; }
		public float AddDef { get; set; }
		public float AddMDef { get; set; }
		public float SmallSizeBonus { get; set; }
		public float MediumSizeBonus { get; set; }
		public float LargeSizeBonus { get; set; }
		public ArmorMaterialType Material { get; set; }

		public float Slash { get; set; }
		public float Aries { get; set; }
		public float Strike { get; set; }
		public float SlashDefense { get; set; }
		public float AriesDefense { get; set; }
		public float StrikeDefense { get; set; }
		public float SlashRange { get; set; }
		public float AriesRange { get; set; }
		public float StrikeRange { get; set; }

		public float FireResistence { get; set; }
		public float IceResistence { get; set; }
		public float LightningResistence { get; set; }
		public float EarthResistence { get; set; }
		public float PoisonResistence { get; set; }
		public float HolyResistence { get; set; }
		public float DarkResistence { get; set; }
		public float SoulResistence { get; set; }

		public float CrtHR { get; set; }
		public float CrtATK { get; set; }
		public float CrtDR { get; set; }
		public float AddHR { get; set; }
		public float AddDR { get; set; }
		public float Str { get; set; }
		public float Dex { get; set; }
		public float Con { get; set; }
		public float Int { get; set; }
		public float Mna { get; set; }
		public float Sr { get; set; }
		public float Sdr { get; set; }
		public float CrtMAtk { get; set; }
		public float Mgp { get; set; }
		public float AddSkillMaxR { get; set; }
		public float Skillrange { get; set; }
		public float Skillangle { get; set; }
		public float Luck { get; set; }
		public float Blockrate { get; set; }
		public float Blk { get; set; }
		public float BlkBreak { get; set; }
		public float Revive { get; set; }
		public float HitCount { get; set; }
		public float BackHit { get; set; }
		public float SkillPower { get; set; }
		public float Aspd { get; set; }
		public float Mspd { get; set; }
		public float KdPow { get; set; }
		public float MHp { get; set; }
		public float MSp { get; set; }
		public float Msta { get; set; }
		public float RHp { get; set; }
		public float RSp { get; set; }
		public float RSptime { get; set; }
		public float RSta { get; set; }
		public float AddCloth { get; set; }
		public float AddLeather { get; set; }
		public float AddChain { get; set; }
		public float AddIron { get; set; }
		public float AddGhost { get; set; }
		public float AddSmallsize { get; set; }
		public float AddMiddlesize { get; set; }
		public float AddLargesize { get; set; }
		public float AddForester { get; set; }
		public float AddWidling { get; set; }
		public float AddVelias { get; set; }
		public float AddParamune { get; set; }
		public float AddKlaida { get; set; }
		public float AddFire { get; set; }
		public float AddIce { get; set; }
		public float AddPoison { get; set; }
		public float AddLightning { get; set; }
		public float AddEarth { get; set; }
		public float AddSoul { get; set; }
		public float AddHoly { get; set; }
		public float AddDark { get; set; }
		public float BaseSocket { get; set; }
		public float MaxSocketCount { get; set; }
		public float BaseSocketMa { get; set; }
		public float MaxSocketMa { get; set; }
		public float Minoption { get; set; }
		public float Maxoption { get; set; }
		public float MinRDmg { get; set; }
		public float MaxRDmg { get; set; }
		public float FdMinR { get; set; }
		public float FdMaxR { get; set; }
		public float Lifetime { get; set; }
		public float Itemlifetimeover { get; set; }
		public float NeedAppraisal { get; set; }
		public float NeedRandomOption { get; set; }
		public float Lootingchance { get; set; }
		public float Isalwayshatvisible { get; set; }
		public float SkillWidthRange { get; set; }
		public float DynamicLifeTime { get; set; }
		public float AddBossAtk { get; set; }
		public float Teambelonging { get; set; }
		public float AddDamageAtk { get; set; }
		public float MagicEarthAtk { get; set; }
		public float ResaddDamage { get; set; }
		public float JobGrade { get; set; }
		public float MagicIceAtk { get; set; }
		public float MagicSoulAtk { get; set; }
		public float MagicDarkAtk { get; set; }
		public float MagicMeleeAtk { get; set; }
		public float MagicFireAtk { get; set; }
		public float MagicLightningAtk { get; set; }
		public int Cooldown { get; set; }
		public string CooldownGroup { get; set; }

		public ItemScriptData Script { get; set; }
		public SkillAttackType AttackType { get; set; } = SkillAttackType.None;

		public bool HasScript => this.Script != null;
		public bool HasCooldown => !string.IsNullOrWhiteSpace(this.CooldownGroup);

		public string EquipSkill { get; internal set; }
		public bool Journal { get; set; }
	}

	[Serializable]
	public class ItemScriptData
	{
		public string Function { get; set; }
		public string StrArg { get; set; }
		public string StrArg2 { get; set; }
		public float NumArg1 { get; set; }
		public float NumArg2 { get; set; }
	}

	/// <summary>
	/// Item database, indexed by item id.
	/// </summary>
	public class ItemDb : DatabaseJsonIndexed<int, ItemData>
	{
		/// <summary>
		/// Returns the item with the given name or null if there was no
		/// matching item.
		/// </summary>
		/// <param name="name">Name of the item (case-insensitive)</param>
		/// <returns></returns>
		public ItemData Find(string name)
		{
			name = name.ToLower();
			return this.Entries.FirstOrDefault(a => a.Value.Name.ToLower() == name).Value;
		}

		/// <summary>
		/// Returns the item with the given class name or null if there was no
		/// matching item.
		/// </summary>
		/// <param name="name">Name of the item (case-insensitive)</param>
		/// <returns></returns>
		public ItemData FindByClass(string name)
		{
			name = name.ToLower();
			return this.Entries.FirstOrDefault(a => a.Value.ClassName.ToLower() == name).Value;
		}


		/// <summary>
		/// Returns a list of all items whose name contains the given string
		/// If there is an exact match, return only those ones
		/// </summary>
		/// <param name="searchString">String to search for (case-insensitive)</param>
		/// <returns></returns>
		public List<ItemData> FindAllPreferExact(string searchString)
		{
			searchString = searchString.ToLower();

			var exactMatches = this.Entries.Values.Where(a => a.Name.ToLower() == searchString);
			if (exactMatches.Any())
				return exactMatches.ToList();

			return this.FindAll(searchString);
		}

		/// <summary>
		/// Returns a list of all items whichs' names contain the given
		/// string.
		/// </summary>
		/// <param name="searchString">String to look for in the item names (case-insensitive)</param>
		/// <returns></returns>
		public List<ItemData> FindAll(string searchString)
		{
			searchString = searchString.ToLower();
			return this.Entries.Where(a => a.Value.Name.ToLower().Contains(searchString)).Select(a => a.Value).ToList();
		}

		/// <summary>
		/// Try to find item by class name if null then search by item name.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="item"></param>
		/// <returns>If item is found or not</returns>
		public bool TryFind(string name, out ItemData item)
		{
			item = this.FindByClass(name);
			if (item != null)
				return true;
			item = this.Find(name);
			if (item != null)
				return true;
			return false;
		}

		/// <summary>
		/// Reads given entry and adds it to the database.
		/// </summary>
		/// <param name="entry"></param>
		protected override void ReadEntry(JObject entry)
		{
			entry.AssertNotMissing("itemId", "className", "name", "type", "group", "weight", "maxStack", "price", "sellPrice");

			var data = new ItemData();

			data.Id = entry.ReadInt("itemId");

			data.ClassName = entry.ReadString("className");
			data.Name = entry.ReadString("name");
			data.Type = entry.ReadEnum<ItemType>("type");
			data.Group = entry.ReadEnum<ItemGroup>("group");
			data.Category = GetCategory(data);

			data.Weight = entry.ReadFloat("weight", 0);
			data.MaxStack = entry.ReadInt("maxStack", 1);
			data.Price = entry.ReadInt("price", 0);
			data.SellPrice = entry.ReadInt("sellPrice", 0);
			data.EquipType1 = entry.ReadEnum<EquipType>("equipType1", EquipType.None);
			data.EquipType2 = entry.ReadEnum<EquipType>("equipType2", EquipType.None);
			data.Grade = entry.ReadInt("grade", 0);
			data.MinLevel = entry.ReadInt("minLevel", 1);
			data.Durability = entry.ReadInt("durability", 0);
			data.MaxDurability = entry.ReadInt("maxDurability", 0);
			data.Journal = entry.ReadBool("journal");

			data.MinAtk = entry.ReadFloat("minAtk", 0);
			data.MaxAtk = entry.ReadFloat("maxAtk", 0);
			data.PAtk = entry.ReadFloat("pAtk", 0);
			data.MAtk = entry.ReadFloat("mAtk", 0);
			data.AddMinAtk = entry.ReadFloat("addMinAtk", 0);
			data.AddMaxAtk = entry.ReadFloat("addMaxAtk", 0);
			data.AddMAtk = entry.ReadFloat("addMAtk", 0);
			data.Def = entry.ReadFloat("def", 0);
			data.MDef = entry.ReadFloat("mDef", 0);
			data.AddDef = entry.ReadFloat("addDef", 0);
			data.AddMDef = entry.ReadFloat("addMDef", 0);
			data.SmallSizeBonus = entry.ReadFloat("smallSizeBonus", 0);
			data.MediumSizeBonus = entry.ReadFloat("mediumSizeBonus", 0);
			data.LargeSizeBonus = entry.ReadFloat("largeSizeBonus", 0);
			data.Material = entry.ReadEnum<ArmorMaterialType>("material", ArmorMaterialType.None);

			data.Aries = entry.ReadFloat("aries", 0);
			data.Slash = entry.ReadFloat("slash", 0);
			data.Strike = entry.ReadFloat("strike", 0);
			data.AriesDefense = entry.ReadFloat("ariesDef", 0);
			data.SlashDefense = entry.ReadFloat("slashDef", 0);
			data.StrikeDefense = entry.ReadFloat("strikeDef", 0);

			data.FireResistence = entry.ReadFloat("fireRes", 0);
			data.IceResistence = entry.ReadFloat("iceRes", 0);
			data.PoisonResistence = entry.ReadFloat("poisonRes", 0);
			data.LightningResistence = entry.ReadFloat("lightningRes", 0);
			data.EarthResistence = entry.ReadFloat("earthRes", 0);
			data.SoulResistence = entry.ReadFloat("soulRes", 0);
			data.HolyResistence = entry.ReadFloat("holyRes", 0);
			data.DarkResistence = entry.ReadFloat("darkRes", 0);

			data.CrtHR = entry.ReadFloat("crtHR", 0);
			data.CrtATK = entry.ReadFloat("crtATK", 0);
			data.CrtDR = entry.ReadFloat("crtDR", 0);
			data.AddHR = entry.ReadFloat("addHR", 0);
			data.AddDR = entry.ReadFloat("addDR", 0);
			data.Str = entry.ReadFloat("str", 0);
			data.Dex = entry.ReadFloat("dex", 0);
			data.Con = entry.ReadFloat("con", 0);
			data.Int = entry.ReadFloat("int", 0);
			data.Mna = entry.ReadFloat("mna", 0);
			data.Sr = entry.ReadFloat("sr", 0);
			data.Sdr = entry.ReadFloat("sdr", 0);
			data.CrtMAtk = entry.ReadFloat("crtMAtk", 0);
			data.Mgp = entry.ReadFloat("mgp", 0);
			data.AddSkillMaxR = entry.ReadFloat("addSkillMaxR", 0);
			data.Skillrange = entry.ReadFloat("skillrange", 0);
			data.Skillangle = entry.ReadFloat("skillangle", 0);
			data.Luck = entry.ReadFloat("luck", 0);
			data.Blockrate = entry.ReadFloat("blockrate", 0);
			data.Blk = entry.ReadFloat("blk", 0);
			data.BlkBreak = entry.ReadFloat("blkBreak", 0);
			data.Revive = entry.ReadFloat("revive", 0);
			data.HitCount = entry.ReadFloat("hitCount", 0);
			data.BackHit = entry.ReadFloat("backHit", 0);
			data.SkillPower = entry.ReadFloat("skillPower", 0);
			data.Aspd = entry.ReadFloat("aspd", 0);
			data.Mspd = entry.ReadFloat("mspd", 0);
			data.KdPow = entry.ReadFloat("kdPow", 0);
			data.MHp = entry.ReadFloat("mHp", 0);
			data.MSp = entry.ReadFloat("mSp", 0);
			data.Msta = entry.ReadFloat("msta", 0);
			data.RHp = entry.ReadFloat("rHp", 0);
			data.RSp = entry.ReadFloat("rSp", 0);
			data.RSptime = entry.ReadFloat("rSptime", 0);
			data.RSta = entry.ReadFloat("rSta", 0);
			data.AddCloth = entry.ReadFloat("addCloth", 0);
			data.AddLeather = entry.ReadFloat("addLeather", 0);
			data.AddChain = entry.ReadFloat("addChain", 0);
			data.AddIron = entry.ReadFloat("addIron", 0);
			data.AddGhost = entry.ReadFloat("addGhost", 0);
			data.AddSmallsize = entry.ReadFloat("addSmallsize", 0);
			data.AddMiddlesize = entry.ReadFloat("addMiddlesize", 0);
			data.AddLargesize = entry.ReadFloat("addLargesize", 0);
			data.AddForester = entry.ReadFloat("addForester", 0);
			data.AddWidling = entry.ReadFloat("addWidling", 0);
			data.AddVelias = entry.ReadFloat("addVelias", 0);
			data.AddParamune = entry.ReadFloat("addParamune", 0);
			data.AddKlaida = entry.ReadFloat("addKlaida", 0);
			data.AddFire = entry.ReadFloat("addFire", 0);
			data.AddIce = entry.ReadFloat("addIce", 0);
			data.AddPoison = entry.ReadFloat("addPoison", 0);
			data.AddLightning = entry.ReadFloat("addLightning", 0);
			data.AddEarth = entry.ReadFloat("addEarth", 0);
			data.AddSoul = entry.ReadFloat("addSoul", 0);
			data.AddHoly = entry.ReadFloat("addHoly", 0);
			data.AddDark = entry.ReadFloat("addDark", 0);
			data.BaseSocket = entry.ReadFloat("maxSocketCount", 0);
			data.MaxSocketCount = entry.ReadFloat("maxSocketCount", 0);
			data.BaseSocketMa = entry.ReadFloat("baseSocketMa", 0);
			data.MaxSocketMa = entry.ReadFloat("maxSocketMa", 0);
			data.Minoption = entry.ReadFloat("minoption", 0);
			data.Maxoption = entry.ReadFloat("maxoption", 0);
			data.AriesRange = entry.ReadFloat("ariesRange", 0);
			data.SlashRange = entry.ReadFloat("slashRange", 0);
			data.StrikeRange = entry.ReadFloat("strikeRange", 0);
			data.MinRDmg = entry.ReadFloat("minRDmg", 0);
			data.MaxRDmg = entry.ReadFloat("maxRDmg", 0);
			data.FdMinR = entry.ReadFloat("fdMinR", 0);
			data.FdMaxR = entry.ReadFloat("fdMaxR", 0);
			data.Lifetime = entry.ReadFloat("lifetime", 0);
			data.Itemlifetimeover = entry.ReadFloat("itemlifetimeover", 0);
			data.NeedAppraisal = entry.ReadFloat("needAppraisal", 0);
			data.NeedRandomOption = entry.ReadFloat("needRandomOption", 0);
			data.Lootingchance = entry.ReadFloat("lootingchance", 0);
			data.Isalwayshatvisible = entry.ReadFloat("isalwayshatvisible", 0);
			data.SkillWidthRange = entry.ReadFloat("skillWidthRange", 0);
			data.DynamicLifeTime = entry.ReadFloat("dynamicLifeTime", 0);
			data.AddBossAtk = entry.ReadFloat("addBossAtk", 0);
			data.Teambelonging = entry.ReadFloat("teambelonging", 0);
			data.AddDamageAtk = entry.ReadFloat("addDamageAtk", 0);
			data.MagicEarthAtk = entry.ReadFloat("magicEarthAtk", 0);
			data.ResaddDamage = entry.ReadFloat("resaddDamage", 0);
			data.JobGrade = entry.ReadFloat("jobGrade", 0);
			data.MagicIceAtk = entry.ReadFloat("magicIceAtk", 0);
			data.MagicSoulAtk = entry.ReadFloat("magicSoulAtk", 0);
			data.MagicDarkAtk = entry.ReadFloat("magicDarkAtk", 0);
			data.MagicMeleeAtk = entry.ReadFloat("magicMeleeAtk", 0);
			data.MagicFireAtk = entry.ReadFloat("magicFireAtk", 0);
			data.MagicLightningAtk = entry.ReadFloat("magicLightningAtk", 0);
			if (entry.ContainsKey("needRandomOption"))
				data.NeedRandomOption = entry.ReadInt("needRandomOption");

			if (entry.ContainsKey("needAppraisal"))
				data.NeedAppraisal = entry.ReadInt("needAppraisal");

			if (entry.ContainsKey("maxSocketCount"))
				data.MaxSocketCount = entry.ReadInt("maxSocketCount");

			if (entry.ContainsKey("cooldown"))
				data.Cooldown = entry.ReadInt("cooldown");

			if (entry.ContainsKey("cooldownGroup"))
				data.CooldownGroup = entry.ReadString("cooldownGroup");

			if (entry.ContainsKey("equipSkill"))
				data.EquipSkill = entry.ReadString("equipSkill");

			if (entry.TryGetObject("script", out var scriptEntry))
			{
				// We can't really assert that no fields are missing,
				// because thanks to dialog transactions, some items
				// have no script function but do define arguments.
				//scriptEntry.AssertNotMissing("function", "strArg", "numArg1", "numArg2");

				var scriptData = new ItemScriptData();

				scriptData.Function = scriptEntry.ReadString("function");
				scriptData.StrArg = scriptEntry.ReadString("strArg");
				scriptData.NumArg1 = scriptEntry.ReadFloat("numArg1");
				scriptData.NumArg2 = scriptEntry.ReadFloat("numArg2");

				data.Script = scriptData;
			}

			this.AddOrReplace(data.Id, data);
		}

		/// <summary>
		/// Returns the category for the given item.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private static InventoryCategory GetCategory(ItemData data)
		{
			// This data is not included in the client and as far as I
			// can tell there is nothing in the client to simplify this.
			// We just have to manually categorize the items.

			if (data.Group == ItemGroup.Premium)
			{
				return InventoryCategory.Premium_Consume;
			}

			if (data.Type == ItemType.Equip)
			{
				if (data.Group == ItemGroup.Weapon)
					return InventoryCategory.Weapon_Bow;

				if (data.Group == ItemGroup.SubWeapon)
					return InventoryCategory.Weapon_Dagger;

				if (data.EquipType1 == EquipType.Boots)
					return InventoryCategory.Armor_Boots;

				if (data.EquipType1 == EquipType.Gloves)
					return InventoryCategory.Armor_Gloves;

				if (data.EquipType1 == EquipType.Pants)
					return InventoryCategory.Armor_Pants;

				if (data.EquipType1 == EquipType.Shield)
					return InventoryCategory.Armor_Shield;

				if (data.EquipType1 == EquipType.Shirt)
					return InventoryCategory.Armor_Shirt;

				if (data.EquipType1 == EquipType.Outer)
					return InventoryCategory.Outer;

				if (data.Group == ItemGroup.Helmet)
					return InventoryCategory.Premium_Helmet;

				if (data.Group == ItemGroup.Armband)
					return InventoryCategory.Accessory_Band;

				return InventoryCategory.Armor_Boots;
			}

			if (data.Type == ItemType.Quest)
				return InventoryCategory.Quest;

			if (data.Group == ItemGroup.Book)
				return InventoryCategory.Consume_Book;

			if (data.Group == ItemGroup.Card)
				return InventoryCategory.Card;

			if (data.Group == ItemGroup.Collection)
				return InventoryCategory.Misc_Collect;

			if (data.Type == ItemType.Consume)
			{
				if (data.Group == ItemGroup.Cube)
					return InventoryCategory.Consume_Cube;

				return InventoryCategory.Consume_Potion;
			}

			if (data.Type == ItemType.Recipe)
				return InventoryCategory.Recipe;

			if (data.Group == ItemGroup.Material)
				return InventoryCategory.Misc_Etc;

			// Use Non for unused, so items like money get hidden.
			if (data.Group == ItemGroup.Unused)
				return InventoryCategory.None;

			// Return unused by default, which is labeled as "N/A".
			//return InventoryCategory.Unused;

			// Actually, for unknown reasons not all items appear when put
			// into Unused. Let's use a random category for now.
			return InventoryCategory.Misc_Usual;
		}
	}
}
