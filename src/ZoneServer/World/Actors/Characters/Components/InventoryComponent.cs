using System;
using System.Collections.Generic;
using System.Linq;
using Melia.Shared.Data.Database;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Items;
using Yggdrasil.Logging;

namespace Melia.Zone.World.Actors.Characters.Components
{
	/// <summary>
	/// Represents a character's inventory.
	/// </summary>
	public class InventoryComponent : CharacterComponent
	{
		private readonly object _syncLock = new object();

		private Dictionary<InventoryCategory, List<Item>> _items = new Dictionary<InventoryCategory, List<Item>>();
		private readonly Dictionary<long, Item> _itemsWorldIndex = new Dictionary<long, Item>();
		private readonly Dictionary<EquipSlot, Item> _equip = new Dictionary<EquipSlot, Item>(InventoryDefaults.EquipSlotCount);
		private readonly List<Item> _warehouse = new List<Item>();

		/// <summary>
		/// Raised when the character equipped an item.
		/// </summary>
		public event Action<Character, Item> Equipped;

		/// <summary>
		/// Raised when the character unequipped an item.
		/// </summary>
		public event Action<Character, Item> Unequipped;

		/// <summary>
		/// Creates new inventory for character.
		/// </summary>
		public InventoryComponent(Character character) : base(character)
		{
			foreach (InventoryCategory category in Enum.GetValues(typeof(InventoryCategory)))
				_items.Add(category, new List<Item>());

			for (EquipSlot slot = 0; slot < (EquipSlot)InventoryDefaults.EquipSlotCount; ++slot)
				_equip.Add(slot, new DummyEquipItem(slot));
		}

		/// <summary>
		/// Returns list of ids of equipped items, in the order of EquipSlot.
		/// </summary>
		/// <returns></returns>
		public int[] GetEquipIds()
		{
			// TODO: Cache.

			lock (_syncLock)
				return _equip.Where(a => (int)a.Key <= InventoryDefaults.EquipSlotCount).OrderBy(a => a.Key).Select(a => a.Value.Id).ToArray();
		}

		/// <summary>
		/// Returns dictionary of equipped items.
		/// </summary>
		/// <remarks>
		/// If no actual item is equipped in a slot, it will be filled with
		/// a dummy item, which this method returns as well.
		/// </remarks>
		/// <returns></returns>
		public Dictionary<EquipSlot, Item> GetEquip()
		{
			lock (_syncLock)
				return _equip.ToDictionary(a => a.Key, a => a.Value);
		}

		/// <summary>
		/// Returns item equipped in the given slot.
		/// </summary>
		/// <remarks>
		/// If no actual item is equipped in a slot, it will be filled with
		/// a dummy item, which this method returns as well.
		/// </remarks>
		/// <param name="slot"></param>
		/// <returns></returns>
		public Item GetEquip(EquipSlot slot)
		{
			lock (_syncLock)
			{
				_equip.TryGetValue(slot, out var item);
				return item;
			}
		}

		/// <summary>
		/// Returns the sum of the property on all equipped items.
		/// </summary>
		/// <returns></returns>
		public float GetEquipProperties(string propertyName)
		{
			lock (_syncLock)
				return _equip.Values.Sum(a => a.Properties.GetFloat(propertyName, 0));
		}

		/// <summary>
		/// Returns the sum of the properties on all equipped items.
		/// </summary>
		/// <returns></returns>
		public float GetSumOfEquipProperties(params string[] propertyNames)
		{
			var total = 0f;

			lock (_syncLock)
			{
				foreach (var propertyName in propertyNames)
					total += _equip.Values.Sum(a => a.Properties.GetFloat(propertyName, 0));
			}

			return total;
		}

		/// <summary>
		/// Returns a dictionary with all items, Key being their inventory
		/// index.
		/// </summary>
		/// <returns></returns>
		public IDictionary<int, Item> GetItems()
			=> this.GetItems(null);

		/// <summary>
		/// Returns a dictionary with all items that match the predicate,
		/// Key being their index.
		/// </summary>
		/// <returns></returns>
		public IDictionary<int, Item> GetItems(Func<Item, bool> predicate)
		{
			var result = new Dictionary<int, Item>();

			lock (_syncLock)
			{
				foreach (var category in _items)
				{
					for (var i = 0; i < category.Value.Count; ++i)
					{
						var index = category.Value[i].GetInventoryIndex(i);
						var item = category.Value[i];

						if (predicate == null || predicate(item))
							result.Add(index, item);
					}
				}
			}

			return result;
		}

		/// <summary>
		/// Returns a list with all items in the warehouse.
		/// </summary>
		/// <returns></returns>
		public IList<Item> GetWarehouseItems()
		{
			lock (_syncLock)
				return this._warehouse;
		}

		/// <summary>
		/// Returns a dictionary with all items' inventory indices and
		/// object ids.
		/// </summary>
		/// <returns></returns>
		public IDictionary<int, long> GetIndices()
		{
			var result = new Dictionary<int, long>();

			lock (_syncLock)
			{
				foreach (var category in _items)
				{
					for (var i = 0; i < category.Value.Count; ++i)
					{
						var index = category.Value[i].GetInventoryIndex(i);
						var itemObjectId = category.Value[i].Id;

						result.Add(index, itemObjectId);
					}
				}
			}

			return result;
		}

		/// <summary>
		/// Returns a dictionary with the inventory indices and object
		/// ids of all items in the given category.
		/// </summary>
		/// <returns></returns>
		public IDictionary<int, long> GetIndices(InventoryCategory category)
		{
			var result = new Dictionary<int, long>();

			lock (_syncLock)
			{
				if (!_items.ContainsKey(category))
					throw new ArgumentException("Unknown item category.");

				var items = _items[category];
				for (var i = 0; i < items.Count; ++i)
				{
					var index = items[i].GetInventoryIndex(i);
					var itemObjectId = items[i].Id;

					result.Add(index, itemObjectId);
				}
			}

			return result;
		}

		/// <summary>
		/// Returns true if any item in the inventory is set to expire
		/// </summary>
		public bool HasExpiringItems => this.HasItems(a => a.IsExpiring);

		/// <summary>
		/// Returns true if an item with the given predicate exist in the inventory.
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public bool HasItems(Func<Item, bool> predicate)
		{
			lock (_syncLock)
				return _items.SelectMany(a => a.Value).Any(predicate);
		}

		/// <summary>
		/// Returns true if an item with the given class name exist in the inventory.
		/// </summary>
		/// <param name="itemClassName">Item's ClassName</param>
		/// <param name="amount">Item Amount</param>
		/// <returns></returns>
		public bool HasItem(string itemClassName, int amount = 1)
		{
			return ZoneServer.Instance.Data.ItemDb.TryFind(itemClassName, out var itemClass)
				&& this.HasItem(itemClass.Id, amount);
		}

		/// <summary>
		/// Returns true if an item with the given id exist in the inventory.
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public bool HasItem(int itemId, int amount = 1)
		{
			lock (_syncLock)
				return _items.SelectMany(a => a.Value).Any(a => a.Id == itemId && a.Amount == amount);
		}

		/// <summary>
		/// Returns amount of items with the given id in the inventory.
		/// </summary>
		/// <remarks>
		/// Stacks count as the amount of items in the stack.
		/// E.g.: One stack with 10 HP potions results in a count of 10.
		/// </remarks>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public int CountItem(int itemId)
		{
			lock (_syncLock)
				return _items.SelectMany(a => a.Value).Where(a => a.Id == itemId).Sum(a => a.Amount);
		}

		/// <summary>
		/// Returns item by world id, or null if it doesn't exist.
		/// </summary>
		/// <param name="worldId"></param>
		/// <returns></returns>
		public Item GetItem(long worldId, InventoryType inventoryType = InventoryType.Inventory)
		{
			Item item;
			lock (_syncLock)
			{
				switch (inventoryType)
				{
					default:
						_itemsWorldIndex.TryGetValue(worldId, out item);
						break;
				}
			}

			return item;
		}

		/// <summary>
		/// Returns an item by its inventory index (category+index).
		/// Returns null if no item with the given index was found.
		/// </summary>
		/// <param name="inventoryIndex"></param>
		/// <returns></returns>
		public Item GetItemByIndex(int inventoryIndex)
		{
			ZoneServer.Instance.Data.InvBaseIdDb.SplitCategoryIndex(inventoryIndex, out var category, out var index);

			Item item;
			lock (_syncLock)
			{
				var list = _items[category];
				if (list.Count < index)
					return null;

				item = list[index];
			}

			return item;
		}

		/// <summary>
		/// Returns item in given equip slot, or null if there is none.
		/// </summary>
		/// <param name="slot"></param>
		/// <returns></returns>
		public Item GetItem(EquipSlot slot)
		{
			Item item;
			lock (_syncLock)
				_equip.TryGetValue(slot, out item);

			return item;
		}

		/// <summary>
		/// Adds item to inventory without updating the character's client.
		/// </summary>
		/// <param name="item"></param>
		public void AddSilent(Item item, InventoryType inventoryType = InventoryType.Inventory)
		{
			var left = this.FillStacks(item, InventoryAddType.NotNew, true, inventoryType);
			if (left > 0)
			{
				item.Amount = left;
				this.AddStack(item, InventoryAddType.NotNew, true, inventoryType);
			}
		}

		/// <summary>
		/// Adds item to inventory and updates client.
		/// </summary>
		/// <param name="item"></param>
		/// <param name="addType"></param>
		public bool Add(Item item, InventoryAddType addType = InventoryAddType.New, InventoryType inventoryType = InventoryType.Inventory, float notificationDelay = 0f)
		{
			if (_items.Count > 2000 && inventoryType == InventoryType.Warehouse)
				return false;

			var amountToAdd = item.Amount;

			var left = this.FillStacks(item, addType, false, inventoryType, notificationDelay);
			if (left > 0)
			{
				item.Amount = left;
				this.AddStack(item, addType, false, inventoryType, notificationDelay);
			}

			Send.ZC_OBJECT_PROPERTY(this.Character, PropertyName.NowWeight);

			// Temp fix. The amounts on item stacks that items were added
			// to are sometimes wrong, a full updates fixes that. Maybe
			// ZC_ITEM_ADD needs an update.
			Send.ZC_ITEM_INVENTORY_DIVISION_LIST(this.Character);

			ZoneServer.Instance.ServerEvents.OnPlayerAddedItem(this.Character, item.Id, amountToAdd);

			return true;
		}

		/// <summary>
		/// Adds new items with given item id to inventory.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="amount"></param>
		/// <param name="addType"></param>
		public void Add(int itemId, int amount, InventoryAddType addType = InventoryAddType.PickUp)
		{
			while (amount > 0)
			{
				// Item caps Amount automatically. By using amount directly
				// either the entire amount is used for the new item,
				// or the max amount for it. This way we add new stacks until
				// amount is 0.

				var item = new Item(itemId, amount);
				this.Add(item, addType);

				amount -= item.Amount;
			}
		}

		/// <summary>
		/// Filles stacks with item, returns the amount of items left.
		/// The item is not modified.
		/// </summary>
		/// <remarks>
		/// If no stacks are found, nothing happens, and the amount returned
		/// will be equal to item.Amount.
		/// </remarks>
		/// <param name="item">Item to fill existing stacks with.</param>
		/// <param name="silent">If true, client isn't updated.</param>
		private int FillStacks(Item item, InventoryAddType addType, bool silent, InventoryType inventoryType = InventoryType.Inventory, float notificationDelay = 0f)
		{
			// If item isn't stackable, we've got nothing to do here.
			if (!item.IsStackable)
				return item.Amount;

			var itemId = item.Id;
			var amount = item.Amount;
			var cat = item.Data.Category;
			var stacks = this.GetStacks(cat, itemId, inventoryType);

			// Fill stacks
			foreach (var index in stacks)
			{
				lock (_syncLock)
				{
					var categoryItem = inventoryType switch
					{
						InventoryType.Warehouse => _warehouse.ElementAtOrDefault(index),
						_ => _items[cat][index],
					};
					if (categoryItem == null)
						return item.Amount;
					var space = (categoryItem.Data.MaxStack - categoryItem.Amount);
					var add = Math.Min(amount, space);

					categoryItem.Amount += add;
					amount -= add;

					if (!silent)
					{
						var categoryIndex = categoryItem.GetInventoryIndex(index);

						// Use given add type if this was the last of it,
						// or NotNew if only some was just added to a stack.
						var adjustedAddType = (amount == 0 ? addType : InventoryAddType.NotNew);

						Send.ZC_ITEM_ADD(this.Character, categoryItem, categoryIndex, add, adjustedAddType, inventoryType, notificationDelay);
					}
				}

				if (amount == 0)
					break;
			}

			return amount;
		}

		/// <summary>
		/// Adds given stack to inventory.
		/// </summary>
		/// <param name="item">Item to add to inventory.</param>
		/// <param name="silent">If true, client isn't updated.</param>
		private void AddStack(Item item, InventoryAddType addType, bool silent, InventoryType inventoryType = InventoryType.Inventory, float notificationDelay = 0f)
		{
			var cat = item.Data.Category;

			lock (_syncLock)
			{
				switch (inventoryType)
				{
					case InventoryType.Warehouse:
						_warehouse.Add(item);
						_itemsWorldIndex[item.ObjectId] = item;
						break;
					default:
						_items[cat].Add(item);
						_itemsWorldIndex[item.ObjectId] = item;
						break;
				}

				if (!silent)
				{
					var categoryIndex = item.GetInventoryIndex(_items[cat].Count - 1);
					Send.ZC_ITEM_ADD(this.Character, item, categoryIndex, item.Amount, addType, inventoryType, notificationDelay);
				}
			}
		}

		/// <summary>
		/// Returns indices of stacks in cat with the given item id that
		/// aren't full yet.
		/// </summary>
		/// <param name="cat"></param>
		/// <param name="itemId"></param>
		/// <returns></returns>
		private List<int> GetStacks(InventoryCategory cat, int itemId, InventoryType inventoryType = InventoryType.Inventory)
		{
			var result = new List<int>();

			lock (_syncLock)
			{
				switch (inventoryType)
				{
					case InventoryType.Warehouse:
						var index = _warehouse.FindIndex(item => item.Id == itemId && item.Amount < item.Data.MaxStack);
						result.Add(index);
						break;
					default:
						var categoryItems = _items[cat];
						for (var i = 0; i < categoryItems.Count; ++i)
						{
							var item = categoryItems[i];
							if (item.Id == itemId && item.Amount < item.Data.MaxStack)
								result.Add(i);
						}
						break;
				}
			}

			return result;
		}

		/// <summary>
		/// Puts item into equip slot without updating the client.
		/// </summary>
		/// <param name="item"></param>
		public void SetEquipSilent(EquipSlot slot, Item item)
		{
			lock (_syncLock)
				_equip[slot] = item;

			this.Character.UpdateStance();
		}

		/// <summary>
		/// Moves item with the given id into the given slot.
		/// </summary>
		/// <param name="slot"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		public InventoryResult Equip(EquipSlot slot, long worldId)
		{
			if (!Enum.IsDefined(typeof(EquipSlot), slot))
				return InventoryResult.InvalidSlot;

			var item = this.GetItem(worldId);
			if (item == null)
				return InventoryResult.ItemNotFound;

			// Unequip existing item first.
			var collision = false;
			lock (_syncLock)
				collision = !(_equip[slot] is DummyEquipItem);

			if (collision)
				this.Unequip(slot);

			// Equip new item
			lock (_syncLock)
			{
				_equip[slot] = item;
				_items[item.Data.Category].Remove(item);
				_itemsWorldIndex.Remove(item.Id);
			}

			// Update character
			this.Character.UpdateStance();

			// Update client
			Send.ZC_ITEM_REMOVE(this.Character, item.ObjectId, 1, InventoryItemRemoveMsg.Equipped, InventoryType.Inventory);
			Send.ZC_ITEM_EQUIP_LIST(this.Character);
			Send.ZC_UPDATED_PCAPPEARANCE(this.Character);
			Send.ZC_ITEM_INVENTORY_DIVISION_LIST(this.Character);

			this.Equipped?.Invoke(this.Character, item);

			// Try to execute script
			var script = item.Data.Script;

			if (ScriptableFunctions.Equip.TryGet("SCP_ON_EQUIP_ITEM_" + item.Data.ClassName, out var scriptFunc))
				scriptFunc(this.Character, item, script.StrArg, script.StrArg2, script.NumArg1, script.NumArg2);

			if (!string.IsNullOrEmpty(item.Data.EquipSkill) && ScriptableFunctions.Equip.TryGet("SCP_ON_EQUIP_ITEM_SKILL", out scriptFunc))
			{
				if (script == null)
				{
					script = new ItemScriptData()
					{
						StrArg2 = item.Data.EquipSkill,
					};
					item.Data.Script = script;
				}
				scriptFunc(this.Character, item, script.StrArg, item.Data.EquipSkill, script.NumArg1, script.NumArg2);
			}

			return InventoryResult.Success;
		}

		/// <summary>
		/// Moves item from given slot into inventory.
		/// </summary>
		/// <param name="slot"></param>
		/// <returns></returns>
		public InventoryResult Unequip(EquipSlot slot)
		{
			if (!Enum.IsDefined(typeof(EquipSlot), slot))
				return InventoryResult.InvalidSlot;

			var item = this.GetItem(slot);
			if (item == null || item is DummyEquipItem)
				return InventoryResult.ItemNotFound;

			lock (_syncLock)
				_equip[slot] = new DummyEquipItem(slot);

			Send.ZC_ITEM_EQUIP_LIST(this.Character);
			Send.ZC_UPDATED_PCAPPEARANCE(this.Character);

			this.Add(item, InventoryAddType.NotNew);

			this.Unequipped?.Invoke(this.Character, item);

			// Try to execute script
			var script = item.Data.Script;

			if (ScriptableFunctions.Unequip.TryGet("SCP_ON_UNEQUIP_ITEM_" + item.Data.ClassName, out var scriptFunc))
				scriptFunc(this.Character, item, script.StrArg, script.StrArg2, script.NumArg1, script.NumArg2);

			if (!string.IsNullOrEmpty(item.Data.EquipSkill) && ScriptableFunctions.Unequip.TryGet("SCP_ON_UNEQUIP_ITEM_SKILL", out scriptFunc))
			{
				if (script == null)
				{
					script = new ItemScriptData()
					{
						StrArg2 = item.Data.EquipSkill,
					};
					item.Data.Script = script;
				}
				scriptFunc(this.Character, item, script.StrArg, item.Data.EquipSkill, script.NumArg1, script.NumArg2);
			}

			return InventoryResult.Success;
		}

		/// <summary>
		/// Unequips all currently equipped items.
		/// </summary>
		public void UnequipAll()
		{
			foreach (var slot in Enum.GetValues(typeof(EquipSlot)))
				this.Unequip((EquipSlot)slot);
		}

		/// <summary>
		/// Remove an item and a given amount
		/// </summary>
		/// <param name="itemClassName"></param>
		/// <param name="amount"></param>
		/// <returns>Amount of pieces removed.</returns>
		public int RemoveItem(string itemClassName, int amount = 1)
		{
			if (ZoneServer.Instance.Data.ItemDb.TryFind(itemClassName, out var itemData))
				return this.Remove(itemData.Id, amount, InventoryItemRemoveMsg.Given);
			return 0;
		}

		/// <summary>
		/// Removes item with given id from inventory.
		/// </summary>
		/// <param name="slot"></param>
		public InventoryResult Remove(long worldId, int amount = 1, InventoryItemRemoveMsg msg = InventoryItemRemoveMsg.Destroyed, InventoryType type = InventoryType.Inventory)
		{
			var item = this.GetItem(worldId, type);
			if (item == null || item is DummyEquipItem)
				return InventoryResult.ItemNotFound;

			return this.Remove(item, amount, msg, type);
		}

		/// <summary>
		/// Removes item from inventory.
		/// </summary>
		/// <param name="slot"></param>
		private InventoryResult Remove(Item item, InventoryItemRemoveMsg msg = InventoryItemRemoveMsg.Destroyed, InventoryType type = InventoryType.Inventory)
		{
			lock (_syncLock)
			{
				switch (type)
				{
					case InventoryType.Warehouse:
						if (!_warehouse.Remove(item))
							return InventoryResult.ItemNotFound;
						break;
					default:
						if (!_items[item.Data.Category].Remove(item))
							return InventoryResult.ItemNotFound;
						break;
				}

				_itemsWorldIndex.Remove(item.Id);
			}

			// TODO: Add localizable strings or dictionary keys to item data,
			//   so that we can send those for the system message.
			if (msg == InventoryItemRemoveMsg.Destroyed)
				this.Character.SystemMessage("Delete{ITEM}{COUNT}", new MsgParameter("ITEM", item.Data.Name), new MsgParameter("COUNT", item.Amount));

			Send.ZC_ITEM_REMOVE(this.Character, item.ObjectId, item.Amount, msg, type);

			// We need to update the indices after removing an item,
			// because we'll run into issues with the client potentially
			// misidentifying items otherwise, caused by duplicate indices.
			// Alternatively, we could revamp our index handling, so there's
			// no more risk for duplicates.
			//Send.ZC_ITEM_INVENTORY_INDEX_LIST(this.Character, item.Data.Category);
			Send.ZC_ITEM_INVENTORY_DIVISION_LIST(this.Character);

			Send.ZC_OBJECT_PROPERTY(this.Character, "NowWeight", "MSPD");

			return InventoryResult.Success;
		}

		/// <summary>
		/// Reduces item's amount by the given value. Item is removed
		/// if amount becomes 0.
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		/// <param name="msg"></param>
		/// <param name="inventoryType"></param>
		/// <returns></returns>
		public InventoryResult Remove(Item item, int amount, InventoryItemRemoveMsg msg, InventoryType inventoryType = InventoryType.Inventory)
		{
			// Check if item exists in inventory
			lock (_syncLock)
			{
				switch (inventoryType)
				{
					case InventoryType.Warehouse:
						if (!_warehouse.Contains(item))
							return InventoryResult.ItemNotFound;
						break;
					default:
						if (!_items[item.Data.Category].Contains(item))
							return InventoryResult.ItemNotFound;
						break;
				}
			}

			int amountRemoved;

			// Remove or reduce
			if (item.Amount <= amount)
			{
				this.Remove(item, msg, inventoryType);
				amountRemoved = item.Amount;
			}
			else
			{
				item.Amount -= amount;
				amountRemoved = amount;

				Send.ZC_ITEM_REMOVE(this.Character, item.ObjectId, amount, msg, inventoryType);

				this.Character.Properties.Invalidate(PropertyName.NowWeight);
				Send.ZC_OBJECT_PROPERTY(this.Character, PropertyName.NowWeight);
			}

			ZoneServer.Instance.ServerEvents.OnPlayerRemovedItem(this.Character, item.Id, amountRemoved);

			return InventoryResult.Success;
		}

		/// <summary>
		/// Removes items with given id from inventory.
		/// </summary>
		/// <param name="itemId">Id of the item to remove.</param>
		/// <param name="amount">Amount of pieces to remove.</param>
		/// <returns>Amount of pieces removed.</returns>
		public int Remove(int itemId, int amount, InventoryItemRemoveMsg msg)
		{
			if (amount == 0)
				return 0;

			var amountRemoved = 0;

			// Potential optimization: don't search every category. However,
			// technically any item can be in any category.
			foreach (var itemkv in this.GetItems(a => a.Id == itemId))
			{
				var index = itemkv.Key;
				var item = itemkv.Value;
				var itemAmount = item.Amount;
				var category = item.Data.Category;
				var reduce = Math.Min(amount, item.Amount);

				item.Amount -= reduce;
				amount -= reduce;
				amountRemoved += reduce;

				if (reduce == itemAmount)
				{
					lock (_syncLock)
					{
						_items[category].Remove(item);
						_itemsWorldIndex.Remove(item.Id);

					}
				}

				Send.ZC_ITEM_REMOVE(this.Character, item.ObjectId, reduce, msg, InventoryType.Inventory);
				//Send.ZC_ITEM_INVENTORY_INDEX_LIST(this.Character, item.Data.Category);
				Send.ZC_ITEM_INVENTORY_DIVISION_LIST(this.Character);
			}

			if (amountRemoved != 0)
			{
				Send.ZC_OBJECT_PROPERTY(this.Character, "NowWeight");
				ZoneServer.Instance.ServerEvents.OnPlayerRemovedItem(this.Character, itemId, amountRemoved);
			}

			return amountRemoved;
		}

		/// <summary>
		/// Swaps the two items with each other.
		/// </summary>
		/// <param name="worldId1"></param>
		/// <param name="worldId2"></param>
		/// <returns></returns>
		public InventoryResult Swap(long worldId1, long worldId2, InventoryType inventoryType = InventoryType.Inventory)
		{
			var item1 = this.GetItem(worldId1, inventoryType);
			var item2 = this.GetItem(worldId2, inventoryType);

			if (item1 == null || item2 == null)
				return InventoryResult.ItemNotFound;

			if (item1.Data.Category != item2.Data.Category)
				return InventoryResult.InvalidOperation;

			var category = item1.Data.Category;

			lock (_syncLock)
			{
				IList<Item> list;
				switch (inventoryType)
				{
					case InventoryType.Warehouse:
						list = _warehouse;
						break;
					default:
						list = _items[category];
						break;
				}
				var index1 = list.IndexOf(item1);
				var index2 = list.IndexOf(item2);

				list[index1] = item2;
				list[index2] = item1;
			}

			//Send.ZC_ITEM_INVENTORY_INDEX_LIST(this.Character, category);

			return InventoryResult.Success;
		}

		/// <summary>
		/// Sorts inventory by given order.
		/// </summary>
		/// <param name="order"></param>
		public void Sort(InventoryOrder order)
		{
			lock (_syncLock)
			{
				var items = new Dictionary<InventoryCategory, List<Item>>();

				// Go through the categories one by one and sort them by
				// the given order.

				foreach (var category in _items.Keys)
				{
					switch (order)
					{
						case InventoryOrder.Price:
							items[category] = _items[category].OrderBy(a => a.Data.Price).ToList();
							break;

						case InventoryOrder.Weight:
							items[category] = _items[category].OrderBy(a => a.Data.Weight).ToList();
							break;

						//case InventoryOrder.Grade:
						//	items[category] = _items[category].OrderBy(a => a.[...]).ToList();
						//	break;

						case InventoryOrder.Name:
							items[category] = _items[category].OrderBy(a => a.Data.Name).ToList();
							break;

						default:
							items[category] = _items[category].OrderBy(a => a.Id).ToList();
							break;
					}
				}

				_items = items;
			}

			// Sending ZC_ITEM_INVENTORY_INDEX_LIST stopped working at some
			// point after the iCBT2, officials send a full list now.
			//Send.ZC_ITEM_INVENTORY_INDEX_LIST(this.Character);

			// Sending ZC_ITEM_INVENTORY_LIST stopped working at some point.
			// Third time's the charm, I bet ZC_ITEM_INVENTORY_DIVISION_LIST
			// is way better than the previous options!
			//Send.ZC_ITEM_INVENTORY_LIST(this.Character);

			Send.ZC_ITEM_INVENTORY_DIVISION_LIST(this.Character);
		}

		/// <summary>
		/// Returns combined weight of all items in the inventory.
		/// </summary>
		/// <returns></returns>
		public float GetNowWeight()
		{
			var result = 0f;

			// TODO: Cache.
			lock (_syncLock)
			{
				result += _items.SelectMany(a => a.Value).Sum(a => a.Data.Weight);
				result += _equip.Values.Where(a => !(a is DummyEquipItem)).Sum(a => a.Data.Weight);
			}

			return result;
		}

		/// <summary>
		/// Logs the entire inventory and the equipment.
		/// </summary>
		public void Debug()
		{
			Log.Debug("<Debug> -----------------------------");

			Log.Debug("Inventory");
			foreach (var category in _items)
			{
				Log.Debug("  {0}", category.Key);
				for (var i = 0; i < category.Value.Count; ++i)
				{
					var index = category.Value[i].GetInventoryIndex(i);
					var item = category.Value[i];

					Log.Debug("    {0} : {1}", index, item.Data.ClassName);
				}
			}

			Log.Debug("Equip");
			foreach (var item in _equip.ToDictionary(a => a.Key, a => a.Value))
				Log.Debug("  {0} : {1}", item.Key, item.Value.Data.ClassName);

			Log.Debug("</Debug> ----------------------------");
		}

		/// <summary>
		/// Removes all items from inventory.
		/// </summary>
		public InventoryResult Clear()
		{
			var modifiedCategories = new HashSet<InventoryCategory>();
			var items = this.GetItems();

			// Remove items
			foreach (var item in items.Values)
			{
				lock (_syncLock)
				{
					_items[item.Data.Category].Remove(item);
					_itemsWorldIndex.Remove(item.Id);
				}

				modifiedCategories.Add(item.Data.Category);
				Send.ZC_ITEM_REMOVE(this.Character, item.ObjectId, item.Amount, InventoryItemRemoveMsg.Destroyed, InventoryType.Inventory);
			}

			// Update categories
			//foreach (var category in modifiedCategories)
			//	Send.ZC_ITEM_INVENTORY_INDEX_LIST(this.Character, category);
			Send.ZC_ITEM_INVENTORY_DIVISION_LIST(this.Character);

			// Update weight
			Send.ZC_OBJECT_PROPERTY(this.Character, "NowWeight");

			return InventoryResult.Success;
		}

		/// <summary>
		/// Try to get an item with a given item world id.
		/// </summary>
		/// <param name="itemWorldId"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool TryGetItem(long itemWorldId, out Item item)
		{
			item = this.GetItem(itemWorldId);
			return item != null;
		}

		/// <summary>
		/// Returns an item by its inventory index (category+index) via out.
		/// Returns whether an item with the given index was found.
		/// </summary>
		/// <param name="inventoryIndex"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool TryGetItemByIndex(int inventoryIndex, out Item item)
		{
			item = this.GetItemByIndex(inventoryIndex);
			return item != null;
		}
	}

	public enum InventoryResult
	{
		Success,
		ItemNotFound,
		InvalidSlot,
		InvalidOperation,
	}
}
