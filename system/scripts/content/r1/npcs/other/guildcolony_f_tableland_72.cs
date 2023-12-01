//--- Melia Script ----------------------------------------------------------
// Sventimas Exile
//--- Description -----------------------------------------------------------
// NPCs found in and around Sventimas Exile.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class GuildColonyFTableland72NpcScript : GeneralScript
{
	public override void Load()
	{
		// Kadumel Cliff
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Kadumel Cliff", "GuildColony_f_tableland_72", 777.5479, 452.2046, 2020.532, 183, "", "TABLELAND72_TABLELAND73", "");
		
		// Grand Yard Mesa
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Grand Yard Mesa", "GuildColony_f_tableland_72", 1029.782, 508.6085, -1489.055, 48, "", "TABLELAND72_TABLELAND71", "");
		
		// Sentry Bailey
		//-------------------------------------------------------------------------
		AddNpc(3, 40001, "Sentry Bailey", "GuildColony_f_tableland_72", 2131.741, 287.9069, 222.4766, 99, "", "TABLELAND72_UNDERFORTRESS65", "");
	}
}
