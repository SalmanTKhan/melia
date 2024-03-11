using System.IO;
using System.Text;
using System;
using Melia.Shared.Data.Database;
using Melia.Shared.Network;
using Melia.Zone.Database;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Houses;
using Yggdrasil.Network.TCP;
using System.Security.Cryptography;
using Melia.Shared.Database;

namespace Melia.Zone.Network
{
	/// <summary>
	/// A connection from the client to the zone server.
	/// </summary>
	public interface IZoneConnection : IConnection
	{
		/// <summary>
		/// Gets or sets whether the player is ready to receive packets.
		/// </summary>
		bool GameReady { get; set; }

		/// <summary>
		/// Gets or sets the account associated with the connection.
		/// </summary>
		Account Account { get; set; }

		/// <summary>
		/// Gets or sets a reference to the currently controlled character.
		/// </summary>
		Character SelectedCharacter { get; set; }

		/// <summary>
		/// Gets or sets the current dialog.
		/// </summary>
		Dialog CurrentDialog { get; set; }

		/// <summary>
		/// Gets or sets the current party.
		/// </summary>
		Party Party { get; set; }

		/// <summary>
		/// Gets or sets the current guild.
		/// </summary>
		Guild Guild { get; set; }

		/// <summary>
		/// Gets or sets the currently shop browsed.
		/// </summary>
		ShopData ActiveShop { get; set; }

		/// <summary>
		/// Gets or sets the currently shop opened.
		/// </summary>
		ShopData ShopCreated { get; set; }

		/// <summary>
		/// Gets or sets the current house.
		/// </summary>
		PersonalHouse ActiveHouse { get; set; }

		/// <summary>
		/// Gets or sets the last heartbeat.
		/// </summary>
		DateTime LastHeartBeat { get; set; }

		/// <summary>
		/// Generate a session key.
		/// </summary>
		/// <returns></returns>
		string GenerateSessionKey();
	}

	public class DummyConnection : IZoneConnection
	{
		public bool GameReady { get; set; } = true;
		public Account Account { get; set; }
		public Character SelectedCharacter { get; set; }
		public Dialog CurrentDialog { get; set; }
		public Party Party { get; set; }
		public Guild Guild { get; set; }
		public ShopData ActiveShop { get; set; }
		public ShopData ShopCreated { get; set; }
		public PersonalHouse ActiveHouse { get; set; }
		public DateTime LastHeartBeat { get; set; }
		public bool LoggedIn { get; set; }
		public string SessionKey { get; set; }

		public void Close()
		{
		}

		public void Close(int milliseconds)
		{
		}

		public string GenerateSessionKey()
		{
			return "";
		}

		public void Send(Packet packet)
		{
		}
	}

	/// <summary>
	/// A connection from the client to the zone server.
	/// </summary>
	public class ZoneConnection : Connection, IZoneConnection
	{
		/// <summary>
		/// Gets or sets whether the player is ready to receive packets.
		/// </summary>
		public bool GameReady { get; set; }
		/// <summary>
		/// Gets or sets the account associated with the connection.
		/// </summary>
		public Account Account { get; set; }

		/// <summary>
		/// Gets or sets a reference to the currently controlled character.
		/// </summary>
		public Character SelectedCharacter { get; set; }

		/// <summary>
		/// Gets or sets the current dialog.
		/// </summary>
		public Dialog CurrentDialog { get; set; }

		/// <summary>
		/// Gets or sets the current party.
		/// </summary>
		public Party Party { get; set; }

		/// <summary>
		/// Gets or sets the current guild.
		/// </summary>
		public Guild Guild { get; set; }

		/// <summary>
		/// Gets or sets the currently shop browsed.
		/// </summary>
		public ShopData ActiveShop { get; set; }

		/// <summary>
		/// Gets or sets the currently shop opened.
		/// </summary>
		public ShopData ShopCreated { get; set; }

		/// <summary>
		/// Gets or sets the current house.
		/// </summary>
		public PersonalHouse ActiveHouse { get; set; }

		/// <summary>
		/// Gets or sets the last heartbeat.
		/// </summary>
		public DateTime LastHeartBeat { get; set; }

		/// <summary>
		/// Handles the given packet for this connection.
		/// </summary>
		/// <param name="packet"></param>
		protected override void OnPacketReceived(Packet packet)
		{
			ZoneServer.Instance.PacketHandler.Handle(this, packet);
		}

		/// <summary>
		/// Called when the connection was closed.
		/// </summary>
		/// <param name="type"></param>
		protected override void OnClosed(ConnectionCloseType type)
		{
			base.OnClosed(type);

			var account = this.Account;
			var character = this.SelectedCharacter;
			var justSaved = character?.SavedForWarp ?? false;

			character?.Tracks?.Cancel();

			if (!justSaved)
			{
				if (account != null)
					ZoneServer.Instance.Database.SaveAccount(account);

				if (character != null)
					ZoneServer.Instance.Database.SaveCharacter(character);

				ZoneServer.Instance.Database.UpdateLoginState(this.Account.Id, 0, LoginState.LoggedOut);
			}

			foreach (var monster in character?.Summons.GetSummons())
				character?.Map.RemoveMonster(monster);

			character?.Map.RemoveCharacter(character);
		}

		/// <summary>
		/// Generates a session key
		/// </summary>
		/// <returns></returns>
		public string GenerateSessionKey()
		{
			var character = this.SelectedCharacter;
			var date = DateTime.Now;
			var result = default(byte[]);

			using (var stream = new MemoryStream())
			{
				using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
				{
					writer.Write(date.Ticks);
					writer.Write(character.Name);
				}

				stream.Position = 0;

				using (var hash = SHA256.Create())
				{
					result = hash.ComputeHash(stream);
				}
			}

			var text = new string[20];

			for (var i = 0; i < text.Length; i++)
			{
				text[i] = result[i].ToString("X2");
			}

			this.SessionKey = "*" + string.Concat(text);
			return this.SessionKey;
		}
	}
}
