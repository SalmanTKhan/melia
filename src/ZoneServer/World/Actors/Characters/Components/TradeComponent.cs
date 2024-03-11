using System.Collections.Generic;
using Melia.Shared.Game.Const;
using Melia.Zone.Network;
using Yggdrasil.Composition;
using Yggdrasil.Logging;

namespace Melia.Zone.World.Actors.Characters.Components
{
	/// <summary>
	/// A representation of a trade between two characters
	/// </summary>
	public class TradeComponent : IComponent
	{
		Character Trader1 { get; set; }
		Character Trader2 { get; set; }

		enum TradeState
		{
			NOT_STARTED,
			STARTED,
			CONFIRMED,
			FINAL_CONFIRMED,
		}

		Dictionary<long, int> Trader1Items { get; } = new Dictionary<long, int>();
		Dictionary<long, int> Trader2Items { get; } = new Dictionary<long, int>();

		private TradeState Trader1State { get; set; } = TradeState.NOT_STARTED;
		private TradeState Trader2State { get; set; } = TradeState.NOT_STARTED;

		public static void RequestTrade(Character sender, Character recipient)
		{
			var trade = new TradeComponent(sender, recipient);

			sender.Trade = trade;
			recipient.Trade = trade;

			Send.ZC_EXCHANGE_REQUEST_ACK(sender);
			Send.ZC_EXCHANGE_REQUEST_RECEIVED(recipient, sender.Name);
		}

		private TradeComponent(Character trader1, Character trader2)
		{
			this.Trader1 = trader1;
			this.Trader2 = trader2;
		}

		public void Offer(Character character, long worldId, int amount)
		{

			if (character.AccountDbId == this.Trader1.AccountDbId)
			{
				if (!this.Trader1.Inventory.TryGetItem(worldId, out var item))
				{
					Log.Warning("Trade Offer: User '{0}' tried to trade a non-existent item.", this.Trader1.Connection.Account.Name);
					return;
				}

				// Check amount
				if (item.Amount < amount)
				{
					Log.Warning("Trade Offer: User '{0}' tried to trade more of an item than they own.", this.Trader1.Connection.Account.Name);
					return;
				}

				// Do not allow trade of locked items.
				if (item.IsLocked)
				{
					Log.Warning("Trade Offer: User '{0}' tried to trade a locked item.", this.Trader1.Connection.Account.Name);
					return;
				}

				this.Trader1Items.Add(worldId, amount);
				Send.ZC_EXCHANGE_OFFER_ACK(this.Trader1, true, item, amount);
				Send.ZC_EXCHANGE_OFFER_ACK(this.Trader2, false, item, amount);
			}
			else if (character.AccountDbId == this.Trader2.AccountDbId)
			{
				if (!this.Trader2.Inventory.TryGetItem(worldId, out var item))
				{
					Log.Warning("Trade Offer: User '{0}' tried to trade a non-existent item.", this.Trader2.Connection.Account.Name);
					return;
				}
				// Check amount
				if (item.Amount < amount)
				{
					Log.Warning("Trade Offer: User '{0}' tried to trade more of an item than they own.", this.Trader2.Connection.Account.Name);
					return;
				}

				// Do not allow trade of locked items.
				if (item.IsLocked)
				{
					Log.Warning("Trade Offer: User '{0}' tried to trade a locked item.", this.Trader2.Connection.Account.Name);
					return;
				}

				this.Trader2Items.Add(worldId, amount);
				Send.ZC_EXCHANGE_OFFER_ACK(this.Trader2, true, item, amount);
				Send.ZC_EXCHANGE_OFFER_ACK(this.Trader1, false, item, amount);
			}
		}

		/// <summary>
		/// Check if offered items exist and have enough quantity to be traded
		/// before swapping items from inventory	
		/// </summary>
		public void Finalized()
		{

			foreach (var item in this.Trader1Items)
			{
				if (!this.Trader1.Inventory.TryGetItem(item.Key, out var tradedItem))
				{
					Log.Warning("Trade Finalized: User '{0}' tried to trade a non-existent item.", this.Trader1.Connection.Account.Name);
					return;
				}

				// Check amount
				if (tradedItem.Amount < item.Value)
				{
					Log.Warning("Trade Finalized: User '{0}' tried to trade more of an item than they own.", this.Trader1.Connection.Account.Name);
					return;
				}

				if (this.Trader1.Inventory.Remove(item.Key, item.Value, InventoryItemRemoveMsg.Given) == InventoryResult.Success)
					this.Trader2.Inventory.Add(tradedItem.Id, item.Value, InventoryAddType.New);
			}

			foreach (var item in this.Trader2Items)
			{
				if (!this.Trader2.Inventory.TryGetItem(item.Key, out var tradedItem))
				{
					Log.Warning("Trade Finalized: User '{0}' tried to trade a non-existent item.", this.Trader2.Connection.Account.Name);
					return;
				}

				// Check amount
				if (tradedItem.Amount < item.Value)
				{
					Log.Warning("Trade Finalized: User '{0}' tried to trade more of an item than they own.", this.Trader2.Connection.Account.Name);
					return;
				}

				if (this.Trader2.Inventory.Remove(item.Key, item.Value, InventoryItemRemoveMsg.Given) == InventoryResult.Success)
					this.Trader1.Inventory.Add(tradedItem.Id, item.Value, InventoryAddType.New);
			}
			Send.ZC_EXCHANGE_SUCCESS(this.Trader1);
			Send.ZC_EXCHANGE_SUCCESS(this.Trader2);
			this.CleanUp();
		}

		/// <summary>
		/// Remove trader/trade references
		/// </summary>
		private void CleanUp()
		{
			this.Trader1.Trade = null;
			this.Trader2.Trade = null;
			this.Trader1 = null;
			this.Trader2 = null;
		}

		/// <summary>
		/// Trade offer confirmation, before final trade confirmation
		/// </summary>
		/// <param name="character"></param>
		public void Confirm(Character character)
		{
			if (character.AccountDbId == this.Trader1.AccountDbId)
			{
				Trader1State = TradeState.CONFIRMED;
				Send.ZC_EXCHANGE_AGREE_ACK(this.Trader1, true);
				Send.ZC_EXCHANGE_AGREE_ACK(this.Trader2, false);
			}
			else if (character.AccountDbId == this.Trader2.AccountDbId)
			{
				Trader2State = TradeState.CONFIRMED;
				Send.ZC_EXCHANGE_AGREE_ACK(this.Trader2, true);
				Send.ZC_EXCHANGE_AGREE_ACK(this.Trader1, false);
			}
		}

		/// <summary>
		/// Trade Final Agreement, if both players agree finalized is called.
		/// </summary>
		/// <param name="character"></param>
		public void FinalConfirm(Character character)
		{
			if (character.AccountDbId == this.Trader1.AccountDbId)
			{
				Trader1State = TradeState.FINAL_CONFIRMED;
				Send.ZC_EXCHANGE_FINALAGREE_ACK(this.Trader1, true);
				Send.ZC_EXCHANGE_FINALAGREE_ACK(this.Trader2, false);
			}
			else if (character.AccountDbId == this.Trader2.AccountDbId)
			{
				Trader2State = TradeState.FINAL_CONFIRMED;
				Send.ZC_EXCHANGE_FINALAGREE_ACK(this.Trader2, true);
				Send.ZC_EXCHANGE_FINALAGREE_ACK(this.Trader1, false);
			}
			if (Trader1State == TradeState.FINAL_CONFIRMED && Trader2State == TradeState.FINAL_CONFIRMED)
				this.Finalized();
		}

		/// <summary>
		/// Start Trade
		/// </summary>
		public void Start()
		{
			Trader1State = TradeState.STARTED;
			Trader2State = TradeState.STARTED;
			Send.ZC_EXCHANGE_START(this.Trader1, this.Trader2.TeamName);
			Send.ZC_EXCHANGE_START(this.Trader2, this.Trader1.TeamName);
		}

		/// <summary>
		/// Cancel Trade
		/// </summary>
		public void Cancel()
		{
			Send.ZC_EXCHANGE_CANCEL_ACK(this.Trader1);
			Send.ZC_EXCHANGE_CANCEL_ACK(this.Trader2);
			this.CleanUp();
		}
	}
}
