//--- Melia Script ----------------------------------------------------------
// Mokusul Chamber
//--- Description -----------------------------------------------------------
// NPCs found in and around Mokusul Chamber.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class IdCatacomb382NpcScript : GeneralScript
{
	public override void Load()
	{
		// Laukyme Swamp
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Laukyme Swamp", "id_catacomb_38_2", 1229.425, 2.2554, -1377.15, 0, "", "CATACOMB_38_2_THORN_39_3", "");
		
		// Underground Grave of Ritinis
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Underground Grave of Ritinis", "id_catacomb_38_2", -1723.054, 279.999, -1487.192, 270, "", "CATACOMB_38_2_CATACOMB_04", "");
		
		// Videntis Shrine
		//-------------------------------------------------------------------------
		AddNpc(3, 40001, "Videntis Shrine", "id_catacomb_38_2", -12.98169, -279.9601, 2080.463, 180, "", "CATACOMB_38_2_CATACOMB_38_1", "");
		
		// Disciple Laius
		//-------------------------------------------------------------------------
		AddNpc(5, 147482, "Disciple Laius", "id_catacomb_38_2", 1638.774, 35.4427, 141.474, 90, "CATACOMB_38_2_NPC_01", "", "");
		
		// Disciple Hones
		//-------------------------------------------------------------------------
		AddNpc(6, 147486, "Disciple Hones", "id_catacomb_38_2", -377.7834, 2.4037, -1014.826, 90, "CATACOMB_38_2_NPC_02", "", "");
		
		// Hardened Astral Body Crystal
		//-------------------------------------------------------------------------
		AddNpc(7, 151051, "Hardened Astral Body Crystal", "id_catacomb_38_2", -389.2628, -279.9601, 1460.534, 90, "CATACOMB_38_2_OBJ_01", "", "");
		
		// Kareras' Memoir
		//-------------------------------------------------------------------------
		AddNpc(8, 47254, "Kareras' Memoir", "id_catacomb_38_2", -2431.969, -134.8228, -747.7094, 90, "CATACOMB_38_2_DIARY_01", "", "", 1);
		
		// Records about Disciple Laius
		//-------------------------------------------------------------------------
		AddNpc(9, 147311, "Records about Disciple Laius", "id_catacomb_38_2", -2357.178, -134.8228, -861.1367, 180, "CATACOMB_38_2_DIARY_02", "", "", 1);
		
		// Records about Disciple Hones
		//-------------------------------------------------------------------------
		AddNpc(10, 147311, "Records about Disciple Hones", "id_catacomb_38_2", -2016.992, -134.8228, -265.5501, 45, "CATACOMB_38_2_DIARY_03", "", "", 1);
		
		// Finishing the research
		//-------------------------------------------------------------------------
		AddNpc(11, 147312, "Finishing the research", "id_catacomb_38_2", -1865.796, -134.8228, -410.7773, 120, "CATACOMB_38_2_DIARY_04", "", "", 1);
		
		// CATACOMB_38_2_SQ_06_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(12, 20026, "CATACOMB_38_2_SQ_06_TRIGGER", "id_catacomb_38_2", -424.3834, 184.7081, -1427.868, 90, "", "CATACOMB_38_2_SQ_06_TRIGGER", "");
		
		// Storage Box
		//-------------------------------------------------------------------------
		AddNpc(13, 151030, "Storage Box", "id_catacomb_38_2", 2404.445, 35.15652, 161.2741, -40, "CATACOMB_38_2_OBJ_02", "", "");
		
		// Storage Box
		//-------------------------------------------------------------------------
		AddNpc(14, 151030, "Storage Box", "id_catacomb_38_2", 2421.691, 1.781, -309.5009, -40, "CATACOMB_38_2_OBJ_02_EMPTY", "", "");
		
		// Storage Box
		//-------------------------------------------------------------------------
		AddNpc(14, 151030, "Storage Box", "id_catacomb_38_2", 2347.812, 1.781, -135.4374, 100, "CATACOMB_38_2_OBJ_02_EMPTY", "", "");
		
		// Storage Box
		//-------------------------------------------------------------------------
		AddNpc(14, 151030, "Storage Box", "id_catacomb_38_2", 2211.666, 1.781, -314.4012, 135, "CATACOMB_38_2_OBJ_02_EMPTY", "", "");
		
		// Storage Box
		//-------------------------------------------------------------------------
		AddNpc(14, 151030, "Storage Box", "id_catacomb_38_2", 2262.9, 1.781, 25.73061, 210, "CATACOMB_38_2_OBJ_02_EMPTY", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(18, 40120, "Statue of Goddess Vakarine", "id_catacomb_38_2", 265.5167, -279.9601, 1848.505, 0, "WARP_ID_CATACOMB_38_2", "STOUP_CAMP", "STOUP_CAMP");
		AddNpc(19, 147364, "Gate Entrance x", "id_catacomb_38_2", 248.6369, -279.9601, 1829.465, 90, "", "", "");
		AddNpc(19, 147364, "Gate Entrance x", "id_catacomb_38_2", -4.218346, -279.9601, 2030.633, 90, "", "", "");
		AddNpc(19, 147364, "Gate Entrance x", "id_catacomb_38_2", -376.575, 2.403698, -909.4868, 90, "", "", "");
		AddNpc(19, 147364, "Gate Entrance x", "id_catacomb_38_2", -232.0862, 2.403687, -1024.906, 90, "", "", "");
		AddNpc(19, 147364, "Gate Entrance x", "id_catacomb_38_2", 1728.606, 35.44273, 179.1661, 90, "", "", "");
		AddNpc(19, 147364, "Gate Entrance x", "id_catacomb_38_2", -1682.78, 266.8977, -1484.368, 90, "", "", "");
		AddNpc(19, 147364, "Gate Entrance x", "id_catacomb_38_2", 1226.652, 2.255372, -1290.33, 90, "", "", "");
		
		// [Warlock Master]{nl}Melanie Melachim
		//-------------------------------------------------------------------------
		AddNpc(21, 151069, "[Warlock Master]{nl}Melanie Melachim", "id_catacomb_38_2", 399.1917, -279.9601, 1812.767, 0, "WARLOCK_MASTER", "", "");
		
		// [Featherfoot Master]{nl}Kyoll Lurawa
		//-------------------------------------------------------------------------
		AddNpc(22, 151070, "[Featherfoot Master]{nl}Kyoll Lurawa", "id_catacomb_38_2", 143.8976, -279.9601, 1882.239, 45, "FEATHERFOOT_MASTER", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(23, 147311, " ", "id_catacomb_38_2", -1938.043, -134.8228, -843.6951, 270, "CATACOMB_38_2_HAUBERK_BOOK_1", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(1000, 147392, "Lv1 Treasure Chest", "id_catacomb_38_2", 1424.84, 2.36, -371.59, 0, "TREASUREBOX_LV_ID_CATACOMB_38_21000", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1001, 151018, " ", "id_catacomb_38_2", -336.394, 2.4, -214.0075, 90, "CATACOMB382_HIDDEN_GHOST", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1002, 20024, " ", "id_catacomb_38_2", -532.1479, 3.62, -645.5749, 90, "CATACOMB382_HIDDENQ1_SPIRIT", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1002, 20024, " ", "id_catacomb_38_2", 290.18, 2.4, -230, 90, "CATACOMB382_HIDDENQ1_SPIRIT", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1002, 20024, " ", "id_catacomb_38_2", 173.13, 2.4, -1077.57, 90, "CATACOMB382_HIDDENQ1_SPIRIT", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1002, 20024, " ", "id_catacomb_38_2", 616.67, 20.23, -612.51, 90, "CATACOMB382_HIDDENQ1_SPIRIT", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1002, 20024, " ", "id_catacomb_38_2", 1261.48, 2.26, -365.86, 90, "CATACOMB382_HIDDENQ1_SPIRIT", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1002, 20024, " ", "id_catacomb_38_2", 1507.8, 2.26, -938.65, 90, "CATACOMB382_HIDDENQ1_SPIRIT", "", "");
		
		// Suspicious Device
		//-------------------------------------------------------------------------
		AddNpc(1003, 151108, "Suspicious Device", "id_catacomb_38_2", -90.39803, 182.0752, -1621.727, 45, "LOWLV_MASTER_ENCY_SQ_50", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1004, 147424, " ", "id_catacomb_38_2", -92.30838, 182.0752, -1491.193, 3, "LOWLV_MASTER_ENCY_SQ_50_DOLL", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1005, 147424, " ", "id_catacomb_38_2", -216.1227, 182.0752, -1614.98, 88, "LOWLV_MASTER_ENCY_SQ_50_DOLL", "", "", 1);
	}
}