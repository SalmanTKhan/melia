using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;

public class ItemGachaScripts : GeneralScript
{
	/// <summary>
	/// Unlocks an achievement by adding 1 achievement point specified by the item.
	/// </summary>
	/// <param name="character"></param>
	/// <param name="item"></param>
	/// <param name="strArg"></param>
	/// <param name="numArg1"></param>
	/// <param name="numArg2"></param>
	/// <returns></returns>
	[ScriptableFunction("SCR_USE_GHACHA_TPCUBE")]
	public ItemUseResult SCR_USE_GHACHA_TPCUBE(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		if (character.IsRiding || character.Buffs.Has(BuffId.SwellLeftArm_Buff) || character.Buffs.Has(BuffId.SwellRightArm_Buff))
		{
			character.SystemMessage("DonUseItemOnRIde");
			return ItemUseResult.Fail;
		}

		// TODO: Implement GachaDb
		//ZoneServer.Instance.Data.GachaDb

		return ItemUseResult.Okay;
	}
}
