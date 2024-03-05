using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Melia.Shared.Data.Database;
using Melia.Shared.Database;
using Melia.Shared.L10N;
using Melia.Shared.Network;
using Melia.Shared.Network.Helpers;
using Melia.Shared.Tos.Const;
using Melia.Shared.Tos.Const.Web;
using Melia.Shared.Tos.Properties;
using Melia.Shared.World;
using Melia.Zone.Events;
using Melia.Zone.Network.Helpers;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.Skills;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Items;
using Melia.Zone.World.Maps;
using Yggdrasil.Logging;

namespace Melia.Zone.Network
{
	public class PacketHandler : PacketHandler<IZoneConnection>
	{
		/// <summary>
		/// Sent wrongfully if a channel wasn't available and the client
		/// tries to log in again afterwards.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_LOGIN)]
		public void CB_LOGIN(IZoneConnection conn, Packet packet)
		{
			// Close connection, which should then make the client try to
			// connect to the barracks server instead.
			conn.Close();
		}

		/// <summary>
		/// Sent after connecting to channel.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CONNECT)]
		public void CZ_CONNECT(IZoneConnection conn, Packet packet)
		{
			var bin1 = packet.GetBin(1024);
			var sessionKey = packet.GetString(64);

			// When using passprt login, this is the account id as string,
			// and it's 18 (?) bytes long.	
			var accountName = packet.GetString(56);

			var mac = packet.GetString(48);
			var socialId = packet.GetLong();
			var l1 = packet.GetLong();
			var accountId = packet.GetLong();
			var characterId = packet.GetLong();
			var bin2 = packet.GetBin(12);
			var bin3 = packet.GetBin(10);
			var b1 = packet.GetByte(); // [i373230 (2023-05-10)] Might've been added before

			// TODO: Check session key or something.

			// Get account
			conn.Account = ZoneServer.Instance.Database.GetAccount(accountName);
			if (conn.Account == null)
			{
				Log.Warning("Stopped attempt to login with invalid account '{0}'. Closing connection.", accountName);
				conn.Close();
				return;
			}

			// Get character
			var character = ZoneServer.Instance.Database.GetCharacter(conn.Account.Id, characterId);
			if (character == null)
			{
				// Don't punish, could be used to auto-ban other people.
				Log.Warning("User '{0}' tried to use a non-existing character, '{1}'. Closing connection.", accountName, characterId);
				conn.Close();
				return;
			}

			// Get map
			var map = ZoneServer.Instance.World.GetMap(character.MapId);
			if (map == null)
			{
				Log.Warning("CZ_GAME_READY: User '{0}' logged on with invalid map '{1}'.", conn.Account.Name, character.MapId);
				conn.Close();
				return;
			}

			character.Connection = conn;
			conn.SelectedCharacter = character;
			conn.Party = ZoneServer.Instance.World.GetParty(character.PartyId);
			conn.Guild = ZoneServer.Instance.World.GetGuild(character.GuildId);
			conn.Account.AssisterCabinet.Character = character;

			ZoneServer.Instance.ServerEvents.OnPlayerLoggedIn(character);

			map.AddCharacter(character);
			conn.LoggedIn = true;
			conn.LastHeartBeat = DateTime.Now;
			conn.GenerateSessionKey();

			ZoneServer.Instance.Database.SaveSessionKey(character.DbId, conn.SessionKey);
			ZoneServer.Instance.Database.UpdateLoginState(conn.Account.Id, character.DbId, LoginState.Zone);
			ZoneServer.Instance.Database.UpdateLastLogin(conn.Account.Id);

			Send.ZC_CONNECT_OK(conn, character);
		}

		/// <summary>
		/// Sent mid-loading, after the player entered the world.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_GAME_READY)]
		public void CZ_GAME_READY(IZoneConnection conn, Packet packet)
		{
			var serverId = packet.GetShort();

			var character = conn.SelectedCharacter;
			var gameReadyArgs = new PlayerGameReadyEventArgs(character);

			ZoneServer.Instance.ServerEvents.OnPlayerGameReady(gameReadyArgs);
			if (gameReadyArgs.CancelHandling)
				return;

			conn.GameReady = true;

			Send.ZC_STANCE_CHANGE(character);
			Send.ZC_NORMAL.AdventureBook(conn);
			Send.ZC_SET_CHATBALLOON_SKIN(character);

			Send.ZC_IES_MODIFY_LIST(conn);
			Send.ZC_ITEM_INVENTORY_DIVISION_LIST(character);
			Send.ZC_SESSION_OBJECTS(character);
			Send.ZC_OPTION_LIST(conn);
			Send.ZC_SKILLMAP_LIST(character);
			//Send.ZC_ACHIEVE_POINT_LIST(character);
			Send.ZC_SPLIT_ACHIEVE_POINT_LIST(character);
			Send.ZC_SPLIT_ACHIEVE_SET(character);
			Send.ZC_CHAT_MACRO_LIST(character);
			Send.ZC_MAP_REVEAL_LIST(conn);
			Send.ZC_NPC_STATE_LIST(character);
			Send.ZC_HELP_LIST(character);
			Send.ZC_MYPAGE_MAP(conn);
			Send.ZC_GUESTPAGE_MAP(conn);
			Send.ZC_NORMAL.UpdateSkillUI(character);
			// Official server sends Skintone Object Property around here
			Send.ZC_ITEM_EQUIP_LIST(character);
			Send.ZC_SKILL_LIST(character);
			Send.ZC_ABILITY_LIST(character);
			Send.ZC_COOLDOWN_LIST(character, null);
			Send.ZC_NORMAL.ItemCollectionList(character);
			Send.ZC_NORMAL.Unknown_E4(character);
			Send.ZC_NORMAL.Unknown_134(character);
			Send.ZC_OBJECT_PROPERTY(conn, character);
			character.SendPCEtcProperties(); // Quick Hack to send required packets
			Send.ZC_START_GAME(conn);
			Send.ZC_UPDATE_ALL_STATUS(character, 0);
			Send.ZC_SET_WEBSERVICE_URL(conn);
			Send.ZC_MOVE_SPEED(character);
			Send.ZC_STAMINA(character, character.Stamina);
			Send.ZC_UPDATE_SP(character, character.Sp, false);
			Send.ZC_RES_DAMAGEFONT_SKIN(conn, character);
			Send.ZC_RES_DAMAGEEFFECT_SKIN(conn, character);
			Send.ZC_LOGIN_TIME(conn, DateTime.Now);
			Send.ZC_MYPC_ENTER(character);

			if (conn.Account.IsAssistersEnabled)
			{
				// TODO: Check if Card Album is unlocked
				Send.ZC_ANCIENT_CARD_RESET(conn);
				Send.ZC_ANCIENT_CARD_LOAD(conn);
			}

			if (conn.Party != null)
			{
				Send.ZC_PARTY_INFO(character, conn.Party);
				Send.ZC_PARTY_LIST(conn.Party);
				conn.Party.UpdateMember(character);
			}
			if (conn.Guild != null)
			{
				Send.ZC_PARTY_INFO(character, conn.Guild);
				Send.ZC_PARTY_LIST(conn.Guild);
				conn.Guild.UpdateMember(character);
			}

			Send.ZC_NORMAL.UsedMedalTotal(conn, conn.Account.Medals);
			Send.ZC_CASTING_SPEED(character);
			Send.ZC_QUICK_SLOT_LIST(character);
			Send.ZC_NORMAL.JobCount(character);
			Send.ZC_UPDATED_PCAPPEARANCE(character);
			Send.ZC_NORMAL.HeadgearVisibilityUpdate(character);
			Send.ZC_ADDITIONAL_SKILL_POINT(character);
			Send.ZC_SET_DAYLIGHT_INFO(character);
			//Send.ZC_DAYLIGHT_FIXED(character);
			Send.ZC_SEND_APPLY_HUD_SKIN_MYSELF(conn, character);

			Send.ZC_NORMAL.AccountProperties(character);

			Send.ZC_NORMAL.SetSessionKey(conn);
			Send.ZC_SEND_CASH_VALUE(conn);
			Send.ZC_SEND_PREMIUM_STATE(conn);

			// The ability points are longer read from the properties for
			// whatever reason. We have to use the "custom commander info"
			// now. Yay.
			Send.ZC_CUSTOM_COMMANDER_INFO(character, CommanderInfoType.AbilityPoints, character.Properties.AbilityPoints);

			// It's currently unknown what exactly ZC_UPDATE_SKL_SPDRATE_LIST
			// does, but the data is necessary for the client to display the
			// overheat bubbles on the skill icons, so we'll send the skills
			// that have an overheat count.
			var skillUpdateList = character.Skills.GetList(a => a.Data.OverheatCount > 0);
			Send.ZC_UPDATE_SKL_SPDRATE_LIST(character, skillUpdateList);
			Send.ZC_NORMAL.AccountProperties(character);

			if (character.HasCompanions)
			{
				foreach (var companion in character.Companions.GetList())
				{
					Send.ZC_NORMAL.Pet_AssociateHandleWorldId(character, companion);
					Send.ZC_OBJECT_PROPERTY(conn, companion);
					if (companion.IsActivated)
						companion.SetCompanionState(companion.IsActivated);
				}
				Send.ZC_NORMAL.PetInfo(character);
			}

			Send.ZC_ANCIENT_CARD_RESET(conn);

			// Send updates for the buffs loaded from db, so the client
			// will display the restored buffs
			foreach (var buff in character.Buffs.GetList())
				Send.ZC_BUFF_UPDATE(character, buff);

			// Send updates for the cooldowns loaded from db, so the client
			// will display the restored cooldowns
			Send.ZC_COOLDOWN_LIST(character, character.Components.Get<CooldownComponent>().GetAll());

			character.AddonMessage(AddonMessage.ENABLE_PCBANG_SHOP, null, 1);
			Send.ZC_PCBANG_SHOP_RENTAL(conn);

			character.AdventureBook.UpdateClient();

			character.OpenEyes();

			ZoneServer.Instance.ServerEvents.OnPlayerReady(character);
		}

		/// <summary>
		/// Response to ZC_MOVE_ZONE that notifies us that the client is
		/// ready to move to the next zone.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_MOVE_ZONE_OK)]
		public void CZ_MOVE_ZONE_OK(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			character.FinalizeWarp();
		}

		/// <summary>
		/// Sent at the end of the loading screen.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CAMPINFO)]
		public void CZ_CAMPINFO(IZoneConnection conn, Packet packet)
		{
			var accountId = packet.GetLong();

			//Send.ZC_CAMPINFO(conn);
		}

		/// <summary>
		/// Sent when chatting publically.
		/// </summary>
		/// <remarks>
		/// Sent together with CZ_CHAT_LOG.
		/// </remarks>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CHAT)]
		public void CZ_CHAT(IZoneConnection conn, Packet packet)
		{
			var len = packet.GetShort(); // length of payload, without garbage
			var msg = packet.GetString();

			var character = conn.SelectedCharacter;

			// Try to execute message as a chat command, don't send if it
			// was handled as one
			if (ZoneServer.Instance.ChatCommands.TryExecute(character, msg))
				return;

			Send.ZC_CHAT(character, msg);
			ZoneServer.Instance.ServerEvents.OnPlayerChat(character, msg);
		}

		/// <summary>
		/// Sent when chatting.
		/// </summary>
		/// <remarks>
		/// Sent together with CZ_CHAT.
		/// When whispering only this one is sent?
		/// </remarks>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CHAT_LOG)]
		public void CZ_CHAT_LOG(IZoneConnection conn, Packet packet)
		{
			var len = packet.GetShort();
			var msg = packet.GetString();

			// ...
		}

		/// <summary>
		/// Sent when clicking [Select Character].
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_MOVE_BARRACK)]
		public void CZ_MOVE_BARRACK(IZoneConnection conn, Packet packet)
		{
			var unkByte = packet.GetByte();

			Log.Info("User '{0}' is leaving for character selection.", conn.Account.Name);

			Send.ZC_SAVE_INFO(conn);
			Send.ZC_MOVE_BARRACK(conn);
		}

		/// <summary>
		/// Sent when clicking [Logout].
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_LOGOUT)]
		public void CZ_LOGOUT(IZoneConnection conn, Packet packet)
		{
			var unkByte = packet.GetByte();

			if (conn.LoggedIn)
			{
				Log.Info("User '{0}' is logging out.", conn.Account.Name);

				Send.ZC_SAVE_INFO(conn);
				Send.ZC_LOGOUT_OK(conn);
			}
		}

		/// <summary>
		/// Sent when character jumps.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_JUMP)]
		public void CZ_JUMP(IZoneConnection conn, Packet packet)
		{
			var unkByte1 = packet.GetByte();
			var position = packet.GetPosition();
			var direction = packet.GetDirection();
			var unkFloat = packet.GetFloat(); // timestamp?
			var bin = packet.GetBin(13);
			var unkByte2 = packet.GetByte();

			var character = conn.SelectedCharacter;

			if (character.IsDead)
				return;

			character.Movement.NotifyJump(position, direction, unkFloat, unkByte2);
		}

		/// <summary>
		/// Sent repeatedly while moving.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_KEYBOARD_MOVE)]
		public void CZ_KEYBOARD_MOVE(IZoneConnection conn, Packet packet)
		{
			//var unkByte = packet.GetByte(); // [i354444] Removed
			var position = packet.GetPosition();
			var direction = packet.GetDirection();
			var f1 = packet.GetFloat(); // timestamp?
			var bin1 = packet.GetBin(31);

			var character = conn.SelectedCharacter;

			if (character.IsDead)
			{
				//Log.Warning("CZ_KEYBOARD_MOVE: User '{0}' tried to move while dead.", conn.Account.Name);
				return;
			}

			character.Movement.NotifyMove(position, direction, f1);
			character.Components.Get<TimeActionComponent>().End(TimeActionResult.CancelledByMove);
		}

		/// <summary>
		/// Sent when stopping movement.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_MOVE_STOP)]
		public void CZ_MOVE_STOP(IZoneConnection conn, Packet packet)
		{
			var unkByte = packet.GetByte();
			var position = packet.GetPosition();
			var direction = packet.GetDirection();
			var unkFloat = packet.GetFloat(); // timestamp?

			var character = conn.SelectedCharacter;

			// TODO: Sanity checks.

			character.Movement.NotifyStopMove(position, direction);
		}

		/// <summary>
		/// Sent when the character is in the air (jumping/falling).
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ON_AIR)]
		public void CZ_ON_AIR(IZoneConnection conn, Packet packet)
		{
			// TODO: Sanity checks.

			conn.SelectedCharacter.Movement.NotifyGrounded(false);
		}

		/// <summary>
		/// Sent when landing on the ground, after being in the air.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ON_GROUND)]
		public void CZ_ON_GROUND(IZoneConnection conn, Packet packet)
		{
			// TODO: Sanity checks.

			conn.SelectedCharacter.Movement.NotifyGrounded(true);
		}

		/// <summary>
		/// Sent repeatedly during jumping.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_MOVEMENT_INFO)]
		public void CZ_MOVEMENT_INFO(IZoneConnection conn, Packet packet)
		{
			var unkByte = packet.GetByte();
			var position = packet.GetPosition();

			// TODO: Sanity checks.
			// TODO: Is there a broadcast for this?

			conn.SelectedCharacter.SetPosition(position);
		}

		/// <summary>
		/// Sent when trying to sit down.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REST_SIT)]
		public void CZ_REST_SIT(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			character.ToggleSitting();
		}

		/// <summary>
		/// Sent when equipping an item.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ITEM_EQUIP)]
		public void CZ_ITEM_EQUIP(IZoneConnection conn, Packet packet)
		{
			var worldId = packet.GetLong();
			var slot = (EquipSlot)packet.GetByte();

			var character = conn.SelectedCharacter;
			var result = character.Inventory.Equip(slot, worldId);

			if (result == InventoryResult.ItemNotFound)
				Log.Warning("CZ_ITEM_EQUIP: User '{0}' tried to equip item he doesn't have ({1}).", conn.Account.Name, worldId);
			else if (result == InventoryResult.InvalidSlot)
				Log.Warning("CZ_ITEM_EQUIP: User '{0}' tried to equip item in invalid slot ({1}).", conn.Account.Name, worldId);
		}

		/// <summary>
		/// Sent when uequipping an item.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ITEM_UNEQUIP)]
		public void CZ_ITEM_UNEQUIP(IZoneConnection conn, Packet packet)
		{
			var slot = (EquipSlot)packet.GetByte();

			var character = conn.SelectedCharacter;
			var result = character.Inventory.Unequip(slot);

			if (result == InventoryResult.ItemNotFound)
				Log.Warning("CZ_ITEM_UNEQUIP: User '{0}' tried to unequip non-existent item from {1}.", conn.Account.Name, slot);
			else if (result == InventoryResult.InvalidSlot)
				Log.Warning("CZ_ITEM_UNEQUIP: User '{0}' tried to unequip item from invalid slot ({1}).", conn.Account.Name, slot);
		}

		/// <summary>
		/// Request to unequip all equipped items.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_UNEQUIP_ITEM_ALL)]
		public void CZ_UNEQUIP_ITEM_ALL(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			character.Inventory.UnequipAll();
		}

		/// <summary>
		/// Sent when removing an item from the inventory.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ITEM_DELETE)]
		public void CZ_ITEM_DELETE(IZoneConnection conn, Packet packet)
		{
			var worldId = packet.GetLong();
			var amount = packet.GetInt();

			var character = conn.SelectedCharacter;
			var item = character.Inventory.GetItem(worldId);

			if (item == null)
			{
				Log.Warning("CZ_ITEM_DELETE: User '{0}' tried to delete non-existent item.", conn.Account.Name);
				return;
			}
			else if (item.IsLocked)
			{
				// The client should stop the player from attempting to do this.
				Log.Warning("CZ_ITEM_DELETE: User '{0}' tried to delete locked item.", conn.Account.Name);
				return;
			}

			var fullStack = (amount >= item.Amount);

			var result = character.Inventory.Remove(item, amount, InventoryItemRemoveMsg.Destroyed);
			if (result != InventoryResult.Success)
			{
				Log.Warning("CZ_ITEM_DELETE: Removing an item for '{0}' failed despite checks.", conn.Account.Name);
				return;
			}

			// Drop item
			if (ZoneServer.Instance.Conf.World.Littering)
			{
				var dropDir = character.Direction;

				if (ZoneServer.Instance.Conf.World.TargetedLittering && character.Variables.Temp.Has("MouseX"))
				{
					var mouseX = character.Variables.Temp.Get("MouseX", 0f);
					var mouseY = character.Variables.Temp.Get("MouseY", 0f);
					var centerX = character.Variables.Temp.Get("ScreenWidth", 0f) / 2;
					var centerY = character.Variables.Temp.Get("ScreenHeight", 0f) / 2;

					dropDir = new Direction(mouseY - centerY, mouseX - centerX).AddDegreeAngle(-45);
				}

				// If the entire stack was discarded, we can simply drop
				// the item. If only a part of the stack was discarded,
				// we need to create a new stack, with the selected amount.
				// TODO: We might need to copy values and properties from
				//   the original stack to the new stack.
				var dropItem = (fullStack ? item : new Item(item.Id, amount));
				dropItem.SetRePickUpProtection(character);
				dropItem.Drop(character.Map, character.Position, dropDir, 30);
			}
		}

		/// <summary>
		/// Request to enchant an item.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_PREMIUM_ENCHANTCHIP)]
		public void CZ_PREMIUM_ENCHANTCHIP(IZoneConnection conn, Packet packet)
		{
			var itemId = packet.GetLong();
			var enchantId = packet.GetLong();

			var character = conn.SelectedCharacter;

			if (character.Inventory.TryGetItem(itemId, out var item))
			{
				Log.Warning("CZ_PREMIUM_ENCHANTCHIP: User '{0}' tried to enchant a non-existent item.", conn.Account.Name);
				return;
			}
			if (character.Inventory.TryGetItem(enchantId, out var enchantItem))
			{
				Log.Warning("CZ_PREMIUM_ENCHANTCHIP: User '{0}' tried to enchant with a non-existent item.", conn.Account.Name);
				return;
			}

			// TODO: Validate Enchant Item as "CLIENT_ENCHANTCHIP".
			// TODO: Validate Item as correct type to enchant.

			// Item Lock
			Send.ZC_EXEC_CLIENT_SCP(conn, string.Format(ClientScripts.REINFORCE_131014_ITEM_LOCK, itemId, "YES"));
			// Do something to generate random options
			//item.GenerateRandomHatOptions();
			Send.ZC_OBJECT_PROPERTY(character.Connection, item);
			// Reset Item Lock
			Send.ZC_EXEC_CLIENT_SCP(conn, string.Format(ClientScripts.REINFORCE_131014_ITEM_LOCK, "None", "YES"));
			var succeeded = true;
			if (succeeded)
				Send.ZC_EXEC_CLIENT_SCP(conn, string.Format(ClientScripts.HAIRENCHANT_SUCCESS, itemId, enchantItem.DbId));
		}

		/// <summary>
		/// Request to save a chat macro.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CHAT_MACRO)]
		public void CZ_CHAT_MACRO(IZoneConnection conn, Packet packet)
		{
			var index = packet.GetInt();
			var message = packet.GetString(128);
			var pose = packet.GetInt();

			if ((index > 10) || (index < 0))
			{
				Log.Warning("CZ_CHAT_MACRO: User '{0}' tried to save a chat macro for an invalid index ({1}).", conn.Account.Name, index);
				return;
			}

			// The client sends the entire list of chat macros each as a single packet.
			// Empty macros are also sent, but there's no reason to persist them.
			if (string.IsNullOrEmpty(message) && pose == 0)
				return;

			var macro = new ChatMacro(index, message, pose);
			conn.Account.AddChatMacro(macro);
		}

		/// <summary>
		/// Sent when dragging an item on top of another one in the same
		/// category to switch their positions.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SWAP_ETC_INV_CHANGE_INDEX)]
		public void CZ_SWAP_ETC_INV_CHANGE_INDEX(IZoneConnection conn, Packet packet)
		{
			var invType = (InventoryType)packet.GetByte();
			var worldId1 = packet.GetLong();
			var index1 = packet.GetInt();
			var worldId2 = packet.GetLong();
			var index2 = packet.GetInt();

			var character = conn.SelectedCharacter;
			var result = character.Inventory.Swap(worldId1, worldId2);

			if (result == InventoryResult.ItemNotFound)
				Log.Warning("CZ_SWAP_ETC_INV_CHANGE_INDEX: User '{0}' tried to swap non-existent item(s) ({1}, {2}).", conn.Account.Name, worldId1, worldId2);
			else if (result == InventoryResult.InvalidOperation)
				Log.Warning("CZ_SWAP_ETC_INV_CHANGE_INDEX: User '{0}' tried to swap two items from different categories ({1}, {2}).", conn.Account.Name, worldId1, worldId2);
		}

		/// <summary>
		/// Sent when clicken the Arrange Inventory button.
		/// </summary>
		/// <remarks>
		/// Named "CZ_SORT_INV_CHANGE_INDEX" (0xCE4) in iCBT1, size 11.
		/// Name changed to "CZ_SORT_INV" in iCBT2 (pre-launch),
		/// one byte added, presumedly for the order.
		/// </remarks>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SORT_INV)]
		public void CZ_SORT_INV(IZoneConnection conn, Packet packet)
		{
			var unkByte = packet.GetByte();
			var order = (InventoryOrder)packet.GetByte(); // [i10622 (2015-10-22)] Added

			var character = conn.SelectedCharacter;

			// TODO: Add cooldown?

			character.Inventory.Sort(order);
		}

		/// <summary>
		/// Extend Team Storage Slot
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_EXTEND_WAREHOUSE)]
		public void CZ_EXTEND_WAREHOUSE(IZoneConnection conn, Packet packet)
		{
			var account = conn.Account;
			var character = conn.SelectedCharacter;
			var prop = account.Properties.GetFloat(PropertyName.AccountWareHouseExtend, 0);
			var fixedCost = (int)(200000 * (prop + 1));

			if (character.Inventory.CountItem(ItemId.Silver) >= fixedCost)
			{
				character.RemoveItem(ItemId.Silver, fixedCost);
				account.Properties.Modify(PropertyName.AccountWareHouseExtend, 1);
				Send.ZC_NORMAL.AccountProperties(character, PropertyName.AccountWareHouseExtend);
				Send.ZC_ADDON_MSG(character, AddonMessage.ACCOUNT_WAREHOUSE_ITEM_LIST);
				Send.ZC_ADDON_MSG(character, AddonMessage.ACCOUNT_UPDATE);
			}
		}

		/// <summary>
		/// Sent on logout to save hotkeys.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_QUICKSLOT_LIST)]
		public void CZ_QUICKSLOT_LIST(IZoneConnection conn, Packet packet)
		{
			var packetSize = packet.GetShort();
			var compressedSize = packet.GetInt();

			var serialized = new StringBuilder("#");

			packet.UncompressData(compressedSize, p =>
			{
				var b2 = p.GetByte();

				for (var i = 0; i < 50; i++)
				{
					var type = (QuickSlotType)p.GetByte();
					var classId = p.GetInt();
					var objectId = p.GetLong();

					serialized.AppendFormat("{0},{1},{2}#", type, classId, objectId);
				}

				for (var i = 0; i < 4; i++)
				{
					var type = (QuickSlotType)p.GetByte();
					var classId = p.GetInt();
					var objectId = p.GetLong();

					serialized.AppendFormat("{0},{1},{2}#", type, classId, objectId);
				}

				var b3 = p.GetByte();
				var b4 = p.GetByte();
			});

			// What do you mean "this is a terrible way of saving the
			// hotkeys"? I bet this is how all great games do it! Yes!
			// I'm certain of it! There's absolutely no reason to refactor
			// any of this! It's perfect! Perfect, I tell you!

			var character = conn.SelectedCharacter;
			character.Variables.Perm.SetString("Melia.QuickSlotList", serialized.ToString());
		}

		/// <summary>
		/// Sent when clicking a pose.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_POSE)]
		public void CZ_POSE(IZoneConnection conn, Packet packet)
		{
			var pose = packet.GetInt();
			var position = packet.GetPosition();
			var direction = packet.GetDirection();

			var character = conn.SelectedCharacter;

			// TODO: Sanity checks.
			if (character.IsDead)
				return;
			if (character.IsSitting)
				character.ToggleSitting();

			Send.ZC_POSE(character, pose);
		}

		/// <summary>
		/// Sent to rotate the character's body. 
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ROTATE)]
		public void CZ_ROTATE(IZoneConnection conn, Packet packet)
		{
			var i1 = packet.GetInt();
			var direction = packet.GetDirection();

			conn.SelectedCharacter.Rotate(direction);
		}

		/// <summary>
		/// Sent to rotate the character's head. 
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_HEAD_ROTATE)]
		public void CZ_HEAD_ROTATE(IZoneConnection conn, Packet packet)
		{
			var i1 = packet.GetInt();
			var direction = packet.GetDirection();

			conn.SelectedCharacter.RotateHead(direction);
		}

		/// <summary>
		/// Sent when the character requests to use an item.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ITEM_USE)]
		public void CZ_ITEM_USE(IZoneConnection conn, Packet packet)
		{
			var worldId = packet.GetLong();
			var handle = packet.GetInt();

			var character = conn.SelectedCharacter;

			// Get item
			var item = character.Inventory.GetItem(worldId);
			if (item == null)
			{
				Log.Warning("CZ_ITEM_USE: User '{0}' tried to use a non-existent item.", conn.Account.Name);
				return;
			}

			// Do not allow use of locked items
			if (item.IsLocked)
			{
				Log.Warning("CZ_ITEM_USE: User '{0}' tried to use a locked item.", conn.Account.Name);
				return;
			}

			// Nothing to do if the item doesn't have a script
			if (!item.Data.HasScript)
			{
				Log.Warning("CZ_ITEM_USE: User '{0}' tried to use an item without script.", conn.Account.Name);
				return;
			}

			// Try to execute script
			var script = item.Data.Script;

			if (!ScriptableFunctions.Item.TryGet(script.Function, out var scriptFunc))
			{
				character.ServerMessage(Localization.Get("This item has not been implemented yet."));
				Log.Debug("CZ_ITEM_USE: Missing script function: {0}(\"{1}\", {2}, {3})", script.Function, script.StrArg, script.NumArg1, script.NumArg2);
				return;
			}

			try
			{
				var result = scriptFunc(character, item, script.StrArg, script.NumArg1, script.NumArg2);
				if (result == ItemUseResult.Fail)
				{
					character.ServerMessage(Localization.Get("Item usage failed."));
					return;
				}

				// Send item on cooldown
				if (item.Data.HasCooldown && item.CooldownData != null)
					character.StartCooldown(item.CooldownData.Id, item.CooldownData.OverheatResetTime);

				// Remove consumeable items on success
				if (item.Data.Type == ItemType.Consume && result != ItemUseResult.OkayNotConsumed)
					character.Inventory.Remove(item, 1, InventoryItemRemoveMsg.Used);

				if (result == ItemUseResult.Okay)
					Send.ZC_ITEM_USE(character, item.Id);
			}
			catch (BuffNotImplementedException ex)
			{
				character.ServerMessage(Localization.Get("This item has not been fully implemented yet."));
				Log.Debug("CZ_ITEM_USE: Buff handler '{4}' missing for script execution of '{0}(\"{1}\", {2}, {3})'", script.Function, script.StrArg, script.NumArg1, script.NumArg2, ex.BuffId);
			}
			catch (Exception ex)
			{
				character.ServerMessage(Localization.Get("Apologies, something went wrong there. Please report this issue."));
				Log.Debug("CZ_ITEM_USE: Exception while executing script function '{0}(\"{1}\", {2}, {3})': {4}", script.Function, script.StrArg, script.NumArg1, script.NumArg2, ex);
			}
		}

		/// <summary>
		/// Sent when "clicking" an NPC.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CLICK_TRIGGER)]
		public void CZ_CLICK_TRIGGER(IZoneConnection conn, Packet packet)
		{
			var handle = packet.GetInt();
			var unkByte = packet.GetByte();

			var character = conn.SelectedCharacter;
			var monster = character.Map.GetMonster(handle);

			if (monster == null)
			{
				Log.Warning("CZ_CLICK_TRIGGER: User '{0}' tried to talk to unknown monster.", conn.Account.Name);
				return;
			}

			if (monster.MonsterType == MonsterType.Mob)
			{
				Log.Warning("CZ_CLICK_TRIGGER: User '{0}' tried to talk to an actual monster.", conn.Account.Name);
				return;
			}

			if (string.IsNullOrWhiteSpace(monster.DialogName))
			{
				Log.Warning("CZ_CLICK_TRIGGER: User '{0}' tried to talk to a monster without dialog.", conn.Account.Name);
				return;
			}

			if (monster is not Npc npc)
			{
				Log.Warning("CZ_CLICK_TRIGGER: User '{0}' tried to talk to a monster that's not an NPC.", conn.Account.Name);
				return;
			}

			if (conn.CurrentDialog != null && conn.CurrentDialog.State != DialogState.Ended)
			{
				// Don't acutally log this, as it might happen naturally.
				//Log.Debug("CZ_CLICK_TRIGGER: User '{0}' is already in a dialog.", conn.Account.Name);
				return;
			}

			conn.CurrentDialog = new Dialog(character, npc);
			conn.CurrentDialog.Start();
		}

		/// <summary>
		/// Sent when selecting a dialog option or entering a number into a
		/// number range dialog.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_DIALOG_SELECT)]
		public void CZ_DIALOG_SELECT(IZoneConnection conn, Packet packet)
		{
			var option = packet.GetByte();

			// Check state
			if (conn.CurrentDialog == null)
			{
				Log.Debug("CZ_DIALOG_SELECT: User '{0}' is not in a dialog.", conn.Account.Name);
				return;
			}

			// Resume dialog with the option as a string. We use a string
			// because we can use one method for both selections and inputs
			// this way.
			conn.CurrentDialog.Resume(option.ToString());
		}

		/// <summary>
		/// Sent to continue dialog?
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_DIALOG_ACK)]
		public void CZ_DIALOG_ACK(IZoneConnection conn, Packet packet)
		{
			var type = packet.GetInt();
			var character = conn.SelectedCharacter;

			// Cutscene Tracker
			if (character.Tracks.ActiveTrack != null)
			{
				var track = character.Tracks.ActiveTrack;
				Send.ZC_DIALOG_CLOSE(conn);
				Send.ZC_NORMAL.SetTrackFrame(character, track.Frame);
				return;
			}

			// Check state
			if (conn.CurrentDialog == null)
			{
				// Don't log, can happen due to key spamming at the end
				// of a dialog.
				//Log.Debug("CZ_DIALOG_ACK: User '{0}' is not in a dialog.", conn.Account.Name);
				return;
			}

			// The type seems to indicate what the client wants to do,
			// 1 being sent when continuing normally and 0 or -1 when
			// escape is pressed, to cancel the dialog.
			if (type == 1)
			{
				conn.CurrentDialog.Resume(null);
			}
			else
			{
				Send.ZC_DIALOG_CLOSE(conn);
				Send.ZC_LEAVE_TRIGGER(conn);
				conn.CurrentDialog = null;
			}
		}

		/// <summary>
		/// Sent after entering a string in an input dialog.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_DIALOG_STRINGINPUT)]
		public void CZ_DIALOG_STRINGINPUT(IZoneConnection conn, Packet packet)
		{
			var input = packet.GetString(128);

			// Check state
			if (conn.CurrentDialog == null)
			{
				Log.Debug("CZ_DIALOG_STRINGINPUT: User '{0}' is not in a dialog.", conn.Account.Name);
				return;
			}

			conn.CurrentDialog.Resume(input);
		}

		/// <summary>
		/// Sent when changing an option in the settings. Or when the
		/// client randomly decides to spam you with all options.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CHANGE_CONFIG)]
		public void CZ_CHANGE_CONFIG(IZoneConnection conn, Packet packet)
		{
			var optionId = packet.GetInt();
			var value = packet.GetInt();

			if (!conn.Account.Settings.IsValid(optionId))
			{
				Log.Debug("CZ_CHANGE_CONFIG: Unknown account option '{0}'.", optionId);
				return;
			}

			conn.Account.Settings.Set(optionId, value);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <remarks>
		/// This packet is spammed near the warp from Siauliai to Kaipeda,
		/// purpose unknown. I guess it expects some kind of response,
		/// more research required.
		/// </remarks>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REVEAL_NPC_STATE)]
		public void CZ_REVEAL_NPC_STATE(IZoneConnection conn, Packet packet)
		{
			var unkInt = packet.GetInt();
		}

		/// <summary>
		/// Sent when attacking enemies.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CLIENT_HIT_LIST)]
		public void CZ_CLIENT_HIT_LIST(IZoneConnection conn, Packet packet)
		{
			var packetSize = packet.GetShort();
			var i1 = packet.GetInt();
			var targetHandleCount = packet.GetInt();
			var originPos = packet.GetPosition();
			var farPos = packet.GetPosition();
			var direction = packet.GetDirection();
			var skillId = (SkillId)packet.GetInt();
			var b1 = packet.GetByte();
			var f3 = packet.GetFloat();
			var speedRate = packet.GetFloat();
			var hitDelay = packet.GetFloat();
			var targetHandles = packet.GetList(targetHandleCount, packet.GetInt);

			var character = conn.SelectedCharacter;

			// Check skill
			if (!character.Skills.TryGet(skillId, out var skill))
			{
				Log.Warning("CZ_CLIENT_HIT_LIST: User '{0}' tried to use a skill they don't have ({1}).", conn.Account.Name, skillId);
				return;
			}

			// Check cooldown
			if (skill.IsOnCooldown)
			{
				Log.Warning("CZ_CLIENT_HIT_LIST: User '{0}' tried to use a skill that's on cooldown ({1}).", conn.Account.Name, skillId);
				character.ServerMessage(Localization.Get("You may not use this yet."));
				return;
			}

			// Get targets
			var targets = new List<ICombatEntity>();
			foreach (var handle in targetHandles)
			{
				if (!character.Map.TryGetCombatEntity(handle, out var target))
				{
					Log.Warning("CZ_CLIENT_HIT_LIST: User '{0}' tried to attack non-existant target '{1}'.", conn.Account.Name, handle);
					continue;
				}

				if (!character.CanAttack(target))
				{
					Log.Warning("CZ_CLIENT_HIT_LIST: User '{0}' tried to attack invalid target '{1}'.", conn.Account.Name, handle);
					continue;
				}

				targets.Add(target);
			}

			// Try to use skill
			try
			{
				switch (skill.Data.UseType)
				{
					case SkillUseType.MeleeGround:
					{
						if (!ZoneServer.Instance.SkillHandlers.TryGetHandler<IMeleeGroundSkillHandler>(skillId, out var handler))
						{
							character.ServerMessage(Localization.Get("This skill has not been implemented yet."));
							Log.Warning("CZ_CLIENT_HIT_LIST: No handler for skill '{0}' found.", skillId);
							return;
						}

						handler.Handle(skill, character, originPos, farPos, targets);
						break;
					}
					case SkillUseType.Force:
					{
						if (!ZoneServer.Instance.SkillHandlers.TryGetHandler<IForceSkillHandler>(skillId, out var handler))
						{
							character.ServerMessage(Localization.Get("This skill has not been implemented yet."));
							Log.Warning("CZ_CLIENT_HIT_LIST: No handler for skill '{0}' found.", skillId);
							return;
						}

						handler.Handle(skill, character, originPos, farPos, targets);
						break;
					}
					default:
					{
						Log.Warning("CZ_CLIENT_HIT_LIST: User '{0}' tried to use skill '{1}' of unknown use type '{2}'.", conn.Account.Name, skillId, skill.Data.UseType);
						break;
					}
				}
			}
			catch (ArgumentException ex)
			{
				Log.Error("CZ_CLIENT_HIT_LIST: Failed to execute the handler for '{0}'. Error: {1}", skillId, ex);
			}
		}

		/// <summary>
		/// Sent when attacking a target with a skill, incl. the default
		/// magic attack and bows.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SKILL_TARGET)]
		public void CZ_SKILL_TARGET(IZoneConnection conn, Packet packet)
		{
			var b1 = packet.GetByte();
			var skillId = (SkillId)packet.GetInt();
			var targetHandle = packet.GetInt();
			var b2 = packet.GetByte();

			var character = conn.SelectedCharacter;

			// Check skill
			if (!character.Skills.TryGet(skillId, out var skill))
			{
				Log.Warning("CZ_SKILL_TARGET: User '{0}' tried to use a skill they don't have ({1}).", conn.Account.Name, skillId);
				return;
			}

			// Check cooldown
			if (skill.IsOnCooldown)
			{
				Log.Warning("CZ_SKILL_TARGET: User '{0}' tried to use a skill that's on cooldown ({1}).", conn.Account.Name, skillId);
				character.ServerMessage(Localization.Get("You may not use this yet."));
				return;
			}

			// Check target
			// TODO: Should the target be checked properly? Is it possible
			//   to use this handler without target? We should document
			//   such things.
			var target = character.Map.GetCombatEntity(targetHandle);
			//if (!character.Map.TryGetCombatEntity(targetHandle, out var target))
			//{
			//	Log.Warning("CZ_SKILL_TARGET: User '{0}' tried to use a skill on a non-existing target.", conn.Account.Name);
			//	return;
			//}

			// Try to use skill
			try
			{
				if (!ZoneServer.Instance.SkillHandlers.TryGetHandler<ITargetSkillHandler>(skillId, out var handler))
				{
					character.ServerMessage(Localization.Get("This skill has not been implemented yet."));
					Log.Warning("CZ_SKILL_TARGET: No handler for skill '{0}' found.", skillId);
					return;
				}

				handler.Handle(skill, character, target);
			}
			catch (ArgumentException ex)
			{
				Log.Error("CZ_SKILL_TARGET: Failed to execute the handler for '{0}'. Error: {1}", skillId, ex);
			}
		}

		/// <summary>
		/// Sent when attacking a target with a skill, incl. the default
		/// magic attack and bows.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SKILL_TARGET_ANI)]
		public void CZ_SKILL_TARGET_ANI(IZoneConnection conn, Packet packet)
		{
			var b1 = packet.GetByte();
			var skillId = (SkillId)packet.GetInt();
			var direction = packet.GetDirection();

			var character = conn.SelectedCharacter;

			// The packet is sent after the attack animation of the default
			// magic attack when there's no target. In this case skillId is
			// 0. It's currently unknown what exactly is supposed to happen
			// in that case, but we probably don't want to execute the skill
			// handler.
			if (skillId == 0)
			{
				// Cancel the attack
				Send.ZC_NORMAL.AttackCancel(character);
				return;
			}

			// Check skill
			if (!character.Skills.TryGet(skillId, out var skill))
			{
				Log.Warning("CZ_SKILL_TARGET_ANI: User '{0}' tried to use a skill they don't have ({1}).", conn.Account.Name, skillId);
				return;
			}

			// Try to use skill
			try
			{
				if (!ZoneServer.Instance.SkillHandlers.TryGetHandler<ITargetSkillHandler>(skillId, out var handler))
				{
					character.ServerMessage(Localization.Get("This skill has not been implemented yet."));
					Log.Warning("CZ_SKILL_TARGET_ANI: No handler for skill '{0}' found.", skillId);
					return;
				}

				handler.Handle(skill, character, null);
			}
			catch (ArgumentException ex)
			{
				Log.Error("CZ_SKILL_TARGET_ANI: Failed to execute the handler for '{0}'. Error: {1}", skillId, ex);
			}
		}

		/// <summary>
		/// This packet is used to cast skills in the ground.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SKILL_GROUND)]
		public void CZ_SKILL_GROUND(IZoneConnection conn, Packet packet)
		{
			var unk1 = packet.GetByte();
			var skillId = (SkillId)packet.GetInt();
			var i3 = packet.GetInt();
			var originPos = packet.GetPosition();
			var farPos = packet.GetPosition();
			var direction = packet.GetDirection();
			var targetHandle = packet.GetInt();
			var i1 = packet.GetInt();
			var unk2 = packet.GetByte();
			var i2 = packet.GetInt();

			var character = conn.SelectedCharacter;

			// Check skill
			if (!character.Skills.TryGet(skillId, out var skill))
			{
				Log.Warning("CZ_SKILL_GROUND: User '{0}' tried to use a skill they don't have ({1}).", conn.Account.Name, skillId);
				return;
			}

			// Check cooldown
			if (skill.IsOnCooldown)
			{
				Log.Warning("CZ_SKILL_GROUND: User '{0}' tried to use a skill that's on cooldown ({1}).", conn.Account.Name, skillId);
				character.ServerMessage(Localization.Get("You may not use this yet."));
				return;
			}

			// Probably just a sanity check since the client doesn't allow this.
			if (!skill.HasRequiredStance)
				return;

			// Check target
			ICombatEntity target = null;
			if (targetHandle != 0)
			{
				if (!character.Map.TryGetActor(targetHandle, out var actor))
				{
					Log.Warning("CZ_SKILL_GROUND: User '{0}' tried to use skill '{1}' on a non-existing target.", conn.Account.Name, skill.Id);
					return;
				}

				// The client sends a handle even if you target a friendly
				// monster, such as an NPC. We'll ignore that case for
				// now and leave target as null, under the assumption
				// that you never use skills on non-combatants.
				if (actor is ICombatEntity ce)
					target = ce;
			}

			// Try to use skill
			try
			{
				if (!ZoneServer.Instance.SkillHandlers.TryGetHandler<IGroundSkillHandler>(skillId, out var handler))
				{
					character.ServerMessage(Localization.Get("This skill has not been implemented yet."));
					Log.Warning("CZ_SKILL_GROUND: No handler for skill '{0}' found.", skillId);
					return;
				}

				handler.Handle(skill, character, originPos, farPos, target);
			}
			catch (ArgumentException ex)
			{
				Log.Error("CZ_SKILL_GROUND: Failed to execute the handler for '{0}'. Error: {1}", skillId, ex);
			}
		}

		/// <summary>
		/// Request from a player to use a skill on their own character.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SKILL_SELF)]
		public void CZ_SKILL_SELF(IZoneConnection conn, Packet packet)
		{
			var b1 = packet.GetByte();
			var skillId = (SkillId)packet.GetInt();
			var originPos = packet.GetPosition();
			var direction = packet.GetDirection();
			var b2 = packet.GetByte();

			var character = conn.SelectedCharacter;

			// Check skill
			if (!character.Skills.TryGet(skillId, out var skill))
			{
				Log.Warning("CZ_SKILL_SELF: User '{0}' tried to use a skill they don't have ({1}).", conn.Account.Name, skillId);
				return;
			}

			// Check cooldown
			if (skill.IsOnCooldown)
			{
				Log.Warning("CZ_SKILL_SELF: User '{0}' tried to use a skill that's on cooldown ({1}).", conn.Account.Name, skillId);
				character.ServerMessage(Localization.Get("You may not use this yet."));
				return;
			}

			// Try to use skill
			try
			{
				if (!ZoneServer.Instance.SkillHandlers.TryGetHandler<ISelfSkillHandler>(skillId, out var handler))
				{
					character.ServerMessage(Localization.Get("This skill has not been implemented yet."));
					Log.Warning("CZ_SKILL_SELF: No handler for skill '{0}' found.", skillId);
					return;
				}

				handler.Handle(skill, character, originPos, direction);
			}
			catch (ArgumentException ex)
			{
				Log.Error("CZ_SKILL_SELF: Failed to execute the handler for '{0}'. Error: {1}", skillId, ex);
			}
		}

		/// <summary>
		/// Sent when character starts casting a hold to cast skill.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_DYNAMIC_CASTING_START)]
		public void CZ_DYNAMIC_CASTING_START(IZoneConnection conn, Packet packet)
		{
			var skillId = (SkillId)packet.GetInt();
			var maxCastTime = packet.GetFloat();

			var character = conn.SelectedCharacter;

			// Check skill
			if (!character.Skills.TryGet(skillId, out var skill))
			{
				Log.Warning("CZ_DYNAMIC_CASTING_START: User '{0}' tried to use a skill they don't have ({1}).", conn.Account.Name, skillId);
				return;
			}

			if (!ZoneServer.Instance.SkillHandlers.TryGetHandler<IDynamicCasted>(skillId, out var handler))
			{
				character.ServerMessage(Localization.Get("This skill has not been implemented yet."));
				Log.Warning("CZ_DYNAMIC_CASTING_START: No handler for skill '{0}' found.", skillId);
				return;
			}

			handler.StartDynamicCast(skill, character, maxCastTime);
		}

		/// <summary>
		/// Sent when character casting ends after holding to cast skill.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_DYNAMIC_CASTING_END)]
		public void CZ_DYNAMIC_CASTING_END(IZoneConnection conn, Packet packet)
		{
			var skillId = (SkillId)packet.GetInt();
			var castTime = packet.GetFloat(); // Max Cast Hold Time?

			var character = conn.SelectedCharacter;

			// Check skill
			if (!character.Skills.TryGet(skillId, out var skill))
			{
				Log.Warning("CZ_DYNAMIC_CASTING_END: User '{0}' tried to use a skill they don't have ({1}).", conn.Account.Name, skillId);
				return;
			}

			if (!ZoneServer.Instance.SkillHandlers.TryGetHandler<IDynamicCasted>(skillId, out var handler))
			{
				character.ServerMessage(Localization.Get("This skill has not been implemented yet."));
				Log.Warning("CZ_DYNAMIC_CASTING_END: No handler for skill '{0}' found.", skillId);
				return;
			}

			handler.EndDynamicCast(skill, character, castTime);
		}

		/// <summary>
		/// Sent when character is using the ground position selection tool
		/// starts.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SELECT_GROUND_POS_START)]
		public void CZ_SELECT_GROUND_POS_START(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			// TODO: keep track of state?
		}

		/// <summary>
		/// Sent when character is using the ground position selection tool ends
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SELECT_GROUND_POS_END)]
		public void CZ_SELECT_GROUND_POS_END(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			// TODO: keep track of state?
		}

		/// <summary>
		/// Sent after selecting a target ground position for a skill.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SKILL_TOOL_GROUND_POS)]
		public void CZ_SKILL_TOOL_GROUND_POS(IZoneConnection conn, Packet packet)
		{
			var pos = packet.GetPosition();
			var skillId = (SkillId)packet.GetInt();
			var b1 = packet.GetByte();

			var character = conn.SelectedCharacter;

			if (!character.Skills.TryGet(skillId, out var skill))
			{
				Log.Warning("CZ_SKILL_TOOL_GROUND_POS: User '{0}' tried to send a position for a skill they don't have.");
				return;
			}

			skill.Vars.Set("Melia.ToolGroundPos", pos);
		}

		[PacketHandler(Op.CZ_REQUEST_GODDESS_ROULETT)]
		public void CZ_REQUEST_GODDESS_ROULETT(IZoneConnection conn, Packet packet)
		{
			var rouletteType = packet.GetInt(); // 3
			var character = conn.SelectedCharacter;

			var itemGrade = "C";
			var item = "misc_reinforce_percentUp_480_NoTrade";
			var itemAmount = 3;

			character.ModifyAccountProperty(PropertyName.GODDESS_RAINBOW_ROULETTE_USE_ROULETTE_COUNT, 1);
			character.AddonMessage(AddonMessage.GODDESS_ROULETTE_START, string.Format("16/{0}/{1}/{2}", itemGrade, item, itemAmount));
		}

		/// <summary>
		/// Sent when clicking Confirm in a shop, with items in the "Bought" list.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ITEM_BUY)]
		public void CZ_ITEM_BUY(IZoneConnection conn, Packet packet)
		{
			var purchases = new Dictionary<int, int>();

			var size = packet.GetShort();
			var count = packet.GetInt();
			for (var i = 0; i < count; ++i)
			{
				var productId = packet.GetInt();
				var amount = packet.GetInt();

				purchases[productId] = amount;
			}

			var character = conn.SelectedCharacter;
			var dialog = conn.CurrentDialog;
			var shopData = dialog?.Shop;

			// Check amount
			if (count > 10)
			{
				Log.Warning("CZ_ITEM_BUY: User '{0}' tried to buy more than 10 items at once.", conn.Account.Name);
				return;
			}

			// Check open shop
			if (dialog == null || shopData == null)
			{
				Log.Warning("CZ_ITEM_BUY: User '{0}' tried to buy something with no shop open.", conn.Account.Name);
				return;
			}

			// Prepare items and get cost
			var totalCost = 0;
			var purchaseList = new List<Tuple<ItemData, int>>();
			foreach (var purchase in purchases)
			{
				var productId = purchase.Key;
				var amount = purchase.Value;

				// Get product
				var productData = shopData.GetProduct(productId);
				if (productData == null)
				{
					Log.Warning("CZ_ITEM_BUY: User '{0}' tried to buy product that's not in the shop ({1}, {2}).", conn.Account.Name, shopData.Name, productId);
					return;
				}

				// Get item
				var itemData = ZoneServer.Instance.Data.ItemDb.Find(productData.ItemId);
				if (itemData == null)
				{
					Log.Warning("CZ_ITEM_BUY: User '{0}' tried to buy item that's not in the db ({1}, {2}).", conn.Account.Name, shopData.Name, productData.ItemId);
					return;
				}

				if (!shopData.IsCustom)
				{
					var singlePrice = (int)(itemData.Price * productData.PriceMultiplier);
					totalCost += singlePrice * amount;
				}
				else
				{
					totalCost += (int)productData.PriceMultiplier * productData.Amount;
				}

				purchaseList.Add(new Tuple<ItemData, int>(itemData, amount));
			}

			// Check and reduce money
			if (character.Inventory.CountItem(ItemId.Silver) < totalCost)
			{
				Log.Warning("CZ_ITEM_BUY: User '{0}' tried to buy items without having enough money.", conn.Account.Name);
				return;
			}

			character.Inventory.Remove(ItemId.Silver, totalCost, InventoryItemRemoveMsg.Given);

			// Give items
			foreach (var purchase in purchaseList)
			{
				var itemData = purchase.Item1;
				var amount = purchase.Item2;

				character.Inventory.Add(itemData.Id, amount, InventoryAddType.Buy);
			}

			// Temporary fix for differences in prices between client and
			// server. Equip prices are being calculated somehow, with their
			// price in the db usually being 0. This msg will reset the shop
			// panel, to display the proper balance after confirming the
			// transaction.
			// 08-29-21 Update, Item Database is updated but equipment for the most part are still priced at 0
			Send.ZC_ADDON_MSG(character, AddonMessage.FAIL_SHOP_BUY, 0, null);
		}

		/// <summary>
		/// Sent when clicking Confirm in a shop, with items in the "Sold" list.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ITEM_SELL)]
		public void CZ_ITEM_SELL(IZoneConnection conn, Packet packet)
		{
			var itemsToSell = new Dictionary<long, int>();

			var size = packet.GetShort();
			var count = packet.GetInt();
			for (var i = 0; i < count; ++i)
			{
				var worldId = packet.GetLong();
				var amount = packet.GetInt();
				var unkInt = packet.GetInt();

				itemsToSell[worldId] = amount;
			}

			var character = conn.SelectedCharacter;

			// Check amount
			if (count > 10)
			{
				Log.Warning("CZ_ITEM_SELL: User '{0}' tried sell more than 10 items at once.", conn.Account.Name);
				return;
			}

			// Remove items and count revenue
			var totalMoney = 0;
			var itemsSold = new List<Item>();
			foreach (var itemToSell in itemsToSell)
			{
				var worldId = itemToSell.Key;
				var amount = itemToSell.Value;

				// Get item
				var item = character.Inventory.GetItem(worldId);
				if (item == null)
				{
					Log.Warning("CZ_ITEM_SELL: User '{0}' tried to sell a non-existent item.", conn.Account.Name);
					return;
				}

				// Check amount
				if (item.Amount < amount)
				{
					Log.Warning("CZ_ITEM_SELL: User '{0}' tried to sell more of an item than they own.", conn.Account.Name);
					return;
				}

				// Try to remove item
				if (character.Inventory.Remove(item, amount, InventoryItemRemoveMsg.Sold) == InventoryResult.Success)
				{
					totalMoney += item.Data.SellPrice * amount;
					itemsSold.Add(item);
				}
				else
					Log.Warning("CZ_ITEM_SELL: Failed to sell an item from user '{0}' .", conn.Account.Name);
			}

			// Give money
			if (totalMoney > 0)
				character.Inventory.Add(ItemId.Silver, totalMoney, InventoryAddType.Sell);


			// Need to keep track of items sold, server sends this list to the client
			Send.ZC_SOLD_ITEM_DIVISION_LIST(character, InventoryType.Sold, itemsSold);
		}

		/// <summary>
		/// Information sent to be saved?
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SAVE_INFO)]
		public void CZ_SAVE_INFO(IZoneConnection conn, Packet packet)
		{
			// TODO: Research what information needs to be saved here and implement it.
		}

		/// <summary>
		/// Sent when attempting to logout or switch characters.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_RUN_GAMEEXIT_TIMER)]
		public void CZ_RUN_GAMEEXIT_TIMER(IZoneConnection conn, Packet packet)
		{
			var destination = packet.GetString();
			var parameter = packet.GetString(); // [i373230]
			var character = conn.SelectedCharacter;

			switch (destination)
			{
				case "Logout":
				case "Barrack":
				case "Channel":
				case "Exit":
					if (conn.SelectedCharacter.Inventory.HasExpiringItems)
					{
						Send.ZC_ADDON_MSG(character, AddonMessage.EXPIREDITEM_ALERT_OPEN, 0, destination);
					}

					var combat = character.Components.Get<CombatComponent>();

					Send.ZC_ADDON_MSG(conn.SelectedCharacter, AddonMessage.GAMEEXIT_TIMER_END, 0, "None");
					break;
				default:
					Log.Warning("CZ_RUN_GAMEEXIT_TIMER: User '{0}' tried to transfer to '{1}' which is an unknown state.", conn.Account.Name, destination);
					return;
			}

			Log.Info("User '{0}' is transferring to '{1}' state.", conn.Account.Name, destination);
		}

		/// <summary>
		/// Sent when a player tries to join a guild (self invite).
		/// Dummy Handler
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SELF_INVITE_NEWBIE_GUILD)]
		public void CZ_SELF_INVITE_NEWBIE_GUILD(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			Send.ZC_SYSTEM_MSG(character, 102502);
		}

		/// <summary>
		/// Sent when a player tries to take a screenshot.
		/// Dummy Handler
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SCREENSHOT_HASH)]
		public void CZ_SCREENSHOT_HASH(IZoneConnection conn, Packet packet)
		{
			var account = conn.SelectedCharacter;
			// Track screenshot meta data (where/when it was taken)?
		}

		/// <summary>
		/// Sent when a player tries to enter instance dungeon via UI.
		/// Dummy Handler
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_MOVE_TO_INDUN)]
		public void CZ_REQ_MOVE_TO_INDUN(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			// TODO: Figure out which indun is requested, attach it to the connection?
			if (character.Level > 0)
				character.SystemMessage("YourLevelIsHighThenIndun");
		}

		/// <summary>
		/// Contains newly uncovered areas of a map.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_MAP_REVEAL_INFO)]
		public void CZ_MAP_REVEAL_INFO(IZoneConnection conn, Packet packet)
		{
			var mapId = packet.GetInt();
			var visible = packet.GetBin(128);

			// Check if the map exists
			var mapData = ZoneServer.Instance.Data.MapDb.Find(mapId);
			if (mapData == null)
			{
				Log.Warning("CZ_MAP_REVEAL_INFO: User '{0}' tried to send an update for map '{1}', which doesn't exist.", conn.Account.Name, mapId);
				return;
			}

			// Check if character is actually on the map
			// The existence check prevents flooding, and this one ensures
			// players can only reveal maps they are actually on.
			// Eventually we might want to improve this further,
			// checking the character's position.
			if (conn.SelectedCharacter.MapId != mapId)
			{
				Log.Warning("CZ_MAP_REVEAL_INFO: User '{0}' tried to send an update for a different map than they're on.", conn.Account.Name);
				return;
			}

			var revealedMap = new RevealedMap(mapId, visible, 0);
			conn.Account.AddRevealedMap(revealedMap);
		}

		/// <summary>
		/// Reports to the server a percentage of the map that has been explored.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_MAP_SEARCH_INFO)]
		public void CZ_MAP_SEARCH_INFO(IZoneConnection conn, Packet packet)
		{
			var map = packet.GetString(41);
			var percentage = packet.GetFloat();

			var mapData = ZoneServer.Instance.Data.MapDb.Find(map);
			if (mapData == null)
			{
				Log.Warning("CZ_MAP_SEARCH_INFO: User '{0}' tried to update the map '{1}' which doesn't exist.", conn.Account.Name, map);
				return;
			}

			if (percentage < 0 || percentage > 100)
			{
				Log.Warning("CZ_MAP_SEARCH_INFO: User '{0}' tried to update the visibility for map '{1}' beyond an acceptable percentage.", conn.Account.Name, map);
				return;
			}

			// Originally null was passed as "explored", but then the server
			// would try to save the null to the database if the map data
			// didn't exist yet.

			var revealedMap = new RevealedMap(mapData.Id, new byte[0], percentage);
			conn.Account.AddRevealedMap(revealedMap);
		}

		/// <summary>
		/// Indicates a request from the client to trade with another character.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_EXCHANGE_REQUEST)]
		public void CZ_EXCHANGE_REQUEST(IZoneConnection conn, Packet packet)
		{
			var targetHandle = packet.GetInt();

			var character = conn.SelectedCharacter;

			if (character == null)
				return;

			if (!character.Map.TryGetCharacter(targetHandle, out var targetCharacter))
			{
				Log.Warning("CZ_EXCHANGE_REQUEST: User '{0}' trade partner not found.", conn.Account.Name);
				return;
			}

			TradeComponent.RequestTrade(character, targetCharacter);
		}

		/// <summary>
		/// Indicates an accepted request from the client to trade with another character.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_EXCHANGE_ACCEPT)]
		public void CZ_EXCHANGE_ACCEPT(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			if (character.Trade == null)
			{
				Log.Warning("CZ_EXCHANGE_ACCEPT:  User '{0}' tried to accept a non-existent trade.", conn.Account.Name);
				return;
			}

			character.Trade.Start();
		}

		/// <summary>
		/// Request to offer an item for trade
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_EXCHANGE_OFFER)]
		public void CZ_EXCHANGE_OFFER(IZoneConnection conn, Packet packet)
		{
			var i1 = packet.GetInt();
			var worldId = packet.GetLong();
			var amount = packet.GetInt();
			var i3 = packet.GetInt();

			var character = conn.SelectedCharacter;

			if (character == null)
				return;

			if (!character.IsTrading)
			{
				Log.Warning("CZ_EXCHANGE_OFFER: User '{0}' tried to trade without actually trading.", conn.Account.Name);
				return;
			}

			character.Trade.Offer(character, worldId, amount);
		}

		/// <summary>
		/// Initial trade agreement request
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_EXCHANGE_AGREE)]
		public void CZ_EXCHANGE_AGREE(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			if (character == null)
				return;

			character.Trade.Confirm(character);
		}

		/// <summary>
		/// Final trade agreement request
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_EXCHANGE_FINALAGREE)]
		public void CZ_EXCHANGE_FINALAGREE(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			if (character == null)
				return;

			character.Trade.FinalConfirm(character);
		}

		/// <summary>
		/// Cancel trade request
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_EXCHANGE_CANCEL)]
		public void CZ_EXCHANGE_CANCEL(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			if (character == null)
				return;
			if (character.IsTrading)
				character.Trade.Cancel();
		}

		/// <summary>
		/// Handles various commands found in the custom command data.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CUSTOM_COMMAND)]
		public void CZ_CUSTOM_COMMAND(IZoneConnection conn, Packet packet)
		{
			var commandId = packet.GetInt();
			var numArg1 = packet.GetInt();
			var numArg2 = packet.GetInt();
			var numArg3 = packet.GetInt();

			var character = conn.SelectedCharacter;

			// Get data
			if (!ZoneServer.Instance.Data.CustomCommandDb.TryFind(commandId, out var data))
			{
				Log.Warning("CZ_CUSTOM_COMMAND: User '{0}' sent an unknown command id ({1}).", conn.Account.Name, commandId);
				return;
			}

			// Get handler
			if (!ScriptableFunctions.CustomCommand.TryGet(data.Script, out var scriptFunc))
			{
				Log.Debug("CZ_CUSTOM_COMMAND: No handler registered for custom command script '{0}({1}, {2}, {3})'", data.Script, numArg1, numArg2, numArg3);
				return;
			}


			// Try to execute command
			try
			{
				var result = scriptFunc(character, numArg1, numArg2, numArg3);
				if (result == CustomCommandResult.Fail)
				{
					Log.Debug("CZ_CUSTOM_COMMAND: Execution of script '{0}({1}, {2}, {3})' failed.", data.Script, numArg1, numArg2, numArg3);

				}
			}
			catch (Exception ex)
			{
				Log.Debug("CZ_CUSTOM_COMMAND: Exception while executing script '{0}({1}, {2}, {3})': {4}", data.Script, numArg1, numArg2, numArg3, ex);
			}
		}

		/// <summary>
		/// Request to reset a character's job, or rather to switch
		/// out one job for another.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_RANKRESET_SYSTEM)]
		public void CZ_REQ_RANKRESET_SYSTEM(IZoneConnection conn, Packet packet)
		{
			var oldJobId = (JobId)packet.GetShort();
			var newJobId = (JobId)packet.GetShort();

			var character = conn.SelectedCharacter;

			if (!character.Jobs.TryGet(oldJobId, out var oldJob))
			{
				Log.Warning("CZ_REQ_RANKRESET_SYSTEM: User '{0}' requested job reset for a job they don't have ({1})'.", conn.Account.Name, oldJobId);
				return;
			}

			if (character.Jobs.TryGet(newJobId, out _))
			{
				Log.Warning("CZ_REQ_RANKRESET_SYSTEM: User '{0}' tried to switch to a job they already have ({1})'.", conn.Account.Name, newJobId);
				return;
			}

			if (oldJobId.ToClass() != newJobId.ToClass())
			{
				Log.Warning("CZ_REQ_RANKRESET_SYSTEM: User '{0}' tried to switch to a job outside of their class tree ({1} -> {2})'.", conn.Account.Name, oldJobId, newJobId);
				return;
			}

			// Remove the skills associated with the old job. This could
			// be easier and safer if we were to save the job a skill was
			// learned for with the skill data.
			var oldJobTreeData = ZoneServer.Instance.Data.SkillTreeDb.FindSkills(oldJob.Id, oldJob.Level);

			foreach (var treeData in oldJobTreeData)
			{
				if (!character.Skills.TryGet(treeData.SkillId, out var skill))
					continue;

				character.Skills.Remove(skill.Id);
			}

			// Remove old job and grant new one
			var newJob = new Job(character, newJobId, oldJob.Circle);
			newJob.TotalExp = oldJob.TotalExp;
			newJob.SkillPoints = oldJob.Level;

			character.Jobs.Remove(oldJobId);
			character.Jobs.Add(newJob);
			character.JobId = newJob.Id;

			// I'd prefer to let the player keep playing after the switch,
			// but the intended behavior is apparently that you get DCed
			// and have to log back in. We'll mimic this for now, though
			// we could probably do it better. The only problem I noticed
			// so far is that the "Are you sure?" prompt doesn't disappear,
			// but that we can solve with client scripting.

			//Send.ZC_PC(character, PcUpdateType.Job, (int)newJob.Id, newJob.Level);
			//Send.ZC_JOB_PTS(character, newJob);
			//Send.ZC_NORMAL.PlayEffect(character, "F_pc_class_change");

			ZoneServer.Instance.ServerEvents.OnPlayerAdvancedJob(character);

			// The intended behavior is to trigger a clean DC from the
			// client with a move to barracks, but if we *need* the
			// player to DC, we might want to force it, because users
			// could make the client skip this packet and stay online.
			Send.ZC_MOVE_BARRACK(conn);
		}

		/// <summary>
		/// Sent when using a Tx Item.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_TX_ITEM)]
		public void CZ_REQ_TX_ITEM(IZoneConnection conn, Packet packet)
		{
			var size = packet.GetShort();
			var txClassId = packet.GetInt();
			var worldId = packet.GetLong();
			var l1 = packet.GetLong();
			var l2 = packet.GetLong();
			var b1 = packet.GetByte();
			var numArg = packet.GetInt();
			var character = conn.SelectedCharacter;

			// Get data
			if (!ZoneServer.Instance.Data.DialogTxDb.TryFind(txClassId, out var data))
			{
				character.ServerMessage(Localization.Get("Apologies, something went wrong there. Please report this issue."));
				Log.Warning("CZ_REQ_TX_ITEM: User '{0}' sent an unknown dialog transaction id: {1}", conn.Account.Name, txClassId);
				return;
			}

			// Get handler
			if (!ScriptableFunctions.Item.TryGet(data.Script, out var scriptFunc))
			{
				character.ServerMessage(Localization.Get("This action has not been implemented yet."));
				Log.Debug("CZ_REQ_TX_ITEM: No handler registered for transaction script '{0}'", data.Script);
				return;
			}

			// Get item from character
			var item = character.Inventory.GetItem(worldId);
			if (item == null)
			{
				Log.Warning("CZ_REQ_TX_ITEM: User '{0}' tried to use an item they don't have.", conn.Account.Name);
				return;
			}

			// Try to execute script
			var script = item.Data.Script;
			try
			{
				var result = scriptFunc(character, item, script.StrArg, script.NumArg1, (float)numArg);
				if (result == ItemUseResult.Fail)
				{
					character.ServerMessage(Localization.Get("Item usage failed."));
					return;
				}

				// Remove consumeable items on success
				if (item.Data.Type == ItemType.Consume)
				{
					if (result != ItemUseResult.OkayNotConsumed)
						character.Inventory.Remove(item, 1, InventoryItemRemoveMsg.Used);
				}

				if (item.Data.HasCooldown && item.CooldownData != null)
					character.StartCooldown(item.CooldownData.Id, item.CooldownData.OverheatResetTime);

				Send.ZC_ITEM_USE(character, item.Id);
			}
			catch (BuffNotImplementedException ex)
			{
				character.ServerMessage(Localization.Get("This item has not been fully implemented yet."));
				Log.Debug("CZ_REQ_TX_ITEM: Buff handler '{4}' missing for script execution of '{0}(\"{1}\", {2}, {3})'", script.Function, script.StrArg, script.NumArg1, script.NumArg2, ex.BuffId);
			}
			catch (Exception ex)
			{
				character.ServerMessage(Localization.Get("Apologies, something went wrong there. Please report this issue."));
				Log.Debug("CZ_REQ_TX_ITEM: Exception while executing script function '{0}(\"{1}\", {2}, {3})': {4}", script.Function, script.StrArg, script.NumArg1, script.NumArg2, ex);
			}
		}

		/// <summary>
		/// Sent after a loading screen is completed.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_LOAD_COMPLETE)]
		public void CZ_LOAD_COMPLETE(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			var house = conn.ActiveHouse;

			if (character.Map.Id >= 7000 && character.Map.Id <= 7002)
			{
				if (house != null)
				{
					Send.ZC_SET_LAYER(character, Map.DefaultLayer, false);
					character.AddonMessage(AddonMessage.SET_PERSONAL_HOUSE_NAME, house.Name);
					character.AddonMessage(AddonMessage.ENTER_PERSONAL_HOUSE, house.IsOwner(character) ? "YES" : "NO");
					character.AddonMessage(AddonMessage.HOUSINGCRAFT_UPDATE_ENDTIME);
				}
				else
				{
					var lastMapId = (int)character.Properties.GetFloat(PropertyName.LastWarpMapID, 1001);

					if (ZoneServer.Instance.World.Maps.TryGet(lastMapId, out var map) && map.Ground.TryGetRandomPosition(out var rndPos))
						character.Warp(map.Id, rndPos);
				}
			}
			Send.ZC_LOAD_COMPLETE(conn);
			character.AddonMessage(AddonMessage.RECEIVE_SERVER_NATION);
			foreach (var quest in character.Quests.GetList())
			{
				if (!quest.InProgress || quest.SessionObjectStaticData == null)
					continue;
				character.AddSessionObject(quest.SessionObjectStaticData.Id);
			}

			foreach (var skill in character.Skills.GetList(s => s.IsPassive))
			{
				if (ZoneServer.Instance.SkillHandlers.TryGetPassiveSkillHandler<IPassiveSkillHandler>(skill.Id, out var handler))
					handler.Handle(skill, skill.Owner);
			}
		}

		/// <summary>
		/// Sent when checking for attendance rewards
		/// Dummy
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ATTENDANCE_REWARD_CLICK)]
		public void CZ_ATTENDANCE_REWARD_CLICK(IZoneConnection conn, Packet packet)
		{
			var rewardId = packet.GetInt();
			var character = conn.SelectedCharacter;

			// TODO: Check if user is eligible for rewards
			Send.ZC_ATTENDANCE_RECEIPT_REWARD(conn, rewardId);
		}

		/// <summary>
		/// Create guild by web?
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CREATE_GUILD_BY_WEB)]
		public void CZ_CREATE_GUILD_BY_WEB(IZoneConnection conn, Packet packet)
		{
			var name = packet.GetString();
			var character = conn.SelectedCharacter;

			if (conn.Guild != null)
			{
				Log.Warning("CZ_CREATE_GUILD_BY_WEB: User '{0}' already has a guild.", conn.Account.Name);
				return;
			}

			if (ZoneServer.Instance.World.Guilds.Create(character, name) != null)
			{
				character.SystemMessage("CreateGuildSuccess");
				Send.ZC_DECREASE_SILVER(character, 1000000);
			}
		}

		/// <summary>
		/// Sent when (un)locking an item.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_INV_ITEM_LOCK)]
		public void CZ_INV_ITEM_LOCK(IZoneConnection conn, Packet packet)
		{
			var worldId = packet.GetLong();
			var lockItem = packet.GetBool();

			var character = conn.SelectedCharacter;

			var item = character.Inventory.GetItem(worldId);
			if (item == null)
			{
				Log.Warning("CZ_INV_ITEM_LOCK: User '{0}' tried to lock non-existent item.", conn.Account.Name);
				return;
			}

			item.IsLocked = lockItem;

			// Officials send the dict key as the item name, we might want
			// to add those to the item data.
			// <Item> item locked.
			// <Item> item unlocked.
			var sysMsg = lockItem ? "{Item}LockSuccess" : "{Item}UnlockSuccess";
			character.SystemMessage(sysMsg, new MsgParameter("Item", item.Data.Name));
		}

		/// <summary> 
		/// Sent upon login, purpose unknown. (Dummy handler)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_FIXED_NOTICE_SHOW)]
		public void CZ_FIXED_NOTICE_SHOW(IZoneConnection conn, Packet packet)
		{
			// No parameters
		}

		/// <summary>
		/// Sent upon logout. Presumably cancels "dungeon matching"?
		/// (Dummy handler)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CANCEL_INDUN_MATCHING)]
		public void CZ_CANCEL_INDUN_MATCHING(IZoneConnection conn, Packet packet)
		{
			// No parameters
		}

		/// <summary>
		/// Sent upon logout. Presumably cancels "dungeon registration"?
		/// (Dummy handler)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CLEAR_INDUN_REG)]
		public void CZ_CLEAR_INDUN_REG(IZoneConnection conn, Packet packet)
		{
			// No parameters
		}

		/// <summary>
		/// Fishing rank request
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_FISHING_RANK)]
		public void CZ_REQ_FISHING_RANK(IZoneConnection conn, Packet packet)
		{
			var type = packet.GetString(64);

			if (type == "SuccessCount" || type == "GoldenFish" || type == "FishRubbing")
				Send.ZC_NORMAL.FishingRankData(conn, type);
		}

		/// <summary>
		/// Attempts to sync the character position with the server and other entities on the map.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SYNC_POS)]
		public void CZ_SYNC_POS(IZoneConnection conn, Packet packet)
		{
			var handle = packet.GetInt();
			var position = packet.GetPosition();

			// Sanity checks...
			// Sync position for the character with the handle? ...
		}

		/// <summary>
		/// Sent upon login. (Dummy handler)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_ADVENTURE_BOOK_RANK)]
		public void CZ_REQ_ADVENTURE_BOOK_RANK(IZoneConnection conn, Packet packet)
		{
			var str = packet.GetString(128);
			var i1 = packet.GetInt();

			// TODO: Send.ZC_ADVENTURE_BOOK_INFO
			Send.ZC_NORMAL.AdventureBookRank(conn);
		}

		/// <summary>
		/// Request to execute a transaction script function with a string
		/// argument.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_NORMAL_TX)]
		public void CZ_REQ_NORMAL_TX(IZoneConnection conn, Packet packet)
		{
			var classId = packet.GetShort();
			var strArg = packet.GetString(33);

			var character = conn.SelectedCharacter;

			// Get data
			if (!ZoneServer.Instance.Data.NormalTxDb.TryFind(classId, out var data))
			{
				Log.Warning("CZ_REQ_NORMAL_TX: User '{0}' sent an unknown dialog transaction id: {1}", conn.Account.Name, classId);
				return;
			}

			// Get handler
			if (!ScriptableFunctions.NormalTx.TryGet(data.Script, out var scriptFunc))
			{
				Log.Debug("CZ_REQ_NORMAL_TX: No handler registered for transaction script '{0}(\"{1}\")'", data.Script, strArg);
				return;
			}

			// Try to execute transaction
			try
			{
				var result = scriptFunc(character, strArg);
				if (result == NormalTxResult.Fail)
				{
					Log.Debug("CZ_REQ_NORMAL_TX: Execution of script '{0}(\"{1}\")' failed.", data.Script, strArg);
				}
			}
			catch (Exception ex)
			{
				Log.Debug("CZ_REQ_NORMAL_TX: Exception while executing script '{0}(\"{1}\")': {2}", data.Script, strArg, ex);
			}
		}

		/// <summary>
		/// Request to execute a transaction script function with numeric
		/// arguments.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_NORMAL_TX_NUMARG)]
		public void CZ_REQ_NORMAL_TX_NUMARG(IZoneConnection conn, Packet packet)
		{
			var size = packet.GetShort();
			var classId = packet.GetShort();
			var argCount = packet.GetInt();
			var numArgs = packet.GetList(argCount, packet.GetInt);

			var character = conn.SelectedCharacter;

			// Get data
			if (!ZoneServer.Instance.Data.NormalTxDb.TryFind(classId, out var data))
			{
				Log.Warning("CZ_REQ_NORMAL_TX_NUMARG: User '{0}' sent an unknown dialog transaction id: {1}", conn.Account.Name, classId);
				return;
			}

			// Get handler
			if (!ScriptableFunctions.NormalTxNum.TryGet(data.Script, out var scriptFunc))
			{
				Log.Debug("CZ_REQ_NORMAL_TX_NUMARG: No handler registered for transaction script '{0}({1})'", data.Script, string.Join(", ", numArgs));
				return;
			}

			// Try to execute transaction
			try
			{
				var result = scriptFunc(character, numArgs);
				if (result == NormalTxResult.Fail)
				{
					Log.Debug("CZ_REQ_NORMAL_TX_NUMARG: Execution of script '{0}({1})' failed.", data.Script, string.Join(", ", numArgs));
				}
			}
			catch (Exception ex)
			{
				Log.Debug("CZ_REQ_NORMAL_TX_NUMARG: Exception while executing script '{0}({1})': {2}", data.Script, string.Join(", ", numArgs), ex);
			}
		}

		/// <summary>
		/// Transaction requests from the player as per the TX item data.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_DIALOG_TX)]
		public void CZ_DIALOG_TX(IZoneConnection conn, Packet packet)
		{
			var size = packet.GetShort();
			var classId = packet.GetInt();
			var itemCount = packet.GetShort();
			var numArgCount = packet.GetShort();
			var strArgCount = packet.GetShort();
			var dialogTxItems = packet.GetList(itemCount, packet.GetDialogTxItem);
			var numArgs = packet.GetList(numArgCount, packet.GetInt);
			var strArgs = packet.GetList(strArgCount, packet.GetLpString);

			var character = conn.SelectedCharacter;

			// Get data
			if (!ZoneServer.Instance.Data.DialogTxDb.TryFind(classId, out var data))
			{
				character.ServerMessage(Localization.Get("Apologies, something went wrong there. Please report this issue."));
				Log.Warning("CZ_DIALOG_TX: User '{0}' sent an unknown dialog transaction id: {1}", conn.Account.Name, classId);
				return;
			}

			// Get handler
			if (!ScriptableFunctions.DialogTx.TryGet(data.Script, out var scriptFunc))
			{
				character.ServerMessage(Localization.Get("This action has not been implemented yet."));
				Log.Debug("CZ_DIALOG_TX: No handler registered for transaction script '{0}'", data.Script);
				return;
			}

			// Get items from character
			var txItems = new Scripting.DialogTxItem[itemCount];
			for (var i = 0; i < dialogTxItems.Length; ++i)
			{
				var dialogTxItem = dialogTxItems[i];

				var item = character.Inventory.GetItem(dialogTxItem.ItemObjectId);
				if (item == null)
				{
					Log.Warning("CZ_DIALOG_TX: User '{0}' tried to use an item they don't have.", conn.Account.Name);
					return;
				}

				if (item.Amount < dialogTxItem.Amount)
				{
					Log.Warning("CZ_DIALOG_TX: User '{0}' tried to use more items than they have.", conn.Account.Name);
					return;
				}

				txItems[i] = new Scripting.DialogTxItem(item, dialogTxItem.Amount);
			}

			// Try to execute transaction
			var args = new DialogTxArgs(character, txItems, numArgs, strArgs);

			try
			{
				var result = scriptFunc(character, args);
				if (result == DialogTxResult.Fail)
				{
					character.ServerMessage(Localization.Get("Apologies, something went wrong there. Please report this issue."));
					Log.Debug("CZ_DIALOG_TX: Execution of script '{0}' failed.", data.Script);

				}
			}
			catch (Exception ex)
			{
				character.ServerMessage(Localization.Get("Apologies, something went wrong there. Please report this issue."));
				Log.Debug("CZ_DIALOG_TX: Exception while executing script '{0}': {1}", data.Script, ex);
			}
		}

		/// <summary>
		/// ? (Dummy)
		/// </summary>
		/// <remarks>
		/// The client sends this packet repeatedly until it gets an
		/// appropriate response.
		/// </remarks>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQUEST_GUILD_INDEX)]
		public void CZ_REQUEST_GUILD_INDEX(IZoneConnection conn, Packet packet)
		{
			var accountId = packet.GetLong();

			var account = ZoneServer.Instance.World.GetCharacter(c => c.AccountDbId == accountId);
			if (account != null)
			{
				var character = account.Connection.SelectedCharacter;
				var guild = conn.Guild;

				// ...

				Send.ZC_RESPONSE_GUILD_INDEX(conn, character, guild);
			}
		}

		/// <summary>
		/// Sent during login after an unexpected disconnect.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_DISCONNECT_REASON_FOR_LOG)]
		public void CZ_DISCONNECT_REASON_FOR_LOG(IZoneConnection conn, Packet packet)
		{
			var size = packet.GetShort();
			var valueCount = packet.GetInt();
			var i2 = packet.GetInt();
			var i3 = packet.GetInt();

			Log.Debug("CZ_DISCONNECT_REASON_FOR_LOG:");

			for (var i = 0; i < valueCount; ++i)
			{
				var name = packet.GetLpString();
				var value = packet.GetLpString();

				Log.Debug("  {0}: {1}", name, value);
			}
		}

		/// <summary>
		/// Sent regularly from the client (every 10 seconds).
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_HEARTBEAT)]
		public void CZ_HEARTBEAT(IZoneConnection conn, Packet packet)
		{
			var secondsSinceStart = packet.GetFloat();

			// If it's been more than 30 seconds since last heart beat, disconnect the client.
			if (conn.LastHeartBeat < DateTime.Now.AddSeconds(-30))
				conn.Close();
			conn.LastHeartBeat = DateTime.Now;
		}

		/// <summary>
		/// Sent when dashing.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_DASHRUN)]
		public void CZ_DASHRUN(IZoneConnection conn, Packet packet)
		{
			var b1 = packet.GetByte();
			var b2 = packet.GetByte(); // 1 = run, 0 = ?

			var character = conn.SelectedCharacter;
			if (character == null)
				return;

			// Only allow dashing for swordsmen, unless the respective
			// feature was enabled.
			if (character.JobClass != JobClass.Swordsman && !Feature.IsEnabled("DashingForAll"))
				return;

			// For some reason this packet is sent multiple times while
			// the character is dashing, which is a potential problem if
			// DashRun gets stacked and started again, but the buff manager
			// should handle it. Alternatively, we could also add a check
			// here, to see if DashRun is already active. What's better
			// is TBD.
			character.Buffs.Start(BuffId.DashRun);
		}

		/// <summary>
		/// Sent during loading screen.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_MYTHIC_DUNGEON_REQUEST_CURRENT_SEASON)]
		public void CZ_MYTHIC_DUNGEON_REQUEST_CURRENT_SEASON(IZoneConnection conn, Packet packet)
		{
		}

		/// <summary>
		/// Sent on game loaded.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_QUICKSLOT_LIST)]
		public void CZ_REQ_QUICKSLOT_LIST(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			Send.ZC_QUICK_SLOT_LIST(character);
		}

		/// <summary>
		/// Sent on game loaded.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_DO_CLIENT_MOVE_CHECK)]
		public void CZ_DO_CLIENT_MOVE_CHECK(IZoneConnection conn, Packet packet)
		{
		}

		/// <summary>
		/// Sent on Popo Shop Opening
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_PCBANG_SHOP_UI)]
		public void CZ_REQ_PCBANG_SHOP_UI(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			Send.ZC_PCBANG_SHOP_POINTSHOP_CATALOG(character);
			Send.ZC_PCBANG_SHOP_COMMON(character);
			Send.ZC_PCBANG_SHOP_POINTSHOP_BUY_COUNT(character);
		}

		/// <summary>
		/// Sent on purchasing an item from the Popo Shop
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_PCBANG_SHOP_PURCHASE)]
		public void CZ_REQ_PCBANG_SHOP_PURCHASE(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			// If can afford send ZC_PCBANG_POINT otherwise send
			// Not enough Popo Points
			Send.ZC_SYSTEM_MSG(character, 21302);
		}

		/// <summary>
		/// Sent on Popo Shop Refreshing
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_PCBANG_SHOP_REFRESH)]
		public void CZ_REQ_PCBANG_SHOP_REFRESH(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			Send.ZC_PCBANG_SHOP_POINTSHOP_CATALOG(character);
			Send.ZC_PCBANG_SHOP_COMMON(character);
			Send.ZC_PCBANG_SHOP_POINTSHOP_BUY_COUNT(character);
		}

		/// <summary>
		/// Sent on opening Beauty Shop
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_BEAUTYSHOP_INFO)]
		public void CZ_REQ_BEAUTYSHOP_INFO(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			Send.ZC_RES_BEAUTYSHOP_PURCHASED_HAIR_LIST(character);
		}

		/// <summary>
		/// Sent on opening Beauty Shop Try New Items
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SEND_BEAUTYSHOP_TRYITON_LIST)]
		public void CZ_SEND_BEAUTYSHOP_TRYITON_LIST(IZoneConnection conn, Packet packet)
		{
			var size = packet.GetShort();
			var count = packet.GetInt();

			BeautyStyle[] beautyStyles;
			if (count > 0)
			{
				beautyStyles = new BeautyStyle[count];
				for (var i = 0; i < count; i++)
				{
					beautyStyles[i] = new BeautyStyle
					{
						StyleName = packet.GetString(256),
						StyleMod = packet.GetString(256),
						StyleType = packet.GetString(256),
						Value = packet.GetInt()
					};
				}
			}
			var character = conn.SelectedCharacter;
			//Send.ZC_RES_BEAUTYSHOP_PURCHASED_HAIR_LIST(character);
		}

		/// <summary>
		/// Sent on Opening Skill Window
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_COMMON_SKILL_LIST)]
		public void CZ_REQ_COMMON_SKILL_LIST(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			Send.ZC_COMMON_SKILL_LIST(character);
		}

		/// <summary>
		/// Swap items in an inventory
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SWAP_ITEM_IN_WAREHOUSE)]
		public void CZ_SWAP_ITEM_IN_WAREHOUSE(IZoneConnection conn, Packet packet)
		{
			var fromSlot = packet.GetInt();
			var toSlot = packet.GetInt();
			var item1ObjectId = packet.GetLong();
			var item2ObjectId = packet.GetLong();

			var character = conn.SelectedCharacter;

			character.Inventory.Swap(item1ObjectId, item2ObjectId, InventoryType.Warehouse);
		}

		/// <summary>
		/// Send when clicking on a time action Cancel button.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_STOP_TIMEACTION)]
		public void CZ_STOP_TIMEACTION(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			character.Components.Get<TimeActionComponent>().End(TimeActionResult.Cancelled);
		}

		/// <summary>
		/// Sent on Opening Commander/Inventory Window
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_COMMANDER_INFO)]
		public void CZ_REQ_COMMANDER_INFO(IZoneConnection conn, Packet packet)
		{
			Send.ZC_TRUST_INFO(conn);
		}

		/// <summary>
		/// Sent on attempting to create a guild
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CHECK_USE_NAME)]
		public void CZ_CHECK_USE_NAME(IZoneConnection conn, Packet packet)
		{
			var type = packet.GetString(58);
			var name = packet.GetString(64);
			var character = conn.SelectedCharacter;

			switch (type)
			{
				case "GuildName":
					// TODO: Validate Name versus database
					if (!ZoneServer.Instance.Database.GuildNameExists(name))
						Send.ZC_ADDON_MSG(character, AddonMessage.ENABLE_CREATE_GUILD_NAME, 0, name);
					break;
			}
		}

		/// <summary>
		/// Sent on Opening Map from Quest Log
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_FIELD_BOSS_EXIST)]
		public void CZ_REQ_FIELD_BOSS_EXIST(IZoneConnection conn, Packet packet)
		{
			Send.ZC_RESPONSE_FIELD_BOSS_EXIST(conn);
		}

		/// <summary>
		/// Sent when a shop is opened?
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_OPEN_SHOP_LOG)]
		public void CZ_OPEN_SHOP_LOG(IZoneConnection conn, Packet packet)
		{
			// TODO: Log the shop type?
		}

		/// <summary>
		/// Sent when setting Custom Greeting Message
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_PC_COMMENT_CHANGE)]
		public void CZ_PC_COMMENT_CHANGE(IZoneConnection conn, Packet packet)
		{
			var type = packet.GetInt(); // 0?
			var message = packet.GetLpString();

			var character = conn.SelectedCharacter;

			if (character != null)
			{
				character.GreetingMessage = message;
				//Send.ZC_NORMAL.SetGreetingMessage(character);
			}
		}

		/// <summary>
		/// Sent to continue dialog?
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_LEARN_ABILITY)]
		public void CZ_REQ_LEARN_ABILITY(IZoneConnection conn, Packet packet)
		{
			var abilityLevelAdds = new Dictionary<int, int>();

			var size = packet.GetShort();
			var category = packet.GetString(32);
			var count = packet.GetInt();

			for (var i = 0; i < count; i++)
			{
				var abilityId = packet.GetInt();
				var level = packet.GetInt();

				abilityLevelAdds[abilityId] = level;
			}

			var character = conn.SelectedCharacter;

			var abilityTreeEntries = ZoneServer.Instance.Data.AbilityTreeDb.Find(category);
			if (!abilityTreeEntries.Any())
			{
				Log.Warning("CZ_REQ_LEARN_ABILITY: User '{0}' tried to learn abilities from an unknown category ({1}).", character.Username, category);
				return;
			}

			foreach (var kv in abilityLevelAdds)
			{
				var classId = kv.Key;
				var addLevels = Math.Max(0, kv.Value);

				var abilityTreeData = abilityTreeEntries.FirstOrDefault(a => a.ClassId == classId);
				if (abilityTreeData == null)
				{
					Log.Warning("CZ_REQ_LEARN_ABILITY: User '{0}' tried to learn the unknown ability '{1}' from category '{2}'.", character.Username, classId, category);
					return;
				}

				var abilityData = ZoneServer.Instance.Data.AbilityDb.Find(abilityTreeData.AbilityId);
				if (abilityData == null)
				{
					Log.Warning("CZ_REQ_LEARN_ABILITY: Ability data '{0}' not found for ability '{1}' from category '{2}'.", abilityTreeData.AbilityId, classId, category);
					return;
				}

				var currentLevel = character.Abilities.GetLevel(abilityData.Id);
				var newLevel = currentLevel + addLevels;
				var maxLevel = abilityTreeData.MaxLevel;

				var totalPrice = 0;
				var totalTime = 0;

				if (abilityTreeData.HasUnlockScript)
				{
					if (!ScriptableFunctions.AbilityUnlock.TryGet(abilityTreeData.UnlockScriptName, out var unlockFunc))
					{
						Log.Warning("CZ_REQ_LEARN_ABILITY: Ability unlock function '{0}' not found.", abilityTreeData.UnlockScriptName);
						return;
					}

					var canLearn = unlockFunc(character, abilityTreeData.UnlockScriptArgStr, abilityTreeData.UnlockScriptArgNum, abilityData);
					if (!canLearn)
					{
						Log.Warning("CZ_REQ_LEARN_ABILITY: User '{0}' tried to learn an ability they haven't unlocked yet (Ability: {1}, Unlock: {2}).", character.Username, abilityData.ClassName, abilityTreeData.UnlockScriptName);
						return;
					}
				}

				if (abilityTreeData.HasPriceTimeScript)
				{
					if (!ScriptableFunctions.AbilityPrice.TryGet(abilityTreeData.PriceTimeScript, out var priceTimeFunc))
					{
						Log.Warning("CZ_REQ_LEARN_ABILITY: Ability calculation function '{0}' not found.", abilityTreeData.PriceTimeScript);
						return;
					}

					for (var i = currentLevel + 1; i <= newLevel; ++i)
					{
						priceTimeFunc(character, abilityData, i, maxLevel, out var price, out var time);
						totalPrice += price;
						totalTime += time;
					}
				}

				if (character.Properties.AbilityPoints < totalPrice)
				{
					// Don't warn about this, as the client allows the
					// player to send the request even if they don't
					// have enough points.
					//Log.Warning("CZ_REQ_LEARN_ABILITY: User '{0}' didn't have enough ability points to learn all abilities.", character.Username);

					character.MsgBox(Localization.Get("You don't have enough points."));
					return;
				}

				character.Abilities.Learn(abilityData.Id, newLevel);
				character.ModifyAbilityPoints(-totalPrice);

				Send.ZC_ADDON_MSG(character, "SUCCESS_LEARN_ABILITY", newLevel, abilityData.ClassName);
				Send.ZC_ADDON_MSG(character, "RESET_ABILITY_UP", 0, null);
			}
		}

		/// <summary>
		/// Request to toggle an ability on or off.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_TOGGLE_ABILITY)]
		public void CZ_REQ_TOGGLE_ABILITY(IZoneConnection conn, Packet packet)
		{
			var abilityId = (AbilityId)packet.GetInt();

			var character = conn.SelectedCharacter;
			var ability = character.Abilities.Get(abilityId);

			if (ability == null)
			{
				Log.Warning("CZ_REQ_TOGGLE_ABILITY: User '{0}' tried to toggle an ability they don't have ({1}).", character.Username, abilityId);
				return;
			}

			ability.Active = !ability.Active;

			Send.ZC_OBJECT_PROPERTY(conn, ability, PropertyName.ActiveState);
			Send.ZC_ADDON_MSG(character, "RESET_ABILITY_ACTIVE", ability.Active ? 1 : 0, ability.Data.ClassName);
		}

		/// <summary>
		/// ToS Hero Emblems?
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQUEST_DRAW_TOSHERO_EMBLEM)]
		public void CZ_REQUEST_DRAW_TOSHERO_EMBLEM(IZoneConnection conn, Packet packet)
		{
			Send.ZC_ADDON_MSG(conn.SelectedCharacter, "TOSHERO_ZONE_ENTER", 0, null);
		}

		/// <summary>
		/// Request to view another character's information.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_PROPERTY_COMPARE)]
		public void CZ_PROPERTY_COMPARE(IZoneConnection conn, Packet packet)
		{
			var handle = packet.GetInt();
			var isView = packet.GetByte() == 1;
			var isLike = packet.GetByte() == 1;

			if (conn.SelectedCharacter.Map.TryGetCharacter(handle, out var targetCharacter))
			{
				Log.Warning("Attempted to compare an unknown character '{0}'.", handle);
				return;
			}

			Send.ZC_PROPERTY_COMPARE(conn, targetCharacter, isView);
			if (isLike)
			{
				var character = conn.SelectedCharacter;
				//TODO Send poses and rotate?
				Send.ZC_NORMAL.SkillProjectile(character, character.Position.GetRandomInRange2D(50, 100),
					"I_like_force#Dummy_bufficon", TimeSpan.FromSeconds(1), null, TimeSpan.FromSeconds(1), 3.5f, 100f);
				character.PlayEffect("F_sys_like3#Bip01 Pelvis", 2);
				character.SystemMessage("{Name}Like{Who}", new MsgParameter("Name", character.TeamName), new MsgParameter("Who", targetCharacter.TeamName));
			}
		}

		/// <summary>
		/// Sent when selecting a new language.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SELECTED_LANGUAGE)]
		public void CZ_SELECTED_LANGUAGE(IZoneConnection conn, Packet packet)
		{
			var language = packet.GetShort();

			// 0 = English, 1 = German, 2 = Portugese,
			// 4 = Indonesian, 5 = Russian, 6 = Thai
		}

		/// <summary>
		/// Request to create an auto seller shop.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REGISTER_AUTOSELLER)]
		public void CZ_REGISTER_AUTOSELLER(IZoneConnection conn, Packet packet)
		{
			var size = packet.GetShort();
			var shopName = packet.GetString(64);
			var itemCount = packet.GetInt();
			var group = packet.GetInt();

			var character = conn.SelectedCharacter;

			if (character.Connection.ShopCreated != null)
			{
				if (itemCount != -1)
				{
					Log.Warning("CZ_REGISTER_AUTOSELLER: Already has a shop open.");
					return;
				}
				var shop = character.Connection.ShopCreated;
				shop.IsClosed = true;
				Send.ZC_AUTOSELLER_LIST(character);
				Send.ZC_AUTOSELLER_TITLE(character);
				Send.ZC_NORMAL.ShopAnimation(conn, character, "Squire_Repair", 1, 0);
				character.Connection.ShopCreated = null;
			}
			else
			{
				var shop = new ShopData
				{
					Name = shopName,
					EffectId = group
				};
				switch (group)
				{
					case 8657:
						shop.Type = PersonalShopType.Buff;
						break;
					case 3076:
						shop.Type = PersonalShopType.ItemAwakening;
						break;
					case 4376:
						shop.Type = PersonalShopType.Repair;
						break;
					case 8565:
						shop.Type = PersonalShopType.Portal;
						break;
					default:
						shop.Type = PersonalShopType.Personal;
						break;
				}
				// for itemCount
				//   int itemId
				//   int amount
				//   int price
				//   byte unk1[264]
				for (var i = 0; i < itemCount; i++)
				{
					var itemId = packet.GetInt();
					var index = packet.GetInt();
					var requiredAmount = packet.GetInt();
					var price = packet.GetInt();
					var amount = packet.GetInt();
					packet.GetBin(260); // Read Additional Data (Unsure if used or not)
					var product = new ProductData();
					product.ItemId = itemId;
					product.Cost = price;
					product.Amount = amount;
					product.RequiredAmount = requiredAmount;
					shop.Products.Add(index, product);
				}
				character.Connection.ShopCreated = shop;
				Send.ZC_AUTOSELLER_LIST(conn, character);
				// Instead of using fixed values 690006 = Repair Shop
				Send.ZC_NORMAL.Shop_Unknown11C(conn, shop.EffectId, (int)shop.Type);
				// TODO: Replace with values from the UserShopPrice file or make a db with it.
				Send.ZC_NORMAL.ShopAnimation(conn, character, "Squire_Repair", 1, 1);
				Send.ZC_AUTOSELLER_TITLE(character);
				//character.MsgBox("This feature has not been implemented yet.");

				Log.Debug("CZ_REGISTER_AUTOSELLER: {0}, {1} item(s)", shopName, itemCount);
			}
		}

		/// <summary>
		/// Request to "purchase" an item from a player shop.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_OPEN_AUTOSELLER)]
		public void CZ_OPEN_AUTOSELLER(IZoneConnection conn, Packet packet)
		{
			var shopType = packet.GetInt();
			var shopOwnerHandle = packet.GetInt();
			var optionSelected = packet.GetInt();
			var amount = packet.GetInt(); // 1?
			var character = conn.SelectedCharacter;

			// Check distance, if too far from seller, send system message
			// "You're too far away from the distribution table..."
			if (!character.Map.TryGetCharacter(shopOwnerHandle, out var shopOwner) || !shopOwner.Position.InRange2D(character.Position, 25))
			{
				character.SystemMessage("FarFromFoodTable");
				return;
			}
			if (shopOwner.Connection.ShopCreated == null)
			{
				Log.Warning("CZ_OPEN_AUTOSELLER: {0} has no shop open.", conn.Account.Name);
				return;
			}
			var shop = conn.ActiveShop = shopOwner.Connection.ShopCreated;
			var product = shop.GetProduct(optionSelected);
			// If you've already eaten the buff from sandwich shop.
			// Send.ZC_SYSTEM_MSG(conn.Character, 200022);
			Send.ZC_AUTOSELLER_LIST(conn, shopOwner);
		}

		/// <summary>
		/// Request to "purchase" an item from a player shop.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_BUY_AUTOSELLER_ITEMS)]
		public void CZ_BUY_AUTOSELLER_ITEMS(IZoneConnection conn, Packet packet)
		{
			var size = packet.GetShort();
			var shopType = packet.GetInt();
			var shopOwnerHandle = packet.GetInt();
			var itemCount = packet.GetInt(); // 1?
			var character = conn.SelectedCharacter;

			// Check distance, if too far from seller, send system message
			// "You're too far away from the distribution table..."
			if (!character.Map.TryGetCharacter(shopOwnerHandle, out var shopOwner) || !shopOwner.Position.InRange2D(character.Position, 25))
			{
				character.SystemMessage("FarFromFoodTable");
				return;
			}

			if (shopOwner.Connection.ShopCreated == null)
			{
				Log.Warning("CZ_BUY_AUTOSELLER_ITEMS: {0} has no shop open.", conn.Account.Name);
				return;
			}

			var shop = conn.ActiveShop = shopOwner.Connection.ShopCreated;
			for (var i = 0; i < itemCount; i++)
			{
				var index = packet.GetInt();
				var itemId = packet.GetLong();
				var itemAmount = packet.GetInt();
				var i0 = packet.GetInt();
				var product = shop.GetProduct(index);
				if (character.Inventory.TryGetItem(itemId, out var item) && product.RequiredAmount >= itemAmount)
				{
					var sellerSilver = shopOwner.Inventory.CountItem(ItemId.Silver);
					var totalCost = product.Cost * itemAmount;
					if (sellerSilver >= totalCost && character.Inventory.Remove(itemId, itemAmount) == InventoryResult.Success
							&& shopOwner.RemoveItem(ItemId.Silver, totalCost) == totalCost)
					{
						product.RequiredAmount -= itemAmount;
						character.AddItem(ItemId.Silver, totalCost);
						shopOwner.AddItem(item.Id, itemAmount);
						Send.ZC_AUTOSELLER_LIST(shopOwner);
					}
				}
			}
			// If you've already eaten the buff from sandwich shop.
			// Send.ZC_SYSTEM_MSG(conn.Character, 200022);
			Send.ZC_AUTOSELLER_LIST(conn, shopOwner);
		}

		/// <summary>
		/// Request to close an open player shop.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_AUTTOSELLER_BUYER_CLOSE)]
		public void CZ_AUTOSELLER_BUYER_CLOSE(IZoneConnection conn, Packet packet)
		{
			var shopType = packet.GetInt();
			var shopOwnerHandle = packet.GetInt();

			var character = conn.SelectedCharacter;

			if (conn.ActiveShop == null)
			{
				Log.Warning("CZ_AUTOSELLER_BUYER_CLOSE: {0} has no shop open.", conn.Account.Name);
				return;
			}
			var shop = conn.ActiveShop;

			if (!character.Map.TryGetCharacter(shopOwnerHandle, out var shopOwner))
			{
				Log.Warning("CZ_AUTOSELLER_BUYER_CLOSE: {0} shop owner not found.", conn.Account.Name);
				return;
			}

			if (shop != shopOwner.Connection.ShopCreated)
			{
				Log.Warning("CZ_AUTOSELLER_BUYER_CLOSE: {0} tried to close a different shop than the one open.", conn.Account.Name);
				return;
			}

			conn.ShopCreated = null;
			Send.ZC_ENABLE_CONTROL(conn, "AUTOSELLER", true);
			Send.ZC_LOCK_KEY(character, "AUTOSELLER", false);
			switch (shopType)
			{
				case 2:
					Send.ZC_EXEC_CLIENT_SCP(conn, ClientScripts.SQUIRE_REPAIR_CANCEL);
					break;
				default:
					Log.Warning("CZ_AUTOSELLER_BUYER_CLOSE: {0} shop type close not implemented.", shopType);
					break;
			}
		}

		/// <summary>
		/// Client ping request, sent through (//ping).
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_PING)]
		public void CZ_PING(IZoneConnection conn, Packet packet)
		{
			Send.ZC_PING(conn);
		}

		/// <summary>
		/// Set a character label (title).
		/// </summary>
		[PacketHandler(Op.CZ_CHANGE_TITLE)]
		public void CZ_CHANGE_TITLE(IZoneConnection conn, Packet packet)
		{
			var title = packet.GetString(64);

			Send.ZC_NORMAL.ActorLabel(conn.SelectedCharacter, title);
		}

		/// <summary>
		/// Request to pick up an item.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_ITEM_GET)]
		public void CZ_REQ_ITEM_GET(IZoneConnection conn, Packet packet)
		{
			var handle = packet.GetInt();

			var character = conn.SelectedCharacter;
			var monster = character.Map.GetMonster(handle);

			// Check for monster validity
			if (monster == null)
			{
				// Don't warn as it happens quite frequently when two
				// players stand in range of a dropped item.
				//Log.Warning("CZ_REQ_ITEM_GET: User '{0}' tried to pick up an item that doesn't exist.", conn.Account.Name);
				return;
			}

			if (!(monster is ItemMonster itemMonster))
			{
				Log.Warning("CZ_REQ_ITEM_GET: User '{0}' tried to pick up a monster that is not an item.", conn.Account.Name);
				return;
			}

			// Accept pick ups only once the character is close enough.
			var pickUpRadius = ZoneServer.Instance.Conf.World.PickUpRadius;
			if (!monster.Position.InRange2D(character.Position, pickUpRadius))
				return;

			// Check if character is allowed to pick up the item.
			if (!itemMonster.CanBePickedUpBy(character))
				return;

			character.PickUp(itemMonster);
		}

		/// <summary>
		/// Sent when clicking Confirm in a shop, with items in the "Sold" list.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_ITEM_LIST)]
		public void CZ_REQ_ITEM_LIST(IZoneConnection conn, Packet packet)
		{
			var type = (InventoryType)packet.GetByte(); // 1 = Personal Storage, 6 = Team Storage

			var character = conn.SelectedCharacter;

			if (!Enum.IsDefined(typeof(InventoryType), type))
			{
				Log.Warning("CZ_REQ_ITEM_LIST: Unknown type requested '{0}'.", type);
				return;
			}

			IList<Item> items;
			switch (type)
			{
				case InventoryType.Warehouse:
					items = character.Inventory.GetWarehouseItems();
					break;
				default:
					items = new List<Item>();
					break;
			}
			// ToDo load list of warehouse items and send them
			// Currently sending an empty list
			Send.ZC_SOLD_ITEM_DIVISION_LIST(character, type, items);
		}

		[PacketHandler(Op.CZ_REQ_ACC_WARE_VIS_LOG)]
		public void CZ_REQ_ACC_WARE_VIS_LOG(IZoneConnection conn, Packet packet)
		{
			Send.ZC_NORMAL.StorageSilverTransactions(conn.SelectedCharacter);
		}

		/// <summary>
		/// Request for the latest channel traffic data, sent when the
		/// player opens the channel selection in-game.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_CHANNEL_TRAFFICS)]
		public void CZ_REQ_CHANNEL_TRAFFICS(IZoneConnection conn, Packet packet)
		{
			var serverGroupId = packet.GetShort();

			Send.ZC_NORMAL.ChannelTraffic(conn.SelectedCharacter);
		}

		/// <summary>
		/// Request to change the channel.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CHANGE_CHANNEL)]
		public void CZ_CHANGE_CHANNEL(IZoneConnection conn, Packet packet)
		{
			var channelId = packet.GetShort();

			conn.SelectedCharacter.WarpChannel(channelId);
		}

		/// <summary>
		/// Sent when attacking with sub-weapon.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_HARDCODED_ITEM)]
		public void CZ_HARDCODED_ITEM(IZoneConnection conn, Packet packet)
		{
			var s1 = packet.GetShort();
			var itemId = packet.GetLong();

			// Do something with this information? It sends the id of
			// the sub-weapon, so perhaps the client is telling us which
			// weapon to attack with, but it uses a different skill for
			// sub-weapon attacks, so we don't need this information. The
			// same packet also appears to be sent twice for some reason.
			// We'll just leave this empty for now.
		}

		[PacketHandler(Op.CZ_CLIENT_DIRECT)]
		public void CZ_CLIENT_DIRECT(IZoneConnection conn, Packet packet)
		{
			var type = packet.GetInt();
			var param = packet.GetString(16);

			Send.ZC_CLIENT_DIRECT(conn, type, param);
		}

		/// <summary>
		/// Sent when transferring item between Warehouse and Inventory
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_WAREHOUSE_CMD)]
		public void CZ_WAREHOUSE_CMD(IZoneConnection conn, Packet packet)
		{
			var b1 = packet.GetByte();
			var worldId = packet.GetLong();
			var i1 = packet.GetInt();
			var amount = packet.GetInt();
			var unkInt = packet.GetInt();
			var warehouseCommandType = packet.GetByte(); // 0 = IN 1 = OUT

			var character = conn.SelectedCharacter;

			// Get item
			if (!character.Inventory.TryGetItem(worldId, out var item))
			{
				Log.Warning("CZ_WAREHOUSE_CMD: User '{0}' tried to store a non-existent item.", conn.Account.Name);
				return;
			}

			// Check amount
			if (item.Amount < amount)
			{
				Log.Warning("CZ_WAREHOUSE_CMD: User '{0}' tried to store more of an item than they own.", conn.Account.Name);
				return;
			}

			// Charge Player 20 silver for use
			character.Inventory.Remove(ItemId.Silver, 20, InventoryItemRemoveMsg.Given); // Fixed Cost

			if (warehouseCommandType == 0)
			{
				// Try to remove item from inventory
				if (character.Inventory.Remove(item, amount, InventoryItemRemoveMsg.Sold) != InventoryResult.Success)
				{
					Log.Warning("CZ_WAREHOUSE_CMD: Failed to remove an item from user '{0}' inventory.", conn.Account.Name);
					return;
				}
				if (item.Amount > 0)
				{
					item = new Item(item.Id, amount);
				}
				// Try to add item to warehouse
				character.Inventory.Add(item, InventoryAddType.New, InventoryType.Warehouse);
			}
			else
			{
				// Try to remove item from warehouse
				if (character.Inventory.Remove(item.ObjectId, amount, InventoryItemRemoveMsg.Sold, InventoryType.Warehouse) != InventoryResult.Success)
				{
					Log.Warning("CZ_WAREHOUSE_CMD: Failed to remove an item from user '{0}' inventory.", conn.Account.Name);
					return;
				}
				// Try to add item to inventory
				character.Inventory.Add(item);
			}
		}

		/// <summary>
		/// When warping from warp function
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.ZC_CLIENT_DIRECT)]
		public void ZC_CLIENT_DIRECT(IZoneConnection conn, Packet packet)
		{
			var command = packet.GetByte();

			// ZC_SET_POS
			// ZC_RESET_VIEW
			// ZC_ENTER_PC
			// ZC_ADD_HP
			// ZC_UPDATE_SP
			// ZC_RESURRECT_SAVE_POINT_ACK
			var character = conn.SelectedCharacter;
			if (command == 1)
			{
				Send.ZC_RESET_VIEW(conn);
				Send.ZC_SET_POS(character);
				Send.ZC_ENTER_PC(conn, character);
				Send.ZC_NORMAL.Revive(character);
				character.Heal();
				//character.Heal(HealType.Hp, character.MaxHp / 2);
				//character.Heal(HealType.Sp, character.Sp);
				Send.ZC_RESURRECT_SAVE_POINT_ACK(character);

			}
		}

		/// <summary>
		/// When visiting a player house
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_HOUSING_REQUEST_POST_HOUSE_WARP)]
		public void CZ_HOUSING_REQUEST_POST_HOUSE_WARP(IZoneConnection conn, Packet packet)
		{
			var accountId = packet.GetLong(); // characterId?
			var character = conn.SelectedCharacter;

			//Send.ZC_SYSTEM_MSG(character, 519083);
			character.EtcProperties.SetString(PropertyName.PersonalHousingPrevZoneName, character.Map.Id.ToString());
			character.EtcProperties.SetFloat(PropertyName.PersonalHousingPrevZonePos_x, character.Position.X);
			character.EtcProperties.SetFloat(PropertyName.PersonalHousingPrevZonePos_y, character.Position.Y);
			character.EtcProperties.SetFloat(PropertyName.PersonalHousingPrevZonePos_z, character.Position.Z);
			Send.ZC_PC_PROP_UPDATE(character, (short)PropertyTable.GetId("PCEtc", PropertyName.PersonalHousingPrevZonePos_x), 1);
			Send.ZC_PC_PROP_UPDATE(character, (short)PropertyTable.GetId("PCEtc", PropertyName.PersonalHousingPrevZonePos_y), 1);
			Send.ZC_PC_PROP_UPDATE(character, (short)PropertyTable.GetId("PCEtc", PropertyName.PersonalHousingPrevZonePos_z), 1);
			Send.ZC_SAVE_INFO(conn);
			// Warp to personal house
			character.Warp(7000, new Position(200, 2200, 1000));
		}

		/// <summary>
		/// Accepting a party invite
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_PARTY_INVITE_ACCEPT)]
		public void CZ_PARTY_INVITE_ACCEPT(IZoneConnection conn, Packet packet)
		{
			var b1 = packet.GetByte();
			var teamName = packet.GetString();
			var character = conn.SelectedCharacter;
			var sender = ZoneServer.Instance.World.GetCharacterByTeamName(teamName);

			if (sender != null)
			{
				var party = sender.Connection.Party;
				party ??= ZoneServer.Instance.World.Parties.Create(sender);
				party.AddMember(character);
			}
		}

		/// <summary>
		/// Rejecting a party invite
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_PARTY_INVITE_CANCEL)]
		public void CZ_PARTY_INVITE_CANCEL(IZoneConnection conn, Packet packet)
		{
			var b1 = packet.GetByte();
			var teamName = packet.GetString();

			var character = conn.SelectedCharacter;
			var partyInviter = ZoneServer.Instance.World.GetCharacterByTeamName(teamName);

			if (partyInviter != null)
			{
				Send.ZC_ADDON_MSG(partyInviter, AddonMessage.PARTY_INVITE_CANCEL, 0, character.TeamName);
			}
		}

		/// <summary>
		/// Leaving a party
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_PARTY_OUT)]
		public void CZ_PARTY_OUT(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			var party = character.Connection.Party;

			if (party != null)
			{
				party.RemoveMember(character);
				if (party.MemberCount == 0)
					ZoneServer.Instance.World.Parties.Delete(party);
			}
		}

		/// <summary>
		/// Changing Party Settings
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_PARTY_PROP_CHANGE)]
		public void CZ_PARTY_PROP_CHANGE(IZoneConnection conn, Packet packet)
		{
			var b1 = packet.GetByte();
			var type = packet.GetInt();
			var b2 = packet.GetByte();
			var b3 = packet.GetByte();
			var s1 = packet.GetShort();
			var value = packet.GetString();

			var character = conn.SelectedCharacter;
			var party = character.Connection.Party;

			if (party != null && party.LeaderDbId == character.DbId)
			{
				party.UpdateSetting(type, value);
			}
		}

		[PacketHandler(Op.CZ_REQ_MARKET_REGISTER)]
		public void CZ_REQ_MARKET_REGISTER(IZoneConnection conn, Packet packet)
		{
			var itemWorldId = packet.GetLong();
			var itemAmount = packet.GetInt();
			var itemId = packet.GetInt();
			var itemPrice = packet.GetLong();
			var s1 = packet.GetShort();
			var s2 = packet.GetShort();
			var i1 = packet.GetInt();
			var saleLength = packet.GetInt();

			var character = conn.SelectedCharacter;
			var fee = 0;
			var item = character.Inventory.GetItem(itemWorldId);

			if (item == null)
			{
				Log.Warning("CZ_REQ_MARKET_REGISTER: User '{0}' tried to sell a non-existent item.", conn.Account.Name);
				return;
			}

			var commissionFee = saleLength switch
			{
				1 => 0.005f,
				3 => 0.0075f,
				5 => 0.01f,
				_ => 0.0125f,
			};
			fee += (int)Math.Truncate(itemPrice * commissionFee);

			if (!character.HasItem(ItemId.Silver, fee))
			{
				Log.Warning("CZ_REQ_MARKET_REGISTER: User '{0}' failed to remove registration fee.", conn.Account.Name);
				return;
			}

			Send.ZC_OBJECT_PROPERTY(character.Connection, item);
			Send.ZC_ADDON_MSG(conn.SelectedCharacter, AddonMessage.MARKET_REGISTER, 0, "None");

			//Remove Item and Cost from Inventory
			if (character.Inventory.Remove(itemWorldId, itemAmount, InventoryItemRemoveMsg.Given) != InventoryResult.Success)
			{
				Log.Warning("CZ_REQ_MARKET_REGISTER: User '{0}' failed to remove item.", conn.Account.Name);
				return;
			}

			character.RemoveItem(ItemId.Silver, fee);
			ZoneServer.Instance.Database.SaveMarketItem(character, item, itemPrice, saleLength);
			Send.ZC_RELOAD_SELL_LIST(character);
		}

		[PacketHandler(Op.CZ_REQ_MARKET_MINMAX_INFO)]
		public void CZ_REQ_MARKET_MINMAX_INFO(IZoneConnection conn, Packet packet)
		{
			var itemWorldId = packet.GetLong();
			var character = conn.SelectedCharacter;

			if (!character.Inventory.TryGetItem(itemWorldId, out var item))
			{
				Log.Warning("CZ_REQ_MARKET_MINMAX_INFO: User '{0}' tried to sell a non-existent item.", conn.Account.Name);
				return;
			}

			// If no prices are found.
			character.SystemMessage("MarketMinMaxInfo_None");
			// TODO: Calculate Market Min/Max Price
			Send.ZC_NORMAL.MarketMinMaxInfo(character, true, 113, 56, 453, 2265, 283);
		}

		[PacketHandler(Op.CZ_REQ_MARKET_BUY)]
		public void CZ_REQ_MARKET_BUY(IZoneConnection conn, Packet packet)
		{
			var size = packet.GetShort();
			var count = packet.GetInt();
			var marketWorldId = packet.GetLong();
			var itemAmount = packet.GetInt();

			var character = conn.SelectedCharacter;
			if (!ZoneServer.Instance.Database.GetMarketItem(marketWorldId, out var item))
			{
				Log.Warning("CZ_REQ_MARKET_BUY: User '{0}' failed to find market item {1}.", conn.Account.Name, marketWorldId);
				return;
			}

			if (itemAmount > item.Count || itemAmount <= 0)
			{
				Log.Warning("CZ_REQ_MARKET_BUY: User '{0}' not enough quantity of the market item {1} - {2} > {3}.", conn.Account.Name, marketWorldId, itemAmount, item.Count);
				return;
			}

			var totalPrice = item.SellPrice * itemAmount;
			var remainAmount = item.Count - itemAmount;
			if (!character.HasItem(ItemId.Silver, totalPrice))
				return;
			Send.ZC_NORMAL.MarketBuyItem(character, marketWorldId, remainAmount, 0);
			character.RemoveItem(ItemId.Silver, totalPrice);
			ZoneServer.Instance.Database.ModifyItemAmount(item.ItemGuid, -itemAmount);
			ZoneServer.Instance.Database.UpdateMarketItemBuyer(marketWorldId, character.DbId);
			Send.ZC_NORMAL.MarketRetrieveItem(character, item.ItemGuid);

		}

		[PacketHandler(Op.CZ_REQ_CABINET_LIST)]
		public void CZ_REQ_CABINET_LIST(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			var items = ZoneServer.Instance.Database.GetMarketItems(character);

			Send.ZC_NORMAL.MarketRetrievalItems(character, items);
		}

		[PacketHandler(Op.CZ_REQ_GET_CABINET_ITEM)]
		public void CZ_REQ_GET_CABINET_ITEM(IZoneConnection conn, Packet packet)
		{
			var itemWorldId = packet.GetLong();
			var itemId = packet.GetInt();
			var itemAmount = packet.GetInt();

			var character = conn.SelectedCharacter;
			if (!ZoneServer.Instance.Database.GetMarketItem(character.DbId, itemWorldId, out var item))
			{
				Log.Warning("CZ_REQ_GET_CABINET_ITEM: User '{0}' failed to find market item {1}.", conn.Account.Name, itemWorldId);
				return;
			}

			if (item.ItemType != itemId || item.Count != itemAmount)
			{
				Log.Warning("CZ_REQ_GET_CABINET_ITEM: User '{0}' market item found doesn't match {1} - {2}:{3} != {4}:{5}.", conn.Account.Name, itemWorldId, item.ItemType, item.Count, itemId, itemAmount);
				return;
			}
			if (!item.HasReceivedItem)
			{
				var retrievedItem = new Item(item.ItemGuid, item.ItemType, item.Count);
				if (!character.Inventory.Add(retrievedItem))
				{
					Log.Warning("CZ_REQ_GET_CABINET_ITEM: User '{0}' failed to add item to inventory.", conn.Account.Name, itemWorldId, item.ItemType, item.Count, itemId, itemAmount);
					return;
				}
				item.Status = MarketItemStatus.ItemReceived;
				ZoneServer.Instance.Database.UpdateMarketItemStatus(character.DbId, item.Status);
				Send.ZC_NORMAL.MarketRetrieveItem(character, item.ItemGuid);
			}
			else if (character.DbId == item.SellerId && item.IsSold && !item.HasReceivedSilver)
			{
				var retrievedSilver = new Item(ItemId.Silver, item.SellPrice);
				if (!character.Inventory.Add(retrievedSilver))
				{
					Log.Warning("CZ_REQ_GET_CABINET_ITEM: User '{0}' failed to add item to inventory.", conn.Account.Name, itemWorldId, item.ItemType, item.Count, itemId, itemAmount);
					return;
				}
				item.Status = MarketItemStatus.SilverReceived;
				ZoneServer.Instance.Database.UpdateMarketItemStatus(character.DbId, item.Status);
				Send.ZC_NORMAL.MarketRetrieveItem(character, item.ItemGuid);
			}
		}

		[PacketHandler(Op.CZ_REQ_CANCEL_MARKET_ITEM)]
		public void CZ_REQ_CANCEL_MARKET_ITEM(IZoneConnection conn, Packet packet)
		{
			var marketWorldId = packet.GetLong();
			var character = conn.SelectedCharacter;

			if (!ZoneServer.Instance.Database.CancelMarketItem(character, marketWorldId))
			{
				Log.Warning("CZ_REQ_CANCEL_MARKET_ITEM: User '{0}' failed to cancel market item {1}.", conn.Account.Name, marketWorldId);
				return;
			}
			Send.ZC_NORMAL.MarketCancelItem(character, marketWorldId);
			Send.ZC_RELOAD_SELL_LIST(character);
		}

		/// <summary>
		/// Client request to summon a companion
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SUMMON_PET)]
		public void CZ_SUMMON_PET(IZoneConnection conn, Packet packet)
		{
			var companionId = packet.GetLong();
			var petId = packet.GetInt();
			var i1 = packet.GetInt();

			if (companionId != 0)
			{
				var character = conn.SelectedCharacter;
				var companion = character.Companions.GetCompanion(companionId);

				if (companion != null && companion.ObjectId == companionId)
					companion.SetCompanionState(!companion.IsActivated);
			}
		}

		/// <summary>
		/// Ride pet request
		/// </summary>
		[PacketHandler(Op.CZ_VEHICLE_RIDE)]
		public void CZ_VEHICLE_RIDE(IZoneConnection conn, Packet packet)
		{
			var petHandle = packet.GetInt();
			var isRiding = packet.GetByte() == 1;

			var character = conn.SelectedCharacter;
			var monster = character.Map.GetMonster(petHandle);

			if (monster is Companion companion && companion.Owner.ObjectId == character.ObjectId)
			{
				if (isRiding)
				{
					character.Components.Get<BuffComponent>()?.Start(BuffId.RidingCompanion);
					companion.Components.Get<BuffComponent>()?.Start(BuffId.TakingOwner);
					// This is buff logic
					character.Properties.Modify(PropertyName.MSPD_BM, 4f);
					character.Properties.Modify(PropertyName.DR_BM, 3f);
					character.Properties.Modify(PropertyName.DEF_BM, 12f);
					Send.ZC_OBJECT_PROPERTY(character, PropertyName.MSPD, PropertyName.MSPD_BM,
						PropertyName.DR, PropertyName.DR_BM, PropertyName.MHP, PropertyName.MHP_RATE_BM,
						PropertyName.DEF, PropertyName.DEF_BM);
					Send.ZC_MOVE_SPEED(character);
				}
				else
				{
					character.Components.Get<BuffComponent>()?.Remove(BuffId.RidingCompanion);
					companion.Components.Get<BuffComponent>()?.Remove(BuffId.TakingOwner);
					character.Properties.Modify(PropertyName.MSPD_BM, -4f);
					character.Properties.Modify(PropertyName.DR_BM, -3f);
					character.Properties.Modify(PropertyName.DEF_BM, -12f);
					Send.ZC_OBJECT_PROPERTY(character, PropertyName.MSPD, PropertyName.MSPD_BM,
						PropertyName.DR, PropertyName.DR_BM, PropertyName.MHP, PropertyName.MHP_RATE_BM,
						PropertyName.DEF, PropertyName.DEF_BM);
					Send.ZC_MOVE_SPEED(character);
				}
				companion.IsRiding = isRiding;
				Send.ZC_NORMAL.PetIsInactive(conn, companion);
				Send.ZC_NORMAL.RidePet(character, companion);
			}
		}

		/// <summary>
		/// Client requests to "Equip" an achievement title
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ACHIEVE_EQUIP)]
		public void CZ_ACHIEVE_EQUIP(IZoneConnection conn, Packet packet)
		{
			var achievementId = packet.GetInt();

			var character = conn.SelectedCharacter;

			// TODO check if character has achievementUnlocked
			Send.ZC_ACHIEVE_EQUIP(character, achievementId);
		}

		/// <summary>
		/// Client requests to continue a track (cutscene)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_DIRECTION_PROCESS)]
		public void CZ_DIRECTION_PROCESS(IZoneConnection conn, Packet packet)
		{
			var i1 = packet.GetInt();
			var handle = packet.GetInt();
			var frame = packet.GetInt();

			var character = conn.SelectedCharacter;

			if (character != null && character.Handle == handle && character.Tracks.ActiveTrack != null)
			{
				// Need to get all possible quest dialogs based on quest state
				var track = character.Tracks.ActiveTrack;
				character.Tracks.Progress(track.Id, frame);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_DIRECTION_MOVE_STATE)]
		public void CZ_DIRECTION_MOVE_STATE(IZoneConnection conn, Packet packet)
		{
			var packetSize = packet.GetShort();
			int count = ((packet.Length - 24) / 28) - 2;

			var character = conn.SelectedCharacter;
			var track = character.Tracks.ActiveTrack;
			if (character != null && track != null)
			{
				// Need to get all possible quest dialogs based on quest state
				track.Frame = -2;
				Send.ZC_NORMAL.SetTrackFrame(character, track.Frame);
				if (count != track.Actors.Count())
				{
					Log.Warning("CZ_DIRECTION_MOVE_STATE: Count mismatch {0} != {1}", count, track.Actors.Count());
				}
				foreach (var entity in track.Actors)
				{
					var direction = packet.GetDirection();
					var position = packet.GetPosition();
					var f1 = packet.GetFloat();
					var f2 = packet.GetFloat();

					//if (entity.Direction != Direction.South && position != Position.Zero)
					//	entity.SetDirection(direction);
					if (position != Position.Zero)
					{
						if (entity is Character character1)
						{
							character1.SetPosition(position);
							Send.ZC_SET_POS(character1);
						}
					}
				}
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//character.Tracks.Progress(track.Id, frame);
			}
		}

		/// <summary>
		/// Check quest state for NPCs
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_QUEST_NPC_STATE_CHECK)]
		public void CZ_QUEST_NPC_STATE_CHECK(IZoneConnection conn, Packet packet)
		{
			var questId = packet.GetInt();

			var character = conn.SelectedCharacter;

			if (character != null)
			{
				//character.HasQuest(questId)
			}
		}

		/// <summary>
		/// Rank System Time Table ?
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQUEST_RANK_SYSTEM_TIME_TABLE)]
		public void CZ_REQUEST_RANK_SYSTEM_TIME_TABLE(IZoneConnection conn, Packet packet)
		{
			var i1 = packet.GetInt();

			Send.ZC_RESPONSE_RANK_SYSTEM_TIME_TABLE(conn);
		}

		/// <summary>
		/// Request Current Week # for Weekly Boss
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQUEST_WEEKLY_BOSS_NOW_WEEK_NUM)]
		public void CZ_REQUEST_WEEKLY_BOSS_NOW_WEEK_NUM(IZoneConnection conn, Packet packet)
		{
			Send.ZC_WEEKLY_BOSS_NOW_WEEK_NUM(conn, 1);
		}

		/// <summary>
		/// Request Current Week # for Guild Raid (Boruta)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQUEST_BORUTA_NOW_WEEK_NUM)]
		public void CZ_REQUEST_BORUTA_NOW_WEEK_NUM(IZoneConnection conn, Packet packet)
		{
			Send.ZC_RESPONSE_BORUTA_NOW_WEEK_NUM(conn, 1);
		}

		/// <summary>
		/// Weekly Boss Start Time
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQUEST_WEEKLY_BOSS_END_TIME)]
		public void CZ_REQUEST_WEEKLY_BOSS_START_TIME(IZoneConnection conn, Packet packet)
		{
			var weekNum = packet.GetInt();

			//TODO check date time by weekNum
			Send.ZC_WEEKLY_BOSS_START_TIME(conn.SelectedCharacter);
		}

		/// <summary>
		/// Weekly Boss End Time
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQUEST_WEEKLY_BOSS_END_TIME)]
		public void CZ_REQUEST_WEEKLY_BOSS_END_TIME(IZoneConnection conn, Packet packet)
		{
			var weekNum = packet.GetInt();

			//TODO check date time by weekNum
			Send.ZC_WEEKLY_BOSS_END_TIME(conn.SelectedCharacter);
		}


		[PacketHandler(Op.CZ_HOUSING_OPEN_EDIT_MODE)]
		public void CZ_HOUSING_OPEN_EDIT_MODE(IZoneConnection conn, Packet packet)
		{
			if (conn.ActiveHouse == null)
				return;
			conn.ActiveHouse.SetEditMode(true);
		}

		[PacketHandler(Op.CZ_HOUSING_REQUEST_GRID_ARRANGED_FURNITURE)]
		public void CZ_HOUSING_REQUEST_GRID_ARRANGED_FURNITURE(IZoneConnection conn, Packet packet)
		{
			if (conn.ActiveHouse == null)
				return;
			var character = conn.SelectedCharacter;

			conn.ActiveHouse.ShowGrid(character);
		}

		/// <summary>
		/// Dummy (Unknown Purpose)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_HOUSING_REQUEST_ARRANGED_FURNITURE)]
		public void CZ_HOUSING_REQUEST_ARRANGED_FURNITURE(IZoneConnection conn, Packet packet)
		{
			if (conn.ActiveHouse == null)
			{
				Log.Warning("CZ_HOUSING_CLOSE_EDIT_MODE: User '{0}' doesn't have an active personal house.", conn.Account.Name);
				return;
			}
		}

		/// <summary>
		/// Personal House close Edit mode
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_HOUSING_CLOSE_EDIT_MODE)]
		public void CZ_HOUSING_CLOSE_EDIT_MODE(IZoneConnection conn, Packet packet)
		{
			if (conn.ActiveHouse == null)
			{
				Log.Warning("CZ_HOUSING_CLOSE_EDIT_MODE: User '{0}' doesn't have an active personal house.", conn.Account.Name);
				return;
			}

			conn.ActiveHouse.SetEditMode(false);
		}

		/// <summary>
		/// Housing Request Group List?
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_PERSONAL_HOUSING_REQUEST_GROUP_LIST)]
		public void CZ_PERSONAL_HOUSING_REQUEST_GROUP_LIST(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			if (conn.ActiveHouse == null)
			{
				Log.Warning("CZ_PERSONAL_HOUSING_REQUEST_GROUP_LIST: User '{0}' doesn't have an active personal house.", conn.Account.Name);
				return;
			}

			Send.ZC_PERSONAL_HOUSING_ANSWER_GROUP_LIST(character);
		}

		/// <summary>
		/// A request to combine ancient cards
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ANCIENT_CARD_COMBINE)]
		public void CZ_ANCIENT_CARD_COMBINE(IZoneConnection conn, Packet packet)
		{
			var cardCount = packet.GetInt();
			var itemWorldIds = packet.GetList(cardCount, packet.GetLong);

			var character = conn.SelectedCharacter;

			//conn.Account.AssisterCabinet.TryGet();
		}

		/// <summary>
		/// A request to evolve an ancient card.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_ANCIENT_CARD_EVOLVE)]
		public void CZ_ANCIENT_CARD_EVOLVE(IZoneConnection conn, Packet packet)
		{
			var cardCount = packet.GetInt();
			var itemWorldIds = packet.GetList(cardCount, packet.GetLong);

			var character = conn.SelectedCharacter;

			//conn.Account.AssisterCabinet.TryGet();
		}

		[PacketHandler(Op.CZ_CANCEL_PAIR_ANIMATION)]
		public void CZ_CANCEL_PAIR_ANIMATION(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			if (character.IsPaired)
			{
				character.IsPaired = false;
				Send.ZC_ENABLE_CONTROL(conn, "MOVE_PC", true);
				Send.ZC_PLAY_PAIR_ANIMATION(character, "None", false);
				Send.ZC_FLY(character);
			}
		}

		/// <summary>
		/// Requests the server to perform various commands upon a dummy PC.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_DUMMYPC_INFO)]
		public void CZ_REQ_DUMMYPC_INFO(IZoneConnection conn, Packet packet)
		{
			var handle = packet.GetInt();
			var command = packet.GetInt();

			if (!conn.SelectedCharacter.Map.TryGetCharacter(handle, out var targetCharacter))
			{
				Log.Warning("CZ_REQ_DUMMYPC_INFO: Failed to find character with handle {0}, for account {1}.", handle, conn.Account.Name);
				return;
			}

			switch (command)
			{
				case 4:
					Send.ZC_DIALOG_SELECT(conn, targetCharacter.Name + "*@* ", "@dicID_^*$ETC_20170313_027457$*^", "@dicID_^*$ETC_20150317_004134$*^", "@dicID_^*$ETC_20150317_004148$*^");
					break;
			}
		}

		[PacketHandler(Op.CZ_VISIT_BARRACK)]
		public void CZ_VISIT_BARRACK(IZoneConnection conn, Packet packet)
		{
			var teamName = packet.GetString();
			var character = ZoneServer.Instance.World.GetCharacterByTeamName(teamName);

			if (character == null)
			{
				Log.Warning("CZ_VISIT_BARRACK: Failed to find character with team name {0}, for account {1}.", teamName, conn.Account.Name);
				return;
			}
			Send.ZC_SAVE_INFO(conn);
			Send.ZC_MOVE_BARRACK(conn);
		}

		/// <summary>
		/// Request player fight (DUMMY)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_FRIENDLY_FIGHT)]
		public void CZ_REQ_FRIENDLY_FIGHT(IZoneConnection conn, Packet packet)
		{
			var handle = packet.GetInt();
			var b1 = packet.GetByte();

			var receiver = conn.SelectedCharacter;
			if (receiver == null)
			{
				Log.Warning("CZ_REQ_FRIENDLY_FIGHT: User '{0}'s character not found.", conn.Account.Name);
				return;
			}

			if (!receiver.Map.TryGetCharacter(handle, out var requester))
			{
				Log.Warning("CZ_REQ_FRIENDLY_FIGHT: User '{0}' tried to respond to a player with handle ({1}) that doesn't exist on the map.", conn.Account.Name, handle);
				return;
			}

			// If they accept
			Send.ZC_FRIENDLY_STATE(conn, true);
			Send.ZC_NORMAL.FightState(conn, requester, true);
			Send.ZC_CHANGE_RELATION(conn, handle, true);

			Send.ZC_FRIENDLY_STATE(requester.Connection, true);
			Send.ZC_NORMAL.FightState(conn, requester, true);
			Send.ZC_CHANGE_RELATION(requester.Connection, handle, true);
		}

		/// <summary>
		/// Leave personal house (DUMMY)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_PERSONAL_HOUSING_REQUEST_LEAVE)]
		public void CZ_PERSONAL_HOUSING_REQUEST_LEAVE(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			var house = conn.ActiveHouse;
			if (house != null)
			{
				conn.ActiveHouse = null;
				var lastMapId = (int)character.EtcProperties.GetFloat(PropertyName.LastWarpMapID, 1001);
				if (ZoneServer.Instance.World.Maps.TryGet(lastMapId, out var map) && map.Ground.TryGetRandomPosition(out var rndPos))
					character.Warp(map.Id, rndPos);
			}
		}

		/// <summary>
		/// Solo Dungeon Enter (DUMMY)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SOLO_INDUN_ENTER)]
		public void CZ_SOLO_INDUN_ENTER(IZoneConnection conn, Packet packet)
		{
			var dungeonId = packet.GetInt(); // 202
			var i1 = packet.GetInt(); // 1
			var i2 = packet.GetInt(); // 0

			var dungeon = ZoneServer.Instance.Data.InstanceDungeonDb.Find(dungeonId);
			if (dungeon == null)
			{
				Log.Warning("CZ_SOLO_INDUN_ENTER: User '{0}' tried to enter dungeon with id ({1}) that doesn't exist.", conn.Account.Name, dungeonId);
				return;
			}

			// TODO Check Entry Qualifications
		}

		[PacketHandler(Op.CZ_QUEST_CHECK_SAVE)]
		public void CZ_QUEST_CHECK_SAVE(IZoneConnection conn, Packet packet)
		{
			var questId = packet.GetInt();
			//var quest = ZoneServer.Instance.Data.QuestDb.Find(questId);

			//if (quest == null)
			{
				//Log.Warning("CZ_QUEST_CHECK_SAVE: User '{0}' tried to save non-existent quest with Id: {1}.", conn.Account.Name, questId);
			}
			// TODO Do something with this?
		}

		/// <summary>
		/// Request Used Medal Total
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQUEST_USED_MEDAL_TOTAL)]
		public void CZ_REQUEST_USED_MEDAL_TOTAL(IZoneConnection conn, Packet packet)
		{
			var medals = conn.Account.Medals;

			Send.ZC_NORMAL.UsedMedalTotal(conn, medals);
		}

		/// <summary>
		/// Sent when offering to Goddess Grace Event
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_BID_FIELDBOSS_WORLD_EVENT)]
		public void CZ_BID_FIELDBOSS_WORLD_EVENT(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;
			var fixedCost = 50000;
			if (character.Inventory.CountItem(ItemId.Silver) < fixedCost)
			{
				Send.ZC_SYSTEM_MSG(character, 10236);
				return;
			}
			// Pick a random item based on weights?
			/**
			var possibleItems = new List<WeightedListItem<string>>
			{
				new WeightedListItem<string>("VakarineCertificateCoin_100p", 10),
				new WeightedListItem<string>("VakarineCertificateCoin_1000p", 1),
			};
			var weightedItems = new WeightedList<string>(possibleItems);
			var itemClassName = weightedItems.Next();
			var itemData = ZoneServer.Instance.Data.ItemDb.FindByClass(itemClassName);
			if (itemData != null)
			{
				Send.ZC_NORMAL.SteamAchievement(character, SteamAchievement.TOS_STEAM_ACHIEVEMENT_GOD_PROTECTION);
				character.RemoveItem(ItemId.Silver, fixedCost);
				character.AddItem(itemData.Id);
				Send.ZC_LOSE_FIELDBOSS_WORLD_EVENT_ITEM(character, itemData.Id);
			}
			**/
		}

		[PacketHandler(Op.CZ_REQ_SOLO_DUNGEON_REWARD)]
		public void CZ_REQ_SOLO_DUNGEON_REWARD(IZoneConnection conn, Packet packet)
		{
			var character = conn.SelectedCharacter;

			// If no rewards send message
			Send.ZC_SYSTEM_MSG(character, 513007);
		}

		[PacketHandler(Op.CZ_HOUSING_REQUEST_GUILD_AGIT_INFO)]
		public void CZ_HOUSING_REQUEST_GUILD_AGIT_INFO(IZoneConnection conn, Packet packet)
		{
			var guildId = packet.GetLong();
			var addonMessage = packet.GetString(128);
			// Get Guild Info
			var guildMapId = 6000;
			var guildLevel = 1;

			Send.ZC_HOUSING_ANSWER_GUILD_AGIT_INFO(conn, guildId, guildMapId, guildLevel);
			Send.ZC_ADDON_MSG(conn.SelectedCharacter, AddonMessage.RECEIVE_OTHER_GUILD_AGIT_INFO, 0, guildId.ToString());
		}

		[PacketHandler(Op.CZ_HOUSING_REQUEST_PREVIEW)]
		public void CZ_HOUSING_REQUEST_PREVIEW(IZoneConnection conn, Packet packet)
		{
			var guildId = packet.GetLong();
			var l1 = packet.GetLong();
			// Get Guild Info
			var guildMapId = 6000;

			Send.ZC_HOUSING_ANSWER_PREVIEW(conn, guildId, guildMapId);
		}

		/// <summary>
		/// Request to arrange furniture (place furniture)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_HOUSING_REQUEST_ARRANGEMENT_FURNITURE)]
		public void CZ_HOUSING_REQUEST_ARRANGEMENT_FURNITURE(IZoneConnection conn, Packet packet)
		{
			var packetSize = packet.GetShort();
			var personalHouse = conn.ActiveHouse;

			if (personalHouse == null)
			{
				Log.Warning("User '{0}' doesn't have an active house.", conn.Account.Name);
				return;
			}

			var character = conn.SelectedCharacter;
			var direction = (CardinalDirection)packet.GetByte();
			var column = packet.GetInt();
			var row = packet.GetInt();
			var cellCount = packet.GetInt();
			var usedCells = new List<int>();
			for (var i = 0; i < cellCount; i++)
			{
				usedCells.Add(packet.GetInt());
			}
			personalHouse.AddFurniture(character, direction, column, row, cellCount, usedCells);
		}

		/// <summary>
		/// Cancel request to place furniture
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_HOUSING_CANCEL_ARRANGEMENT_FURNITURE)]
		public void CZ_HOUSING_CANCEL_ARRANGEMENT_FURNITURE(IZoneConnection conn, Packet packet)
		{
			var personalHouse = conn.ActiveHouse;
			var character = conn.SelectedCharacter;

			if (personalHouse == null)
			{
				Log.Warning("User '{0}' doesn't have an active house.", conn.Account.Name);
				return;
			}
			personalHouse.CancelFurnitureArrangement(character);
		}

		[PacketHandler(Op.CZ_HOUSING_REQUEST_MOVE_FURNITURE)]
		public void CZ_HOUSING_REQUEST_MOVE_FURNITURE(IZoneConnection conn, Packet packet)
		{
			var packetSize = packet.GetShort();
			var personalHouse = conn.ActiveHouse;

			if (personalHouse == null)
			{
				Log.Warning("User '{0}' doesn't have an active house.", conn.Account.Name);
				return;
			}

			var character = conn.SelectedCharacter;
			var furnitureId = packet.GetInt();
			var furnitureHandle = packet.GetInt();
			var direction = (CardinalDirection)packet.GetByte();
			var column = packet.GetInt();
			var row = packet.GetInt();
			var cellCount = packet.GetInt();
			var usedCells = new List<int>();
			for (var i = 0; i < cellCount; i++)
			{
				usedCells.Add(packet.GetInt());
			}
			personalHouse.MoveFurniture(character, furnitureId, furnitureHandle, direction, column, row, cellCount, usedCells);
		}

		/// <summary>
		/// Remove furniture(s)
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_HOUSING_REQUEST_REMOVE_FURNITURE_ALOT)]
		public void CZ_HOUSING_REQUEST_REMOVE_FURNITURE_ALOT(IZoneConnection conn, Packet packet)
		{
			var packetSize = packet.GetShort();
			var personalHouse = conn.ActiveHouse;

			if (personalHouse == null)
			{
				Log.Warning("User '{0}' doesn't have an active house.", conn.Account.Name);
				return;
			}

			var character = conn.SelectedCharacter;
			var furnitureCount = packet.GetInt();
			for (var i = 0; i < furnitureCount; i++)
			{
				var furnitureId = packet.GetInt();
				var furnitureHandle = packet.GetInt();
				personalHouse.RemoveFurniture(character, furnitureId, furnitureHandle);
			}
		}

		[PacketHandler(Op.CZ_HOUSING_REQUEST_REMOVE_ALL_FURNITURE)]
		public void CZ_HOUSING_REQUEST_REMOVE_ALL_FURNITURE(IZoneConnection conn, Packet packet)
		{
			var personalHouse = conn.ActiveHouse;

			if (personalHouse == null)
			{
				Log.Warning("User '{0}' doesn't have an active house.", conn.Account.Name);
				return;
			}
			var character = conn.SelectedCharacter;

			personalHouse.RemoveAllFurniture(character);
		}

		[PacketHandler(Op.CZ_HOUSING_REQUEST_ENABLE_MOVE_FURNITURE)]
		public void CZ_HOUSING_REQUEST_ENABLE_MOVE_FURNITURE(IZoneConnection conn, Packet packet)
		{
			var personalHouse = conn.ActiveHouse;

			if (personalHouse == null)
			{
				Log.Warning("CZ_HOUSING_REQUEST_ENABLE_MOVE_FURNITURE: User '{0}' doesn't have an active house.", conn.Account.Name);
				return;
			}

			var character = conn.SelectedCharacter;
			var furnitureId = packet.GetInt();
			var furnitureHandle = packet.GetInt();

			personalHouse.EnableMoveFurniture(character, furnitureId, furnitureHandle);
		}

		/// <summary>
		/// Skills which require the user to select a cell list.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_SKILL_CELL_LIST)]
		public void CZ_SKILL_CELL_LIST(IZoneConnection conn, Packet packet)
		{
			var s1 = packet.GetShort(); // 64
			var castPosition = packet.GetPosition();
			var castDirection = packet.GetDirection();
			var cellCount = packet.GetInt();

			var character = conn.SelectedCharacter;

			if (character == null)
			{
				Log.Warning("CZ_SKILL_CELL_LIST: Account '{0}' tried to use a non-existing character.", conn.Account.Name);
				return;
			}

			character.Variables.Temp.Set("SkillCellCastPosition", castPosition);
			character.Variables.Temp.Set("SkillCellCastDirection", castDirection);
			character.Variables.Temp.SetInt("SkillCellCount", cellCount);
			var cells = new List<SkillCellPosition>();
			for (var index = 0; index < cellCount; ++index)
			{
				var cellZ = packet.GetInt();
				var cellX = packet.GetInt();
				cells.Add(new SkillCellPosition(cellX, cellZ));
			}
			character.Variables.Temp.Set("SkillCellList", cells);
		}

		/// <summary>
		/// Request to start or stop playing the flute while resting.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_READY_FLUTING)]
		public void CZ_REQ_READY_FLUTING(IZoneConnection conn, Packet packet)
		{
			var enabled = packet.GetBool();

			var character = conn.SelectedCharacter;

			if (!character.Jobs.Has(JobId.PiedPiper))
			{
				Log.Warning("CZ_REQ_READY_FLUTING: User '{0}' tried to play the flute without being a Pied Piper.", conn.Account.Name);
				return;
			}

			if (!character.IsSitting)
			{
				Log.Warning("CZ_REQ_READY_FLUTING: User '{0}' tried to play the flute while not sitting.", conn.Account.Name);
				return;
			}

			Send.ZC_READY_FLUTING(character, enabled);
		}

		/// <summary>
		/// Request to play a note on the flute while resting.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_PLAY_FLUTING)]
		public void CZ_REQ_PLAY_FLUTING(IZoneConnection conn, Packet packet)
		{
			var note = packet.GetInt();
			var octave = packet.GetInt();
			var semitone = packet.GetBool();

			var character = conn.SelectedCharacter;

			if (!character.Jobs.Has(JobId.PiedPiper))
			{
				Log.Warning("CZ_REQ_READY_FLUTING: User '{0}' tried to play the flute without being a Pied Piper.", conn.Account.Name);
				return;
			}

			if (!character.IsSitting)
			{
				Log.Warning("CZ_REQ_READY_FLUTING: User '{0}' tried to play the flute while not sitting.", conn.Account.Name);
				return;
			}

			Send.ZC_PLAY_FLUTING(character, note, octave, semitone, true);
		}

		/// <summary>
		/// Request to stop playing a note on the flute while resting.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_STOP_FLUTING)]
		public void CZ_REQ_STOP_FLUTING(IZoneConnection conn, Packet packet)
		{
			var note = packet.GetInt();
			var octave = packet.GetInt();
			var semitone = packet.GetBool();

			var character = conn.SelectedCharacter;

			if (!character.Jobs.Has(JobId.PiedPiper))
			{
				Log.Warning("CZ_REQ_READY_FLUTING: User '{0}' tried to play the flute without being a Pied Piper.", conn.Account.Name);
				return;
			}

			if (!character.IsSitting)
			{
				Log.Warning("CZ_REQ_READY_FLUTING: User '{0}' tried to play the flute while not sitting.", conn.Account.Name);
				return;
			}

			// If the user starts playing a note, but doesn't stop
			// playing it, or they send a different note to stop,
			// the note will keep playing for a moment until stopping
			// on its own. We could catch this by saving the notes on
			// start, but since you can play multiple notes at once,
			// that will require a bit more effort than simply setting
			// a couple variables which we then get here. We'd need
			// to keep track of all notes being played, stop specific
			// ones, and stop all if anything goes wrong.

			Send.ZC_STOP_FLUTING(character, note, octave, semitone);
		}

		/// <summary>
		/// Request to select class representation
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_CHANGE_REPRESENTATION_CLASS)]
		public void CZ_CHANGE_REPRESENTATION_CLASS(IZoneConnection conn, Packet packet)
		{
			var jobId = (JobId)packet.GetInt();
			var character = conn.SelectedCharacter;

			if (!character.Jobs.Has(jobId))
			{
				Log.Warning("CZ_CHANGE_REPRESENTATION_CLASS: User '{0}' tried to select a class they don't have {1}.", conn.Account.Name, jobId.ToString());
				return;
			}
			character.EtcProperties.SetString(PropertyName.RepresentationClassID, jobId.ToString());
			character.AddonMessage(AddonMessage.UPDATE_REPRESENTATION_CLASS_ICON, "None", (int)jobId);
		}

		/// <summary>
		/// Packet with unknown purpose that is spammed by the client
		/// while the player character is dead.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(0x520A)]
		public void CZ_InteractionCancel(IZoneConnection conn, Packet packet)
		{
			// The packet is spammed with a frequency of about 1-2 packets
			// per millisecond. It's 64 bytes long, with the last 5 looking
			// like random garbage data, though the packet doesn't seem to
			// contain any useful information in general. Its name seems
			// to be "CZ_InteractionCancel", though it doesn't appear in
			// the op code list.
		}

		/// <summary>
		/// Request from a player to revive their character.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_RESURRECT)]
		public void CZ_RESURRECT(IZoneConnection conn, Packet packet)
		{
			var optionIdx = packet.GetByte();
			var l1 = packet.GetLong();

			var character = conn.SelectedCharacter;
			var option = (ResurrectOptions)(1 << (int)optionIdx);

			if (!character.IsDead)
			{
				Log.Warning("CZ_RESURRECT: User '{0}' tried to revive their character while not dead.", conn.Account.Name);
				return;
			}

			character.Resurrect(option);
		}

		/// <summary>
		/// Request to apply a certain HUD skin.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_APPLY_HUD_SKIN)]
		public void CZ_REQ_APPLY_HUD_SKIN(IZoneConnection conn, Packet packet)
		{
			var skinId = packet.GetInt();

			var character = conn.SelectedCharacter;

			if (skinId < 0 || skinId > 5)
			{
				Log.Warning("CZ_REQ_APPLY_HUD_SKIN: User '{0}' tried to apply an invalid skin id {1}.", conn.Account.Name, skinId);
				return;
			}

			// TODO: Check if player owns the HUD skin?
			character.Variables.Perm.SetInt("Melia.HudSkin", skinId);

			Send.ZC_SEND_APPLY_HUD_SKIN_MYSELF(conn, character);
			if (conn.Party != null)
				Send.ZC_SEND_APPLY_HUD_SKIN_PARTY(conn, character, conn.Party);
			Send.ZC_SEND_APPLY_HUD_SKIN_OTHER(conn, character);
		}

		/// <summary>
		/// Request the current HUD skin.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CZ_REQ_CURRENT_HUD_SKIN)]
		public void CZ_REQ_CURRENT_HUD_SKIN(IZoneConnection conn, Packet packet)
		{
			// TODO: Don't know if this is used for anything else.
		}
	}
}
