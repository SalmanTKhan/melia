using System;
using System.Threading;
using Melia.Shared.Data.Database;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Tos.Const;
using Melia.Shared.Tos.Const.Web;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Maps;
using Yggdrasil.Util;

namespace Melia.Zone.World.Items
{
	/// <summary>
	/// An item, that might be lying around in the world or is owned by
	/// some entity.
	/// </summary>
	public class Item : IPropertyObject
	{
		private static long ObjectIds = ObjectIdRanges.Items;

		/// <summary>
		/// Returns the item's class id.
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// Returns a reference to the item's data from the item data file.
		/// </summary>
		public ItemData Data { get; private set; }

		/// <summary>
		/// Gets or sets the item's amount (clamped to 1~max),
		/// does not update the client.
		/// </summary>
		public int Amount
		{
			get { return _amount; }
			set
			{
				var max = (this.Data != null ? this.Data.MaxStack : 1);
				_amount = Math2.Clamp(1, max, value);
			}
		}
		private int _amount;

		/// <summary>
		/// Returns true if item's MaxStack is higher than 1, indicating
		/// that it can contain more than one item of its type.
		/// </summary>
		public bool IsStackable => this.Data.MaxStack > 1;

		/// <summary>
		/// Gets or sets item's globally unique db id.
		/// </summary>
		public long DbId { get; set; }

		/// <summary>
		/// Returns the globally unique object id.
		/// </summary>
		public virtual long ObjectId { get; } = Interlocked.Increment(ref ObjectIds);

		/// <summary>
		/// Returns item's buy price.
		/// </summary>
		public int Price { get; private set; }

		private int _durability = -1; // Initialized as -1 to force Max Durability if no durability specified.

		/// <summary>
		/// Returns the item's current durability.
		/// </summary>
		public int Durability
		{
			get => _durability;
			set => _durability = (int)Math2.Clamp(0, this.Properties.GetFloat(PropertyName.MaxDur), value);
		}

		/// <summary>
		/// Gets or sets whether the item is locked.
		/// </summary>
		/// <remarks>
		/// XXX: Should this be saved? If so, we have to figure out where
		///   that goes in the item data.
		/// </remarks>
		public bool IsLocked { get; set; }

		/// <summary>
		/// Gets or sets an expiration date on the item
		/// </summary>
		public DateTime ExpirationDate { get; private set; } = DateTime.MaxValue;

		/// <summary>
		/// Checks if an item is expiring or can expire.
		/// </summary>
		public bool IsExpiring => this.ExpirationDate != DateTime.MaxValue;

		/// <summary>
		/// Returns the handle of the entity who originally dropped the item.
		/// </summary>
		public int OriginalOwnerHandle { get; private set; } = -1;

		/// <summary>
		/// Returns the time at which the owner can pick the item back up.
		/// </summary>
		public DateTime RePickUpTime { get; private set; }

		/// <summary>
		/// Gets or sets the owner of the item, who is the only one able
		/// to pick it up while the loot protection is active.
		/// </summary>
		public int OwnerHandle { get; private set; } = -1;

		/// <summary>
		/// Returns the time at which the item is free to be picked up
		/// by anyone.
		/// </summary>
		public DateTime LootProtectionEnd { get; private set; } = DateTime.MinValue;

		/// <summary>
		/// Returns the item's property collection.
		/// </summary>
		public Properties Properties { get; } = new Properties("Item");

		/// <summary>
		/// Returns reference to the item's cooldown data from the database
		/// database.
		/// </summary>
		public CooldownData CooldownData { get; private set; }

		/// <summary>
		/// Returns the if the option has random options generated
		/// </summary>
		public bool NeedRandomOptions => this.Properties.GetFloat(PropertyName.NeedRandomOption) == 1;

		public bool IsLegendGroupItem => this.Properties.GetString("LegendGroup", "None") != "None";

		/// <summary>
		/// Returns if the item is saved.
		/// </summary>
		public bool IsSaved => this.DbId != 0;

		/// <summary>
		/// Creates new item.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="amount"></param>
		public Item(long dbId, int itemId, int amount = 1)
		{
			this.DbId = dbId;
			this.Id = itemId;
			this.LoadData();

			// Set amount after loading the data so we can clamp it
			// to the max stack size
			this.Amount = amount;
		}

		/// <summary>
		/// Creates new item.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="amount"></param>
		public Item(int itemId, int amount = 1)
		{
			this.Id = itemId;
			this.LoadData();

			// Set amount after loading the data so we can clamp it
			// to the max stack size
			this.Amount = amount;
		}

		/// <summary>
		/// Loads item data from data files.
		/// </summary>
		private void LoadData()
		{
			if (this.Id == 0)
				throw new InvalidOperationException("Item id wasn't set before calling LoadData.");

			this.Data = ZoneServer.Instance.Data.ItemDb.Find(this.Id);
			if (this.Data == null)
				throw new NullReferenceException("No item data found for '" + this.Id + "'.");

			if (!string.IsNullOrEmpty(this.Data.CooldownGroup))
			{
				this.CooldownData = ZoneServer.Instance.Data.CooldownDb.Find(this.Data.CooldownGroup);
				if (this.CooldownData == null)
					throw new NullReferenceException($"Unknown item '{this.Id}' cooldown group '{this.Data.CooldownGroup}'.");
			}

			this.Properties.CopyFrom(this.Data.Properties);

			if (this.Data.MaxDurability != 0)
			{
				this.Properties.SetFloat(PropertyName.MaxDur, this.Data.MaxDurability);
				if (this.Data.Name.StartsWith("Old "))
					this.Properties.Modify(PropertyName.MaxDur, -this.Data.MaxDurability * .50f);
				if (_durability != -1)
					this.Properties.SetFloat(PropertyName.Dur, this.Durability);
				else
					this.Properties.SetFloat(PropertyName.Dur, this.Properties.GetFloat(PropertyName.MaxDur));
			}

			if (this.Data.Grade != 0)
			{
				var modifier = (this.Data.Grade * 0.05f) + 0.05f;

				this.Properties.SetFloat(PropertyName.ItemGrade, this.Data.Grade);

				if (this.Data.MinAtk != 0)
					this.Properties.Modify(PropertyName.MINATK, MathF.Floor(this.Data.MinAtk * modifier));

				if (this.Data.MaxAtk != 0)
					this.Properties.Modify(PropertyName.MAXATK, MathF.Round(this.Data.MaxAtk * modifier));

				if (this.Data.MAtk != 0)
					this.Properties.Modify(PropertyName.MATK, MathF.Round(this.Data.MAtk * modifier));

				if (this.Data.PAtk != 0)
					this.Properties.Modify(PropertyName.PATK, MathF.Round(this.Data.PAtk * modifier));
			}
		}

		/// <summary>
		/// Returns the item's index in the inventory, using the given
		/// index as an offset for the category the item belongs to.
		/// </summary>
		/// <example>
		/// item = Drug_HP1
		/// item.GetInventoryIndex(5) => 265001 + 5 = 265006
		/// </example>
		/// <remarks>
		/// The client uses index ranges for categorizing the items.
		/// For example:
		/// 45000~109999:  Equipment/MainWeapon
		/// 265000~274999: Item/Consumable
		/// 
		/// The server needs to put the items indices into the correct
		/// ranges for them to appear where they belong, otherwise a
		/// potion might be put into the equip category.
		/// </remarks>
		/// <param name="index"></param>
		/// <returns></returns>
		public int GetInventoryIndex(int index)
		{
			// If the category is none, use the index. This will put
			// the item well below the first category at index 5000
			// and effectively hide it.
			if (this.Data.Category == InventoryCategory.None)
				return index;

			// Get the base id from the database, add the index and return it.
			if (!ZoneServer.Instance.Data.InvBaseIdDb.TryFind(this.Data.Category, out var invBaseData))
				throw new MissingFieldException($"Category '{this.Data.Category}' on item '{this.Id}' not found in base id database.");

			return invBaseData.BaseId + index;
		}

		/// <summary>
		/// Drops item to the map as an ItemMonster.
		/// </summary>
		/// <remarks>
		/// Items are typically dropped by "tossing" them from the source,
		/// such as a killed monster. The given position is the initial
		/// position, and the item is then tossed in the given direction,
		/// by the distance.
		/// </remarks>
		/// <param name="map">Map to drop to the item on.</param>
		/// <param name="position">Initial position of the drop item.</param>
		/// <param name="direction">Direction to toss the item in.</param>
		/// <param name="distance">Distance to toss the item.</param>
		public ItemMonster Drop(Map map, Position position, Direction direction, float distance, int layer = 0)
		{
			// ZC_NORMAL_ItemDrop animates the item flying from its
			// initial drop position to its final position. To keep
			// everything in sync, we use the monster's position as
			// the drop position, then add the item to the map,
			// and then make it fly and set the final position.
			// the direction of the item becomes the direction
			// it flies in.
			// FromGround is necessary for the client to attempt to
			// pick up the item. Might act as "IsYourDrop" for items.

			var itemMonster = ItemMonster.Create(this);
			var flyDropPos = position.GetRelative(direction, distance);

			itemMonster.Position = position;
			itemMonster.Direction = direction;
			itemMonster.FromGround = true;
			itemMonster.DisappearTime = DateTime.Now.AddSeconds(ZoneServer.Instance.Conf.World.DropDisappearSeconds);
			itemMonster.Layer = layer;

			map.AddMonster(itemMonster);

			itemMonster.Position = flyDropPos;
			Send.ZC_NORMAL.ItemDrop(itemMonster, direction, distance);

			return itemMonster;
		}

		/// <summary>
		/// Drops item to the map as an ItemMonster.
		/// </summary>
		/// <param name="map">Map to drop to the item on.</param>
		/// <param name="fromPosition">Initial position of the drop item.</param>
		/// <param name="toPosition">Position the item gets tossed to.</param>
		public ItemMonster Drop(Map map, Position fromPosition, Position toPosition, int layer = 0)
		{
			var direction = fromPosition.GetDirection(toPosition);
			var distance = (float)fromPosition.Get2DDistance(toPosition);

			return this.Drop(map, fromPosition, direction, distance, layer);
		}

		/// <summary>
		/// Activates the loot protection for the item if actor is set.
		/// Deactivates it if actor is null.
		/// </summary>
		/// <param name="actor"></param>
		/// <param name="protectionTime"></param>
		public void SetLootProtection(IActor actor, TimeSpan protectionTime)
		{
			if (actor == null)
			{
				this.OwnerHandle = -1;
				this.LootProtectionEnd = DateTime.MinValue;
			}
			else
			{
				this.OwnerHandle = actor.Handle;
				this.LootProtectionEnd = DateTime.Now.Add(protectionTime);
			}
		}

		/// <summary>
		/// Sets up a protection, so that the actor won't pick the item
		/// right back up.
		/// </summary>
		/// <param name="actor"></param>
		public void SetRePickUpProtection(IActor actor)
		{
			if (actor == null)
			{
				this.OriginalOwnerHandle = -1;
				this.RePickUpTime = DateTime.MinValue;
			}
			else
			{
				this.OriginalOwnerHandle = actor.Handle;
				this.RePickUpTime = DateTime.Now.AddSeconds(2);
			}
		}

		/// <summary>
		/// Clears protections, so the item can be picked up by anyone.
		/// </summary>
		/// <param name="entity"></param>
		public void ClearProtections()
		{
			this.SetLootProtection(null, TimeSpan.Zero);
			this.SetRePickUpProtection(null);
		}

		/// <summary>
		/// Modify the durability of an item and
		/// sends update to connection after modification.
		/// </summary>
		/// <param name="character"></param>
		/// <param name="amount">If set to -1, the durability will be reset to max.</param>
		public void ModifyDurability(Character character, int amount = -1)
		{
			var maxDurability = (int)this.Properties.GetFloat(PropertyName.MaxDur);
			if (this.Durability == maxDurability)
				return;
			if (amount == -1)
				this.Durability = maxDurability;
			else
				this.Durability += amount;
			Send.ZC_OBJECT_PROPERTY(character.Connection, this);
		}

		/// <summary>
		/// Generate random options on an item.
		/// </summary>
		/// <param name="minOptions"></param>
		/// <param name="maxOptions"></param>
		public void GenerateRandomOptions(int minOptions = 1, int maxOptions = 5)
		{
			if (!this.NeedRandomOptions)
				return;

			this.Properties.SetFloat(PropertyName.NeedRandomOption, 0);
			var random = RandomProvider.Get();
			var options = random.Next(minOptions, maxOptions);
			var utilOptions = new string[] { "CRTHR", "CRTDR", "BLK_BREAK", "BLK", "ADD_HR", "ADD_DR", "RHP", "MSP" };
			var atkOptions = new string[] { "ADD_CLOTH", "ADD_LEATHER", "ADD_IRON", "ADD_SMALLSIZE", "ADD_MIDDLESIZE",
				"ADD_LARGESIZE", "ADD_GHOST", "ADD_FORESTER", "ADD_WIDLING", "ADD_VELIAS",
				"ADD_PARAMUNE", "ADD_KLAIDA", "MiddleSize_Def","Cloth_Def", "Leather_Def", "Iron_Def"};
			var dmgOptions = new string[] { "ResAdd_Damage", "Add_Damage_Atk" };
			var statOptions = new string[] { "LootingChance", "STR", "DEX", "CON", "INT", "MNA", "RSP" };
			var staminaOption = "MSTA"; // Not used, seems useless
										// TODO: Weighted Random Options
			for (var i = 0; i < options; i++)
			{
				switch (i)
				{
					case 0:
						this.AddRandomOption(i + 1, atkOptions[random.Next(0, atkOptions.Length)], "ATK", ((this.Data.Group == ItemGroup.Weapon || this.Data.Group == ItemGroup.SubWeapon) ? random.Next(565, 1132) : random.Next(302, 605)));
						break;
					case 1:
						this.AddRandomOption(i + 1, utilOptions[random.Next(0, utilOptions.Length)],
							"UTIL_" + ((this.Data.Group == ItemGroup.Weapon || this.Data.Group == ItemGroup.SubWeapon) ? "WEAPON" : "ARMOR"),
							(this.Data.Group == ItemGroup.Weapon || this.Data.Group == ItemGroup.SubWeapon) ? random.Next(283, 567) : random.Next(131, 303));
						break;
					case 2:
						this.AddRandomOption(i + 1, dmgOptions[random.Next(0, dmgOptions.Length)], "ATK",
							(this.Data.Group == ItemGroup.Weapon || this.Data.Group == ItemGroup.SubWeapon) ? random.Next(565, 1132) : random.Next(302, 605));
						break;
					case 3:
						this.AddRandomOption(i + 1, statOptions[random.Next(0, statOptions.Length)], "STAT",
							(this.Data.Group == ItemGroup.Weapon || this.Data.Group == ItemGroup.SubWeapon) ? random.Next(85, 171) : random.Next(45, 92));
						break;
				}
			}
		}

		/// <summary>
		/// Add a random option to an item.
		/// </summary>
		/// <param name="optionIndex"></param>
		/// <param name="optionType"></param>
		/// <param name="optionGroup"></param>
		/// <param name="optionValue"></param>
		private void AddRandomOption(int optionIndex, string optionType, string optionGroup, float optionValue)
		{
			var optionPropId = string.Format("RandomOption_{0}", optionIndex);
			var optionPropGroup = string.Format("RandomOptionGroup_{0}", optionIndex);
			var optionPropValue = string.Format("RandomOptionValue_{0}", optionIndex);

			this.Properties.SetString(optionPropId, optionType);
			this.Properties.SetString(optionPropGroup, optionGroup);
			this.Properties.SetFloat(optionPropValue, optionValue);
		}

		/// <summary>
		/// This is based off the RandomOptions function,
		/// so inaccuracies in options are a possibility.
		/// </summary>
		public void GenerateRandomHatOptions(int minOptions = 1, int maxOptions = 2)
		{
			var random = RandomProvider.Get();
			var options = random.Next(minOptions, maxOptions);
			var utilOptions = new string[] { "CRTHR", "CRTDR", "BLK_BREAK", "BLK", "ADD_HR", "ADD_DR", "RHP" };
			var atkOptions = new string[] { "MSP", "ADD_CLOTH", "ADD_LEATHER", "ADD_IRON", "ADD_SMALLSIZE", "ADD_MIDDLESIZE",
				"ADD_LARGESIZE", "ADD_GHOST", "ADD_FORESTER", "ADD_WIDLING", "ADD_VELIAS",
				"ADD_PARAMUNE", "ADD_KLAIDA", "MiddleSize_Def","Cloth_Def", "Leather_Def", "Iron_Def"};
			var dmgOptions = new string[] { "ResAdd_Damage", "Add_Damage_Atk" };
			var statOptions = new string[] { "LootingChance", "STR", "DEX", "CON", "INT", "MNA", "RSP" };
			var staminaOption = "MSTA"; // Not used, seems useless
										// TODO: Weighted Random Options
			for (var i = 0; i < options; i++)
			{
				switch (i)
				{
					case 0:
						this.AddOption("HatProp", i + 1, atkOptions[random.Next(0, atkOptions.Length)], ((this.Data.Group == ItemGroup.Weapon || this.Data.Group == ItemGroup.SubWeapon) ? random.Next(565, 1132) : random.Next(302, 605)));
						break;
					case 1:
						this.AddOption("HatProp", i + 1, utilOptions[random.Next(0, utilOptions.Length)],
							((this.Data.Group == ItemGroup.Weapon || this.Data.Group == ItemGroup.SubWeapon) ? random.Next(283, 567) : random.Next(131, 303)));
						break;
					case 2:
						this.AddOption("HatProp", i + 1, dmgOptions[random.Next(0, dmgOptions.Length)],
							((this.Data.Group == ItemGroup.Weapon || this.Data.Group == ItemGroup.SubWeapon) ? random.Next(565, 1132) : random.Next(302, 605)));
						break;
					case 3:
						this.AddOption("HatProp", i, statOptions[random.Next(0, statOptions.Length)],
							((this.Data.Group == ItemGroup.Weapon || this.Data.Group == ItemGroup.SubWeapon) ? random.Next(85, 171) : random.Next(45, 92)));
						break;
				}
			}
		}

		/// <summary>
		/// Add an option to the item.
		/// </summary>
		/// <param name="optionPrefix"></param>
		/// <param name="optionIndex"></param>
		/// <param name="optionPropertyName"></param>
		/// <param name="optionValue"></param>
		private void AddOption(string optionPrefix, int optionIndex, string optionPropertyName, float optionValue)
		{
			var nameProp = string.Format("{0}Name_{1}", optionPrefix, optionIndex);
			var valueProp = string.Format("{0}Value_{1}", optionPrefix, optionIndex);

			// Reset previous value if it exists
			var optionName = this.Properties.GetString(nameProp);
			if (optionName != null && optionName != "None")
			{
				var prevValue = this.Properties.GetFloat(optionName);
				// Can we just set it to 0, rather than modify it?
				this.Properties.Modify(optionName, -prevValue);
			}

			this.Properties.SetString(nameProp, optionPropertyName);
			this.Properties.SetFloat(valueProp, optionValue);
			this.Properties.SetFloat(optionPropertyName, optionValue);
		}
	}
}
