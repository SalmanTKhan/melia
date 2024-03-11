//--- Melia Script ----------------------------------------------------------
// Equip Items
//--- Description -----------------------------------------------------------
// Item scripts that add and remove buffs on equipping items.
//---------------------------------------------------------------------------

using System;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;

public class ItemEquipScript : GeneralScript
{

	[ScriptableFunction]
	public ItemEquipResult SCP_ON_EQUIP_ITEM(Character character, Item item, EquipSlot equipSlot)
	{
		var strArg = item.Data.Script.StrArg;

		if (ZoneServer.Instance.Data.BuffDb.TryFind(strArg, out var buffData))
			character.StartBuff(buffData.Id, TimeSpan.Zero);
		else if (ZoneServer.Instance.Data.HairTypeDb.TryFind(character.Gender, strArg, out var hairData))
			Send.ZC_NORMAL.UpdateCharacterLook(character, item.Id, equipSlot, true, hairData.Index);

		return ItemEquipResult.Okay;
	}

	[ScriptableFunction]
	public ItemUnequipResult SCP_ON_UNEQUIP_ITEM(Character character, Item item, EquipSlot equipSlot)
	{
		var strArg = item.Data.Script.StrArg;

		if (ZoneServer.Instance.Data.BuffDb.TryFind(strArg, out var buffData))
			character.Buffs.Remove(buffData.Id);
		else if (ZoneServer.Instance.Data.HairTypeDb.TryFind(character.Gender, strArg, out var hairData))
			Send.ZC_NORMAL.UpdateCharacterLook(character, item.Id, equipSlot, false, hairData.Index);

		return ItemUnequipResult.Okay;
	}
}
