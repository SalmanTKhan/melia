using System;
using System.Collections.Generic;
using System.Linq;
using Melia.Shared.Database;
using Melia.Shared.L10N;
using Melia.Shared.Network.Helpers;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Scripting;
using Melia.Shared.Tos.Const;
using Melia.Shared.Tos.Const.Web;
using Melia.Shared.Tos.Properties;
using Melia.Shared.Util;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting.AI;
using Melia.Zone.World.Actors.Characters.Components;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Components;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Composition;
using Yggdrasil.Logging;
using Yggdrasil.Scheduling;
using Yggdrasil.Util;

namespace Melia.Zone.World.Actors.Characters
{
	/// <summary>
	/// Represents a player character.
	/// </summary>
	public class Character : Actor, ICombatEntity, ICommander, IPropertyObject, IUpdateable
	{
		private bool _warping;
		private int _destinationChannelId;

		private readonly object _lookAroundLock = new object();
		private readonly object _hpLock = new object();
		private IMonster[] _visibleMonsters = new IMonster[0];
		private Character[] _visibleCharacters = new Character[0];

		private readonly static TimeSpan ResurrectDialogDelay = TimeSpan.FromSeconds(2);
		private TimeSpan _resurrectDialogTimer = ResurrectDialogDelay;

		/// <summary>
		/// Returns true if the character was just saved before a warp.
		/// </summary>
		internal bool SavedForWarp { get; private set; }

		/// <summary>
		/// Connection this character uses.
		/// </summary>
		public IZoneConnection Connection { get; set; }

		/// <summary>
		/// Returns the name of the character's account.
		/// </summary>
		public string Username => this.Connection.Account.Name;

		/// <summary>
		/// Gets or sets the character's unique database id.
		/// </summary>
		public long DbId { get; set; }

		/// <summary>
		/// Returns the character's globally unique id.
		/// </summary>
		public long ObjectId => ObjectIdRanges.Characters + this.DbId;

		/// <summary>
		/// Returns the character's globally unique id on the social server.
		/// </summary>
		public long SocialUserId => ObjectIdRanges.SocialUser + this.DbId;

		/// <summary>
		/// Id of the character's account.
		/// </summary>
		public long AccountDbId { get; set; }

		/// <summary>
		/// Id of the character's account.
		/// </summary>
		public long AccountObjectId => this.AccountDbId;

		/// <summary>
		/// Returns the character's faction.
		/// </summary>
		public FactionType Faction => FactionType.Law;

		/// <summary>
		/// Returns the character's race.
		/// </summary>
		public RaceType Race => RaceType.None;

		/// <summary>
		/// Returns the character's element/attribute.
		/// </summary>
		public AttributeType Attribute => (AttributeType)(int)this.Properties.GetFloat(PropertyName.Attribute, (int)AttributeType.None);

		/// <summary>
		/// Returns the character's armor material.
		/// </summary>
		public ArmorMaterialType ArmorMaterial => (ArmorMaterialType)(int)this.Properties.GetFloat(PropertyName.ArmorMaterial, (int)ArmorMaterialType.None);

		/// <summary>
		/// Returns the character's mode of movement.
		/// </summary>
		public MoveType MoveType => MoveType.Normal;

		/// <summary>
		/// Gets or sets the character's tendency
		/// </summary>
		public TendencyType Tendency { get; set; } = TendencyType.Peaceful;

		/// <summary>
		/// Character's name.
		/// </summary>
		public override string Name { get; set; }

		/// <summary>
		/// Character's team name.
		/// </summary>
		public string TeamName { get; set; }

		/// <summary>
		/// Gets or sets the character's current job id.
		/// </summary>
		/// <remarks>
		/// This should essentially and presumably alwas be the id of the
		/// last job the character changed to.
		/// </remarks>
		public JobId JobId { get; set; }

		/// <summary>
		/// Returns the class of the character's current job.
		/// </summary>
		public JobClass JobClass => this.JobId.ToClass();

		/// <summary>
		/// Returns the character's current job.
		/// </summary>
		public Job Job => this.Jobs.Get(this.JobId);

		/// <summary>
		/// Returns a reference to the character's job list.
		/// </summary>
		/// <remarks>
		/// A character has one main job which determines, for example,
		/// what items they can equip, but they can have various jobs,
		/// that all come with their own skills and abilities.
		/// </remarks>
		public JobComponent Jobs { get; }

		/// <summary>
		/// Character's gender.
		/// </summary>
		public Gender Gender { get; set; }

		/// <summary>
		/// Character's hair style.
		/// </summary>
		public int Hair { get; set; }

		/// <summary>
		/// Character's pose.
		/// </summary>
		public byte Pose { get; set; }

		/// <summary>
		/// Returns stance, based on job and other factors.
		/// </summary>
		public int Stance { get; protected set; }

		/// <summary>
		/// The map the character is in.
		/// </summary>
		public int MapId { get; set; }

		/// <summary>
		/// Character's head's direction.
		/// </summary>
		public Direction HeadDirection { get; set; }

		/// <summary>
		/// Gets or sets whether the character is sitting.
		/// </summary>
		public bool IsSitting { get; set; }

		/// <summary>
		/// The character's inventory.
		/// </summary>
		public InventoryComponent Inventory { get; }

		/// <summary>
		/// Gets or set the character's greeting message.
		/// </summary>
		public string GreetingMessage { get; set; }

		/// <summary>
		/// Holds the order of successive changes in character HP.
		/// A higher value indicates the latest HP amount.
		/// </summary>
		/// TODO: I'm not sure when this gets rolled over;
		///   More investigation is needed.
		public int HpChangeCounter { get; private set; }

		/// <summary>
		/// Gets or sets the character's chat balloon.
		/// </summary>
		public int ChatBalloon { get; set; } = 1;

		/// <summary>
		/// Get or set the character's chat balloon expiration
		/// Max Date: 2999/12/31 (2) 23:59:59:00
		/// </summary>
		public DateTime ChatBalloonExpiration { get; set; } = new DateTime(2999, 12, 31, 23, 59, 59, DateTimeKind.Local);

		/// <summary>
		/// Specifies whether the character currently updates the visible
		/// entities around the character.
		/// </summary>
		public bool EyesOpen { get; private set; }

		/// <summary>
		/// Character's scripting variables.
		/// </summary>
		public VariablesContainer Variables { get; } = new VariablesContainer();

		/// <summary>
		/// Specifies which hats are visible on the character.
		/// </summary>
		public VisibleEquip VisibleEquip { get; set; } = VisibleEquip.All;

		/// <summary>
		/// Current experience points.
		/// </summary>
		public long Exp { get; set; }

		/// <summary>
		/// Current maximum experience points.
		/// </summary>
		public long MaxExp { get; set; }

		/// <summary>
		/// Total number of accumulated experience points.
		/// </summary>
		public long TotalExp { get; set; }

		/// <summary>
		/// Returns the character's current class level, which is
		/// equivalent to their current job's level.
		/// </summary>
		public int ClassLevel
		{
			get
			{
				var job = this.Jobs.Get(this.JobId);
				return job.Level;
			}
		}

		/// <summary>
		/// Returns the character's current level.
		/// </summary>
		public int Level => (int)this.Properties.GetFloat(PropertyName.Lv);

		/// <summary>
		/// Returns the character's current HP.
		/// </summary>
		public int Hp => (int)this.Properties.GetFloat(PropertyName.HP);

		/// <summary>
		/// Returns the character's max HP.
		/// </summary>
		public int MaxHp => (int)this.Properties.GetFloat(PropertyName.MHP);

		/// <summary>
		/// Returns the character's current SP.
		/// </summary>
		public int Sp => (int)this.Properties.GetFloat(PropertyName.SP);

		/// <summary>
		/// Returns the character's max SP.
		/// </summary>
		public int MaxSp => (int)this.Properties.GetFloat(PropertyName.MSP);

		/// <summary>
		/// Returns the character's current stamina.
		/// </summary>
		public int Stamina => this.Properties.Stamina;

		/// <summary>
		/// Returns the character's max stamina.
		/// </summary>
		public int MaxStamina => this.Properties.MaxStamina;

		/// <summary>
		/// Returns true if the character has run out of HP and died.
		/// </summary>
		public bool IsDead => (this.Hp == 0);

		/// <summary>
		/// Character's session objects.
		/// </summary>
		public SessionObjects SessionObjects { get; } = new SessionObjects();

		/// <summary>
		/// Character's skills.
		/// </summary>
		public SkillComponent Skills { get; }

		/// <summary>
		/// Character's abilities.
		/// </summary>
		public AbilityComponent Abilities { get; }

		/// <summary>
		/// Character's buffs.
		/// </summary>
		public BuffComponent Buffs { get; }

		/// <summary>
		/// Returns the character's quests manager.
		/// </summary>
		public QuestComponent Quests { get; }

		/// <summary>
		/// Character's timed events.
		/// </summary>
		public TimedEventComponent TimedEvents { get; }

		/// <summary>
		/// Character's track manager.
		/// </summary>
		public TrackComponent Tracks { get; }

		/// <summary>
		/// Character's achievement manager.
		/// </summary>
		public AchievementComponent Achievements { get; }

		public AdventureBookComponent AdventureBook { get; }

		/// <summary>
		/// Returns the character's movement component.
		/// </summary>
		public MovementComponent Movement { get; }

		/// <summary>
		/// Returns the character's companion component.
		/// </summary>
		public CompanionComponent Companions { get; }

		/// <summary>
		/// Returns the character's summoned monsters.
		/// </summary>
		public SummonComponent Summons { get; }

		/// <summary>
		/// Returns the account's assister cabinet.
		/// </summary>
		public AssisterCabinet AssisterCabinet => this.Connection.Account.AssisterCabinet;

		/// <summary>
		/// Character's properties.
		/// </summary>
		/// <remarks>
		/// Beware, some of these are reference properties that can't be
		/// set directly. Use this object's actual properties whenever
		/// possible.
		/// </remarks>
		public CharacterProperties Properties { get; }

		/// <summary>
		/// PCEtc Properties
		/// Used for "Hiding NPC states", Quest Completions, Skintone, Hair
		/// </summary>
		public Properties EtcProperties { get; } = new Properties("PCEtc");

		/// <summary>
		/// GuildMember Properties
		/// </summary>
		public Properties GuildMemberProperties { get; } = new Properties("GuildMember");

		/// <summary>
		/// Returns a reference to the character's properties.
		/// </summary>
		Properties IPropertyHolder.Properties => this.Properties;

		/// <summary>
		/// Gets or sets the player's localizer.
		/// </summary>
		public Localizer Localizer
		{
			get => _localizer ?? ZoneServer.Instance.MultiLocalization.GetDefault();
			private set => _localizer = value;
		}

		private Localizer _localizer;

		/// <summary>
		/// Raised when the characters sits down or stands up.
		/// </summary>
		public event Action<Character> SitStatusChanged;

		/// <summary>
		/// Has Companion(s)
		/// </summary>
		public bool HasCompanions => this.Components.Get<CompanionComponent>()?.HasCompanions ?? false;

		/// <summary>
		/// Active Companion
		/// </summary>
		public Companion ActiveCompanion => this.Components.Get<CompanionComponent>()?.ActiveCompanion ?? null;

		/// <summary>
		/// Character's online status.
		/// </summary>
		public bool IsOnline { get; set; } = false;

		/// <summary>
		/// A dictionary with help shown
		/// </summary>
		public Dictionary<int, bool> Help { get; set; } = new Dictionary<int, bool>();

		/// <summary>
		/// Character's current trade
		/// </summary>
		public TradeComponent Trade { get; set; }

		/// <summary>
		/// Check if character is trading
		/// </summary>
		public bool IsTrading => this.Trade != null;

		/// <summary>
		/// Character's class change reset points
		/// </summary>
		public int ResetPoints { get; set; }

		/// <summary>
		/// Character's Balloon Id
		/// </summary>
		public int BalloonId { get; set; }

		/// <summary>
		/// Animation Pairing
		/// </summary>
		public bool IsPaired { get; set; }
		/// <summary>
		/// Character is riding a "vehicle" (Companion)
		/// </summary>
		public bool IsRiding { get; set; }
		public long PartyId { get; set; }
		public long GuildId { get; set; }

		public Triggers Triggers { get; set; }

		/// <summary>
		/// Creates new character.
		/// </summary>
		public Character() : base()
		{
			this.Components.Add(this.Inventory = new InventoryComponent(this));
			this.Components.Add(this.Jobs = new JobComponent(this));
			this.Components.Add(this.Skills = new SkillComponent(this));
			this.Components.Add(this.Abilities = new AbilityComponent(this));
			this.Components.Add(this.Buffs = new BuffComponent(this));
			this.Components.Add(new RecoveryComponent(this));
			this.Components.Add(new CombatComponent(this));
			this.Components.Add(new CooldownComponent(this));
			this.Components.Add(new TimeActionComponent(this));
			this.Components.Add(this.Quests = new QuestComponent(this));
			this.Components.Add(this.Movement = new MovementComponent(this));

			this.Components.Add(this.TimedEvents = new TimedEventComponent(this));
			this.Components.Add(this.Tracks = new TrackComponent(this));
			this.Components.Add(this.Triggers = new Triggers(this));
			this.Components.Add(this.Achievements = new AchievementComponent(this));
			this.Components.Add(this.AdventureBook = new AdventureBookComponent(this));
			// These two are class specific components should they go somewhere else?
			this.Components.Add(this.Companions = new CompanionComponent(this));
			this.Components.Add(this.Summons = new SummonComponent(this));
			this.Properties = new CharacterProperties(this);

			this.AddSessionObjects();
		}

		/// <summary>
		/// Adds default session objects.
		/// </summary>
		private void AddSessionObjects()
		{
			// The exact purpose of those objects is unknown right now,
			// but apparently they hold some properties of importance.
			// For now we'll add only one, to be able to get rid of the
			// message "You can buy items from a shop", which has been
			// bugging me. I know I can buy items! I coded that!
			// 
			// Update: Disabling this for now so we can take a fresh
			//   look at session objects. Curiously, I don't get the
			//   aformentioned tooltip anymore right now, even if this
			//   object is missing.
			// Update2: Client doesn't even have this idspace anymore.
			// [ERROR_IES_COULDNT_FIND_CLASS] idspace:[SessionObject] classID:[770001]
			//this.SessionObjects.Add(new SessionObject(SessionObjectId.Jansori));

			this.SessionObjects.Add(new SessionObject(SessionObjectId.Drop));
			this.SessionObjects.Add(new SessionObject(SessionObjectId.MapEventReward));
			this.SessionObjects.Add(new SessionObject(SessionObjectId.SmartGen));
			this.SessionObjects.Add(new SessionObject(SessionObjectId.Raid));
			this.SessionObjects.Add(new SessionObject(SessionObjectId.NpcDialogCount));
			this.SessionObjects.Add(new SessionObject(SessionObjectId.Request));
			this.SessionObjects.Add(new SessionObject(SessionObjectId.Shop));
			this.SessionObjects.Add(new SessionObject(SessionObjectId.ExpCardUse));

			var sessionObject = new SessionObject(SessionObjectId.Main);
			sessionObject.Properties.SetString(PropertyName.QSTARTZONETYPE, "StartLine1");
			this.SessionObjects.Add(sessionObject);
		}

		/// <summary>
		/// Gives character its initial properties if they're missing,
		/// such as on a newly created character.
		/// </summary>
		public virtual void InitProperties()
		{
			if (this.Job == null)
				throw new InvalidOperationException("Character's jobs need to be loaded before initializing the properties.");

			// We need something to check whether the properties were
			// already initialized. Let's just use a variable for that.
			if (!this.Variables.Perm.Has("Melia.PropertiesInitialized"))
			{
				this.Exp = 0;
				this.TotalExp = 0;
				this.MaxExp = ZoneServer.Instance.Data.ExpDb.GetNextExp(1);

				// Invalidate max properties so we get the correct values
				// when using them here
				this.Properties.Invalidate(PropertyName.MHP, PropertyName.MSP, PropertyName.MaxSta);

				// Set HP, SP and stamina to max
				this.Properties.SetFloat(PropertyName.HP, this.Properties.GetFloat(PropertyName.MHP));
				this.Properties.SetFloat(PropertyName.SP, this.Properties.GetFloat(PropertyName.MSP));
				this.Properties.Stamina = (int)this.Properties.GetFloat(PropertyName.MaxSta);

				// Only do this once, as we will have saved property values
				// next time we come here
				this.Variables.Perm.SetBool("Melia.PropertiesInitialized", true);
			}

			// Invalidate all properties so they get updated and then set
			// up the auto-updates
			this.Properties.InvalidateAll();
			this.Properties.InitAutoUpdates();
		}

		/// <summary>
		/// Updates character and its components.
		/// </summary>
		/// <param name="elapsed"></param>
		public void Update(TimeSpan elapsed)
		{
			this.Components.Update(elapsed);
			this.UpdateResurrection(elapsed);
		}

		/// <summary>
		/// Sends the resurrection dialog as nexessary.
		/// </summary>
		/// <param name="elapsed"></param>
		private void UpdateResurrection(TimeSpan elapsed)
		{
			// Why are we sending the resurrection dialog over and over on
			// the update? Well, because certain packets sent to the client,
			// such as hits, can cause it to close this dialog, which then
			// leaves players with having to relog to get it again to be
			// able to resurrect. Spamming isn't a great hotfix, but it is
			// an effective one, as it will ensure that the dialog is always
			// there when it should be. And of course, as you would expect,
			// it appears that this is normal, based on the packet logs.
			if (this.IsDead)
			{
				_resurrectDialogTimer -= elapsed;
				if (_resurrectDialogTimer <= TimeSpan.Zero)
				{
					// TODO: Get a list of the appropriate resurrection
					//   options and save them, to sanity check the coming
					//   resurrection request.

					Send.ZC_RESURRECT_DIALOG(this, ResurrectOptions.NearestRevivalPoint);
					_resurrectDialogTimer = ResurrectDialogDelay;
				}
			}
		}

		/// <summary>
		/// Returns character's jump type.
		/// </summary>
		/// <returns></returns>
		public int GetJumpType()
		{
			return 1;
		}

		/// <summary>
		/// Sets character's position.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public void SetPosition(float x, float y, float z)
			=> this.SetPosition(new Position(x, y, z));

		/// <summary>
		/// Sets character's position.
		/// </summary>
		/// <param name="pos"></param>
		public void SetPosition(Position pos)
		{
			this.Position = pos;
		}

		/// <summary>
		/// Sets character's direction.
		/// </summary>
		/// <param name="cos"></param>
		/// <param name="sin"></param>
		public void SetDirection(float cos, float sin)
			=> this.SetDirection(new Direction(cos, sin));

		/// <summary>
		/// Sets character's direction.
		/// </summary>
		/// <param name="dir"></param>
		public void SetDirection(Direction dir)
		{
			this.Direction = dir;
		}

		/// <summary>
		/// Sets character's direction.
		/// </summary>
		/// <param name="cos"></param>
		/// <param name="sin"></param>
		public void SetHeadDirection(float cos, float sin)
			=> this.SetHeadDirection(new Direction(cos, sin));

		/// <summary>
		/// Sets character's direction.
		/// </summary>
		/// <param name="dir"></param>
		public void SetHeadDirection(Direction dir)
		{
			this.HeadDirection = dir;
		}

		/// <summary>
		/// Warps character to given location.
		/// </summary>
		/// <param name="location"></param>
		public void Warp(Location location)
			=> this.Warp(location.MapId, location.Position);

		/// <summary>
		/// Warps character to given location.
		/// </summary>
		/// <param name="mapName"></param>
		/// <param name="pos"></param>
		/// <exception cref="ArgumentException">Thrown if map doesn't exist in data.</exception>
		public void Warp(string mapName, Position pos)
		{
			if (!ZoneServer.Instance.Data.MapDb.TryFind(mapName, out var map))
				throw new ArgumentException("Map '" + mapName + "' not found in data.");

			this.Warp(map.Id, pos);
		}

		/// <summary>
		/// Warps character to given location.
		/// </summary>
		/// <param name="mapId"></param>
		/// <param name="pos"></param>
		/// <exception cref="ArgumentException">Thrown if map doesn't exist in world.</exception>
		public void Warp(int mapId, Position pos)
		{
			if (!ZoneServer.Instance.World.TryGetMap(mapId, out var map))
				throw new ArgumentException($"Map with id '{mapId}' doesn't exist in world.");

			this.Position = pos;

			if (this.MapId == mapId)
			{
				Send.ZC_SET_POS(this);
			}
			else
			{
				this.MapId = mapId;
				_warping = true;

				Send.ZC_MOVE_ZONE(this.Connection);
			}
		}

		/// <summary>
		/// Makes character warp to the same map on another, previously
		/// selected channel.
		/// </summary>
		internal void WarpChannel(int channelId)
		{
			_warping = true;
			_destinationChannelId = channelId;

			Send.ZC_SAVE_INFO(this.Connection);
			Send.ZC_MOVE_ZONE(this.Connection);
		}

		/// <summary>
		/// Finalizes warp, after client announced readiness.
		/// </summary>
		internal void FinalizeWarp()
		{
			// Check permission
			if (!_warping)
			{
				Log.Warning("Character.FinalizeWarp: Player '{0}' tried to warp without permission.", this.AccountDbId);
				return;
			}

			// Find an available zone server for the target map
			var availableZones = ZoneServer.Instance.ServerList.GetZoneServers(this.MapId);
			if (availableZones.Length == 0)
				throw new Exception($"No suitable zone server found for map '{this.MapId}'");

			var channelId = Math2.Clamp(0, availableZones.Length, _destinationChannelId);
			var serverInfo = availableZones[channelId];

			// Save everything before leaving the server
			ZoneServer.Instance.Database.SaveCharacter(this);
			ZoneServer.Instance.Database.SaveAccount(this.Connection.Account);
			ZoneServer.Instance.Database.UpdateLoginState(this.Connection.Account.Id, 0, LoginState.LoggedOut);
			this.SavedForWarp = true;

			// Instruct client to initiate warp
			Send.ZC_MOVE_ZONE_OK(this, channelId, serverInfo.Ip, serverInfo.Port, this.MapId);

			_warping = false;
		}

		/// <summary>
		/// Increases character's level by the given amount.
		/// </summary>
		/// <param name="amount"></param>
		public void LevelUp(int amount = 1)
		{
			if (amount < 1)
				throw new ArgumentException("Amount can't be lower than 1.");

			var newLevel = this.Properties.Modify(PropertyName.Lv, amount);
			this.Properties.Modify(PropertyName.StatByLevel, amount);

			this.MaxExp = ZoneServer.Instance.Data.ExpDb.GetNextExp((int)newLevel);
			this.Heal();

			Send.ZC_MAX_EXP_CHANGED(this, 0);
			Send.ZC_PC_LEVELUP(this);
			Send.ZC_OBJECT_PROPERTY(this);

			this.AddonMessage("NOTICE_Dm_levelup_base", "!@#$Auto_KaeLigTeo_LeBeli_SangSeungHayeossSeupNiDa#@!", 3);
			this.PlayEffect("F_pc_level_up", 3);
		}

		public void ClassUp(int amount = 1)
		{
			if (amount < 1)
				throw new ArgumentException("Amount can't be lower than 1.");

			var job = this.Job;
			var classLevel = job.Level;
			var classExp = ZoneServer.Instance.Data.ExpDb.GetNextTotalClassExp(this.Jobs.GetCurrentRank(), job.Level + amount - 1);

			// Limit EXP to the total max, otherwise the client will
			// display level 1 with 0%.
			job.TotalExp = Math.Min(job.TotalMaxExp, job.TotalExp + classExp);

			var newClassLevel = this.ClassLevel;
			var classLevelsGained = (newClassLevel - classLevel);

			Send.ZC_JOB_EXP_UP(this, classExp);

			if (classLevelsGained > 0)
				this.ClassLevelUp(classLevelsGained);
		}

		/// <summary>
		/// Gives skill points to the current job and updates client.
		/// </summary>
		/// <param name="amount"></param>
		private void ClassLevelUp(int amount = 1)
		{
			if (amount < 1)
				throw new ArgumentException("Amount can't be lower than 1.");

			this.Jobs.ModifySkillPoints(this.JobId, amount);
			this.Heal();

			Send.ZC_OBJECT_PROPERTY(this);
			this.AddonMessage("NOTICE_Dm_levelup_skill", "!@#$Auto_KeulLeSeu_LeBeli_SangSeungHayeossSeupNiDa#@!", 3);
			this.PlayEffect("F_pc_joblevel_up", 3);
		}

		/// <summary>
		/// Heals character's HP, SP, and Stamina fully and updates
		/// the client.
		/// </summary>
		public void Heal()
		{
			var maxHp = this.Properties.GetFloat(PropertyName.MHP);
			var maxSp = this.Properties.GetFloat(PropertyName.MSP);

			this.Heal(maxHp, maxSp);
		}

		/// <summary>
		/// Heals character's HP and SP by the given amounts and updates
		/// the client.
		/// </summary>
		/// <param name="hpAmount"></param>
		/// <param name="spAmount"></param>
		public void Heal(float hpAmount, float spAmount)
		{
			if (hpAmount == 0 && spAmount == 0)
				return;

			this.ModifyHpSafe(hpAmount, out var hp, out var priority);
			if (hpAmount > 0)
				Send.ZC_HEAL_INFO(this, hpAmount, this.Properties.GetFloat(PropertyName.MHP), HealType.Hp);
			this.Properties.Modify(PropertyName.SP, spAmount);
			if (spAmount > 0)
				Send.ZC_HEAL_INFO(this, spAmount, this.Properties.GetFloat(PropertyName.MSP), HealType.Sp);

			Send.ZC_UPDATE_ALL_STATUS(this, priority);
		}

		/// <summary>
		/// Modifies character's HP by the given amount without updating
		/// the client. Returns the new HP value and the priority number
		/// of this modification.
		/// </summary>
		/// <remarks>
		/// There are several packets in this game that require the HP
		/// to be set synchronized, to ensure that it's only set from
		/// one source and to identify the latest amount based on the
		/// "priority".
		/// </remarks>
		/// <param name="amount"></param>
		public void ModifyHpSafe(float amount, out float newHp, out int priority)
		{
			// Make sure it's not possible for two calls to interfere
			// with each other, so that the correct amount makes it to
			// the client, with the correct priority.
			lock (_hpLock)
			{
				newHp = (int)this.Properties.Modify(PropertyName.HP, amount);
				priority = (this.HpChangeCounter += 1);
			}
		}

		/// <summary>
		/// Modifies character's HP by the given amount and updates the
		/// client with ZC_ADD_HP.
		/// </summary>
		/// <param name="amount"></param>
		public void ModifyHp(int amount)
		{
			this.ModifyHpSafe(amount, out var hp, out var priority);
			Send.ZC_ADD_HP(this, amount, hp, priority);
		}

		/// <summary>
		/// Modifies character's SP by the given amount and updates the
		/// client with ZC_UPDATE_SP.
		/// </summary>
		/// <param name="amount"></param>
		public void ModifySp(float amount)
		{
			var sp = this.Properties.Modify(PropertyName.SP, amount);
			Send.ZC_UPDATE_SP(this, sp, true);
		}

		/// <summary>
		/// Modifies character's current stamina and updates the client.
		/// </summary>
		/// <param name="amount"></param>
		public void ModifyStamina(int amount)
		{
			this.Properties.Stamina += amount;
			Send.ZC_STAMINA(this, this.Properties.Stamina);
		}

		/// <summary>
		/// Modifies the character's ability points by the given amount
		/// and updates the respective property on the client.
		/// </summary>
		/// <param name="amount"></param>
		public void ModifyAbilityPoints(int amount)
		{
			var abilityPoints = int.Parse(this.Properties.GetString(PropertyName.AbilityPoint));
			abilityPoints += amount;
			this.Properties.SetString(PropertyName.AbilityPoint, abilityPoints.ToString());

			// For some reason the client no longer reads the ability
			// point property when updating the amount. Instead there's
			// the commander info now.

			//Send.ZC_OBJECT_PROPERTY(this, PropertyName.AbilityPoint);
			Send.ZC_CUSTOM_COMMANDER_INFO(this, CommanderInfoType.AbilityPoints, abilityPoints);
		}

		/// <summary>
		/// Grants exp to character and handles level ups.
		/// </summary>
		/// <param name="exp"></param>
		/// <param name="classExp"></param>
		/// <param name="monster"></param>
		public void GiveExp(long exp, long classExp, IMonster monster)
		{
			// Base EXP
			this.Exp += exp;
			this.TotalExp += exp;

			Send.ZC_EXP_UP_BY_MONSTER(this, exp, classExp, monster);
			Send.ZC_EXP_UP(this, exp, classExp); // Not always sent? Might be quest related?

			var level = this.Level;
			var levelUps = 0;
			var maxExp = this.MaxExp;
			var maxLevel = ZoneServer.Instance.Data.ExpDb.GetMaxLevel();

			// Consume EXP as many times as possible to reach new levels
			while (this.Exp >= maxExp && level < maxLevel)
			{
				this.Exp -= maxExp;

				level++;
				levelUps++;
				maxExp = ZoneServer.Instance.Data.ExpDb.GetNextExp(level);
			}

			// Execute level up only once to avoid client lag on multiple
			// level ups. Leveling up a thousand times in a loop is not
			// fun for the client =D"
			if (levelUps > 0)
				this.LevelUp(levelUps);

			// Class EXP
			// Increase the total EXP and check whether the class level,
			// which is calculcated from that value, has changed.
			var classLevel = this.ClassLevel;
			var rank = this.Jobs.GetCurrentRank();
			var job = this.Job;

			// Limit EXP to the total max, otherwise the client will
			// display level 1 with 0%.
			job.TotalExp = Math.Min(job.TotalMaxExp, (job.TotalExp + classExp));

			var newClassLevel = this.ClassLevel;
			var classLevelsGained = (newClassLevel - classLevel);

			Send.ZC_JOB_EXP_UP(this, classExp);

			if (classLevelsGained > 0)
				this.ClassLevelUp(classLevelsGained);

			if (this.HasCompanions)
			{
				foreach (var companion in this.Companions.GetList())
					companion.GiveExp(exp, monster);
			}
		}

		/// <summary>
		/// Returns ids of equipped items.
		/// </summary>
		/// <returns></returns>
		public int[] GetEquipIds()
		{
			return this.Inventory.GetEquipIds();
		}

		/// <summary>
		/// Updates visible entities around character.
		/// </summary>
		public void LookAround()
		{
			if (!this.EyesOpen)
				return;

			lock (_lookAroundLock)
			{
				// Get lists
				var currentlyVisibleMonsters = this.Map.GetVisibleMonsters(this);
				var currentlyVisibleCharacters = this.Map.GetVisibleCharacters(this);

				// Appears
				var appearMonsters = currentlyVisibleMonsters.Except(_visibleMonsters);
				var appearCharacters = currentlyVisibleCharacters.Except(_visibleCharacters);

				// Disappears
				var disappearMonsters = _visibleMonsters.Except(currentlyVisibleMonsters);
				var disappearCharacters = _visibleCharacters.Except(currentlyVisibleCharacters);

				// Monsters
				foreach (var monster in appearMonsters)
				{
					Send.ZC_ENTER_MONSTER(this.Connection, monster);

					monster.Components?.Get<EffectsComponent>()?.ShowEffects(this.Connection);

					if (!monster.AttachableEffects.IsEmpty)
					{
						foreach (var effect in monster.AttachableEffects)
							Send.ZC_NORMAL.AttachEffect(this.Connection, monster, effect.PacketString, effect.Scale);
					}

					if (monster.OwnerHandle != 0)
						Send.ZC_OWNER(this, monster);

					if (monster is Summon summon)
					{
						Send.ZC_IS_SUMMON_SORCERER_MONSTER(this, summon);
					}

					if (monster is Companion companion)
					{
						Send.ZC_NORMAL.PetOwner(this.Connection, companion);
						Send.ZC_NORMAL.Pet_AssociateWorldId(this.Connection, companion);
					}

					if (monster is ICombatEntity entity)
					{
						Send.ZC_FACTION(this.Connection, monster, entity.Faction);

						if (entity.HasBuffs())
							Send.ZC_BUFF_LIST(this.Connection, entity);
					}
				}

				foreach (var monster in disappearMonsters)
				{
					Send.ZC_LEAVE(this.Connection, monster);
					if (monster is ICombatEntity entity)
						Send.ZC_BUFF_CLEAR(this.Connection, entity);
				}

				// Characters
				foreach (var character in appearCharacters)
				{
					Send.ZC_ENTER_PC(this.Connection, character);

					Send.ZC_SEND_APPLY_HUD_SKIN_OTHER(this.Connection, character);
					//Send.ZC_SEND_MODE_HUD_SKIN(this.Connection, character);

					if (character.AttachableEffects.Count != 0)
					{
						foreach (var effect in character.AttachableEffects)
							Send.ZC_NORMAL.AttachEffect(this.Connection, character, effect.PacketString, effect.Scale);
					}

					if (character.Components.Get<BuffComponent>()?.Count != 0)
						Send.ZC_BUFF_LIST(this.Connection, character);
				}

				foreach (var character in disappearCharacters)
					Send.ZC_LEAVE(this.Connection, character);

				// Save lists for next run
				_visibleMonsters = currentlyVisibleMonsters;
				_visibleCharacters = currentlyVisibleCharacters;
			}
		}

		/// <summary>
		/// Starts auto-updates of visible entities.
		/// </summary>
		public void OpenEyes()
		{
			this.EyesOpen = true;
			this.LookAround();
		}

		/// <summary>
		/// Stops auto-updates of visible entities.
		/// </summary>
		public void CloseEyes()
		{
			this.EyesOpen = false;

			lock (_lookAroundLock)
			{
				foreach (var monster in _visibleMonsters)
					Send.ZC_LEAVE(this.Connection, monster);

				foreach (var character in _visibleCharacters)
					Send.ZC_LEAVE(this.Connection, character);

				_visibleMonsters = new IMonster[0];
				_visibleCharacters = new Character[0];
			}
		}

		/// <summary>
		/// Sets direction and updates clients.
		/// </summary>
		/// <param name="dir"></param>
		public void Rotate(Direction dir)
		{
			if (this.Direction != dir)
				this.SetDirection(dir);

			Send.ZC_ROTATE(this);
		}

		/// <summary>
		/// Sets direction and updates clients.
		/// </summary>
		/// <param name="d1"></param>
		/// <param name="d2"></param>
		public void RotateHead(Direction dir)
		{
			if (this.HeadDirection != dir)
				this.SetHeadDirection(dir);

			Send.ZC_HEAD_ROTATE(this);
		}

		/// <summary>
		/// Returns the character's current location.
		/// </summary>
		/// <returns></returns>
		public Location GetLocation()
		{
			return new Location(this.MapId, this.Position);
		}

		/// <summary>
		/// Displays server message in character's chat.
		/// </summary>
		/// <remarks>
		/// Abuses a certain system message that takes two parameters,
		/// which are then output, separated by a colon. Since there's
		/// no customizable server message packet I know of, this will
		/// serve as the next best thing for now, and is certainly an
		/// improvement over using ZC_CHAT.
		/// </remarks>
		/// <param name="format"></param>
		/// <param name="args"></param>
		public void ServerMessage(string format, params object[] args)
		{
			if (args.Length > 0)
				format = string.Format(format, args);

			// Since there doesn't seem to be a way to send custom system
			// messages, we're abusing clientmessage 21254, which has the
			// format "X:Y", where we replace X and Y with a prefix and
			// our custom message.
			this.SystemMessage("{Hour}:{Min}", new MsgParameter("Hour", "Server "), new MsgParameter("Min", " " + format));
		}

		/// <summary>
		/// Displays system message in character's chat.
		/// </summary>
		/// <remarks>
		/// Uses pre-defined, argument-supporting system messages found
		/// in the clientmessage.xml file. The class name corresponds to
		/// the class name in said XML, with arguments found inside those
		/// messages, wrapped in curly braces.
		/// </remarks>
		/// <example>
		/// ClassName="{Day}days"
		/// SystemMessage("{Day}days", new MsgParameter("Day", "5 "))
		/// -> "5 days"
		/// </example>
		/// <param name="className"></param>
		/// <param name="args"></param>
		public void SystemMessage(string className, params MsgParameter[] args)
		{
			if (!ZoneServer.Instance.Data.SystemMessageDb.TryFind(className, out var sysMsgData))
				throw new ArgumentException($"System message '{className}' not found.");

			Send.ZC_SYSTEM_MSG(this, sysMsgData.ClassId, args);
		}

		/// <summary>
		/// Sends server message to character.
		/// </summary>
		/// <param name="format"></param>
		/// <param name="args"></param>
		public void MsgBox(string format, params object[] args)
		{
			if (args.Length > 0)
				format = string.Format(format, args);

			if (format.IndexOf("'") != -1)
				format = format.Replace("'", "\\'");

			Send.ZC_EXEC_CLIENT_SCP(this.Connection, "ui.MsgBox('" + format + "')");
		}

		/// <summary>
		/// Adds amount to character's stat points and updates the client.
		/// </summary>
		/// <param name="amount"></param>
		public void AddStatPoints(int amount)
		{
			if (amount < 1)
				throw new ArgumentException("Amount can't be negative.");

			this.Properties.Modify(PropertyName.StatByBonus, amount);
			Send.ZC_OBJECT_PROPERTY(this, PropertyName.StatByBonus);
		}

		/// <summary>
		/// Resets the character's stats.
		/// </summary>
		/// <remarks>
		/// Sets all stats to 1 (some level bonuses might still apply,
		/// raising the default value above 1) and gives back the points
		/// that were put into the stats. Also resets the points the
		/// character got from its job on creation.
		/// </remarks>
		public void ResetStats()
		{
			var character = this;

			// The three properties that control the stat points are
			// StatByLevel, StatByBonus, and UsedStat. The first two
			// get added together and UsedStat is subtracted to arrive
			// at the number of available stat points. To reset the
			// stat points that were used, all we have to do is reset
			// UsedStat and the *_STAT properties. For a full reset,
			// however, that allows for distributing the initial stats
			// from the chosen job, we need to give the player the points
			// that went into the *_JOB properties, which we'll just add
			// to StatByBonus.

			var jobStatPoints = character.Properties.Sum(PropertyName.STR_JOB, PropertyName.CON_JOB, PropertyName.INT_JOB, PropertyName.MNA_JOB, PropertyName.DEX_JOB) - 5;
			character.Properties.Modify(PropertyName.StatByBonus, jobStatPoints);

			character.Properties.SetFloat(PropertyName.UsedStat, 0);

			character.Properties.SetFloat(PropertyName.STR_STAT, 0);
			character.Properties.SetFloat(PropertyName.CON_STAT, 0);
			character.Properties.SetFloat(PropertyName.INT_STAT, 0);
			character.Properties.SetFloat(PropertyName.MNA_STAT, 0);
			character.Properties.SetFloat(PropertyName.DEX_STAT, 0);

			character.Properties.SetFloat(PropertyName.STR_JOB, 1);
			character.Properties.SetFloat(PropertyName.CON_JOB, 1);
			character.Properties.SetFloat(PropertyName.INT_JOB, 1);
			character.Properties.SetFloat(PropertyName.MNA_JOB, 1);
			character.Properties.SetFloat(PropertyName.DEX_JOB, 1);

			// TODO: Add semi-automatic updating of all properties that
			//   changed.
			//Send.ZC_OBJECT_PROPERTY(character,
			//	"STR", "STR_STAT", "STR_JOB", "CON", "CON_STAT", "CON_JOB",
			//	"INT", "INT_STAT", "INT_JOB", "MNA", "MNA_STAT", "MNA_JOB",
			//	"DEX", "DEX_STAT", "DEX_JOB",
			//	"UsedStat", "StatByLevel", "StatByBonus",
			//	"MINPATK", "MAXPATK", "MINMATK", "MAXMATK", "MINPATK_SUB", "MAXPATK_SUB",
			//	"CRTATK", "HR", "DR", "BLK_BREAK", "BLK", "RHP",
			//	"RSP", "MHP", "MSP"
			//);

			// I don't trust that we will always get the updated properties
			// right and creating semi-auto updating is difficult with this
			// game's property system, so we'll just update all of them
			// That might not actually be necessary in all cases, but it's
			// much simpler and safer. It's also not like we reset characters
			// all the time anyway.
			character.Properties.InvalidateAll();
			Send.ZC_OBJECT_PROPERTY(character);
		}

		/// <summary>
		/// Resets the character's skills.
		/// </summary>
		/// <remarks>
		/// Resets the levels of all skills the character has and returns
		/// the points that were put into them to the jobs.
		/// </remarks>
		public void ResetSkills()
		{
			// Remove all skills
			foreach (var skill in this.Skills.GetList())
				this.Skills.Remove(skill.Id);

			// Reset jobs' skill points, so they're equal to their level,
			// minus 1, because 1 is the default level.
			foreach (var job in this.Jobs.GetList())
				job.SetSkillPoints(job.Level - 1);
		}

		/// <summary>
		/// Sets and returns the currently correct stance, based on this
		/// character's properties. Does not update client.
		/// </summary>
		public int UpdateStance()
		{
			var jobId = this.JobId;
			var riding = false;
			var rightHand = this.Inventory.GetItem(EquipSlot.RightHand).Data.EquipType1;
			var leftHand = this.Inventory.GetItem(EquipSlot.LeftHand).Data.EquipType1;

			this.Stance = ZoneServer.Instance.Data.StanceConditionDb.FindStanceId(jobId, riding, rightHand, leftHand);

			return this.Stance;
		}

		/// <summary>
		/// These should be reference properties?
		/// PCETC Properties
		/// </summary>
		public void SendPCEtcProperties()
		{
			if (!this.EtcProperties.Has(PropertyName.SkintoneName))
			{
				this.EtcProperties.SetString(PropertyName.SkintoneName, "skintone2");
				if (ZoneServer.Instance.Data.HairTypeDb.TryFind(this.Hair, out var hair))
					this.EtcProperties.SetString(PropertyName.StartHairName, hair.ClassName);
				this.EtcProperties.SetFloat(PropertyName.LobbyMapID, this.MapId);
				this.EtcProperties.SetString(PropertyName.RepresentationClassID, ((int)this.JobId).ToString());
				this.EtcProperties.SetFloat(PropertyName.CTRLTYPE_RESET_EXCEPT, 1);
			}
			this.EtcProperties.SetFloat(PropertyName.LastPlayDate, DateTimeUtils.ToSPropertyDateToFloat(DateTime.Now));

			Send.ZC_OBJECT_PROPERTY(this.Connection, this.SocialUserId, this.EtcProperties.GetAll());
		}

		/// <summary>
		/// Makes character take damage and kills them if their HP reached 0.
		/// Returns true if the character is dead.
		/// </summary>
		/// <param name="damage"></param>
		/// <param name="attacker"></param>
		/// <returns></returns>
		public bool TakeDamage(float damage, ICombatEntity attacker)
		{
			// Don't hit an already dead character
			if (this.IsDead)
				return true;

			this.Components.Get<CombatComponent>().SetAttackState(true);
			this.ModifyHpSafe(-damage, out _, out _);

			this.Components.Get<CombatComponent>()?.RegisterHit(attacker, damage);

			if (this.Hp == 0)
				this.Kill(attacker);

			this.Map.AlertAis(this, new HitEventAlert(this, attacker, damage));

			return this.IsDead;
		}

		/// <summary>
		/// Kills character.
		/// </summary>
		/// <param name="killer"></param>
		public void Kill(ICombatEntity killer)
		{
			this.Properties.SetFloat(PropertyName.HP, 0);

			//this.Died?.Invoke(this, killer);
			ZoneServer.Instance.ServerEvents.OnEntityKilled(this, killer);

			Send.ZC_DEAD(this);

			this.Tracks.Cancel();

			_resurrectDialogTimer = ResurrectDialogDelay;
		}

		/// <summary>
		/// Resurrects the character if its dead.
		/// </summary>
		/// <param name="option"></param>
		public void Resurrect(ResurrectOptions option)
		{
			var startHp = this.Properties.GetFloat(PropertyName.MHP) * 0.50f;
			this.Heal(startHp, 0);

			switch (option)
			{
				default:
				case ResurrectOptions.NearestRevivalPoint:
				{
					var safePos = this.Map.GetSafePositionNear(this.Position, true);
					this.Warp(this.MapId, safePos);
					break;
				}
			}

			Send.ZC_RESURRECT_SAVE_POINT_ACK(this);
			Send.ZC_RESURRECT(this);
		}

		/// <summary>
		/// Returns true if the character can attack the entity.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public bool CanAttack(ICombatEntity entity)
		{
			if (entity == this)
				return false;

			if (entity.IsDead)
				return false;

			// For now, let's specify that characters can attack actual
			// monsters.
			var isHostileMonster = (entity is IMonster monster && monster.MonsterType == MonsterType.Mob);
			if (!isHostileMonster)
				return false;

			return true;
		}

		/// <summary>
		/// Returns true if the character can attack others.
		/// </summary>
		/// <returns></returns>
		public bool CanFight()
		{
			if (this.IsDead)
				return false;

			return true;
		}

		/// <summary>
		/// Returns true if the character can move.
		/// </summary>
		/// <returns></returns>
		public bool CanMove()
		{
			if (this.IsDead || this.IsBuffActive(BuffId.Stop_Debuff))
				return false;

			return true;
		}

		/// <summary>
		/// Turns item monster into an item and adds it to the character's
		/// inventory.
		/// </summary>
		/// <param name="itemMonster"></param>
		public void PickUp(ItemMonster itemMonster)
		{
			itemMonster.PickedUp = true;
			itemMonster.Item.ClearProtections();

			// Play pickup animation. This is what actually makes the item
			// disappear, the client doesn't seem to react to ZC_LEAVE in
			// the case of items. Or at least not reliably? It's weird.
			Send.ZC_ITEM_GET(this, itemMonster);

			// Add the item to the inventory
			this.Inventory.Add(itemMonster.Item, InventoryAddType.PickUp);

			if (itemMonster.Item.Data.Journal)
			{
				if (itemMonster.MonsterId != 0)
					this.AdventureBook.AddMonsterDrop(itemMonster.MonsterId, itemMonster.Item.Id, itemMonster.Item.Amount);
				if (this.AdventureBook.IsNewEntry(AdventureBookType.ItemObtained, itemMonster.Item.Id))
					this.AddonMessage("ADVENTURE_BOOK_NEW", itemMonster.Item.Data.Name);

				this.AdventureBook.AddItemObtained(itemMonster.Item.Id, itemMonster.Item.Amount);
			}

			// Remove it from the map, so it can't be picked up again.
			this.Map.RemoveMonster(itemMonster);
		}

		/// <summary>
		/// Toggles whether the character is sitting or not.
		/// </summary>
		public void ToggleSitting()
		{
			if (this.IsDead)
				return;

			this.IsSitting = !this.IsSitting;
			this.SitStatusChanged?.Invoke(this);

			Send.ZC_REST_SIT(this);
		}

		/// <summary>
		/// Plays effect for the character.
		/// </summary>
		/// <param name="packetString"></param>
		public void PlayEffectLocal(string packetString, float scale = 1, string heightOffset = "BOT")
		{
			this.PlayEffectLocal(this.Connection, packetString, scale, heightOffset);
		}

		/// <summary>
		/// Reduces character's stamina and updates the client.
		/// </summary>
		/// <param name="staminaUsage"></param>
		private void UseStamina(int staminaUsage)
		{
			var stamina = (this.Properties.Stamina -= staminaUsage);
			Send.ZC_STAMINA(this, stamina);
		}

		/// <summary>
		/// Add a session object
		/// </summary>
		/// <param name="sessionObjectId"></param>
		public SessionObject AddSessionObject(string sessionObjectId, int i1 = 1)
		{
			return this.AddSessionObject(PropertyTable.GetId("SessionObject", sessionObjectId));
		}

		/// <summary>
		/// Add a Session Object and updates client
		/// </summary>
		/// <param name="sessionObjectId"></param>
		public SessionObject AddSessionObject(int sessionObjectId)
		{
			var sessionObject = this.SessionObjects.GetOrCreate(sessionObjectId);
			Send.ZC_SESSION_OBJ_ADD(this, sessionObject);
			return sessionObject;
		}

		/// <summary>
		/// Remove Session Object and updates the client
		/// </summary>
		/// <param name="sessionObjectId"></param>
		public bool RemoveSessionObject(int sessionObjectId)
		{
			if (this.SessionObjects.Remove(sessionObjectId))
			{
				Send.ZC_SESSION_OBJ_REMOVE(this, sessionObjectId);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Remove an item from the inventory.
		/// </summary>
		/// <param name="itemClassName"></param>
		/// <param name="amount"></param>
		public bool HasItem(string itemClassName, int amount = 1)
		{
			if (ZoneServer.Instance.Data.ItemDb.TryFind(itemClassName, out var item))
				return this.HasItem(item.Id, amount);
			return false;
		}

		/// <summary>
		/// Returns true if the player has the item and has at least
		/// the request amount.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="requiredAmount"></param>
		/// <returns></returns>
		public bool HasItem(int itemId, int requiredAmount = 1)
		{
			return this.Inventory.CountItem(itemId) >= requiredAmount;
		}

		/// <summary>
		/// Remove an item from the inventory and returns amount removed.
		/// </summary>
		/// <param name="itemClassName"></param>
		/// <param name="amount"></param>
		public int RemoveItem(string itemClassName, int amount = 1)
		{
			if (ZoneServer.Instance.Data.ItemDb.TryFind(itemClassName, out var item))
				return this.RemoveItem(item.Id, amount);
			return -1;
		}

		/// <summary>
		/// Remove an item from the inventory and returns amount removed.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="amount"></param>
		public int RemoveItem(int itemId, int amount = 1)
		{
			return this.Inventory.Remove(itemId, amount, InventoryItemRemoveMsg.Given);
		}

		/// <summary>
		/// Add an item to the inventory.
		/// </summary>
		/// <param name="itemClassName"></param>
		/// <param name="amount"></param>
		public void AddItem(string itemClassName, int amount = 1)
		{
			var item = ZoneServer.Instance.Data.ItemDb.FindByClass(itemClassName);
			if (item != null)
				this.AddItem(item.Id, amount);
		}

		/// <summary>
		/// Add an item to the inventory.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="amount"></param>
		public void AddItem(int itemId, int amount = 1)
		{
			this.Inventory.Add(itemId, amount);
		}

		/// <summary>
		/// Sends an addon message
		/// </summary>
		/// <param name="function"></param>
		/// <param name="stringParameter"></param>
		/// <param name="intParameter"></param>
		public void AddonMessage(string function, string stringParameter = null, int intParameter = 0)
		{
			Send.ZC_ADDON_MSG(this, function, intParameter, stringParameter);
		}

		/// <summary>
		/// Show help
		/// </summary>
		/// <param name="className"></param>
		public void ShowHelp(string className)
		{
			var help = ZoneServer.Instance.Data.HelpDb.Find(className);

			if (help == null)
			{
				Log.Warning("ShowHelp: Unable to find help by class name {0}.", className);
				return;
			}

			if (this.Help.ContainsKey(help.Id) && this.Help[help.Id])
				return;

			this.Help[help.Id] = true;

			Send.ZC_HELP_ADD(this, help.Id, true);
			if (help.DbSave)
				ZoneServer.Instance.Database.SaveHelp(this.DbId, help.Id, true);
		}

		/// <summary>
		/// Set a Property and send it to the client
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="value"></param>
		public void SetProperty(string propertyName, float value)
		{
			this.Properties.SetFloat(propertyName, value);
			Send.ZC_OBJECT_PROPERTY(this, propertyName);
		}

		/// <summary>
		/// Set a Property and send it to the client
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="value"></param>
		public void SetProperty(string propertyName, string value)
		{
			this.Properties.SetString(propertyName, value);
			Send.ZC_OBJECT_PROPERTY(this, propertyName);
		}

		/// <summary>
		/// Modify a Property and send it to the client
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="value"></param>
		public void ModifyProperty(string propertyName, float value)
		{
			this.Properties.Modify(propertyName, value);
			Send.ZC_OBJECT_PROPERTY(this, propertyName);
		}

		/// <summary>
		/// Set an account property and update the client.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="value"></param>
		public void SetAccountProperty(string propertyName, int value)
		{
			var properties = this.Connection.Account.Properties;
			properties.SetFloat(propertyName, value);

			Send.ZC_NORMAL.AccountProperties(this, propertyName);
		}

		/// <summary>
		/// Modify an account property and update the client.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="modifier"></param>
		public void ModifyAccountProperty(string propertyName, float modifier)
		{
			var properties = this.Connection.Account.Properties;
			properties.Modify(propertyName, modifier);

			Send.ZC_OBJECT_PROPERTY(this.Connection, this.Connection.Account, propertyName);
			Send.ZC_NORMAL.AccountProperties(this, propertyName);
			Send.ZC_PC_PROP_UPDATE(this, (short)PropertyTable.GetId("Account", propertyName), 1);
		}

		public void AddAchievePoint(string achievementName, int value)
		{
			this.Achievements?.AddAchievementPoints(achievementName, value);
		}

		/// <summary>
		/// Used to setup a "new" instance of a map in the client.
		/// </summary>
		public int StartLayer()
		{
			this.Layer = this.Map.GetNewLayer();
			Send.ZC_SET_LAYER(this, this.Layer, true);

			return this.Layer;
		}

		/// <summary>
		/// Used to remove a "new" instance of a map in the client.
		/// </summary>
		public void StopLayer()
		{
			this.Layer = 0;
			Send.ZC_SET_LAYER(this, this.Layer, false);
		}

		/// <summary>
		/// Changes the character's hair and updates nearby clients.
		/// </summary>
		/// <param name="hairTypeIndex"></param>
		public void ChangeHair(int hairTypeIndex)
		{
			this.Hair = hairTypeIndex;
			Send.ZC_UPDATED_PCAPPEARANCE(this);
		}

		/// <summary>
		/// Set ETC property and updates client.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="value"></param>
		public void SetEtcProperty(string propertyName, int value)
		{
			this.EtcProperties.SetFloat(propertyName, value);
			Send.ZC_OBJECT_PROPERTY(this, this.SocialUserId, this.EtcProperties.GetSelect(propertyName));
		}

		/// <summary>
		/// Set ETC property and updates client.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="value"></param>
		public void SetEtcProperty(string propertyName, string value)
		{
			this.EtcProperties.SetString(propertyName, value);
			Send.ZC_OBJECT_PROPERTY(this, this.SocialUserId, this.EtcProperties.GetSelect(propertyName));
		}

		/// <summary>
		/// Modify ETC property and updates client.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="amount"></param>
		public void ModifyEtcProperty(string propertyName, int amount)
		{
			this.EtcProperties.Modify(propertyName, amount);
			Send.ZC_OBJECT_PROPERTY(this, this.SocialUserId, this.EtcProperties.GetSelect(propertyName));
		}

		/// <summary>
		/// Enable or disable character control.
		/// </summary>
		/// <param name="controlScript"></param>
		/// <param name="enabled"></param>
		public void EnableControl(string controlScript, bool enabled)
		{
			Send.ZC_ENABLE_CONTROL(this.Connection, controlScript, enabled);
		}
	}
}
