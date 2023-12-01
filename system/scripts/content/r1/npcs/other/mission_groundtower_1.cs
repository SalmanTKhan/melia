//--- Melia Script ----------------------------------------------------------
// Earth Tower Lolopanther Area
//--- Description -----------------------------------------------------------
// NPCs found in and around Earth Tower Lolopanther Area.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class MissionGroundtower1NpcScript : GeneralScript
{
	public override void Load()
	{
		AddNpc(1, 154073, "", "mission_groundtower_1", 3178.68, 266.48, -6044.75, 9, "", "", "");
		AddNpc(2, 153140, "", "mission_groundtower_1", 3194.74, 266.48, -6060.33, 0, "", "", "");
		
		// Kupole Ruta
		//-------------------------------------------------------------------------
		AddNpc(3, 154013, "Kupole Ruta", "mission_groundtower_1", 3079.993, 266.48, -6288.347, 68, "GT_LUTHA_NPC", "", "");
	}
}
