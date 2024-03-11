//--- Melia Script ----------------------------------------------------------
// Underground Grave of Ritinis
//--- Description -----------------------------------------------------------
// NPCs found in and around Underground Grave of Ritinis.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class IdCatacomb04NpcScript : GeneralScript
{
	public override void Load()
	{
		// Mokusul Chamber
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Mokusul Chamber", "id_catacomb_04", -332.5004, 193.4551, -1978.717, 90, "", "CATACOMB_04_CATACOMB_38_2", "");
		
		// Videntis Shrine
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Videntis Shrine", "id_catacomb_04", 2267.073, 325.2974, 1353.261, 180, "", "CATACOMB_04_CATACOMB_38_1", "");
		
		// Istora Ruins
		//-------------------------------------------------------------------------
		AddNpc(3, 40001, "Istora Ruins", "id_catacomb_04", -2243.331, 368.4542, -429.943, 235, "", "CATACOMB_04_REMAINS37_3", "");
		
		// Teleport Device
		//-------------------------------------------------------------------------
		AddNpc(4, 147500, "Teleport Device", "id_catacomb_04", 3279.531, 370.8011, -948.3315, 225, "CATACOMB_04_SECRETOUT", "", "");
		
		// Magic Gem Fusion Device
		//-------------------------------------------------------------------------
		AddNpc(6, 147475, "Magic Gem Fusion Device", "id_catacomb_04", -423.866, 272.5154, -1760.795, 90, "CATACOMB_04_OBJ_01", "", "");
		
		// Magic Field of Preservation
		//-------------------------------------------------------------------------
		AddNpc(7, 154000, "Magic Field of Preservation", "id_catacomb_04", -1566, 346.3554, -756, 90, "CATACOMB_04_OBJ_02", "", "");
		
		// Barrier Stone
		//-------------------------------------------------------------------------
		AddNpc(8, 147413, "Barrier Stone", "id_catacomb_04", 617, 285.2842, 1192, 90, "CATACOMB_04_OBJ_03", "", "", 0);
		
		// Sealed Spatial Magic Gem
		//-------------------------------------------------------------------------
		AddNpc(9, 151058, "Sealed Spatial Magic Gem", "id_catacomb_04", 1589, 265.3084, 861, 180, "CATACOMB_04_OBJ_04", "", "", 0);
		
		// Black Shadow
		//-------------------------------------------------------------------------
		AddNpc(10, 147469, "Black Shadow", "id_catacomb_04", -774, 264.8956, 952, 90, "CATACOMB_04_OBJ_05", "", "", 1);
		
		// Teleport Device
		//-------------------------------------------------------------------------
		AddNpc(11, 147500, "Teleport Device", "id_catacomb_04", 1395.222, 419.9288, -154.5499, 90, "CATACOMB_04_OBJ_06", "", "");
		
		// The Inheritance of the Master
		//-------------------------------------------------------------------------
		AddNpc(12, 151052, "The Inheritance of the Master", "id_catacomb_04", 2918, 385.5559, -1596, 225, "CATACOMB_04_OBJ_07", "", "");
		AddNpc(16, 147366, "Gate Entrance x", "id_catacomb_04", 2604.43, 391.7112, -1284.371, 90, "", "", "");
		AddNpc(16, 147366, "Gate Entrance x", "id_catacomb_04", 2760.448, 391.7112, -1695.491, 90, "", "", "");
		AddNpc(16, 147366, "Gate Entrance x", "id_catacomb_04", 2993.383, 391.7112, -1447.848, 90, "", "", "");
		AddNpc(16, 147366, "Gate Entrance x", "id_catacomb_04", 3174.381, 377.6325, -1063.251, 90, "", "", "");
		AddNpc(17, 147364, "Gate Entrance x", "id_catacomb_04", -439.5161, 193.4551, -2002.339, 90, "", "", "");
		AddNpc(17, 147364, "Gate Entrance x", "id_catacomb_04", 2268.249, 308.3572, 1303.312, 90, "", "", "");
		AddNpc(17, 147364, "Gate Entrance x", "id_catacomb_04", -2196.184, 348.4096, -462.0588, 90, "", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(1000, 147392, "Lv1 Treasure Chest", "id_catacomb_04", -126.31, 265, 1200.43, -45, "TREASUREBOX_LV_ID_CATACOMB_041000", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1001, 152057, " ", "id_catacomb_04", 2068.551, 306.68, 1249.537, 90, "HT_CATACOMB_04_SKULL", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1001, 152057, " ", "id_catacomb_04", 2069.956, 307.28, 1197.621, 90, "HT_CATACOMB_04_SKULL", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1001, 152057, " ", "id_catacomb_04", 2071.464, 307.82, 1151.012, 90, "HT_CATACOMB_04_SKULL", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1001, 152057, " ", "id_catacomb_04", 2069.15, 308.36, 973.76, 90, "HT_CATACOMB_04_SKULL", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1001, 152057, " ", "id_catacomb_04", 2069.725, 308.36, 885.4551, 90, "HT_CATACOMB_04_SKULL", "", "");
	}
}
