//--- Melia Script ----------------------------------------------------------
// Skalda Outskirts
//--- Description -----------------------------------------------------------
// NPCs found in and around Skalda Outskirts.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FCastle102NpcScript : GeneralScript
{
	public override void Load()
	{
		// Rinksmas Ruins
		//-------------------------------------------------------------------------
		AddNpc(6, 40001, "Rinksmas Ruins", "f_castle_102", -3141.893, 52.90469, 277.3966, 260, "", "WARP_CASTLE102_TO_DCAPITAL53_1", "");
		
		// Tvirtumas Fortress
		//-------------------------------------------------------------------------
		AddNpc(7, 40001, "Tvirtumas Fortress", "f_castle_102", -1473.447, 240.429, -1715.916, 0, "", "WARP_CASTLE102_TO_CASTLE99", "");
		AddNpc(9, 147366, " ", "f_castle_102", -1491.447, 240.429, -1521.799, 90, "", "", "");
		AddNpc(9, 147366, " ", "f_castle_102", -1077, 52, 538, 90, "", "", "");
		AddNpc(9, 147366, " ", "f_castle_102", -1263.418, 245.2507, -1484.74, 90, "", "", "");
		
		// Goddess Austeja
		//-------------------------------------------------------------------------
		AddNpc(10, 151041, "Goddess Austeja", "f_castle_102", -1506, 240, -1612, 45, "CASTLE102_AUSTEJA_01", "", "", 1);
		
		// Laima's Wheel
		//-------------------------------------------------------------------------
		AddNpc(12, 150215, "Laima's Wheel", "f_castle_102", -1090.85, 52.90469, 669.7462, 0, "CASTLE102_RAIMA_WHEEL", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(13, 40095, " ", "f_castle_102", -966.3862, 59.82299, 710.7999, 90, "", "EXPLORER_MISLE36", "");
	}
}
