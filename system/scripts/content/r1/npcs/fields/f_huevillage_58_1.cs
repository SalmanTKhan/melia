//--- Melia Script ----------------------------------------------------------
// Veja Ravine
//--- Description -----------------------------------------------------------
// NPCs found in and around Veja Ravine.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FHuevillage581NpcScript : GeneralScript
{
	public override void Load()
	{
		// Old Man of Andale Village
		//-------------------------------------------------------------------------
		AddNpc(3, 147396, "Old Man of Andale Village", "f_huevillage_58_1", 200, 370, -1300, 101, "HUEVILLAGE_58_1_MQ01_NPC", "", "", 0);
		
		// Holy Pond
		//-------------------------------------------------------------------------
		AddNpc(7, 147372, "Holy Pond", "f_huevillage_58_1", -973.57, 230.98, 983.3, 90, "HUEVILLAGE_58_1_MQ02_NPC", "", "", 0);
		
		// Corrupted Pond 1
		//-------------------------------------------------------------------------
		AddNpc(8, 20026, "Corrupted Pond 1", "f_huevillage_58_1", -985, 231, 1035, 90, "", "HUEVILLAGE_58_1_MQ02_SMOKE_01", "");
		
		// Injured Villager
		//-------------------------------------------------------------------------
		AddNpc(10, 147407, "Injured Villager", "f_huevillage_58_1", -232, 233, -434, 190, "HUEVILLAGE_58_1_MQ03_NPC", "", "", 1);
		
		// Nugria Altar
		//-------------------------------------------------------------------------
		AddNpc(11, 47124, "Nugria Altar", "f_huevillage_58_1", -1250, 230, 490, 60, "HUEVILLAGE_58_1_PORTAL", "", "");
		
		// Nefritas Cliff
		//-------------------------------------------------------------------------
		AddNpc(16, 40001, "Nefritas Cliff", "f_huevillage_58_1", 1562.31, 371.3148, -1187.531, 79, "", "HUEVILLAGE58_1_TO_GELE573", "");
		
		// Vieta Gorge
		//-------------------------------------------------------------------------
		AddNpc(17, 40001, "Vieta Gorge", "f_huevillage_58_1", -719.62, 236.42, -402.6, -51, "", "HUEVILLAGE58_1_TO_HUEVILLAGE58_2", "");
		AddNpc(29, 147366, "Field Gen x", "f_huevillage_58_1", 251.46, 371.31, -1340.35, 90, "", "", "");
		AddNpc(29, 147366, "Field Gen x", "f_huevillage_58_1", -615.5, 230.98, -322.77, 90, "", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(33, 40120, "Statue of Goddess Vakarine", "f_huevillage_58_1", 217.9083, 371.3148, -916.1648, 79, "WARP_F_HUEVILLAGE_58_1", "STOUP_CAMP", "STOUP_CAMP");
		AddNpc(29, 147366, "Field Gen x", "f_huevillage_58_1", 198.2025, 371.3148, -1023.708, 90, "", "", "");
		AddNpc(29, 147366, "Field Gen x", "f_huevillage_58_1", 636.4652, 99.3913, 622.957, 90, "", "", "");
		
		// HUEVILLAGE_58_1_MQ11_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(34, 20026, "HUEVILLAGE_58_1_MQ11_TRIGGER", "f_huevillage_58_1", -1044.6, 230.9787, 415.3144, 90, "", "HUEVILLAGE_58_1_MQ11_TRIGGER", "");
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(35, 147372, "Source of Corruption", "f_huevillage_58_1", -428.3319, 230.9787, 946.6636, 90, "HUEVILLAGE_58_1_SQ02_NPC", "", "", 0);
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(35, 147372, "Source of Corruption", "f_huevillage_58_1", -279.0617, 230.9787, 996.8748, 90, "HUEVILLAGE_58_1_SQ02_NPC", "", "", 0);
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(35, 147372, "Source of Corruption", "f_huevillage_58_1", -41.62195, 230.9787, 901.6882, 90, "HUEVILLAGE_58_1_SQ02_NPC", "", "", 0);
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(35, 147372, "Source of Corruption", "f_huevillage_58_1", -179.4038, 230.9787, 827.4052, 90, "HUEVILLAGE_58_1_SQ02_NPC", "", "", 0);
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(35, 147372, "Source of Corruption", "f_huevillage_58_1", -274.3823, 230.9787, 680.8425, 90, "HUEVILLAGE_58_1_SQ02_NPC", "", "", 0);
		
		// HUEVILLAGE_58_3_MQ04_Trigger for return
		//-------------------------------------------------------------------------
		AddNpc(38, 20026, "HUEVILLAGE_58_3_MQ04_Trigger for return", "f_huevillage_58_1", -511.3197, 230.9787, -277.6531, 90, "", "HUEVILLAGE_58_3_MQ04_TO_HUE1", "");
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(35, 147372, "Source of Corruption", "f_huevillage_58_1", -330.3746, 230.9787, 809.6934, 90, "HUEVILLAGE_58_1_SQ02_NPC", "", "", 0);
		
		// Gytis Settlement Area
		//-------------------------------------------------------------------------
		AddNpc(41, 40001, "Gytis Settlement Area", "f_huevillage_58_1", 222.0356, 371.3148, -1974.421, -22, "", "HUEVILLAGE_58_1_SIAUL50_1", "");
		
		// To the other side
		//-------------------------------------------------------------------------
		AddNpc(42, 40070, "To the other side", "f_huevillage_58_1", 647.6614, 371.3148, -188.8819, 0, "HUEVILLAGE_58_1_CABLETEMP_01", "", "");
		
		// To the other side
		//-------------------------------------------------------------------------
		AddNpc(43, 40070, "To the other side", "f_huevillage_58_1", 632.8807, 99.40303, 596.5604, 0, "HUEVILLAGE_58_1_CABLETEMP_02", "", "");
		AddNpc(46, 20170, "Search Skill Trigger", "f_huevillage_58_1", 817.11, 99.49, 707.01, 90, "", "", "");
		
		// Klaipeda Mayor's Spirit
		//-------------------------------------------------------------------------
		AddNpc(47, 155022, "Klaipeda Mayor's Spirit", "f_huevillage_58_1", 259.65, 371.88, -656.01, 90, "KLAIPEDA_MAYER", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(48, 40095, "", "f_huevillage_58_1", 429.9816, 371.3148, -890.0194, 135, "PARTY_Q4_TRIGGER", "", "", 1);
		
		// Spirit Eye
		//-------------------------------------------------------------------------
		AddNpc(49, 151022, "Spirit Eye", "f_huevillage_58_1", 429.9816, 371.3148, -890.0194, 90, "PARTY_Q41_ORB", "", "", 1);
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(50, 147392, "Lv1 Treasure Chest", "f_huevillage_58_1", -315.6, 371.41, -1374.85, 180, "TREASUREBOX_LV_F_HUEVILLAGE_58_150", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(51, 40095, " ", "f_huevillage_58_1", 263.469, 156.4492, 928.6599, 90, "", "EXPLORER_MISLE10", "");
		AddNpc(52, 160034, "Transportation Device", "f_huevillage_58_1", 647.7823, 102.4037, 463.3117, 90, "", "", "");
		AddNpc(53, 160034, "Transportation Device", "f_huevillage_58_1", 637.1606, 370.2988, -83.6208, 90, "", "", "");
	}
}
