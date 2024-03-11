using System;
using System.Collections.Generic;
using System.Linq;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Items;
using Melia.Zone.World.Maps;
using Yggdrasil.Logging;

namespace Melia.Zone.World.Houses
{
	/// <summary>
	/// Represents a character's personal house.
	/// </summary>
	public class PersonalHouse
	{
		private readonly object _syncLock = new object();
		private readonly Dictionary<int, Prop> _usedCells = new Dictionary<int, Prop>();

		/// <summary>
		/// Gets or sets the house's globally unique id.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Gets or sets the house's name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the house owner's id.
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// Gets or sets the house owner's name.
		/// </summary>
		public string OwnerName { get; set; }

		/// <summary>
		/// Gets or sets house's map id.
		/// </summary>
		public int MapId { get; set; }

		/// <summary>
		/// Gets or sets the house's X-coordinate
		/// </summary>
		public float X { get; set; }

		/// <summary>
		/// Gets or sets the house's Z-coordinate
		/// </summary>
		public float Z { get; set; }

		/// <summary>
		/// Gets or sets reference to the house's dynamic map.
		/// </summary>
		public PersonalHouseMap Map { get; set; }

		/// <summary>
		/// Gets or sets the last time the owner entered the house.
		/// </summary>
		public DateTime LastEnterTime { get; set; }

		public bool IsGridVisible { get; set; }
		public bool IsEditing { get; set; }
		public bool IsEdited { get; set; } = false;

		public List<Prop> Props { get; set; } = new List<Prop>();
		public Item ActiveFurnitureItem { get; private set; }

		/// <summary>
		/// Creates new house for entity, saves and returns it.
		/// </summary>
		/// <param name="character"></param>
		/// <param name="name"></param>
		/// <param name="x"></param>
		/// <param name="z"></param>
		/// <returns></returns>
		public static PersonalHouse CreateNew(Character character, string name, float x = 0f, float z = 0f)
		{
			// Create house
			var house = new PersonalHouse
			{
				Id = character.DbId,
				Name = name,
				OwnerId = character.DbId,
				OwnerName = character.Name,
				X = x,
				Z = z,

				MapId = 7000
			};

			ZoneServer.Instance.Database.SaveHouse(house);
			house.Init();

			return house;
		}

		/// <summary>
		/// Initializes house after it was loaded from database,
		/// setting its data and map.
		/// </summary>
		public void Init()
		{
			if (ZoneServer.Instance.Data.MapDb.Find(this.MapId) == null)
				throw new InvalidOperationException($"No house map data found for map id '{this.MapId}'.");

			this.Map = CreateMap(this);
		}

		/// <summary>
		/// Creates a region for the house.
		/// </summary>
		/// <param name="house"></param>
		/// <returns></returns>
		public static PersonalHouseMap CreateMap(PersonalHouse house)
		{
			var map = new PersonalHouseMap(house);
			map.PlayerLeaves += house.OnPlayerLeaves;
			map.PlayerEnters += house.OnPlayerEntered;
			ZoneServer.Instance.World.AddMap(map);
			return map;
		}

		/// <summary>
		/// Returns true if the entity is this house's owner.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public bool IsOwner(Character character)
		{
			return (this.OwnerId == character.DbId);
		}

		/// <summary>
		/// Return prop if found or null.
		/// </summary>
		/// <param name="furnitureHandle"></param>
		/// <returns></returns>
		private Prop GetProp(int furnitureHandle)
		{
			lock (_syncLock)
			{
				return this.Props.Find(f => f.Handle == furnitureHandle);
			}
		}

		/// <summary>
		/// Called when a player enters the house.
		/// </summary>
		/// <param name="character"></param>
		/// <param name="prevMapId"></param>
		private void OnPlayerEntered(Character character)
		{
			character.Connection.ActiveHouse = this;

			if (this.IsOwner(character))
			{
				if (this.LastEnterTime == DateTime.MinValue)
					character.Variables.Temp.SetBool("Melia.HouseEnterFirstTime", true);

				this.LastEnterTime = DateTime.Now;
			}
		}

		/// <summary>
		/// Called when a player leaves the house.
		/// </summary>
		/// <param name="character"></param>
		private void OnPlayerLeaves(Character character)
		{
			character.Connection.ActiveHouse = null;
			if (!this.IsOwner(character))
				return;

			ZoneServer.Instance.Database.SaveHouse(this);
		}

		/// <summary>
		/// Returns the location to warp to when entering this house.
		/// </summary>
		/// <returns></returns>
		public Location GetEnterLocation()
		{
			return new Location(this.Map.WorldId, 324f, 79f, -116f);
		}

		/// <summary>
		/// Returns the entity's return location.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public Location GetReturnLocation(Character entity)
		{

			return new Location(this.Map.WorldId, 324f, 79f, -116f);
		}

		/// <summary>
		/// Updates house to given map.
		/// </summary>
		/// <param name="mapId"></param>
		public void Upgrade(int mapId)
		{
			this.MapId = mapId;
			this.Init();
		}

		/// <summary>
		/// Set grid state.
		/// </summary>
		/// <param name="isVisible"></param>
		public void SetGridVisible(bool isVisible)
		{
			this.IsGridVisible = isVisible;
		}

		/// <summary>
		/// Set if personal house is in editing mode.
		/// </summary>
		/// <param name="isEditing"></param>
		public void SetEditMode(bool isEditing)
		{
			this.IsEditing = isEditing;
		}

		public bool StartFurnitureArrangement(Character character, Item itemFurniture)
		{
			if (!this.IsOwner(character))
				return false;

			if (!this.IsEditing)
			{
				this.IsEditing = true;
				var furniture = ZoneServer.Instance.Data.FurnitureDb.FindByClass(itemFurniture.Data.Script.StrArg);
				if (furniture != null)
				{
					if (!this.IsGridVisible)
					{
						this.SetGridVisible(true);
						Send.ZC_HOUSING_READY_GRID(character);
					}
					this.ActiveFurnitureItem = itemFurniture;
					Send.ZC_HOUSING_START_ARRANGEMENT_FURNITURE(character, furniture.Id);
				}
				return true;
			}

			character.SystemMessage("Housing_Cant_Do_It_While_Arrangement");
			return false;
		}

		public void AddFurniture(Character character, CardinalDirection direction, int column, int row, int cellCount, List<int> usedCells)
		{
			if (!this.IsOwner(character) || this.ActiveFurnitureItem == null)
				return;

			var furniture = ZoneServer.Instance.Data.FurnitureDb.FindByClass(this.ActiveFurnitureItem.Data.Script.StrArg);
			if (furniture != null)
			{
				if (!ZoneServer.Instance.Data.MonsterDb.TryFind(furniture.ClassName, out var monsterData))
				{
					Log.Warning("AddFurniture: Monster not found by class {0}", furniture.ClassName);
					return;
				}
				if (character.Inventory.Remove(ActiveFurnitureItem.ObjectId) == InventoryResult.Success)
				{
					var firstCell = usedCells[0];
					var x = -120f + (firstCell % 15 * 20);
					var y = (float)(Math.Floor(firstCell / 225d) * 20);
					var z = (float)(-130 + (Math.Floor(firstCell / 15d) * 20));
					var prop = new Prop(furniture.Id)
					{
						MonsterId = monsterData.Id,
						FurnitureId = furniture.Id,
						Position = new Position(x, y, z),
						Direction = Direction.FromCardinalDirection(direction),
					};

					for (var i = 0; i < usedCells.Count; i++)
					{
						prop.UsedCells[i] = usedCells[i];
						_usedCells.Add(prop.UsedCells[i], prop);
					}

					this.Props.Add(prop);

					var monster = new Mob(prop.MonsterId, MonsterType.NPC);
					monster.Position = prop.Position;
					monster.Direction = prop.Direction;
					monster.IsProp = furniture.IsBackgroundModel;
					this.Map.AddMonster(monster);
					prop.Handle = monster.Handle;
					Send.ZC_HOUSING_READY_ARRANGED_FURNITURE(character, ActiveFurnitureItem, prop);
					Send.ZC_PERSONAL_HOUSING_ANSWER_GROUP_LIST(character);
				}
			}
		}

		public void CancelFurnitureArrangement(Character character)
		{
			if (!this.IsOwner(character))
				return;
			this.SetGridVisible(false);
			this.SetEditMode(false);
			this.ActiveFurnitureItem = null;
		}

		public void EnableMoveFurniture(Character character, int furnitureId, int furnitureHandle)
		{
			if (!this.IsOwner(character))
				return;
			var prop = this.GetProp(furnitureHandle);
			var furniture = this.Map.GetMonster(furnitureHandle);
			if (furniture != null && prop != null && prop.FurnitureId == furnitureId)
			{
				Send.ZC_HOUSING_ANSWER_ENABLE_MOVE_FURNITURE(character, furnitureId, furnitureHandle);
			}
		}

		public void MoveFurniture(Character character, int furnitureId, int furnitureHandle, CardinalDirection direction, int column, int row, int cellCount, List<int> usedCells)
		{
			if (!this.IsOwner(character))
				return;

			var prop = this.GetProp(furnitureHandle);

			if (this.Map.TryGetMonster(furnitureHandle, out var furniture) && prop != null && prop.FurnitureId == furnitureId)
			{
				var firstCell = usedCells[0];
				var x = -120f + ((firstCell % 15) * 20);
				var y = (float)(Math.Floor(firstCell / 225d) * 20);
				var z = (float)(-130 + (Math.Floor(firstCell / 15d) * 20));
				prop.Position = new Position(x, y, z);
				prop.Direction = Direction.FromCardinalDirection(direction);
				furniture.Position = prop.Position;
				furniture.Direction = prop.Direction;

				for (var i = 0; i < prop.UsedCells.Length; i++)
				{
					_usedCells.Remove(prop.UsedCells[i]);
				}
				for (var i = 0; i < usedCells.Count; i++)
				{
					prop.UsedCells[i] = usedCells[i];
					_usedCells.Add(prop.UsedCells[i], prop);
				}
				Send.ZC_PLAY_SOUND(character, 2628);
				Send.ZC_HOUSING_MOVE_BG_FURNITURE(furniture);
				Send.ZC_GROUND_EFFECT(character, AnimationName.WhiteSmoke, furniture.Position, 4.5f, 3f, 0, 0, 0, 0, -14968, 0);
			}
		}

		public void RemoveFurniture(Character character, int furnitureId, int furnitureHandle)
		{
			if (!this.IsOwner(character))
				return;

			var prop = this.GetProp(furnitureHandle);

			if (this.Map.TryGetMonster(furnitureHandle, out var furniture) && prop != null && prop.FurnitureId == furnitureId)
			{
				var itemData = ZoneServer.Instance.Data.ItemDb.FindByClass(prop.Data.ItemClassName);
				if (itemData != null)
				{
					this.Props.Remove(prop);
					character.Inventory.Add(new Item(itemData.Id));

					if (furniture is Mob mob && mob.IsProp)
						Send.ZC_HOUSING_REMOVE_BG_FURNITURE(furniture);
					else
					{
						Send.ZC_NORMAL.ClearEffects(furniture);
						Send.ZC_DEAD(furniture, null, true);
						Send.ZC_SKILL_CAST_CANCEL(furniture);
					}
					Send.ZC_HOUSING_ANSWER_REMOVE_FURNITURE(furniture, furnitureId);
					Send.ZC_PERSONAL_HOUSING_ANSWER_GROUP_LIST(character);
					this.Map.RemoveMonster(furniture);
				}
			}
		}

		public void RemoveAllFurniture(Character character)
		{
			if (!this.IsOwner(character))
				return;
			lock (_syncLock)
			{
				var removedProps = new List<Prop>();
				foreach (var prop in this.Props)
				{
					var furniture = this.Map.GetMonster(prop.Handle);
					if (furniture != null)
					{
						var itemData = ZoneServer.Instance.Data.ItemDb.FindByClass(prop.Data.ItemClassName);
						if (itemData != null)
						{
							removedProps.Add(prop);
							character.Inventory.Add(new Item(itemData.Id));
							Send.ZC_HOUSING_ANSWER_REMOVE_FURNITURE(furniture, prop.FurnitureId);
							if (furniture is Mob mob && mob.IsProp)
								Send.ZC_HOUSING_REMOVE_BG_FURNITURE(furniture);
							else
							{
								Send.ZC_NORMAL.ClearEffects(furniture);
								Send.ZC_DEAD(furniture, null, true);
								Send.ZC_SKILL_CAST_CANCEL(furniture);
							}
							this.Map.RemoveMonster(furniture);
						}
					}
				}
				foreach (var prop in removedProps)
					this.Props.Remove(prop);
				Send.ZC_PERSONAL_HOUSING_ANSWER_GROUP_LIST(character);
			}
		}

		public void ShowGrid(Character character)
		{
			if (!this.IsOwner(character))
				return;
			if (!this.IsGridVisible)
			{
				this.SetGridVisible(true);
				Send.ZC_HOUSING_READY_GRID(character);
			}
		}
	}
}
