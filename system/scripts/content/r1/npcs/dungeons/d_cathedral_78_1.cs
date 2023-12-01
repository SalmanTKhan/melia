//--- Melia Script ----------------------------------------------------------
// Neighport Church East Building
//--- Description -----------------------------------------------------------
// NPCs found in and around Neighport Church East Building.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCathedral781NpcScript : GeneralScript
{
	public override void Load()
	{
		// Stogas Plateau
		//-------------------------------------------------------------------------
		AddNpc(1, 147507, "Stogas Plateau", "d_cathedral_78_1", 1359, 145, 264, 90, "CATHEDRAL_78_1_TO_TABLELAND_28_2", "", "");
		AddNpc(17, 147365, "CantGen", "d_cathedral_78_1", 1399.483, 144.2495, 225.5164, 90, "", "", "");
	}
}
