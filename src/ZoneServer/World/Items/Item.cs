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
		public bool NeedRandomOptions => this.Properties.GetFloat(PropertyName.NeedRandomOption) != 0;

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

			if (this.Data.MinAtk != 0) this.Properties.SetFloat(PropertyName.MINATK, this.Data.MinAtk);
			if (this.Data.MaxAtk != 0) this.Properties.SetFloat(PropertyName.MAXATK, this.Data.MaxAtk);
			if (this.Data.MAtk != 0) this.Properties.SetFloat(PropertyName.MATK, this.Data.MAtk);
			if (this.Data.PAtk != 0) this.Properties.SetFloat(PropertyName.PATK, this.Data.PAtk);
			if (this.Data.AddMinAtk != 0) this.Properties.SetFloat(PropertyName.ADD_MINATK, this.Data.AddMinAtk);
			if (this.Data.AddMaxAtk != 0) this.Properties.SetFloat(PropertyName.ADD_MAXATK, this.Data.AddMaxAtk);
			if (this.Data.AddMAtk != 0) this.Properties.SetFloat(PropertyName.ADD_MATK, this.Data.AddMAtk);
			if (this.Data.Def != 0) this.Properties.SetFloat(PropertyName.DEF, this.Data.Def);
			if (this.Data.MDef != 0) this.Properties.SetFloat(PropertyName.MDEF, this.Data.MDef);
			if (this.Data.AddDef != 0) this.Properties.SetFloat(PropertyName.ADD_DEF, this.Data.AddDef);
			if (this.Data.AddMDef != 0) this.Properties.SetFloat(PropertyName.ADD_MDEF, this.Data.AddMDef);
			if (this.Data.CrtHR != 0) this.Properties.SetFloat(PropertyName.CRTHR, this.Data.CrtHR);
			if (this.Data.CrtATK != 0) this.Properties.SetFloat(PropertyName.CRTATK, this.Data.CrtATK);
			if (this.Data.CrtDR != 0) this.Properties.SetFloat(PropertyName.CRTDR, this.Data.CrtDR);
			if (this.Data.AddHR != 0) this.Properties.SetFloat(PropertyName.ADD_HR, this.Data.AddHR);
			if (this.Data.AddDR != 0) this.Properties.SetFloat(PropertyName.ADD_DR, this.Data.AddDR);
			if (this.Data.Str != 0) this.Properties.SetFloat(PropertyName.STR, this.Data.Str);
			if (this.Data.Dex != 0) this.Properties.SetFloat(PropertyName.DEX, this.Data.Dex);
			if (this.Data.Con != 0) this.Properties.SetFloat(PropertyName.CON, this.Data.Con);
			if (this.Data.Int != 0) this.Properties.SetFloat(PropertyName.INT, this.Data.Int);
			if (this.Data.Mna != 0) this.Properties.SetFloat(PropertyName.MNA, this.Data.Mna);
			if (this.Data.Sr != 0) this.Properties.SetFloat(PropertyName.SR, this.Data.Sr);
			if (this.Data.Sdr != 0) this.Properties.SetFloat(PropertyName.SDR, this.Data.Sdr);
			if (this.Data.CrtMAtk != 0) this.Properties.SetFloat(PropertyName.CRTMATK, this.Data.CrtMAtk);
			if (this.Data.Mgp != 0) this.Properties.SetFloat(PropertyName.MGP, this.Data.Mgp);
			if (this.Data.AddSkillMaxR != 0) this.Properties.SetFloat(PropertyName.AddSkillMaxR, this.Data.AddSkillMaxR);
			if (this.Data.Skillrange != 0) this.Properties.SetFloat(PropertyName.SkillRange, this.Data.Skillrange);
			if (this.Data.Skillangle != 0) this.Properties.SetFloat(PropertyName.SkillAngle, this.Data.Skillangle);
			if (this.Data.Luck != 0) this.Properties.SetFloat(PropertyName.Luck, this.Data.Luck);
			if (this.Data.Blockrate != 0) this.Properties.SetFloat(PropertyName.BlockRate, this.Data.Blockrate);
			if (this.Data.Blk != 0) this.Properties.SetFloat(PropertyName.BLK, this.Data.Blk);
			if (this.Data.BlkBreak != 0) this.Properties.SetFloat(PropertyName.BLK_BREAK, this.Data.BlkBreak);
			if (this.Data.Revive != 0) this.Properties.SetFloat(PropertyName.Revive, this.Data.Revive);
			if (this.Data.HitCount != 0) this.Properties.SetFloat(PropertyName.HitCount, this.Data.HitCount);
			if (this.Data.BackHit != 0) this.Properties.SetFloat(PropertyName.BackHit, this.Data.BackHit);
			if (this.Data.SkillPower != 0) this.Properties.SetFloat(PropertyName.SkillPower, this.Data.SkillPower);
			if (this.Data.Aspd != 0) this.Properties.SetFloat(PropertyName.ASPD, this.Data.Aspd);
			if (this.Data.Mspd != 0) this.Properties.SetFloat(PropertyName.MSPD, this.Data.Mspd);
			if (this.Data.KdPow != 0) this.Properties.SetFloat(PropertyName.KDPow, this.Data.KdPow);
			if (this.Data.MHp != 0) this.Properties.SetFloat(PropertyName.MHP, this.Data.MHp);
			if (this.Data.MSp != 0) this.Properties.SetFloat(PropertyName.MSP, this.Data.MSp);
			if (this.Data.Msta != 0) this.Properties.SetFloat(PropertyName.MSTA, this.Data.Msta);
			if (this.Data.RHp != 0) this.Properties.SetFloat(PropertyName.RHP, this.Data.RHp);
			if (this.Data.RSp != 0) this.Properties.SetFloat(PropertyName.RSP, this.Data.RSp);
			if (this.Data.RSptime != 0) this.Properties.SetFloat(PropertyName.RSPTIME, this.Data.RSptime);
			if (this.Data.RSta != 0) this.Properties.SetFloat(PropertyName.RSTA, this.Data.RSta);
			if (this.Data.AddCloth != 0) this.Properties.SetFloat(PropertyName.ADD_CLOTH, this.Data.AddCloth);
			if (this.Data.AddLeather != 0) this.Properties.SetFloat(PropertyName.ADD_LEATHER, this.Data.AddLeather);
			if (this.Data.AddChain != 0) this.Properties.SetFloat(PropertyName.ADD_CHAIN, this.Data.AddChain);
			if (this.Data.AddIron != 0) this.Properties.SetFloat(PropertyName.ADD_IRON, this.Data.AddIron);
			if (this.Data.AddGhost != 0) this.Properties.SetFloat(PropertyName.ADD_GHOST, this.Data.AddGhost);
			if (this.Data.AddSmallsize != 0) this.Properties.SetFloat(PropertyName.ADD_SMALLSIZE, this.Data.AddSmallsize);
			if (this.Data.AddMiddlesize != 0) this.Properties.SetFloat(PropertyName.ADD_MIDDLESIZE, this.Data.AddMiddlesize);
			if (this.Data.AddLargesize != 0) this.Properties.SetFloat(PropertyName.ADD_LARGESIZE, this.Data.AddLargesize);
			if (this.Data.AddForester != 0) this.Properties.SetFloat(PropertyName.ADD_FORESTER, this.Data.AddForester);
			if (this.Data.AddWidling != 0) this.Properties.SetFloat(PropertyName.ADD_WIDLING, this.Data.AddWidling);
			if (this.Data.AddVelias != 0) this.Properties.SetFloat(PropertyName.ADD_VELIAS, this.Data.AddVelias);
			if (this.Data.AddParamune != 0) this.Properties.SetFloat(PropertyName.ADD_PARAMUNE, this.Data.AddParamune);
			if (this.Data.AddKlaida != 0) this.Properties.SetFloat(PropertyName.ADD_KLAIDA, this.Data.AddKlaida);
			if (this.Data.AddFire != 0) this.Properties.SetFloat(PropertyName.ADD_FIRE, this.Data.AddFire);
			if (this.Data.AddIce != 0) this.Properties.SetFloat(PropertyName.ADD_ICE, this.Data.AddIce);
			if (this.Data.AddPoison != 0) this.Properties.SetFloat(PropertyName.ADD_POISON, this.Data.AddPoison);
			if (this.Data.AddLightning != 0) this.Properties.SetFloat(PropertyName.ADD_LIGHTNING, this.Data.AddLightning);
			if (this.Data.AddEarth != 0) this.Properties.SetFloat(PropertyName.ADD_EARTH, this.Data.AddEarth);
			if (this.Data.AddSoul != 0) this.Properties.SetFloat(PropertyName.ADD_SOUL, this.Data.AddSoul);
			if (this.Data.AddHoly != 0) this.Properties.SetFloat(PropertyName.ADD_HOLY, this.Data.AddHoly);
			if (this.Data.AddDark != 0) this.Properties.SetFloat(PropertyName.ADD_DARK, this.Data.AddDark);
			if (this.Data.BaseSocket != 0) this.Properties.SetFloat(PropertyName.BaseSocket, this.Data.BaseSocket);
			if (this.Data.MaxSocketCount != 0) this.Properties.SetFloat(PropertyName.MaxSocket_COUNT, this.Data.MaxSocketCount);
			if (this.Data.BaseSocketMa != 0) this.Properties.SetFloat(PropertyName.BaseSocket_MA, this.Data.BaseSocketMa);
			if (this.Data.MaxSocketMa != 0) this.Properties.SetFloat(PropertyName.MaxSocket_MA, this.Data.MaxSocketMa);
			if (this.Data.Minoption != 0) this.Properties.SetFloat(PropertyName.MinOption, this.Data.Minoption);
			if (this.Data.Maxoption != 0) this.Properties.SetFloat(PropertyName.MaxOption, this.Data.Maxoption);
			if (this.Data.Aries != 0) this.Properties.SetFloat(PropertyName.Aries, this.Data.Aries);
			if (this.Data.AriesDefense != 0) this.Properties.SetFloat(PropertyName.AriesDEF, this.Data.AriesDefense);
			if (this.Data.Slash != 0) this.Properties.SetFloat(PropertyName.Slash, this.Data.Slash);
			if (this.Data.SlashDefense != 0) this.Properties.SetFloat(PropertyName.SlashDEF, this.Data.SlashDefense);
			if (this.Data.Strike != 0) this.Properties.SetFloat(PropertyName.Strike, this.Data.Strike);
			if (this.Data.StrikeDefense != 0) this.Properties.SetFloat(PropertyName.StrikeDEF, this.Data.StrikeDefense);
			if (this.Data.AriesRange != 0) this.Properties.SetFloat(PropertyName.Aries_Range, this.Data.AriesRange);
			if (this.Data.SlashRange != 0) this.Properties.SetFloat(PropertyName.Slash_Range, this.Data.SlashRange);
			if (this.Data.StrikeRange != 0) this.Properties.SetFloat(PropertyName.Strike_Range, this.Data.StrikeRange);
			if (this.Data.MinRDmg != 0) this.Properties.SetFloat(PropertyName.MinRDmg, this.Data.MinRDmg);
			if (this.Data.MaxRDmg != 0) this.Properties.SetFloat(PropertyName.MaxRDmg, this.Data.MaxRDmg);
			if (this.Data.FdMinR != 0) this.Properties.SetFloat(PropertyName.FDMinR, this.Data.FdMinR);
			if (this.Data.FdMaxR != 0) this.Properties.SetFloat(PropertyName.FDMaxR, this.Data.FdMaxR);
			if (this.Data.FireResistence != 0) this.Properties.SetFloat(PropertyName.RES_FIRE, this.Data.FireResistence);
			if (this.Data.IceResistence != 0) this.Properties.SetFloat(PropertyName.RES_ICE, this.Data.IceResistence);
			if (this.Data.PoisonResistence != 0) this.Properties.SetFloat(PropertyName.RES_POISON, this.Data.PoisonResistence);
			if (this.Data.LightningResistence != 0) this.Properties.SetFloat(PropertyName.RES_LIGHTNING, this.Data.LightningResistence);
			if (this.Data.EarthResistence != 0) this.Properties.SetFloat(PropertyName.RES_EARTH, this.Data.EarthResistence);
			if (this.Data.SoulResistence != 0) this.Properties.SetFloat(PropertyName.RES_SOUL, this.Data.SoulResistence);
			if (this.Data.HolyResistence != 0) this.Properties.SetFloat(PropertyName.RES_HOLY, this.Data.HolyResistence);
			if (this.Data.DarkResistence != 0) this.Properties.SetFloat(PropertyName.RES_DARK, this.Data.DarkResistence);
			if (this.Data.Lifetime != 0) this.Properties.SetFloat(PropertyName.LifeTime, this.Data.Lifetime);
			if (this.Data.Itemlifetimeover != 0) this.Properties.SetFloat(PropertyName.ItemLifeTimeOver, this.Data.Itemlifetimeover);
			if (this.Data.NeedAppraisal != 0) this.Properties.SetFloat(PropertyName.NeedAppraisal, this.Data.NeedAppraisal);
			if (this.Data.NeedRandomOption != 0) this.Properties.SetFloat(PropertyName.NeedRandomOption, this.Data.NeedRandomOption);
			if (this.Data.Lootingchance != 0) this.Properties.SetFloat(PropertyName.LootingChance, this.Data.Lootingchance);
			if (this.Data.Isalwayshatvisible != 0) this.Properties.SetFloat(PropertyName.IsAlwaysHatVisible, this.Data.Isalwayshatvisible);
			if (this.Data.SkillWidthRange != 0) this.Properties.SetFloat(PropertyName.SkillWidthRange, this.Data.SkillWidthRange);
			if (this.Data.DynamicLifeTime != 0) this.Properties.SetFloat(PropertyName.DynamicLifeTime, this.Data.DynamicLifeTime);
			if (this.Data.AddBossAtk != 0) this.Properties.SetFloat(PropertyName.ADD_BOSS_ATK, this.Data.AddBossAtk);
			if (this.Data.Teambelonging != 0) this.Properties.SetFloat(PropertyName.TeamBelonging, this.Data.Teambelonging);
			if (this.Data.AddDamageAtk != 0) this.Properties.SetFloat(PropertyName.Add_Damage_Atk, this.Data.AddDamageAtk);
			if (this.Data.MagicEarthAtk != 0) this.Properties.SetFloat(PropertyName.Magic_Earth_Atk, this.Data.MagicEarthAtk);
			if (this.Data.ResaddDamage != 0) this.Properties.SetFloat(PropertyName.ResAdd_Damage, this.Data.ResaddDamage);
			if (this.Data.JobGrade != 0) this.Properties.SetFloat(PropertyName.JobGrade, this.Data.JobGrade);
			if (this.Data.MagicIceAtk != 0) this.Properties.SetFloat(PropertyName.Magic_Ice_Atk, this.Data.MagicIceAtk);
			if (this.Data.MagicSoulAtk != 0) this.Properties.SetFloat(PropertyName.Magic_Soul_Atk, this.Data.MagicSoulAtk);
			if (this.Data.MagicDarkAtk != 0) this.Properties.SetFloat(PropertyName.Magic_Dark_Atk, this.Data.MagicDarkAtk);
			if (this.Data.MagicMeleeAtk != 0) this.Properties.SetFloat(PropertyName.Magic_Melee_Atk, this.Data.MagicMeleeAtk);
			if (this.Data.MagicFireAtk != 0) this.Properties.SetFloat(PropertyName.Magic_Fire_Atk, this.Data.MagicFireAtk);
			if (this.Data.MagicLightningAtk != 0) this.Properties.SetFloat(PropertyName.Magic_Lightning_Atk, this.Data.MagicLightningAtk);
			if (this.Data.Cooldown != 0) this.Properties.SetFloat(PropertyName.CoolDown, this.Data.Cooldown);
			if (this.Data.MinLevel != 0) this.Properties.SetFloat(PropertyName.UseLv, this.Data.MinLevel);
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
