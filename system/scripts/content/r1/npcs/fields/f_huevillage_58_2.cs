//--- Melia Script ----------------------------------------------------------
// Vieta Gorge
//--- Description -----------------------------------------------------------
// NPCs found in and around Vieta Gorge.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FHuevillage582NpcScript : GeneralScript
{
	public override void Load()
	{
		// Old Man of Andale Village
		//-------------------------------------------------------------------------
		AddNpc(4, 147396, "Old Man of Andale Village", "f_huevillage_58_2", -186.69, 274.21, -1570.87, 73, "HUEVILLAGE_58_2_MQ01_NPC", "", "", 0);
		
		// Andale Village Priest
		//-------------------------------------------------------------------------
		AddNpc(5, 147409, "Andale Village Priest", "f_huevillage_58_2", -239.14, 0.25, -200.18, 73, "HUEVILLAGE_58_2_MQ02_NPC", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(6, 40095, " ", "f_huevillage_58_2", 58.31734, -57.3364, 653.9138, 90, "HUEVILLAGE_58_2_SQ01_NPC", "", "");
		
		// Wood Sap Container
		//-------------------------------------------------------------------------
		AddNpc(7, 151028, "Wood Sap Container", "f_huevillage_58_2", -89, 41, 1399, 90, "HUEVILLAGE_58_2_MQ02_BUCKET01", "", "");
		
		// Wood Sap Container
		//-------------------------------------------------------------------------
		AddNpc(7, 151028, "Wood Sap Container", "f_huevillage_58_2", -243, 41, 1305, 90, "HUEVILLAGE_58_2_MQ02_BUCKET01", "", "");
		
		// Wood Sap Container
		//-------------------------------------------------------------------------
		AddNpc(7, 151028, "Wood Sap Container", "f_huevillage_58_2", -345, 41, 1134, 90, "HUEVILLAGE_58_2_MQ02_BUCKET01", "", "");
		
		// Wood Sap Container
		//-------------------------------------------------------------------------
		AddNpc(7, 151028, "Wood Sap Container", "f_huevillage_58_2", 83, 41, 1278, 90, "HUEVILLAGE_58_2_MQ02_BUCKET01", "", "");
		
		// Wood Sap Container
		//-------------------------------------------------------------------------
		AddNpc(8, 147354, "Wood Sap Container", "f_huevillage_58_2", 181, 41, 1363, 90, "HUEVILLAGE_58_2_MQ02_BUCKET02", "", "");
		
		// Ershike Altar
		//-------------------------------------------------------------------------
		AddNpc(15, 147417, "Ershike Altar", "f_huevillage_58_2", -439, 50, 234, 45, "HUEVILLAGE_58_2_MQ03_NPC", "", "");
		
		// Obelisk
		//-------------------------------------------------------------------------
		AddNpc(19, 147414, "Obelisk", "f_huevillage_58_2", 859, 0, 205, 20, "HUEVILLAGE_58_2_OBELISK_BEFORE", "", "", 0);
		
		// Veja Ravine
		//-------------------------------------------------------------------------
		AddNpc(22, 40001, "Veja Ravine", "f_huevillage_58_2", 439.58, 274.21, -1641.15, 95, "", "HUEVILLAGE58_2_TO_HUEVILLAGE58_1", "");
		
		// Cobalt Forest
		//-------------------------------------------------------------------------
		AddNpc(23, 40001, "Cobalt Forest", "f_huevillage_58_2", 1461.54, -10.36, 1157.1, 173, "", "HUEVILLAGE58_2_TO_HUEVILLAGE58_3", "");
		
		// Gravestone
		//-------------------------------------------------------------------------
		AddNpc(27, 47192, "Gravestone", "f_huevillage_58_2", -254.08, 52.89, 250.03, 91, "HUEVILLAGE_58_2_STORN01", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(34, 40120, "Statue of Goddess Vakarine", "f_huevillage_58_2", -515.8, 271.89, -1541.66, 125, "WARP_F_HUEVILLAGE_58_2", "STOUP_CAMP", "STOUP_CAMP");
		
		// Obelisk
		//-------------------------------------------------------------------------
		AddNpc(35, 147414, "Obelisk", "f_huevillage_58_2", 859, 0, 205, 20, "", "HUEVILLAGE_58_2_OBELISK_AFTER", "");
		AddNpc(37, 147366, "Field Gen x", "f_huevillage_58_2", -696.94, 274.21, -1209.64, 90, "", "", "");
		AddNpc(37, 147366, "Field Gen x", "f_huevillage_58_2", -368.19, 274.21, -1528.76, 90, "", "", "");
		AddNpc(37, 147366, "Field Gen x", "f_huevillage_58_2", 87.16, 274.21, -1648.95, 90, "", "", "");
		AddNpc(37, 147366, "Field Gen x", "f_huevillage_58_2", -120.21, 274.21, -1608.63, 90, "", "", "");
		AddNpc(37, 147366, "Field Gen x", "f_huevillage_58_2", 411.04, 274.21, -1647.49, 90, "", "", "");
		
		// JOB_PALADIN3_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(1, 20026, "JOB_PALADIN3_1_TRIGGER", "f_huevillage_58_2", -686.4, 274.21, -1179.39, 90, "", "JOB_PALADIN3_1_TRIGGER", "");
		AddNpc(41, 147363, "Field Gen x", "f_huevillage_58_2", -224.2, 0.33, -195.08, 90, "", "", "");
		AddNpc(42, 147366, "Field Gen x", "f_huevillage_58_2", 803.55, 0.65, 343.43, 90, "", "", "");
		AddNpc(42, 147366, "Field Gen x", "f_huevillage_58_2", 1484.24, -10.36, 1092.74, 90, "", "", "");
		
		// Gytis Settlement Area
		//-------------------------------------------------------------------------
		AddNpc(46, 40001, "Gytis Settlement Area", "f_huevillage_58_2", -390.231, 271.8455, -1617.554, -8, "", "HUEVILLAGE_58_2_SIAUL50_1", "");
		AddNpc(47, 20026, "", "f_huevillage_58_2", 479.2794, 173.6138, -816.7524, 90, "", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(48, 147392, "Lv1 Treasure Chest", "f_huevillage_58_2", -862, 5.811579, 203, 0, "TREASUREBOX_LV_F_HUEVILLAGE_58_248", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(49, 147392, "Lv1 Treasure Chest", "f_huevillage_58_2", -159.95, 274.31, -1274.28, 90, "TREASUREBOX_LV_F_HUEVILLAGE_58_249", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(50, 40095, " ", "f_huevillage_58_2", -836.0075, 273.4701, -1075.877, 90, "", "EXPLORER_MISLE21", "");
	}
}
