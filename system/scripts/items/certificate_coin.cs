//--- Melia Script ----------------------------------------------------------
// Add Certificate Coin Items
//--- Description -----------------------------------------------------------
// Item scripts that add coin (Gabija/Vakrine) to an account.
//---------------------------------------------------------------------------

using System;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Game.Const;
using Melia.Shared.Game.Properties;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;

public class CertificateCoinItemScript : GeneralScript
{
	[ScriptableFunction]
	public ItemUseResult SCR_USE_ITEM_CERTIFICATE_COIN(Character character, Item item, string propertyName, float coinAmount, float numArg2)
	{
		character.ModifyAccountProperty(propertyName, coinAmount);
		// Obtained Points message
		character.SystemMessage("PointGet{name}{count}", new MsgParameter("name", item.Data.Name), new MsgParameter("count", coinAmount.ToString()));
		return ItemUseResult.Okay;
	}

	[ScriptableFunction]
	public ItemUseResult SCR_USE_MISC_PVP_MINE2(Character character, Item item, string propertyName, float numArg1, float numArg2)
	{
		var previousValue = character.Connection.Account.Properties.GetFloat(PropertyName.MISC_PVP_MINE2);
		character.ModifyAccountProperty(PropertyName.MISC_PVP_MINE2, item.Amount);
		var newValue = character.Connection.Account.Properties.GetFloat(PropertyName.MISC_PVP_MINE2);
		character.SystemMessage("GET_MISC_PVP_MINE2{count}", new MsgParameter("count", item.Amount.ToString()));
		character.AddonMessage(AddonMessage.EARTHTOWERSHOP_BUY_ITEM_RESULT, $"{previousValue}/{newValue}");
		return ItemUseResult.Okay;
	}
}
