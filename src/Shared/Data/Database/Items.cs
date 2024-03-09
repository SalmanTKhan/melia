using System;
using System.Collections.Generic;
using System.Linq;
using Melia.Shared.Game.Const;
using Newtonsoft.Json.Linq;
using Yggdrasil.Data.JSON;

namespace Melia.Shared.Data.Database
{
	[Serializable]
	public class ItemData : PropertizedData
	{
		public int Id { get; set; }

		public string ClassName { get; set; }
		public string Name { get; set; }

		public ItemType Type { get; set; }
		public ItemGroup Group { get; set; }
		public InventoryCategory Category { get; set; }

		[Property(PropertyName.Weight)]
		public float Weight { get; set; }
		[Property(PropertyName.MaxStack)]
		public int MaxStack { get; set; }
		[Property(PropertyName.Price)]
		public int Price { get; set; }
		[Property(PropertyName.SellPrice)]
		public int SellPrice { get; set; }

		public EquipType EquipType1 { get; set; }
		public EquipType EquipType2 { get; set; }
		[Property(PropertyName.ItemGrade)]
		public int Grade { get; set; }
		[Property(PropertyName.UseLv)]
		public int MinLevel { get; set; }
		public int Durability { get; set; }
		[Property(PropertyName.MaxDur)]
		public int MaxDurability { get; set; }
		[Property(PropertyName.MINATK)]
		public float MinAtk { get; set; }
		[Property(PropertyName.MAXATK)]
		public float MaxAtk { get; set; }
		[Property(PropertyName.PATK)]
		public float PAtk { get; set; }
		[Property(PropertyName.MATK)]
		public float MAtk { get; set; }
		[Property(PropertyName.ADD_MINATK)]
		public float AddMinAtk { get; set; }
		[Property(PropertyName.ADD_MINATK)]
		public float AddMaxAtk { get; set; }
		[Property(PropertyName.ADD_MATK)]
		public float AddMAtk { get; set; }
		[Property(PropertyName.DEF)]
		public float Def { get; set; }
		[Property(PropertyName.MDEF)]
		public float MDef { get; set; }
		[Property(PropertyName.ADD_DEF)]
		public float AddDef { get; set; }
		[Property(PropertyName.ADD_MDEF)]
		public float AddMDef { get; set; }
		[Property(PropertyName.ADD_SMALLSIZE)]
		public float SmallSizeBonus { get; set; }
		[Property(PropertyName.ADD_MIDDLESIZE)]
		public float MediumSizeBonus { get; set; }
		[Property(PropertyName.ADD_LARGESIZE)]
		public float LargeSizeBonus { get; set; }
		public ArmorMaterialType Material { get; set; }

		[Property(PropertyName.Slash)]
		public float Slash { get; set; }
		[Property(PropertyName.Aries)]
		public float Aries { get; set; }
		[Property(PropertyName.Strike)]
		public float Strike { get; set; }
		[Property(PropertyName.SlashDEF)]
		public float SlashDefense { get; set; }
		[Property(PropertyName.AriesDEF)]
		public float AriesDefense { get; set; }
		[Property(PropertyName.StrikeDEF)]
		public float StrikeDefense { get; set; }
		[Property(PropertyName.Slash_Range)]
		public float SlashRange { get; set; }
		[Property(PropertyName.Aries_Range)]
		public float AriesRange { get; set; }
		[Property(PropertyName.Strike_Range)]
		public float StrikeRange { get; set; }

		[Property(PropertyName.RES_FIRE)]
		public float FireResistence { get; set; }
		[Property(PropertyName.RES_ICE)]
		public float IceResistence { get; set; }
		[Property(PropertyName.RES_LIGHTNING)]
		public float LightningResistence { get; set; }
		[Property(PropertyName.RES_EARTH)]
		public float EarthResistence { get; set; }
		[Property(PropertyName.RES_POISON)]
		public float PoisonResistence { get; set; }
		[Property(PropertyName.RES_HOLY)]
		public float HolyResistence { get; set; }
		[Property(PropertyName.RES_DARK)]
		public float DarkResistence { get; set; }
		[Property(PropertyName.RES_SOUL)]
		public float SoulResistence { get; set; }

		[Property(PropertyName.CRTHR)]
		public float CriticalHitRate { get; set; }
		[Property(PropertyName.CRTATK)]
		public float CriticalAttack { get; set; }
		[Property(PropertyName.CRTDR)]
		public float CriticalDodgeRate { get; set; }
		[Property(PropertyName.ADD_HR)]
		public float AddHitRate { get; set; }
		[Property(PropertyName.ADD_DR)]
		public float AddDodgeRate { get; set; }
		[Property(PropertyName.STR)]
		public float Str { get; set; }
		[Property(PropertyName.DEX)]
		public float Dex { get; set; }
		[Property(PropertyName.CON)]
		public float Con { get; set; }
		[Property(PropertyName.INT)]
		public float Int { get; set; }
		[Property(PropertyName.MNA)]
		public float Mna { get; set; }
		[Property(PropertyName.SR)]
		public float SR { get; set; }
		[Property(PropertyName.SDR)]
		public float SDR { get; set; }
		[Property(PropertyName.CRTMATK)]
		public float CriticalMagicAttack { get; set; }
		[Property(PropertyName.MGP)]
		public float MGP { get; set; }
		[Property(PropertyName.AddSkillMaxR)]
		public float AddSkillMaxR { get; set; }
		[Property(PropertyName.SkillRange)]
		public float SkillRange { get; set; }
		[Property(PropertyName.SkillAngle)]
		public float SkillAngle { get; set; }
		[Property(PropertyName.Luck)]
		public float Luck { get; set; }
		[Property(PropertyName.BlockRate)]
		public float BlockRate { get; set; }
		[Property(PropertyName.BLK)]
		public float Block { get; set; }
		[Property(PropertyName.BLK_BREAK)]
		public float BlockBreak { get; set; }
		[Property(PropertyName.Revive)]
		public float Revive { get; set; }
		[Property(PropertyName.HitCount)]
		public float HitCount { get; set; }
		[Property(PropertyName.BackHit)]
		public float BackHit { get; set; }
		[Property(PropertyName.SkillPower)]
		public float SkillPower { get; set; }
		[Property(PropertyName.ASPD)]
		public float ASPD { get; set; }
		[Property(PropertyName.MSPD)]
		public float MSPD { get; set; }
		[Property(PropertyName.KDPow)]
		public float KnockdownPower { get; set; }
		[Property(PropertyName.MHP)]
		public float MHp { get; set; }
		[Property(PropertyName.MSP)]
		public float MSp { get; set; }
		[Property(PropertyName.MSTA)]
		public float Msta { get; set; }
		[Property(PropertyName.RHP)]
		public float RHp { get; set; }
		[Property(PropertyName.RSP)]
		public float RSp { get; set; }
		[Property(PropertyName.RSPTIME)]
		public float RSptime { get; set; }
		[Property(PropertyName.RSTA)]
		public float RSta { get; set; }
		[Property(PropertyName.ADD_CLOTH)]
		public float ClothBonus { get; set; }
		[Property(PropertyName.ADD_LEATHER)]
		public float LeatherBonus { get; set; }
		[Property(PropertyName.ADD_CHAIN)]
		public float ChainBonus { get; set; }
		[Property(PropertyName.ADD_IRON)]
		public float IronBonus { get; set; }
		[Property(PropertyName.ADD_GHOST)]
		public float AddGhost { get; set; }
		[Property(PropertyName.ADD_FORESTER)]
		public float AddForester { get; set; }
		[Property(PropertyName.ADD_WIDLING)]
		public float AddWidling { get; set; }
		[Property(PropertyName.ADD_VELIAS)]
		public float AddVelias { get; set; }
		[Property(PropertyName.ADD_PARAMUNE)]
		public float AddParamune { get; set; }
		[Property(PropertyName.ADD_KLAIDA)]
		public float AddKlaida { get; set; }
		[Property(PropertyName.ADD_FIRE)]
		public float AddFire { get; set; }
		[Property(PropertyName.ADD_ICE)]
		public float AddIce { get; set; }
		[Property(PropertyName.ADD_POISON)]
		public float AddPoison { get; set; }
		[Property(PropertyName.ADD_LIGHTNING)]
		public float AddLightning { get; set; }
		[Property(PropertyName.ADD_EARTH)]
		public float AddEarth { get; set; }
		[Property(PropertyName.ADD_SOUL)]
		public float AddSoul { get; set; }
		[Property(PropertyName.ADD_HOLY)]
		public float AddHoly { get; set; }
		[Property(PropertyName.ADD_DARK)]
		public float AddDark { get; set; }
		[Property(PropertyName.ADD_BOSS_ATK)]
		public float AddBossAtk { get; set; }
		[Property(PropertyName.BaseSocket)]
		public float BaseSocket { get; set; }
		[Property(PropertyName.MaxSocket_COUNT)]
		public float MaxSocketCount { get; set; }
		[Property(PropertyName.BaseSocket_MA)]
		public float BaseSocketMa { get; set; }
		[Property(PropertyName.MaxSocket_MA)]
		public float MaxSocketMa { get; set; }
		[Property(PropertyName.MinOption)]
		public float MinOption { get; set; }
		[Property(PropertyName.MaxOption)]
		public float MaxOption { get; set; }
		public float MinRDmg { get; set; }
		public float MaxRDmg { get; set; }
		public float FDMinR { get; set; }
		public float FDMaxR { get; set; }
		[Property(PropertyName.LifeTime)]
		public float LifeTime { get; set; }
		[Property(PropertyName.ItemLifeTimeOver)]
		public float ItemLifeTimeOver { get; set; }
		[Property(PropertyName.NeedAppraisal)]
		public float NeedAppraisal { get; set; }
		[Property(PropertyName.NeedRandomOption)]
		public float NeedRandomOption { get; set; }
		public float LootingChance { get; set; }
		public float IsAlwaysHatVisible { get; set; }
		public float SkillWidthRange { get; set; }
		public float DynamicLifeTime { get; set; }
		public float TeamBelonging { get; set; }
		[Property(PropertyName.Add_Damage_Atk)]
		public float AddDamageAtk { get; set; }
		[Property(PropertyName.ResAdd_Damage)]
		public float ResAddDamage { get; set; }
		[Property(PropertyName.JobGrade)]
		public float JobGrade { get; set; }
		[Property(PropertyName.Magic_Ice_Atk)]
		public float MagicIceAtk { get; set; }
		[Property(PropertyName.Magic_Earth_Atk)]
		public float MagicEarthAtk { get; set; }
		[Property(PropertyName.Magic_Soul_Atk)]
		public float MagicSoulAtk { get; set; }
		[Property(PropertyName.Magic_Dark_Atk)]
		public float MagicDarkAtk { get; set; }
		[Property(PropertyName.Magic_Melee_Atk)]
		public float MagicMeleeAtk { get; set; }
		[Property(PropertyName.Magic_Fire_Atk)]
		public float MagicFireAtk { get; set; }
		[Property(PropertyName.Magic_Lightning_Atk)]
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
			data.AddDef = entry.ReadFloat("defBonus", 0);
			data.AddMDef = entry.ReadFloat("mDefBonus", 0);
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
			data.AriesRange = entry.ReadFloat("ariesRange", 0);
			data.SlashRange = entry.ReadFloat("slashRange", 0);
			data.StrikeRange = entry.ReadFloat("strikeRange", 0);

			data.FireResistence = entry.ReadFloat("fireRes", 0);
			data.IceResistence = entry.ReadFloat("iceRes", 0);
			data.PoisonResistence = entry.ReadFloat("poisonRes", 0);
			data.LightningResistence = entry.ReadFloat("lightningRes", 0);
			data.EarthResistence = entry.ReadFloat("earthRes", 0);
			data.SoulResistence = entry.ReadFloat("soulRes", 0);
			data.HolyResistence = entry.ReadFloat("holyRes", 0);
			data.DarkResistence = entry.ReadFloat("darkRes", 0);

			data.CriticalAttack = entry.ReadFloat("criticalAttack", 0);
			data.CriticalMagicAttack = entry.ReadFloat("criticalMagicAttack", 0);
			data.CriticalHitRate = entry.ReadFloat("criticalHitRate", 0);
			data.CriticalDodgeRate = entry.ReadFloat("criticalDodgeRate", 0);
			data.AddHitRate = entry.ReadFloat("hitRateBonus", 0);
			data.AddDodgeRate = entry.ReadFloat("dodgeRateBonus", 0);
			data.Str = entry.ReadFloat("str", 0);
			data.Dex = entry.ReadFloat("dex", 0);
			data.Con = entry.ReadFloat("con", 0);
			data.Int = entry.ReadFloat("int", 0);
			data.Mna = entry.ReadFloat("mna", 0);
			data.SR = entry.ReadFloat("sr", 0);
			data.SDR = entry.ReadFloat("sdr", 0);
			data.MGP = entry.ReadFloat("mgp", 0);
			data.AddSkillMaxR = entry.ReadFloat("addSkillMaxR", 0);
			data.SkillRange = entry.ReadFloat("skillRange", 0);
			data.SkillAngle = entry.ReadFloat("skillAngle", 0);
			data.Luck = entry.ReadFloat("luck", 0);
			data.BlockRate = entry.ReadFloat("blockRate", 0);
			data.Block = entry.ReadFloat("block", 0);
			data.BlockBreak = entry.ReadFloat("blockBreak", 0);
			data.Revive = entry.ReadFloat("revive", 0);
			data.HitCount = entry.ReadFloat("hitCount", 0);
			data.BackHit = entry.ReadFloat("backHit", 0);
			data.SkillPower = entry.ReadFloat("skillPower", 0);
			data.ASPD = entry.ReadFloat("aspd", 0);
			data.MSPD = entry.ReadFloat("mspd", 0);
			data.KnockdownPower = entry.ReadFloat("knockdownPower", 0);
			data.MHp = entry.ReadFloat("maxHp", 0);
			data.MSp = entry.ReadFloat("maxSp", 0);
			data.Msta = entry.ReadFloat("maxStamina", 0);
			data.RHp = entry.ReadFloat("recoveryHp", 0);
			data.RSp = entry.ReadFloat("recoverySp", 0);
			data.RSptime = entry.ReadFloat("recoverySpTime", 0);
			data.RSta = entry.ReadFloat("recoverySta", 0);
			data.ClothBonus = entry.ReadFloat("clothDamageBonus", 0);
			data.LeatherBonus = entry.ReadFloat("leatherDamageBonus", 0);
			data.ChainBonus = entry.ReadFloat("chainDamageBonus", 0);
			data.IronBonus = entry.ReadFloat("ironDamageBonus", 0);
			data.AddGhost = entry.ReadFloat("ghostDamageBonus", 0);
			data.AddForester = entry.ReadFloat("foresterDamageBonus", 0);
			data.AddWidling = entry.ReadFloat("widlingDamageBonus", 0);
			data.AddVelias = entry.ReadFloat("veliasDamageBonus", 0);
			data.AddParamune = entry.ReadFloat("paramuneDamageBonus", 0);
			data.AddKlaida = entry.ReadFloat("klaidaDamageBonus", 0);
			data.AddFire = entry.ReadFloat("fireDamageBonus", 0);
			data.AddIce = entry.ReadFloat("iceDamageBonus", 0);
			data.AddPoison = entry.ReadFloat("poisonDamageBonus", 0);
			data.AddLightning = entry.ReadFloat("lightningDamageBonus", 0);
			data.AddEarth = entry.ReadFloat("earthDamageBonus", 0);
			data.AddSoul = entry.ReadFloat("soulDamageBonus", 0);
			data.AddHoly = entry.ReadFloat("holyDamageBonus", 0);
			data.AddDark = entry.ReadFloat("darkDamageBonus", 0);
			data.AddBossAtk = entry.ReadFloat("bossBonusDamage", 0);
			data.BaseSocket = entry.ReadFloat("maxSocketCount", 0);
			data.MaxSocketCount = entry.ReadFloat("maxSocketCount", 0);
			data.BaseSocketMa = entry.ReadFloat("baseSocketMagicAmulet", 0);
			data.MaxSocketMa = entry.ReadFloat("maxSocketMagicAmulet", 0);
			data.MinOption = entry.ReadFloat("minOption", 0);
			data.MaxOption = entry.ReadFloat("maxOption", 0);
			data.MinRDmg = entry.ReadFloat("minRDmg", 0);
			data.MaxRDmg = entry.ReadFloat("maxRDmg", 0);
			data.FDMinR = entry.ReadFloat("fdMinR", 0);
			data.FDMaxR = entry.ReadFloat("fdMaxR", 0);
			data.LifeTime = entry.ReadFloat("lifetime", 0);
			data.ItemLifeTimeOver = entry.ReadFloat("itemLifeTimeOver", 0);
			data.NeedAppraisal = entry.ReadFloat("needAppraisal", 0);
			data.NeedRandomOption = entry.ReadFloat("needRandomOption", 0);
			data.LootingChance = entry.ReadFloat("lootingchance", 0);
			data.IsAlwaysHatVisible = entry.ReadFloat("isAlwaysHatVisible", 0);
			data.SkillWidthRange = entry.ReadFloat("skillWidthRange", 0);
			data.DynamicLifeTime = entry.ReadFloat("dynamicLifeTime", 0);
			data.TeamBelonging = entry.ReadFloat("teamBelonging", 0);
			data.AddDamageAtk = entry.ReadFloat("addDamageAtk", 0);
			data.MagicEarthAtk = entry.ReadFloat("magicEarthAtk", 0);
			data.ResAddDamage = entry.ReadFloat("resAddDamage", 0);
			data.JobGrade = entry.ReadFloat("jobGrade", 0);
			data.MagicIceAtk = entry.ReadFloat("magicIceAtk", 0);
			data.MagicSoulAtk = entry.ReadFloat("magicSoulAtk", 0);
			data.MagicDarkAtk = entry.ReadFloat("magicDarkAtk", 0);
			data.MagicMeleeAtk = entry.ReadFloat("magicMeleeAtk", 0);
			data.MagicFireAtk = entry.ReadFloat("magicFireAtk", 0);
			data.MagicLightningAtk = entry.ReadFloat("magicLightningAtk", 0);

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
