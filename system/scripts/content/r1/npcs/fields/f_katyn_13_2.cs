//--- Melia Script ----------------------------------------------------------
// Secret Room
//--- Description -----------------------------------------------------------
// NPCs found in and around Secret Room.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FKatyn132NpcScript : GeneralScript
{
	public override void Load()
	{
		// Tenet Garden
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Tenet Garden", "f_katyn_13_2", 522, 198, -1938, 90, "", "KATYN_13_2_GELE574", "");
		
		// Dvasia Peak
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Dvasia Peak", "f_katyn_13_2", -2252, 197, 1338, 270, "", "KATYN13_2_THORN22", "");
		
		// Septyni Glen
		//-------------------------------------------------------------------------
		AddNpc(3, 40001, "Septyni Glen", "f_katyn_13_2", -937, 197, -2022, 270, "", "KATYN13_2_HUEVILLAGE58_4", "");
		
		// Letas Stream
		//-------------------------------------------------------------------------
		AddNpc(4, 40001, "Letas Stream", "f_katyn_13_2", -52, 201, 2609, 180, "", "KATYN13_2_KATYN12", "");
		
		// The quest for the hidden trigger(for skill checks)
		//-------------------------------------------------------------------------
		AddNpc(201, 20026, "The quest for the hidden trigger(for skill checks)", "f_katyn_13_2", -227.26, 198.2, -1965.17, 90, "KATYN_13_2_HQ_01", "KATYN_13_2_HQ_01_TRIGGER01", "KATYN_13_2_HQ_01_TRIGGER02");
	}
}
