//--- Melia Script ----------------------------------------------------------
// Narcon Prison
//--- Description -----------------------------------------------------------
// NPCs found in and around Narcon Prison.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DPrison751NpcScript : GeneralScript
{
	public override void Load()
	{
		// Gytis Settlement Area
		//-------------------------------------------------------------------------
		AddNpc(13, 147507, "Gytis Settlement Area", "d_prison_75_1", -516, -196, 1633, 90, "PRISON_75_1_TO_SIAULIAI_50_1", "", "");
	}
}
