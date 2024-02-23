//--- Melia Script ----------------------------------------------------------
// Test Zone
//--- Description -----------------------------------------------------------
// NPCs found in and around Test Zone.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class TestZoneNpcScript : GeneralScript
{
	public override void Load()
	{
		AddNpc(1, 20026, "TEST", "test_zone", 9, 0, -310, 90, "", "", "");
		
		// TP Shop
		//-------------------------------------------------------------------------
		AddNpc(3, 20113, "TP Shop", "test_zone", -35, 0, 81, 90, "TEST_TP_SHOP", "", "");
		AddNpc(15, 20011, "Equipment Trade Point Shop", "test_zone", -51, 0, -310, 90, "", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(2, 20113, "", "test_zone", -40, 0, 126, 90, "TEST_RANK", "", "");
		
		// Statue of Goddess Ausrine
		//-------------------------------------------------------------------------
		AddNpc(108, 40130, "Statue of Goddess Ausrine", "test_zone", 38, 0, 190, 90, "SKILLPOINTUP2", "", "");
		AddNpc(31, 48021, "Thorn Forest Gate 1", "test_zone", -59, 0, 288, 370, "", "", "");
		AddNpc(32, 48022, "Thorn Forest Gate 2", "test_zone", 40, 0, 388, 370, "", "", "");
		AddNpc(33, 48023, "Thorn Forest Gate 3", "test_zone", 153, 0, 501, 370, "", "", "");
		AddNpc(34, 48024, "Thorn Forest Gate 4", "test_zone", 246, 0, 594, 370, "", "", "");
		AddNpc(35, 47085, "Thorn Forest Gate 5", "test_zone", 342, 0, 690, 45, "", "", "");
		AddNpc(36, 47086, "Thorn Forest Gate 6", "test_zone", 391, 0, 456, 45, "", "", "");
		
		// IMC_Guard
		//-------------------------------------------------------------------------
		AddNpc(37, 20016, "IMC_Guard", "test_zone", -713, 0, -611, 90, "IMC_GUARD", "", "");
	}
}
