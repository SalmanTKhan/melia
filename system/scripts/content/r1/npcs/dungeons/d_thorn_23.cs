//--- Melia Script ----------------------------------------------------------
// Sunset Flag Forest
//--- Description -----------------------------------------------------------
// NPCs found in and around Sunset Flag Forest.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DThorn23NpcScript : GeneralScript
{
	public override void Load()
	{
		// Dvasia Peak
		//-------------------------------------------------------------------------
		AddNpc(15, 40001, "Dvasia Peak", "d_thorn_23", -2159, 1137, -2969, 252, "", "THORN23_THORN22", "");
		
		// Gateway of the Great King
		//-------------------------------------------------------------------------
		AddNpc(16, 40001, "Gateway of the Great King", "d_thorn_23", 2420, 289, 2163, 163, "", "THORN23_ROKAS24", "");
		
		// Sunset Flag Forest
		//-------------------------------------------------------------------------
		AddNpc(17, 40001, "Sunset Flag Forest", "d_thorn_23", -1528, 1041, -1792, 215, "", "THORN23_1_THORN23_2", "");
		
		// Sunset Flag Forest
		//-------------------------------------------------------------------------
		AddNpc(18, 40001, "Sunset Flag Forest", "d_thorn_23", -1631, 1026, -1637, 25, "", "THORN23_2_THORN23_1", "");
		
		// Sunset Flag Forest
		//-------------------------------------------------------------------------
		AddNpc(19, 40001, "Sunset Flag Forest", "d_thorn_23", 2295, 384, 937, 144, "", "THORN23_2_THORN23_3", "");
		
		// Sunset Flag Forest
		//-------------------------------------------------------------------------
		AddNpc(20, 40001, "Sunset Flag Forest", "d_thorn_23", 2581, 384, 1036, -83, "", "THORN23_3_THORN23_2", "");
		
		// Soldier Alan
		//-------------------------------------------------------------------------
		AddNpc(502, 20011, "Soldier Alan", "d_thorn_23", -1578.7, 1137.75, -2850.12, 90, "THORN23_ALAN", "", "", 0);
		
		// Commander Wallace
		//-------------------------------------------------------------------------
		AddNpc(504, 20107, "Commander Wallace", "d_thorn_23", -1494, 965, -1093, 90, "THORN23_WALLACE", "", "", 0);
		
		// Soldier Weiz
		//-------------------------------------------------------------------------
		AddNpc(505, 20013, "Soldier Weiz", "d_thorn_23", -1887.8, 798.14, 337.47, 90, "THORN23_WISE", "", "", 0);
		
		// Old Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(510, 48004, "Old Owl Sculpture", "d_thorn_23", 390, 459, 312, -5, "THORN23_OWL2", "", "");
		
		// Worrying Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(514, 12081, "Worrying Owl Sculpture", "d_thorn_23", 734, 515, -252, -5, "THORN23_OWL3", "", "");
		
		// Sleeping Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(515, 153036, "Sleeping Owl Statue", "d_thorn_23", 1345.73, 514.5, 164.33, -5, "THORN23_OWL4", "", "", 0);
		
		// Sleeping Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(516, 153037, "Sleeping Owl Statue", "d_thorn_23", 1428.57, 515.6718, -118.9404, -5, "THORN23_OWL5", "", "", 0);
		
		// Sleeping Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(517, 153038, "Sleeping Owl Statue", "d_thorn_23", 1030.352, 515.6605, 38.84108, 16, "THORN23_OWL6", "", "");
		
		// Gaigalas Summoning Area
		//-------------------------------------------------------------------------
		AddNpc(518, 20026, "Gaigalas Summoning Area", "d_thorn_23", 2517.447, 288.7384, 1577.391, 90, "", "THORN23_BOSS_TRIGGER", "");
		
		// Useless Report Trigger
		//-------------------------------------------------------------------------
		AddNpc(601, 20041, "Useless Report Trigger", "d_thorn_23", -1916.87, 1137.75, -2346.68, 90, "", "THORN23_Q_4_TRIGGER", "");
		
		// Tomb
		//-------------------------------------------------------------------------
		AddNpc(602, 47170, "Tomb", "d_thorn_23", -833.408, 1070.326, -1295.349, 37, "THORN23_Q_7_TRIGGER", "", "");
		
		// Kvailas Forest
		//-------------------------------------------------------------------------
		AddNpc(604, 40001, "Kvailas Forest", "d_thorn_23", -588, 544, 899, 180, "", "THORN23_THORN21", "");
		AddNpc(609, 20041, "THORN_23_HQ01 Soldiers Trigger", "d_thorn_23", -901.43, 777.28, -705.55, 90, "", "", "");
		
		// Firewood
		//-------------------------------------------------------------------------
		AddNpc(509, 47223, "Firewood", "d_thorn_23", -993, 600, 290, 90, "THORN23_FIRETRIGGER", "THORN23_BONFIRE", "");
		AddNpc(629, 151000, " ", "d_thorn_23", -551.9221, 575.9372, 307.6099, 154, "", "", "");
		AddNpc(630, 147362, "Field Gen x", "d_thorn_23", -2093.752, 1137.75, -2972.707, 90, "", "", "");
		AddNpc(630, 147362, "Field Gen x", "d_thorn_23", -1483.259, 1041.166, -1846.156, 90, "", "", "");
		AddNpc(630, 147362, "Field Gen x", "d_thorn_23", -1657.725, 1026.442, -1577.925, 90, "", "", "");
		AddNpc(630, 147362, "Field Gen x", "d_thorn_23", -569.866, 553.3329, 828.8657, 90, "", "", "");
		AddNpc(630, 147362, "Field Gen x", "d_thorn_23", 2262.275, 384.9307, 892.9347, 90, "", "", "");
		AddNpc(630, 147362, "Field Gen x", "d_thorn_23", 2646.512, 384.9307, 1030.487, 90, "", "", "");
		AddNpc(630, 147362, "Field Gen x", "d_thorn_23", 2408.298, 289.4841, 2111.454, 90, "", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(631, 147392, "Lv1 Treasure Chest", "d_thorn_23", -1369.76, 1041.88, -1847.77, 90, "TREASUREBOX_LV_D_THORN_23631", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(632, 20026, " ", "d_thorn_23", -1577.77, 1137.75, -2852.41, 90, "", "HT2_THORN23_ALAN_EFFECT", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(632, 20026, " ", "d_thorn_23", -1461.79, 1137.75, -2749.7, 90, "", "HT2_THORN23_ALAN_EFFECT", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(633, 20026, " ", "d_thorn_23", -1494.42, 965.38, -1091.03, 90, "", "HT2_THORN23_WALLACE_EFFECT", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(634, 20026, " ", "d_thorn_23", -1881.967, 798.14, 339.897, 90, "", "HT2_THORN23_WISE_EFFECT", "");
	}
}