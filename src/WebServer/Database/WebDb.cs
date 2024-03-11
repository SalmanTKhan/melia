using System;
using System.Collections.Generic;
using MySqlConnector;
using Melia.Shared.Database;
using Melia.Shared.Game.Const;
using Melia.Shared.Game.Const.Web;
using Yggdrasil.Logging;

namespace Melia.Web.Database
{
	public partial class WebDb : MeliaDb
	{
		/// <summary>
		/// Check if we have a valid session key and
		/// return a character associated with it.
		/// </summary>
		/// <param name="sessionKey"></param>
		/// <param name="character"></param>
		/// <returns></returns>
		public bool CheckSessionKeyExists(string sessionKey, out Character character)
		{
			character = default;
			if (string.IsNullOrEmpty(sessionKey))
				return false;

			try
			{
				using (var conn = this.GetConnection())
				using (var cmd = new MySqlCommand("SELECT * FROM `characters` WHERE `sessionKey` = @sessionKey", conn))
				{
					cmd.AddParameter("@sessionKey", sessionKey);

					using (var reader = cmd.ExecuteReader())
					{
						if (!reader.Read())
							return false;
						character = new Character(reader.GetInt64("characterId"), reader.GetInt64("accountId"));
					}
				}
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
			return character != null;
		}

		/// <summary>
		/// Get Market Items for a specific character
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		public MarketSearchResult GetMarketItems(Character character)
		{
			var result = new MarketSearchResult();
			if (character == null)
				return result;
			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT * FROM `market_items` WHERE `characterId` = @characterId", conn))
			{
				cmd.AddParameter("@characterId", character.Id);

				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
						return result;
					if (reader.GetInt64("price") != -1)
					{
						var item = new ItemList(reader.GetInt32("itemId"));
						item.ItemGuid = reader.GetInt64("itemUniqueId");
						item.MarketGuid = reader.GetInt64("marketItemUniqueId");
						item.EndTime = reader.GetDateTimeSafe("dateExpired");
						item.SellPrice = reader.GetInt32("price");
						item.ItemType = reader.GetInt32("itemId");
						item.Count = reader.GetInt32("amount");
						item.Status = (MarketItemStatus)reader.GetByte("status");
						item.IsMine = true;
						item.IsPrivate = true;
						if (!item.IsExpired && !item.IsCancelled)
							result.ItemList.Add(item);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Get Market Items (Paged)
		/// </summary>
		/// <param name="page"></param>
		/// <param name="perPage"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public MarketSearchResult GetMarketItems(int page, int perPage, MarketSearch data)
		{
			var result = new MarketSearchResult();
			if (data == null)
				return result;
			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand($"SELECT * FROM `market_items` ORDER BY `price` LIMIT {(page - 1) * perPage}, {perPage}", conn))
			{
				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
						return result;
					var item = new ItemList(reader.GetInt32("itemId"));
					item.ItemGuid = reader.GetInt64("itemUniqueId");
					item.MarketGuid = reader.GetInt64("marketItemUniqueId");
					item.EndTime = reader.GetDateTimeSafe("dateExpired");
					item.SellPrice = reader.GetInt32("price");
					item.ItemType = reader.GetInt32("itemId");
					item.Count = reader.GetInt32("amount");
					item.Status = (MarketItemStatus)reader.GetByte("status");
					item.IsMine = true;
					item.IsPrivate = true;
					if (!item.IsExpired && !item.IsCancelled)
						result.ItemList.Add(item);
				}
			}
			return result;
		}

		/// <summary>
		/// Get Market Items for a specific character
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public long GetMarketItemMinPrice(int itemId)
		{
			var minPrice = 0L;
			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT `price` FROM `market_items` WHERE `itemId` = @itemId ORDER BY `price` LIMIT 1", conn))
			{
				cmd.AddParameter("@itemId", itemId);

				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
						return minPrice;
					minPrice = reader.GetInt64("price");
				}
			}
			return Math.Max(0, minPrice);
		}

		public List<ItemList> LoadMarketItems()
		{
			var result = new List<ItemList>();
			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT `market_items`.*, `items`.`itemId`, `items`.`amount` FROM `market_items` INNER JOIN `items` WHERE `market_items`.`itemUniqueId` = `items`.`itemUniqueId`", conn))
			{
				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
						return result;
					var item = new ItemList(reader.GetInt32("itemId"));
					item.ItemGuid = reader.GetInt64("itemUniqueId");
					item.MarketGuid = reader.GetInt64("marketItemUniqueId");
					item.EndTime = reader.GetDateTimeSafe("dateExpired");
					item.SellPrice = reader.GetInt32("price");
					item.ItemType = reader.GetInt32("itemId");
					item.Count = reader.GetInt32("amount");
					item.Status = (MarketItemStatus)reader.GetByte("status");
					item.SellerId = reader.GetInt64("sellerId");
					item.BuyerId = reader.GetInt64("buyerId");
					item.IsMine = false;
					item.IsPrivate = true;
					result.Add(item);
				}
			}
			return result;
		}

		public GuildInfo GetGuild(long guildId)
		{
			GuildInfo result = null;
			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT * FROM `guild` WHERE `guildId` = @guildId", conn))
			{
				cmd.AddParameter("@guildId", guildId);

				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
						return result;
					result = new GuildInfo();
					result.Id = guildId.ToString();
				}
			}
			return result;
		}

		public GuildMemberInfoList GetGuildMembers(long guildId)
		{
			var result = new GuildMemberInfoList();

			return result;
		}

		/// <summary>
		/// Returns all guilds
		/// </summary>
		/// <returns></returns>
		public List<GuildInfo> LoadGuilds()
		{
			var result = new List<GuildInfo>();

			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT * FROM `guild`", conn))
			{
				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
						return result;
					var guild = new GuildInfo();
					guild.Id = reader.GetInt64("guildId").ToString();

					result.Add(guild);
				}
			}

			return result;
		}
	}
}
