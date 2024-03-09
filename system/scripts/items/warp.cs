//--- Melia Script ----------------------------------------------------------
// Warp Items
//--- Description -----------------------------------------------------------
// Item scripts that warp the character.
//---------------------------------------------------------------------------

using System;
using Melia.Shared.World;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;

public class WarpScript : GeneralScript
{
	[ScriptableFunction]
	public ItemUseResult SCR_USE_ITEM_WARP_KLAIPE(Character character, Item item, string buffName, float numArg1, float numArg2)
	{
		character.Warp("c_Klaipe", new Position(-179, 150, 72));

		return ItemUseResult.Okay;
	}

	[ScriptableFunction]
	public ItemUseResult SCR_USE_ITEM_WARP_ORSHA(Character character, Item item, string buffName, float numArg1, float numArg2)
	{
		character.Warp("c_orsha", new Position(145, 177, 278));

		return ItemUseResult.Okay;
	}

	[ScriptableFunction]
	public ItemUseResult SCR_USE_ITEM_WARP_FEDIMIAN(Character character, Item item, string buffName, float numArg1, float numArg2)
	{
		character.Warp("c_fedimian", new Position(-243, 161, -303));

		return ItemUseResult.Okay;
	}
}
