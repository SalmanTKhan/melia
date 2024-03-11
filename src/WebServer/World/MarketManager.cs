using System;
using System.Collections.Generic;
using System.Linq;
using Melia.Shared.Game.Const;
using Melia.Shared.Game.Const.Web;
using Yggdrasil.Logging;

namespace Melia.Web.World
{
	public class MarketManager
	{
		private readonly object _syncLock = new object();

		private Dictionary<long, ItemList> _marketIndexedItems = new Dictionary<long, ItemList>();
		private Dictionary<long, List<ItemList>> _characterIndexedItems = new Dictionary<long, List<ItemList>>();
		private Dictionary<InventoryCategory, List<ItemList>> _categoryIndexedItems = new Dictionary<InventoryCategory, List<ItemList>>();
		private Dictionary<int, List<ItemList>> _classIndexedItems = new Dictionary<int, List<ItemList>>();

		public MarketSearchResult EmptySearchResult { get; } = new MarketSearchResult();
		public void Load()
		{
			var items = WebServer.Instance.Database.LoadMarketItems();
			foreach (var item in items)
			{
				if (!this._categoryIndexedItems.ContainsKey(item.Data.Category))
					this._categoryIndexedItems.Add(item.Data.Category, new List<ItemList>());
				this._categoryIndexedItems[item.Data.Category].Add(item);

				if (!this._characterIndexedItems.ContainsKey(item.SellerId))
					this._characterIndexedItems.Add(item.SellerId, new List<ItemList>());
				this._characterIndexedItems[item.SellerId].Add(item);


				if (!this._classIndexedItems.ContainsKey(item.ItemType))
					this._classIndexedItems.Add(item.ItemType, new List<ItemList>());
				this._classIndexedItems[item.ItemType].Add(item);

				this._marketIndexedItems.Add(item.MarketGuid, item);
			}
			Log.Info("Loaded {0} market items from database.", items.Count);
		}

		/// <summary>
		/// Gets the minimum price for an item id, if it 
		/// doesn't exist the minimum price is 0.
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public long GetMarketItemMinPrice(int itemId)
		{
			var minPrice = 0L;
			lock (_syncLock)
			{
				if (this._classIndexedItems.ContainsKey(itemId))
					minPrice = this._classIndexedItems[itemId].Min(a => a.SellPrice);
			}
			return minPrice;
		}

		public MarketSearchResult GetMarketItems(long characterId)
		{
			lock (_syncLock)
			{
				if (this._characterIndexedItems.ContainsKey(characterId))
				{
					return new MarketSearchResult(this._characterIndexedItems[characterId].Where(item => !item.IsSold && !item.IsCancelled && !item.IsExpired).ToList());
				}
			}
			return this.EmptySearchResult;
		}

		public MarketSearchResult GetMarketItems(int page, int perPage, MarketSearch data)
		{
			var startIndex = (page - 1) * perPage;
			lock (_syncLock)
			{
				if (!string.IsNullOrEmpty(data.Category) && Enum.TryParse(data.Category, out InventoryCategory category) && this._categoryIndexedItems.ContainsKey(category))
				{
					var items = data.PriceOrder == 0 ?
						this._categoryIndexedItems[category].OrderBy(a => a.SellPrice).ToList() :
						this._categoryIndexedItems[category].OrderByDescending(a => a.SellPrice).ToList();
					var count = 0;
					if (items.Count > perPage)
						count = perPage % items.Count != 0 ? perPage % items.Count : perPage;
					else
						count = items.Count;
					return new MarketSearchResult(items.Where(item => !item.IsSold && !item.IsCancelled && !item.IsExpired).ToList().GetRange(startIndex, count));
				}
			}
			return this.EmptySearchResult;
		}
	}
}
