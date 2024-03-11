﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Melia.Shared.Network;
using Melia.Zone.Events;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Maps;
using Melia.Zone.World.Spawning;
using Yggdrasil.Logging;
using Yggdrasil.Scheduling;

namespace Melia.Zone.World
{
	/// <summary>
	/// Manages the world, including maps and the heartbeat update loop.
	/// </summary>
	public class WorldManager
	{
		// Unique handles for entities
		private int _handles = 0;

		// Unique handles for buffs
		private int _buffhandles = 0;

		// Unique handles for attacks
		private int _attackHandles = 0;

		// Unique handles for skills
		private int _skillHandles = 0;

		// Unique handles for effects
		private int _effectHandles = 0;

		private int _genTypes = 1_000_000;

		private readonly Dictionary<int, MonsterSpawner> _spawners = new Dictionary<int, MonsterSpawner>();
		private readonly Dictionary<string, SpawnAreaCollection> _spawnAreaCollections = new Dictionary<string, SpawnAreaCollection>();

		/// <summary>
		/// Returns the amount of maps in the world.
		/// </summary>
		public int Count => this.Maps.Count;

		/// <summary>
		/// Returns the world's heartbeat, a manager for regularly
		/// occurring events.
		/// </summary>
		public Heartbeat Heartbeat { get; } = new Heartbeat(4);

		/// <summary>
		/// Returns the world's day/night cycle manager.
		/// </summary>
		public DayNightCycle DayNightCycle { get; private set; }

		/// <summary>
		/// Returns the world's parties, a manager for
		/// all the parties in the world.
		/// </summary>
		public PartyManager Parties { get; } = new PartyManager();

		/// <summary>
		/// Returns the world's parties, a collection of
		/// all the parties in the world.
		/// </summary>
		public GuildManager Guilds { get; } = new GuildManager();

		/// <summary>
		/// Returns the world's maps, a collection of 
		/// all loaded maps.
		/// </summary>
		public MapManager Maps { get; } = new MapManager();

		/// <summary>
		/// Returns the world's NPCs indexed by their dialogue.
		/// </summary>
		public Dictionary<string, Npc> NPCs { get; } = new Dictionary<string, Npc>();

		/// <summary>
		/// Returns a new handle to be used for a character or monster.
		/// </summary>
		/// <returns></returns>
		public int CreateHandle()
		{
			// TODO: 2b are a lot, but if items use this as well... we might
			//   need a fallback, or a way to release handles of logged out
			//   characters or killed monsters.
			return Interlocked.Increment(ref _handles);
		}

		/// <summary>
		/// Returns a new gen type to be used for a monster.
		/// </summary>
		/// <returns></returns>
		public int CreateGenType()
		{
			return Interlocked.Increment(ref _genTypes);
		}

		/// <summary>
		/// Returns a new handle to be used for a casted Attack.
		/// </summary>
		/// <returns></returns>
		public int CreateAttackHandle()
		{
			return Interlocked.Increment(ref _attackHandles);
		}

		/// <summary>
		/// Returns a new handle to be used for a casted Buff.
		/// </summary>
		/// <returns></returns>
		public int CreateBuffHandle()
		{
			return Interlocked.Increment(ref _buffhandles);
		}

		/// <summary>
		/// Returns a new handle to be used for an effect added to the map.
		/// </summary>
		/// <returns></returns>
		public int CreateEffectHandle()
		{
			return Interlocked.Increment(ref _effectHandles);
		}

		/// <summary>
		/// Returns a new handle to be used for a casted Skill.
		/// </summary>
		/// <returns></returns>
		public int CreateSkillHandle()
		{
			return Interlocked.Increment(ref _skillHandles);
		}

		/// <summary>
		/// Initializes world, creating maps and setting up events.
		/// </summary>
		internal void Initialize()
		{
			this.CreateMaps();
			this.InitUpdatables();
		}

		/// <summary>
		/// Populates world mit maps based on the map data and adds them
		/// to the heartbeat.
		/// </summary>
		private void CreateMaps()
		{
			foreach (var entry in ZoneServer.Instance.Data.MapDb.Entries.Values)
			{
				var map = new Map(entry.Id, entry.ClassName);
				this.AddMap(map);

				this.Heartbeat.Add(map);
			}
		}

		/// <summary>
		/// Initializes updatable world objects, such as event raisers.
		/// </summary>
		private void InitUpdatables()
		{
			this.Heartbeat.Add(new TimeEventRaiser());
			this.Heartbeat.Add(this.DayNightCycle = new DayNightCycle());
		}

		/// <summary>
		/// Starts the world's heartbeat if it isn't already running.
		/// </summary>
		internal void Start()
		{
			this.Heartbeat.Start();
		}

		/// <summary>
		/// Returns map by id, or null if it doesn't exist.
		/// </summary>
		/// <param name="mapId"></param>
		public Map GetMap(int mapId)
			=> this.Maps.Get(mapId);

		/// <summary>
		/// Returns map by name, or null if it doesn't exist.
		/// </summary>
		/// <param name="mapClassName"></param>
		public Map GetMap(string mapClassName)
		=> this.Maps.Get(mapClassName);

		/// <summary>
		/// Returns map by name via out, returns false if the map doesn't
		/// exist.
		/// </summary>
		/// <param name="mapClassId"></param>
		/// <param name="map"></param>
		public bool TryGetMap(int mapClassId, out Map map)
		=> this.Maps.TryGet(mapClassId, out map);

		/// <summary>
		/// Returns map by name via out, returns false if the map doesn't
		/// exist.
		/// </summary>
		/// <param name="mapClassName"></param>
		/// <param name="map"></param>
		public bool TryGetMap(string mapClassName, out Map map)
		=> this.Maps.TryGet(mapClassName, out map);

		/// <summary>
		/// Removes all scripted entities, like NPCs.
		/// </summary>
		public void RemoveScriptedEntities()
		{
			this.Maps.RemoveScriptedEntities();

			lock (_spawners)
			{
				foreach (var spawner in _spawners.Values)
				{
					spawner.InitializePopulation();
					this.Heartbeat.Remove(spawner);
				}
				_spawners.Clear();
			}

			lock (_spawnAreaCollections)
				_spawnAreaCollections.Clear();
		}

		/// <summary>
		/// Returns the first character found with the given team name,
		/// or null if none were found.
		/// </summary>
		public Character GetCharacterByTeamName(string teamName)
		=> this.Maps.GetCharacterByTeamName(teamName);

		/// <summary>
		/// Adds a monster spawner object to the world
		/// </summary>
		/// <param name="spawner"></param>
		public void AddSpawner(MonsterSpawner spawner)
		{
			lock (_spawners)
			{
				_spawners.Add(spawner.Id, spawner);
				this.Heartbeat.Add(spawner);
			}
		}

		/// <summary>
		/// Adds a spawn area collection to the world.
		/// </summary>
		/// <param name="spawnAreas"></param>
		public void AddSpawnAreas(SpawnAreaCollection spawnAreas)
		{
			// Just replace the old one if it exists, since users might
			// want to override existing spawn areas.

			lock (_spawnAreaCollections)
				_spawnAreaCollections[spawnAreas.Identifier] = spawnAreas;
		}

		/// <summary>
		/// Returns by out a spawn area collection with a given identifier
		/// if it exists in the world. Returns true if found, false otherwise.
		/// </summary>
		/// <param name="identifier"></param>
		/// <param name="spawner"></param>
		/// <returns></returns>
		public bool TryGetSpawnAreas(string identifier, out SpawnAreaCollection spawnAreas)
		{
			lock (_spawnAreaCollections)
				return _spawnAreaCollections.TryGetValue(identifier, out spawnAreas);
		}

		/// <summary>
		/// Returns a list of all spawn areas that currently exist in the
		/// world. Returns it as an array.
		/// </summary>
		/// <returns></returns>
		public SpawnAreaCollection[] GetSpawnAreas()
		{
			lock (_spawners)
				return _spawnAreaCollections.Values.ToArray();
		}

		/// <summary>
		/// Returns a list of all spawners that currently exist in the world.
		/// </summary>
		/// <returns></returns>
		public MonsterSpawner[] GetSpawners()
		{
			lock (_spawners)
				return _spawners.Values.ToArray();
		}

		/// <summary>
		/// Returns the first character found with the given team name via
		/// out. Retrns false if no matching character was found.
		/// </summary>
		/// <param name="teamName"></param>
		/// <param name="character"></param>
		/// <returns></returns>
		public bool TryGetCharacterByTeamName(string teamName, out Character character)
		{
			character = this.GetCharacterByTeamName(teamName);
			return character != null;
		}

		/// <summary>
		/// Returns the first monster that matches the given predicate
		/// on any map via out. Returns false if no matching monster was
		/// found.
		/// </summary>
		/// <param name="predicate"></param>
		/// <param name="monster"></param>
		/// <returns></returns>
		public bool TryGetMonster(Func<IMonster, bool> predicate, out IMonster monster)
			=> this.Maps.TryGetMonster(predicate, out monster);

		/// <summary>
		/// Returns the total number of player characters across all maps.
		/// </summary>
		/// <returns></returns>
		public int GetCharacterCount()
			=> this.Maps.GetCharacterCount();

		/// <summary>
		/// Returns all characters that are currently online.
		/// </summary>
		public Character[] GetCharacters()
			=> this.Maps.GetCharacters();

		/// <summary>
		/// Returns all online characters that match the given predicate.
		/// </summary>
		public Character[] GetCharacters(Func<Character, bool> predicate)
			=> this.Maps.GetCharacters(predicate);

		/// <summary>
		/// Broadcasts packet on all maps.
		/// </summary>
		/// <param name="packet"></param>
		public void Broadcast(Packet packet)
			=> this.Maps.Broadcast(packet);

		/// <summary>
		/// Returns all online characters that match the given predicate.
		/// </summary>
		public Character GetCharacter(Func<Character, bool> predicate)
			=> this.Maps.GetCharacter(predicate);

		/// <summary>
		/// Returns a party if found by id or null
		/// </summary>
		/// <param name="partyId"></param>
		/// <returns></returns>
		public Party GetParty(long partyId)
			=> this.Parties.GetParty(partyId);

		/// <summary>
		/// Returns a guild if found by id or null
		/// </summary>
		/// <param name="guildId"></param>
		/// <returns></returns>
		public Guild GetGuild(long guildId)
			=> this.Guilds.GetGuild(guildId);

		/// <summary>
		/// Generates a new id for a dynamic region.
		/// </summary>
		/// <returns></returns>
		public int GenerateDynamicMapId()
			=> this.Maps.GenerateDynamicMapId();

		/// <summary>
		/// Adds a map to the world's maps.
		/// </summary>
		/// <param name="map"></param>
		public void AddMap(Map map)
			=> this.Maps.Add(map);

		public Npc FindNPC(string dialogName)
		{
			this.NPCs.TryGetValue(dialogName, out var npc);

			return npc;
		}
	}
}
