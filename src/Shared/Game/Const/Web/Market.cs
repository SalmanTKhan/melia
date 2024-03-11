using System;
using System.Collections.Generic;
using Melia.Shared.Data.Database;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Melia.Shared.Game.Const.Web
{
	public class MarketSearch
	{
		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("find_text")]
		public string FindText { get; set; }

		[JsonProperty("price_order")]
		public int PriceOrder { get; set; }

		[JsonProperty("search_option")]
		public SearchOption SearchOption { get; set; }
	}

	public class SearchOption
	{
		[JsonProperty("CT_ItemGrade")]
		public string CTItemGrade { get; set; }
		[JsonProperty("CT_UseLv")]
		public string CTUseLv { get; set; }
		[JsonProperty("ADD_DEF")]
		public string ADDDEF { get; set; }
		[JsonProperty("Random_Item")]
		public string RandomItem { get; set; }
		[JsonProperty("Reinforce_2")]
		public string Reinforce2 { get; set; }

		[JsonProperty("STR")]
		public string STR { get; set; }

		[JsonProperty("Transcend")]
		public string Transcend { get; set; }
	}

	public class Property
	{
		[JsonProperty("iesID")]
		public object IesID { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }
	}

	public class EquipGem
	{
	}

	public class ItemList
	{
		public ItemList(int itemId)
		{
			this.ItemType = itemId;
		}
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("translated_name")]
		public List<string> TranslatedName { get; set; }

		[JsonProperty("properties")]
		public List<Property> Properties { get; set; }

		[JsonProperty("equip_gem")]
		public EquipGem EquipGem { get; set; }

		[JsonProperty("marketGuid")]
		public long MarketGuid { get; set; }

		[JsonProperty("itemGuid")]
		public long ItemGuid { get; set; }

		[JsonProperty("itemType")]
		public int ItemType { get; set; }

		[JsonProperty("sellPrice")]
		public int SellPrice { get; set; }

		[JsonProperty("count")]
		public int Count { get; set; }

		[JsonProperty("isPrivate")]
		public bool IsPrivate { get; set; }

		/// <summary>
		/// (Seen values 0 - Not premium or 2 - Premium)
		/// </summary>
		[JsonProperty("premiumState")]
		public int PremiumState { get; set; }

		[JsonProperty("is_mine")]
		public bool IsMine { get; set; }

		/// <summary>
		/// If set to null, on api call, the Market shows Waiting.
		/// </summary>
		[JsonProperty("end_time")]
		public DateTime EndTime { get; set; }

		public ItemData Data { get; set; }
		public bool IsExpired => DateTime.MinValue != this.EndTime && DateTime.Now > this.EndTime;
		public bool IsCancelled => this.Status.HasFlag(MarketItemStatus.Cancelled);
		public bool IsSold => this.Status.HasFlag(MarketItemStatus.Sold);
		public bool HasReceivedSilver => this.Status.HasFlag(MarketItemStatus.SilverReceived);
		public bool HasReceivedItem => this.Status.HasFlag(MarketItemStatus.ItemReceived);
		public DateTime RegTime { get; set; }
		public long SellerId { get; set; }
		public long BuyerId { get; set; }
		public MarketItemStatus Status { get; set; }

		public int GetItemId(long characterId)
		{
			if (this.SellerId == characterId && IsSold)
				return ItemId.Silver;
			return this.ItemType;
		}

		/// <summary>
		/// Used for packets
		/// </summary>
		public string GetMarketStatus(long characterId)
		{
			if (this.BuyerId == characterId)
				return "market_buy";
			else if (this.SellerId == characterId)
			{
				if (this.IsSold)
					return "market_sell";
				if (this.IsCancelled)
					return "market_cancel";
				if (this.IsExpired)
					return "market_expire";
			}
			return "market_unknown";
		}

		/// <summary>
		/// Loads item data from data files.
		/// </summary>
		public void LoadData(ItemDb itemDb)
		{
			if (this.ItemType == 0)
				throw new InvalidOperationException("Item id wasn't set before calling LoadData.");

			this.Data = itemDb.Find(this.ItemType);
			if (this.Data == null)
				throw new NullReferenceException("No item data found for '" + ItemType + "'.");
			this.Name = this.Data.Name;
		}
	}

	public class MarketSearchResult
	{
		public MarketSearchResult()
		{
			this.ItemList = new List<ItemList>();
		}
		public MarketSearchResult(List<ItemList> itemList)
		{
			this.ItemList = itemList;
			this.TotalCount = itemList.Count;
		}

		[JsonProperty("total_cnt")]
		public int TotalCount { get; set; } = 0;

		[JsonProperty("item_list")]
		public List<ItemList> ItemList { get; set; }
	}

	public class MarketSearchRecipe
	{
		[JsonProperty("find_recipe_list")]
		public string FindRecipeList { get; set; }
	}
}
