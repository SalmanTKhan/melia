//--- Melia Script ----------------------------------------------------------
// Tenet Church B1
//--- Description -----------------------------------------------------------
// NPCs found in and around Tenet Church B1.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DChapel575NpcScript : GeneralScript
{
	public override void Load()
	{
		// Tenet Garden
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Tenet Garden", "d_chapel_57_5", -1258, 1, 1163, 180, "", "CHAPEL575_GELE574", "");
		
		// Tenet Church 1F
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Tenet Church 1F", "d_chapel_57_5", 627, 1, -565, 180, "", "CHAPEL575_CHAPEL576", "");
		
		// Follower Tomas
		//-------------------------------------------------------------------------
		AddNpc(3, 147399, "Follower Tomas", "d_chapel_57_5", -489, -38, 618, 0, "CHAPEL_TOMAS", "", "");
		
		// Follower Tiberius
		//-------------------------------------------------------------------------
		AddNpc(4, 147400, "Follower Tiberius", "d_chapel_57_5", 140.07, -39.42, 588.18, 0, "CHAPEL_TABERIJUS", "", "");
		
		// Follower Vaidas
		//-------------------------------------------------------------------------
		AddNpc(6, 147400, "Follower Vaidas", "d_chapel_57_5", -359.66, 0.55, -94.15, 34, "CHAPEL_VIDAS", "", "");
		
		// Underground Central Altar
		//-------------------------------------------------------------------------
		AddNpc(8, 147358, "Underground Central Altar", "d_chapel_57_5", -600, -17, 422, 45, "", "CHAPEL575_BASIC_1", "CHAPEL575_BASIC_1");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(9, 147456, "", "d_chapel_57_5", -572, -17, 418, 90, "", "CHAPLE575_MQ_04", "");
		
		// Demon Army Barrier
		//-------------------------------------------------------------------------
		AddNpc(14, 40071, "Demon Army Barrier", "d_chapel_57_5", 363, 2, -782, 90, "CHAPLE575_MQ_09", "", "", 0);
		AddNpc(23, 147364, "Field Gen x", "d_chapel_57_5", -1293.18, 0.55, 1019.85, 90, "", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(24, 40120, "Statue of Goddess Vakarine", "d_chapel_57_5", -1429.68, 0.55, 1033.58, 76, "WARP_D_CHAPEL_57_5", "STOUP_CAMP", "STOUP_CAMP");
		
		// Altar of Purification
		//-------------------------------------------------------------------------
		AddNpc(27, 147357, "Altar of Purification", "d_chapel_57_5", 439.29, 0.55, -108.8, 45, "CHAPLE575_MQ_05", "", "");
		AddNpc(23, 147364, "Field Gen x", "d_chapel_57_5", -394.98, 0.55, -132.74, 90, "", "", "");
		AddNpc(23, 147364, "Field Gen x", "d_chapel_57_5", 647.39, 0.55, -650.46, 90, "", "", "");
		AddNpc(29, 147362, "Field Gen x", "d_chapel_57_5", 138.97, -39.42, 565.13, 90, "", "", "");
		AddNpc(29, 147362, "Field Gen x", "d_chapel_57_5", -551.91, -39.42, 195.25, 90, "", "", "");
		AddNpc(29, 147362, "Field Gen x", "d_chapel_57_5", -55.68, 0.55, -448.51, 90, "", "", "");
		AddNpc(29, 147362, "Field Gen x", "d_chapel_57_5", -538.42, 0.55, -144.54, 90, "", "", "");
		AddNpc(29, 147362, "Field Gen x", "d_chapel_57_5", -345.12, 0.55, -146.17, 90, "", "", "");
		AddNpc(29, 147362, "Field Gen x", "d_chapel_57_5", -381.22, 0.55, -771.35, 90, "", "", "");
		AddNpc(29, 147362, "Field Gen x", "d_chapel_57_5", -1419.69, 0.55, 623.52, 90, "", "", "");
		AddNpc(23, 147364, "Field Gen x", "d_chapel_57_5", 417.93, 0.55, -70.84, 90, "", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(33, 147392, "Lv1 Treasure Chest", "d_chapel_57_5", 814.34, 0.65, -988.18, 90, "TREASUREBOX_LV_D_CHAPEL_57_533", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(34, 40095, " ", "d_chapel_57_5", -1036.696, 0.5532227, -166.6513, 90, "", "EXPLORER_MISLE6", "");
	}
}
