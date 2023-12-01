//--- Melia Script ----------------------------------------------------------
// Baron Allerno
//--- Description -----------------------------------------------------------
// NPCs found in and around Baron Allerno.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class GuildColonyFSiauliai474NpcScript : GeneralScript
{
	public override void Load()
	{
		// Myrkiti Farm
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Myrkiti Farm", "GuildColony_f_siauliai_47_4", -2167.146, 109.7638, -153.8053, -84, "", "SIAUL47_4_TO_FARM_47_3", "");
		
		// Gytis Settlement Area
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Gytis Settlement Area", "GuildColony_f_siauliai_47_4", 2445.227, 209.9945, -1354.79, -5, "", "SIAUL47_4_TO_SIAUL50_1", "");
		
		// Tenants' Farm
		//-------------------------------------------------------------------------
		AddNpc(3, 40001, "Tenants' Farm", "GuildColony_f_siauliai_47_4", 653.1481, 109.7638, 1595.561, 185, "", "SIAUL47_4_TO_FARM_47_1", "");
	}
}
