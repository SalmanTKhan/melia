using System.Collections.Generic;
using System.Linq;
using Melia.Shared.ObjectProperties;
using Melia.Zone.Network;

namespace Melia.Zone.World.Actors.Characters.Components
{
	/// <summary>
	/// Assister Cabinet.
	/// </summary>
	public class AssisterCabinet
	{
		/// <summary>
		/// Assister Collection
		/// </summary>
		private readonly IList<AssisterCard> _assisters = new List<AssisterCard>();

		public Character Character { get; set; }

		/// <summary>
		/// Assister Collection Count
		/// </summary>
		public int Count
		{
			get
			{
				lock (_assisters)
					return this._assisters.Count;
			}
		}

		public AssisterCabinet()
		{
		}

		/// <summary>
		/// Add to account's album
		/// </summary>
		/// <param name="assister"></param>
		public bool Add(string assister)
		{
			var card = new AssisterCard(-1, assister, this.Count);

			return this.Add(card);
		}

		/// <summary>
		/// Add to account's album
		/// </summary>
		/// <param name="card"></param>
		public bool Add(AssisterCard card, bool silently = false)
		{
			if (!this.Character.Connection.Account.IsAssistersEnabled)
				return false;

			if (card.DbId == -1)
				ZoneServer.Instance.Database.CreateAssister(this.Character.AccountDbId, ref card);

			lock (this._assisters)
				this._assisters.Add(card);

			if (!silently)
				Send.ZC_ANCIENT_CARD_ADD(this.Character, card);

			return true;
		}

		/// <summary>
		/// Combine cards
		/// </summary>
		/// <param name="cards"></param>
		public void Combine(params AssisterCard[] cards)
		{
			// TODO: Combine Cards?
		}

		public void Evolve(params AssisterCard[] cards)
		{
			// TODO: Evolve Cards?
		}


		/// <summary>
		/// Swap to card slot
		/// </summary>
		/// <param name="slot1"></param>
		/// <param name="slot2"></param>
		public void Swap(int slot1, int slot2)
		{
			lock (this._assisters)
			{
				var card1 = this._assisters[slot1];
				var card2 = this._assisters[slot2];

				if (card1 != null && card2 != null)
				{
					this._assisters[slot1].Slot = card2.Slot;
					this._assisters[slot2].Slot = card1.Slot;
				}
				Send.ZC_ANCIENT_CARD_UPDATE(this.Character, card1);
			}
		}

		public AssisterCard[] GetAssisters()
		{
			lock (_assisters)
				return _assisters.ToArray();
		}
	}

	/// <summary>
	/// Assister Card
	/// </summary>
	public class AssisterCard
	{
		/// <summary>
		/// Assister card's globally unique id.
		/// </summary>
		/// <remarks>
		/// This is different than the original item's object id.
		/// Looks like it's in the item id range
		/// (So might be an item subclass?)                                 
		/// </remarks>
		public long DbId { get; set; }
		public long ObjectId => this.DbId + ObjectIdRanges.Assisters;
		public string Name { get; set; }
		public int Slot { get; set; }
		public long Experience { get; set; } = 0;

		public AssisterCard(long id, string name, int slot)
		{
			this.DbId = id;
			this.Name = name;
			this.Slot = slot;
		}
	}
}
