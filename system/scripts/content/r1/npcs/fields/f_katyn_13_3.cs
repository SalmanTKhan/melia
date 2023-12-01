//--- Melia Script ----------------------------------------------------------
// Arrow Path
//--- Description -----------------------------------------------------------
// NPCs found in and around Arrow Path.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FKatyn133NpcScript : GeneralScript
{
	public override void Load()
	{
		// Letas Stream
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Letas Stream", "f_katyn_13_3", 2393, 200, 294, 90, "", "KATYN13_3_KATYN12", "");
		
		// Ramstis Ridge
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Ramstis Ridge", "f_katyn_13_3", -1921, 244, -350, 270, "", "KATYN13_3_ROKAS25", "");
	}
}
