//--- Melia Script ----------------------------------------------------------
// Fedimian Public House
//--- Description -----------------------------------------------------------
// NPCs found in and around Fedimian Public House.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CRequest1NpcScript : GeneralScript
{
	public override void Load()
	{
		// Fedimian
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Fedimian", "c_request_1", 195, 4, -130, 90, "", "REQUEST1_FEDIMIAN", "");
		
		// [Fedimian Public House]{nl}Owner
		//-------------------------------------------------------------------------
		AddNpc(10, 152002, "[Fedimian Public House]{nl}Owner", "c_request_1", 98, 0, -29, 405, "FEDIMIAN_BOARD_01", "", "");
		
		// [Fedimian Public House]{nl}Waiter
		//-------------------------------------------------------------------------
		AddNpc(11, 147494, "[Fedimian Public House]{nl}Waiter", "c_request_1", -16.54351, 18.45353, 40.40888, -13, "C_REQUEST_1_NPC_01", "", "");
		
		// [Fedimian Public House]{nl}Waitress
		//-------------------------------------------------------------------------
		AddNpc(12, 20116, "[Fedimian Public House]{nl}Waitress", "c_request_1", -9.983923, 0.2498226, -140.5775, 74, "C_REQUEST_1_NPC_02", "", "");
	}
}
