using System;
using System.Collections.Generic;
using System.Linq;
using Melia.Shared.Data.Database;
using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Extensions;

namespace Melia.Zone.World.GameEvents
{
	public class GlobalBonusManager
	{
		private readonly List<GlobalBonus> _bonuses = new List<GlobalBonus>();
		private readonly List<GlobalBuff> _buffs = new List<GlobalBuff>();
		private readonly List<GlobalDrop> _drops = new List<GlobalDrop>();

		/// <summary>
		/// Adds global bonus.
		/// </summary>
		/// <param name="identifier"></param>
		/// <param name="name"></param>
		/// <param name="stat"></param>
		/// <param name="multiplier"></param>
		public void AddBonus(string identifier, string name, GlobalBonusStat stat, float multiplier)
		{
			var bonus = new GlobalBonus(identifier, name, stat, multiplier);
			lock (_bonuses)
				_bonuses.Add(bonus);
		}

		/// <summary>
		/// Removes all global bonuses with given event id.
		/// </summary>
		/// <param name="identifier"></param>
		public void RemoveBonuses(string identifier)
		{
			lock (_bonuses)
				_bonuses.RemoveAll(a => a.Identifier == identifier);
		}

		/// <summary>
		/// Returns whether there are any bonuses for the given stat,
		/// and if so returns the total multiplier and the names of the
		/// events that affected it via out parameter.
		/// </summary>
		/// <param name="stat"></param>
		/// <param name="multiplier"></param>
		/// <param name="eventNames"></param>
		public bool GetBonusMultiplier(GlobalBonusStat stat, out float multiplier, out string eventNames)
		{
			multiplier = 0;
			eventNames = "";

			lock (_bonuses)
			{
				if (!_bonuses.Any(a => a.Stat == stat))
					return false;
			}

			var names = new HashSet<string>();

			lock (_bonuses)
			{
				foreach (var bonus in _bonuses.Where(a => a.Stat == stat))
				{
					multiplier += bonus.Multiplier;
					if (!string.IsNullOrWhiteSpace(bonus.Name))
						names.Add(bonus.Name);
				}
			}

			eventNames = string.Join(", ", names);

			return true;
		}

		/// <summary>
		/// Adds global drop.
		/// </summary>
		/// <param name="identifier"></param>
		/// <param name="drop"></param>
		public void AddDrop(string identifier, GlobalDrop drop)
		{
			lock (_drops)
				_drops.Add(drop);
		}

		/// <summary>
		/// Adds global drop.
		/// </summary>
		/// <param name="drop"></param>
		public void AddDrop(GlobalDrop drop)
		{
			lock (_drops)
				_drops.Add(drop);
		}

		/// <summary>
		/// Removes all global drops associated with the given identifier.
		/// </summary>
		/// <param name="identifier"></param>
		public void RemoveAllDrops(string identifier)
		{
			lock (_drops)
				_drops.RemoveAll(a => a.Identifier == identifier);
		}

		/// <summary>
		/// Returns list of all global drops the given target might drop.
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public List<DropData> GetDrops(ICombatEntity target, ICombatEntity killer)
		{
			var result = new List<DropData>();

			lock (_drops)
				result.AddRange(_drops.Where(a => a.Matches(target, killer)).Select(a => a.Data.Random()));

			return result;
		}


		/// <summary>
		/// Adds global buff.
		/// </summary>
		/// <param name="identifier"></param>
		/// <param name="name"></param>
		/// <param name="buffId"></param>
		/// <param name="numArg1"></param>
		/// <param name="numArg2"></param>
		public void AddBuff(string identifier, string name, BuffId buffId, float numArg1 = 0, float numArg2 = 0)
		{
			var buff = new GlobalBuff(identifier, name, buffId, numArg1, numArg2);
			lock (_buffs)
				_buffs.Add(buff);
		}

		/// <summary>
		/// Removes all global bonuses with given event id.
		/// </summary>
		/// <param name="identifier"></param>
		public void RemoveBuffs(string identifier)
		{
			lock (_buffs)
				_buffs.RemoveAll(a => a.Identifier == identifier);
		}

		/// <summary>
		/// Returns list of all global drops the given target might drop.
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		public List<GlobalBuff> GetBuffs(Character character)
		{
			var result = new List<GlobalBuff>();

			lock (_buffs)
			{
				var buff = _buffs.Where(a => !character.IsBuffActive(a.Buff));
				result.AddRange(buff);
			}

			return result;
		}
	}

	public class GlobalBonus
	{
		public string Identifier { get; private set; }
		public string Name { get; private set; }
		public GlobalBonusStat Stat { get; private set; }
		public float Multiplier { get; private set; }

		public GlobalBonus(string identifier, string name, GlobalBonusStat stat, float multiplier)
		{
			this.Identifier = identifier;
			this.Name = name;
			this.Stat = stat;
			this.Multiplier = multiplier;
		}
	}

	public class GlobalBuff
	{
		public string Identifier { get; private set; }
		public string Name { get; private set; }
		public BuffId Buff { get; private set; }
		public float NumArg1 { get; private set; }
		public float NumArg2 { get; private set; }

		public GlobalBuff(string identifier, string name, BuffId buff, float numArg1 = 0, float numArg2 = 0)
		{
			this.Identifier = identifier;
			this.Name = name;
			this.Buff = buff;
			this.NumArg1 = numArg1;
			this.NumArg2 = numArg2;
		}
	}

	public abstract class GlobalDrop
	{
		public string Identifier { get; private set; }
		public DropData[] Data { get; private set; }

		public GlobalDrop(string identifier, params DropData[] data)
		{
			this.Identifier = identifier;
			this.Data = data;
		}

		public abstract bool Matches(ICombatEntity target, ICombatEntity killer);
	}

	public class GlobalDropById : GlobalDrop
	{
		public int Id { get; private set; }

		public GlobalDropById(string identifier, int id, params DropData[] data)
			: base(identifier, data)
		{
			this.Id = id;
		}

		public override bool Matches(ICombatEntity target, ICombatEntity killer)
		{
			var isRace = (target is Mob mob) && mob.Id == this.Id;
			return isRace;
		}
	}

	public class GlobalDropByMatch : GlobalDrop
	{
		public Func<ICombatEntity, ICombatEntity, bool> IsMatch { get; private set; }

		public GlobalDropByMatch(string identifier, Func<ICombatEntity, ICombatEntity, bool> isMatch, params DropData[] data)
			: base(identifier, data)
		{
			this.IsMatch = isMatch;
		}

		public override bool Matches(ICombatEntity target, ICombatEntity killer)
		{
			return this.IsMatch(target, killer);
		}
	}
	public class GlobalDropByMap : GlobalDrop
	{
		public int MapId { get; private set; }

		public GlobalDropByMap(string identifier, int mapId, params DropData[] data)
			: base(identifier, data)
		{
			this.MapId = mapId;
		}

		public override bool Matches(ICombatEntity target, ICombatEntity killer)
		{
			return (target.Map.Id == this.MapId);
		}
	}

	public enum GlobalBonusStat
	{
		CombatExp,
		QuestExp,
		ItemDropRate,
		SilverDropRate,
		SilverDropAmount,
	}
}
