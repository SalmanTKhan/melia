//--- Melia Script ----------------------------------------------------------
// Mission_test
//--- Description -----------------------------------------------------------
// NPCs found in and around Mission_test.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class MissionTestNpcScript : GeneralScript
{
	public override void Load()
	{
		// Royal Mausoleum 3F
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Royal Mausoleum 3F", "mission_test", -796, 447, 99, 90, "", "ZACHARIEL35_1_ZACHARIEL34_1", "");
	}
}
