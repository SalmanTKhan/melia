//--- Melia Script ----------------------------------------------------------
// Mage Tower 1F
//--- Description -----------------------------------------------------------
// NPCs found in and around Mage Tower 1F.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DFiretower41NpcScript : GeneralScript
{
	public override void Load()
	{
		// Fedimian Suburbs
		//-------------------------------------------------------------------------
		AddNpc(20, 147500, "Fedimian Suburbs", "d_firetower_41", -2301.328, 1552.729, -1410.267, 90, "", "FIRETOWER41_TO_REMAINS40", "");
		
		// Mage Tower 2F
		//-------------------------------------------------------------------------
		AddNpc(21, 147500, "Mage Tower 2F", "d_firetower_41", 2956.427, 1460.486, -1409.302, 90, "", "FIRETOWER41_TO_FIRETOWER42", "");
		
		// Grita
		//-------------------------------------------------------------------------
		AddNpc(100, 147449, "Grita", "d_firetower_41", -2600, 1552, -1571, 90, "FTOWER41_GRITA_01", "", "", 1);
		
		// Defense Activation Device 
		//-------------------------------------------------------------------------
		AddNpc(105, 151000, "Defense Activation Device ", "d_firetower_41", 2360, 1335, -2276, 135, "FTOWER41_MQ_05", "", "");
		
		// 2nd Transport Magic Circle
		//-------------------------------------------------------------------------
		AddNpc(104, 147500, "2nd Transport Magic Circle", "d_firetower_41", -582, 1410, -1856, 90, "FTOWER41_MQ_03", "", "", 0);
		
		// Owyn
		//-------------------------------------------------------------------------
		AddNpc(107, 20117, "Owyn", "d_firetower_41", -1664, 1489, -1786, 90, "FTOWER41_SQ_01", "", "");
		
		// Cordelier
		//-------------------------------------------------------------------------
		AddNpc(108, 20146, "Cordelier", "d_firetower_41", 491, 1482, -1696, 90, "FTOWER41_SQ_03", "", "");
		
		// Book Shelf
		//-------------------------------------------------------------------------
		AddNpc(109, 147372, "Book Shelf", "d_firetower_41", 1199.668, 1602.249, -891.27, 90, "FTOWER41_SQ_05_NPC", "", "");
		
		// JOB_THAUMATURGE4_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(110, 20026, "JOB_THAUMATURGE4_1_TRIGGER", "d_firetower_41", 1860.145, 1334.283, -2304.492, 90, "", "JOB_THAUMATURGE4_1_TRIGGER", "");
		
		// 1st Transport Magic Circle
		//-------------------------------------------------------------------------
		AddNpc(112, 147500, "1st Transport Magic Circle", "d_firetower_41", -1609, 1552, -1402, 90, "FTOWER41_MQ_02_NPC", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(116, 40120, "Statue of Goddess Vakarine", "d_firetower_41", 2005.266, 1446.488, -1369.808, 30, "WARP_D_FIRETOWER_41", "STOUP_CAMP", "STOUP_CAMP");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(120, 40095, "", "d_firetower_41", -2176.399, 1490.141, -2123.405, 90, "FTOWER41_MQ_01_NPC", "", "");
		AddNpc(122, 147366, "No Field Gen", "d_firetower_41", -2482.698, 1552.729, -1427.249, 90, "", "", "");
		AddNpc(123, 147364, "No Field Gen", "d_firetower_41", 514.0264, 1482.606, -1729.013, 90, "", "", "");
		AddNpc(122, 147366, "No Field Gen", "d_firetower_41", 2926.119, 1460.486, -1442.581, 90, "", "", "");
		AddNpc(123, 147364, "No Field Gen", "d_firetower_41", -2181.629, 1489.793, -2197.364, 90, "", "", "");
		
		// Psychokino Tome Volume 1
		//-------------------------------------------------------------------------
		AddNpc(125, 147311, "Psychokino Tome Volume 1", "d_firetower_41", 1252.079, 1334.283, -2282.968, 90, "JOB_2_PSYCHOKINO_5_1_BOOK_1", "", "", 1);
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(126, 147392, "Lv1 Treasure Chest", "d_firetower_41", -2714.8, 1552.83, -1436.66, 90, "TREASUREBOX_LV_D_FIRETOWER_41126", "", "");
	}
}
