//--- Melia Script ----------------------------------------------------------
// Outer Wall Sewers
//--- Description -----------------------------------------------------------
// NPCs found in and around Outer Wall Sewers.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DUnderaqueductNpcScript : GeneralScript
{
	public override void Load()
	{
		// Sewer Teleportation Device
		//-------------------------------------------------------------------------
		AddNpc(1, 152078, "Sewer Teleportation Device", "d_underaqueduct", 1048.242, 215.4466, 1272.548, 90, "D_UNDERAQUEDUCT_SETPOS_1", "", "");
		
		// Sewer Teleportation Device
		//-------------------------------------------------------------------------
		AddNpc(2, 152078, "Sewer Teleportation Device", "d_underaqueduct", -1717.808, 193.516, -880.9163, 90, "D_UNDERAQUEDUCT_SETPOS_2", "", "");
		
		// Sewer Teleportation Device
		//-------------------------------------------------------------------------
		AddNpc(3, 152078, "Sewer Teleportation Device", "d_underaqueduct", -1695.672, 141.7013, 1669.149, 90, "D_UNDERAQUEDUCT_SETPOS_3", "", "");
		
		// Sewer Teleportation Device
		//-------------------------------------------------------------------------
		AddNpc(4, 152078, "Sewer Teleportation Device", "d_underaqueduct", 1036.604, 215.4466, -1126.836, 90, "D_UNDERAQUEDUCT_SETPOS_4", "", "");
		
		// Supply Device
		//-------------------------------------------------------------------------
		AddNpc(5, 151108, "Supply Device", "d_underaqueduct", -1176.419, 176.026, 1355.446, 90, "D_UNDERAQUEDUCT_EVENT_1", "", "");
		
		// Secret Supply Device
		//-------------------------------------------------------------------------
		AddNpc(6, 151108, "Secret Supply Device", "d_underaqueduct", -1183.232, 176.026, 1265.041, 90, "D_UNDERAQUEDUCT_EVENT_2", "", "", 1);
		
		// Chamber Entry Device
		//-------------------------------------------------------------------------
		AddNpc(7, 151003, "Chamber Entry Device", "d_underaqueduct", -1039.296, 176.026, 1373.089, 90, "D_UNDERAQUEDUCT_BOSS_SETPOS", "", "");
		
		// Docks
		//-------------------------------------------------------------------------
		AddNpc(8, 154069, "Docks", "d_underaqueduct", -158.1535, 168.591, 1374.568, 90, "D_UNDERAQUEDUCT_BOSS_SETPOS2", "", "");
		AddNpc(9, 154005, "", "d_underaqueduct", 1136, 215, 110, 90, "", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(10, 147312, "", "d_underaqueduct", 1215.218, 215.0766, -528.3562, 90, "D_UNDERAQUEDUCT_BOOK_1_NPC", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(11, 147312, "", "d_underaqueduct", 270.8728, 193.5902, 744.741, 90, "D_UNDERAQUEDUCT_BOOK_2_NPC", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(12, 147312, "", "d_underaqueduct", -1789.095, 215.5579, 169.8979, 90, "D_UNDERAQUEDUCT_BOOK_3_NPC", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(13, 147312, "", "d_underaqueduct", -1221.999, 176.026, 1526.404, 90, "D_UNDERAQUEDUCT_BOOK_4_NPC", "", "");
		
		// Skull
		//-------------------------------------------------------------------------
		AddNpc(14, 152015, "Skull", "d_underaqueduct", 22.14384, 176.194, 1510.373, 90, "D_UNDERAQUEDUCT_BOOK_5_NPC", "", "");
		
		// Outer Wall District 14
		//-------------------------------------------------------------------------
		AddNpc(15, 147507, "Outer Wall District 14", "d_underaqueduct", 1704.62, 281.4161, -445.665, 90, "D_UNDERAQUEDUCT_TO_F_CASTLE_96", "", "");
		AddNpc(24, 147366, "", "d_underaqueduct", -59.99216, 176.6545, 1366.18, 90, "", "", "");
		AddNpc(25, 147365, "", "d_underaqueduct", -1044.746, 176.026, 1567.357, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(26, 40095, " ", "d_underaqueduct", -857.996, 176.026, 1350.304, 90, "", "EXPLORER_MISLE31", "");
	}
}
