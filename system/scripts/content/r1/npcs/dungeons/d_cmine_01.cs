//--- Melia Script ----------------------------------------------------------
// Crystal Mine 1F
//--- Description -----------------------------------------------------------
// NPCs found in and around Crystal Mine 1F.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCmine01NpcScript : GeneralScript
{
	public override void Load()
	{
		// Miners' Village
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Miners' Village", "d_cmine_01", -1294, 318, -1710, -76, "", "WS_ACT4_1_ACT3", "");
		
		// Crystal Mine 2F
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Crystal Mine 2F", "d_cmine_01", -1412, 154, 679, 241, "", "WS_ACT4_1_ACT4_2", "");
		
		// [Alchemist Master]{nl}Vaidotas
		//-------------------------------------------------------------------------
		AddNpc(100, 20110, "[Alchemist Master]{nl}Vaidotas", "d_cmine_01", -1188, 317, -1799, 90, "MINE_1_ALCHEMIST", "", "", 1);
		
		// Entrance Purifier
		//-------------------------------------------------------------------------
		AddNpc(101, 151006, "Entrance Purifier", "d_cmine_01", -881.8724, 183.7008, -1246.434, 90, "MINE_1_PURIFY_1", "", "");
		
		// Passage Purifier
		//-------------------------------------------------------------------------
		AddNpc(107, 151006, "Passage Purifier", "d_cmine_01", -341.71, 111.38, 992.15, 90, "MINE_1_PURIFY_7", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(112, 147453, "", "d_cmine_01", 748.17, 17.46, 103.72, -5, "MINE_1_CRYSTAL_10", "", "", 0);
		
		// Central Purifier
		//-------------------------------------------------------------------------
		AddNpc(105, 151006, "Central Purifier", "d_cmine_01", 33.13, 184.14, -44.16, 5, "MINE_1_PURIFY_5", "", "");
		
		// JOB_HIGHLANDER4_3_Transferred Quest
		//-------------------------------------------------------------------------
		AddNpc(528, 20026, "JOB_HIGHLANDER4_3_Transferred Quest", "d_cmine_01", 1196.97, 3.59, 195.8, 90, "", "JOB_HIGHLANDER4_3", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(529, 40120, "Statue of Goddess Vakarine", "d_cmine_01", -1222.77, 316.34, -1230.72, 60, "WARP_D_CMINE_01", "STOUP_CAMP", "STOUP_CAMP");
		AddNpc(527, 147364, "Field Gen x", "d_cmine_01", -1169.71, 316.4, -1790.85, 90, "", "", "");
		AddNpc(527, 147364, "Field Gen x", "d_cmine_01", -1174.41, 316.34, -1389.54, 90, "", "", "");
		
		// Lv2 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(533, 40030, "Lv2 Treasure Chest", "d_cmine_01", 1316, 4, 730, 360, "TREASUREBOX_LV_D_CMINE_01533", "", "");
		AddNpc(527, 147364, "Field Gen x", "d_cmine_01", -1442.68, 169.5, 706.58, 90, "", "", "");
		
		// Entrance Purifier Parts
		//-------------------------------------------------------------------------
		AddNpc(536, 151015, "Entrance Purifier Parts", "d_cmine_01", -1035.85, 181.9, -1460.69, 90, "MINE_1_CRYSTAL_4", "", "", 1);
		
		// Entrance Purifier Parts
		//-------------------------------------------------------------------------
		AddNpc(536, 151015, "Entrance Purifier Parts", "d_cmine_01", -743.19, 181.47, -85.56, 90, "MINE_1_CRYSTAL_4", "", "", 1);
		
		// MINE_1_CRYSTAL_9_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(537, 20026, "MINE_1_CRYSTAL_9_TRIGGER", "d_cmine_01", 1287, 33, -994, 90, "", "MINE_1_CRYSTAL_9_TRIGGER", "");
		
		// Spare Purifier
		//-------------------------------------------------------------------------
		AddNpc(538, 151006, "Spare Purifier", "d_cmine_01", 1417.74, 32.72, -913.54, 0, "MINE_1_CRYSTAL_9_DEVICE", "", "");
		
		// MINE_1_CRYSTAL_18_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(539, 20026, "MINE_1_CRYSTAL_18_TRIGGER", "d_cmine_01", -1125.76, 111.38, 427.64, 90, "", "MINE_1_CRYSTAL_18_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(540, 151008, " ", "d_cmine_01", -1501.23, 189.36, 706.83, -16, "", "MINE_1_ELEVATOR", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(541, 147392, "Lv1 Treasure Chest", "d_cmine_01", 645.39, 17.75, -27.96, 0, "TREASUREBOX_LV_D_CMINE_01541", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(542, 147392, "Lv1 Treasure Chest", "d_cmine_01", 331.21, 111.48, 494.6, 0, "TREASUREBOX_LV_D_CMINE_01542", "", "");
		AddNpc(527, 147364, "Field Gen x", "d_cmine_01", 34.74209, 184.1443, -46.6522, 90, "", "", "");
		AddNpc(527, 147364, "Field Gen x", "d_cmine_01", -877.587, 183.8141, -1249.203, 90, "", "", "");
		AddNpc(527, 147364, "Field Gen x", "d_cmine_01", -337.6631, 111.3751, 991.0704, 90, "", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(543, 147392, "Lv1 Treasure Chest", "d_cmine_01", -1542.96, 154.8, 494.07, 90, "TREASUREBOX_LV_D_CMINE_01543", "", "");
	}
}
