//--- Melia Script ----------------------------------------------------------
// Laima's Sanctuary
//--- Description -----------------------------------------------------------
// NPCs found in and around Laima's Sanctuary.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CKlaipeCathedralMediumNpcScript : GeneralScript
{
	public override void Load()
	{
		// Laima
		//-------------------------------------------------------------------------
		AddNpc(1, 47236, "Laima", "c_klaipe_cathedral_medium", 46.24644, 21.4838, 13.83598, 90, "NPC_LITTLEGIRL_01", "", "", 0);
		
		// Mulia
		//-------------------------------------------------------------------------
		AddNpc(2, 150238, "Mulia", "c_klaipe_cathedral_medium", 43.72981, 21.6091, -19.68866, 90, "NPC_RANGDAGIRL_02", "", "", 1);
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(3, 40120, "Statue of Goddess Vakarine", "c_klaipe_cathedral_medium", 441.8155, -82.07249, 290.5834, 49, "WARP_C_KLAIPE_CATHEDRAL_MEDIUM", "STOUP_CAMP", "STOUP_CAMP");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(4, 156043, "Goddess Lada", "c_klaipe_cathedral_medium", 12.21679, 0.6483388, 163.2583, 80, "EP13_GODDESS_LADA4TO5", "", "", 1);
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(5, 156043, "Goddess Lada", "c_klaipe_cathedral_medium", 12.21679, 0.6483388, 163.2583, 80, "GODDESS_LADA_1", "", "", 1);
	}
}
