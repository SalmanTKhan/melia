//--- Melia Script ----------------------------------------------------------
// Earth Tower Solmiki Area
//--- Description -----------------------------------------------------------
// NPCs found in and around Earth Tower Solmiki Area.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class MissionGroundtower2NpcScript : GeneralScript
{
	public override void Load()
	{
		// Kupole Ruta
		//-------------------------------------------------------------------------
		AddNpc(1, 154013, "Kupole Ruta", "mission_groundtower_2", 5451.209, 239.8083, -6240.683, -7, "GT2_LUTHA_NPC", "", "");
		
		// CK_SOLMIKI
		//-------------------------------------------------------------------------
		AddNpc(2, 20026, "CK_SOLMIKI", "mission_groundtower_2", 5593.586, 239.8083, -6469.392, 90, "", "GT2_INIT_MGAME_STARTER", "");
	}
}
