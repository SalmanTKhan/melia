//--- Melia Script ----------------------------------------------------------
// Mullers Passage
//--- Description -----------------------------------------------------------
// NPCs found in and around Mullers Passage.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class PCatacomb1NpcScript : GeneralScript
{
	public override void Load()
	{
		// Pilgrim Path
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Pilgrim Path", "p_catacomb_1", 19, 267, 1161, 180, "", "PCATACOMB1_PILGRIM47", "");
		
		// Rukas Plateau
		//-------------------------------------------------------------------------
		AddNpc(3, 40001, "Rukas Plateau", "p_catacomb_1", 21, 267, -1146, 360, "", "PCATACOMB1_ROKAS29", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(4, 40120, "Statue of Goddess Vakarine", "p_catacomb_1", 63.74635, 260.2255, 8.646395, 30, "WARP_P_CATACOMB_1", "STOUP_CAMP", "STOUP_CAMP");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(5, 40070, "Warning", "p_catacomb_1", -3.177528, 267.5362, 1062.539, 90, "UPPER_WARNING_P_CATACOMB_1", "", "");
		
		// [Necromancer Master]{nl}Loretta Nimbus
		//-------------------------------------------------------------------------
		AddNpc(6, 147446, "[Necromancer Master]{nl}Loretta Nimbus", "p_catacomb_1", 193.1828, 260.2255, 82.64813, 0, "JOB_NECRO4_NPC", "", "");
	}
}
