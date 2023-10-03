//--- Melia Script ----------------------------------------------------------
// Add TP Items
//--- Description -----------------------------------------------------------
// Item scripts that add TP (medals) to an account.
//---------------------------------------------------------------------------

using System;
using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;

public class AssisterItemScript : GeneralScript
{
	[ScriptableFunction("ANCIENT_MONSTER_PIECE_USE")]
	public ItemUseResult ANCIENT_MONSTER_PIECE_USE(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		character.AssisterCabinet.Add(strArg);

		return ItemUseResult.Okay;
	}
}
