//--- Melia Script ----------------------------------------------------------
// Demon Prison District 2
//--- Description -----------------------------------------------------------
// NPCs found in and around Demon Prison District 2.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DVelniasprison512NpcScript : GeneralScript
{
	public override void Load()
	{
		// Kupole Arune
		//-------------------------------------------------------------------------
		AddNpc(1, 154016, "Kupole Arune", "d_velniasprison_51_2", -93.1524, 254.129, 553.9767, 0, "VPRISON512_MQ_NORGAILE", "", "", 1);
		
		// Kupole Aldona
		//-------------------------------------------------------------------------
		AddNpc(2, 154014, "Kupole Aldona", "d_velniasprison_51_2", 989.9536, 254.1407, -57.53646, 90, "VPRISON512_MQ_ALDONA", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(3, 154000, " ", "d_velniasprison_51_2", 1105, 361, -998, 90, "VELNIASP_512_GROUP_3_2", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(4, 154000, " ", "d_velniasprison_51_2", 1187, 255, -175, 90, "VELNIASP_512_GROUP_3_1", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(5, 154000, " ", "d_velniasprison_51_2", 46, 255, 448, 90, "VELNIASP_512_GROUP_2_2", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(6, 154000, " ", "d_velniasprison_51_2", 421, 255, 441, 90, "VELNIASP_512_GROUP_2_1", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(7, 154000, " ", "d_velniasprison_51_2", 1056, 254, 990, 90, "VELNIASP_512_GROUP_1_1", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(8, 154000, " ", "d_velniasprison_51_2", 1102, 297, 1550, 90, "VELNIASP_512_GROUP_1_2", "", "");
		
		// Demon Prison District 1
		//-------------------------------------------------------------------------
		AddNpc(9, 154000, "Demon Prison District 1", "d_velniasprison_51_2", 1123, 297, 1884, 90, "VELNIASP512_TO_VELNIASP511", "", "");
		
		// Demon Prison District 3
		//-------------------------------------------------------------------------
		AddNpc(10, 154000, "Demon Prison District 3", "d_velniasprison_51_2", 1458, 183, 429, 90, "VELNIASP512_TO_VELNIASP513", "", "");
		AddNpc(14, 147366, "Gate Entrance x", "d_velniasprison_51_2", 1080.051, 182.7841, 403.7549, 90, "", "", "");
		AddNpc(15, 147365, "Gate Entrance x", "d_velniasprison_51_2", 1103.113, 296.5582, 1704.946, 90, "", "", "");
		AddNpc(16, 147364, "Gate Entrance x", "d_velniasprison_51_2", 1096.546, 360.4956, -1130.945, 90, "", "", "");
		AddNpc(16, 147364, "Gate Entrance x", "d_velniasprison_51_2", -50.13038, 254.129, 430.4098, 90, "", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(22, 40120, "Statue of Goddess Vakarine", "d_velniasprison_51_2", 1041.867, 296.5582, 1709.221, 60, "WARP_D_VPRISON_51_2", "STOUP_CAMP", "STOUP_CAMP");
		
		// Tesla's Dedication
		//-------------------------------------------------------------------------
		AddNpc(23, 147464, "Tesla's Dedication", "d_velniasprison_51_2", 1046.443, 296.5582, 1676.101, 90, "VPRISON512_STONE_01", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(25, 147392, "Lv1 Treasure Chest", "d_velniasprison_51_2", -972.24, 395.65, -460.24, 90, "TREASUREBOX_LV_D_VELNIASPRISON_51_225", "", "");
	}
}
