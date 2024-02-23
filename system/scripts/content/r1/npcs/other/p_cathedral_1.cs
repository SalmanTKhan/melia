//--- Melia Script ----------------------------------------------------------
// Passage of the Recluse
//--- Description -----------------------------------------------------------
// NPCs found in and around Passage of the Recluse.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class PCathedral1NpcScript : GeneralScript
{
	public override void Load()
	{
		// Stele Road
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Stele Road", "p_cathedral_1", 61, 0, 363, 180, "", "PCATHEDRAL1_REMAINS37", "");
		
		// Sirdgela Forest
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Sirdgela Forest", "p_cathedral_1", -437, 0, -1059, 360, "", "PCATHEDRAL1_THORN20", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(3, 40120, "Statue of Goddess Vakarine", "p_cathedral_1", 429.5168, 0.3999373, -446.9579, 270, "WARP_P_CATHEDRAL_1", "STOUP_CAMP", "STOUP_CAMP");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(4, 40070, "Warning", "p_cathedral_1", 10.10509, 0.4, 295.0023, 90, "UPPER_WARNING_P_CATHEDRAL_1", "", "");
		
		// [Miko Master]{nl}Hitomiko
		//-------------------------------------------------------------------------
		AddNpc(5, 153173, "[Miko Master]{nl}Hitomiko", "p_cathedral_1", 580.6166, 0.3999939, -320.2625, 0, "MIKO_MASTER", "", "", 1);
		
		// Divine Spirit
		//-------------------------------------------------------------------------
		AddNpc(6, 151018, "Divine Spirit", "p_cathedral_1", 541.7883, 0.3999939, -321.3452, 90, "MIKO_SOUL_SPIRIT", "", "", 1);
		
		// [Illusionist Master]{nl}Cordelia
		//-------------------------------------------------------------------------
		AddNpc(7, 160195, "[Illusionist Master]{nl}Cordelia", "p_cathedral_1", 328.658, 0.3999939, -585.8873, 90, "NPC_ILLUSIONIST", "", "");
	}
}
