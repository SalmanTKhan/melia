//--- Melia Script ----------------------------------------------------------
// Inner Wall District 10
//--- Description -----------------------------------------------------------
// NPCs found in and around Inner Wall District 10.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FCastle94NpcScript : GeneralScript
{
	public override void Load()
	{
		// Wounded Soldier Spirit
		//-------------------------------------------------------------------------
		AddNpc(7, 150200, "Wounded Soldier Spirit", "f_castle_94", 1062, 295, 775, 90, "CASTLE94_NPC_MAIN01", "CASTLE94_NPC_MAIN01", "", 0);
		
		// Switchgear
		//-------------------------------------------------------------------------
		AddNpc(8, 151050, "Switchgear", "f_castle_94", -1416, 289, 1000, 90, "CASTLE94_NPC_01", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(9, 150201, " ", "f_castle_94", 188, 289, 2459, 0, "CASTLE94_NPC_03", "", "", 0);
		
		// Evil Aura
		//-------------------------------------------------------------------------
		AddNpc(10, 154065, "Evil Aura", "f_castle_94", 575, 289, 2887, 90, "CASTLE94_NPC_02", "", "", 0);
		
		// Royal Soldier Spirit
		//-------------------------------------------------------------------------
		AddNpc(11, 154017, "Royal Soldier Spirit", "f_castle_94", 1062, 295, 775, 90, "CASTLE94_NPC_MAIN02", "", "", 1);
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(12, 152032, "Energized Tombstone", "f_castle_94", 78.65771, 289.9216, 1205.302, 0, "CASTLE94_NPC_MONUMENT", "", "");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(12, 152032, "Energized Tombstone", "f_castle_94", -208.4962, 289.9216, 857.0498, 0, "CASTLE94_NPC_MONUMENT", "", "");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(12, 152032, "Energized Tombstone", "f_castle_94", -267.3208, 289.9216, 1243.94, 0, "CASTLE94_NPC_MONUMENT", "", "");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(12, 152032, "Energized Tombstone", "f_castle_94", -458.674, 289.9216, 852.9813, 0, "CASTLE94_NPC_MONUMENT", "", "");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(12, 152032, "Energized Tombstone", "f_castle_94", -786.1778, 289.9216, 1203.331, 0, "CASTLE94_NPC_MONUMENT", "", "");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(12, 152032, "Energized Tombstone", "f_castle_94", -759.1938, 289.9216, 854.4965, 0, "CASTLE94_NPC_MONUMENT", "", "");
		
		// Statue of Purification
		//-------------------------------------------------------------------------
		AddNpc(13, 152023, "Statue of Purification", "f_castle_94", 575, 289, 2887, 0, "CASTLE94_NPC_04", "", "", 1);
		AddNpc(14, 153156, " ", "f_castle_94", -1366, 289, 950, 90, "", "", "");
		AddNpc(16, 153156, " ", "f_castle_94", -1366, 289, 1050, 90, "", "", "");
		AddNpc(15, 153156, " ", "f_castle_94", -1466, 289, 950, 90, "", "", "");
		AddNpc(17, 153156, " ", "f_castle_94", -1466, 289, 1050, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(18, 40095, " ", "f_castle_94", -1031.764, 289.9216, 999.8374, 90, "", "CASTLE94_MAIN05_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 150202, " ", "f_castle_94", 188, 289, 2459, 0, "CASTLE94_NPC_05", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20, 154067, " ", "f_castle_94", -1416, 289, 1000, 90, "CASTLE94_MAIN05_SHIELD", "", "", 0);
		
		// Inner Wall District 9
		//-------------------------------------------------------------------------
		AddNpc(21, 40001, "Inner Wall District 9", "f_castle_94", -688.4324, 289.9216, -862.6098, 0, "", "F_CASTLE_94_TO_F_CASTLE_20_2", "");
		
		// Outer Wall District 11
		//-------------------------------------------------------------------------
		AddNpc(22, 40001, "Outer Wall District 11", "f_castle_94", 1475.366, 289.9216, 999.3951, 90, "", "F_CASTLE_94_TO_F_CASTLE_93", "");
		
		// Outer Wall District 13
		//-------------------------------------------------------------------------
		AddNpc(23, 40001, "Outer Wall District 13", "f_castle_94", -518.7258, 289.9216, 3216.284, 180, "", "F_CASTLE_94_TO_F_CASTLE_95", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(24, 40120, "Statue of Goddess Vakarine", "f_castle_94", 1133.941, 295.1365, 726.7096, 90, "WARP_F_CASTLE_94", "STOUP_CAMP", "STOUP_CAMP");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(12, 152032, "Energized Tombstone", "f_castle_94", -527.4627, 289.9216, 1003.283, 0, "CASTLE94_NPC_MONUMENT", "", "");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(12, 152032, "Energized Tombstone", "f_castle_94", -80.13569, 289.9216, 1002.779, 0, "CASTLE94_NPC_MONUMENT", "", "");
	}
}
