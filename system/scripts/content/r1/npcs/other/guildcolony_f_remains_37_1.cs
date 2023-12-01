//--- Melia Script ----------------------------------------------------------
// Nuoridin Falls
//--- Description -----------------------------------------------------------
// NPCs found in and around Nuoridin Falls.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class GuildColonyFRemains371NpcScript : GeneralScript
{
	public override void Load()
	{
		// Valius' Eternal Resting Place
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Valius' Eternal Resting Place", "GuildColony_f_remains_37_1", -65.84995, 221.1378, -1794.304, 151, "", "REMAINS37_1_CATACOMB_02", "");
		
		// Stele Road
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Stele Road", "GuildColony_f_remains_37_1", 2123.194, 314.1065, -745.3977, 48, "", "REMAINS37_1_REMAINS37", "");
		
		// Namu Temple Ruins
		//-------------------------------------------------------------------------
		AddNpc(3, 40001, "Namu Temple Ruins", "GuildColony_f_remains_37_1", -2785.502, 296.6722, 1350.796, 14, "", "REMAINS37_1_REMAINS37_2", "");
	}
}
