//--- Melia Script ----------------------------------------------------------
// Poslinkis Forest
//--- Description -----------------------------------------------------------
// NPCs found in and around Poslinkis Forest.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FKatyn13NpcScript : GeneralScript
{
	public override void Load()
	{
		// Owl Burial Ground
		//-------------------------------------------------------------------------
		AddNpc(4, 40001, "Owl Burial Ground", "f_katyn_13", 71, 123, -2123, 94, "", "KATYN13_KATYN7_2", "");
		
		// Sincere Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(95, 12081, "Sincere Owl Sculpture", "f_katyn_13", -663, 238, -797, 0, "KATYN13_1_OWLBOSS", "", "");
		
		// Scared Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(96, 48004, "Scared Owl Sculpture", "f_katyn_13", -353, 120, -2081, 0, "KATYN13_1_KEYNPC", "", "");
		
		// Devoted Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(97, 48004, "Devoted Owl Sculpture", "f_katyn_13", 809, 239, -960, 0, "KATYN13_1_OWLJUNIOR1", "", "");
		
		// Troubled Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(98, 48004, "Troubled Owl Sculpture", "f_katyn_13", 909, 239, 1010, 0, "KATYN13_1_OWLJUNIOR2", "", "");
		
		// Weak Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(99, 48024, "Weak Owl Sculpture", "f_katyn_13", -1180, 238, 977, 0, "KATYN13_1_OWLJUNIOR3", "", "", 0);
		
		// Defeat the monsters blocking the road
		//-------------------------------------------------------------------------
		AddNpc(701, 20041, "Defeat the monsters blocking the road", "f_katyn_13", -665.667, 238.8102, -1326.814, -5, "", "KATYN13_1_KEY_SUB1_TRIGGER", "");
		
		// Defeat the monsters blocking the road
		//-------------------------------------------------------------------------
		AddNpc(702, 20041, "Defeat the monsters blocking the road", "f_katyn_13", 1188, 239, 303, 0, "", "KATYN13_1_TO_OWLJUNIOR2_S1_TRIGGER", "");
		
		// Defeat the monsters blocking the road
		//-------------------------------------------------------------------------
		AddNpc(704, 20041, "Defeat the monsters blocking the road", "f_katyn_13", -897.2285, 237.8263, 202.1599, 0, "", "KATYN13_1_TO_OWLJUNIOR3_S1_TRIGGER", "");
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(705, 48021, "Broken Owl Statue", "f_katyn_13", -2290, 240, 1381, 90, "KATYN13_ADDQUEST1_NPC", "", "", 0);
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(706, 48022, "Broken Owl Statue", "f_katyn_13", -2324.545, 241.1181, 1368.72, 60, "KATYN13_ADDQUEST1_NPC", "", "", 0);
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(707, 48023, "Broken Owl Statue", "f_katyn_13", -2307, 240, 1389, 120, "KATYN13_ADDQUEST1_NPC", "", "", 0);
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(708, 48024, "Broken Owl Statue", "f_katyn_13", -1069.055, 239.8916, 2324.004, 0, "KATYN13_ADDQUEST2_NPC", "", "", 0);
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(709, 48021, "Broken Owl Statue", "f_katyn_13", -1094.45, 240.1709, 2329.341, 45, "KATYN13_ADDQUEST2_NPC", "", "", 0);
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(710, 48022, "Broken Owl Statue", "f_katyn_13", -1090, 240, 2298, 60, "KATYN13_ADDQUEST2_NPC", "", "", 0);
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(711, 48023, "Broken Owl Statue", "f_katyn_13", 8, 240, 1440, 30, "KATYN13_ADDQUEST3_NPC", "", "", 0);
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(712, 48024, "Broken Owl Statue", "f_katyn_13", 14, 239, 1455, 50, "KATYN13_ADDQUEST3_NPC", "", "", 0);
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(713, 48021, "Broken Owl Statue", "f_katyn_13", 25, 240, 1441, 160, "KATYN13_ADDQUEST3_NPC", "", "", 0);
		
		// Oil Boxes
		//-------------------------------------------------------------------------
		AddNpc(717, 46212, "Oil Boxes", "f_katyn_13", -1330, 237, 255, 180, "KATYN13_ADDQUEST4_NPC", "KATYN13_ADDQUEST4_TRIGGER", "");
		
		// Oil Boxes
		//-------------------------------------------------------------------------
		AddNpc(718, 46212, "Oil Boxes", "f_katyn_13", -1336, 237, 274, 180, "KATYN13_ADDQUEST4_NPC", "KATYN13_ADDQUEST4_TRIGGER", "");
		
		// Oil Boxes
		//-------------------------------------------------------------------------
		AddNpc(719, 46212, "Oil Boxes", "f_katyn_13", -1321, 237, 269, 180, "KATYN13_ADDQUEST4_NPC", "KATYN13_ADDQUEST4_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(721, 40095, " ", "f_katyn_13", -2283.21, 240.42, 1364.55, 0, "KATYN13_ADDQUEST6_NPC", "KATYN13_ADDQUEST1_TRIGGER1", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(722, 40095, " ", "f_katyn_13", -1076.23, 239.95, 2296.26, 0, "KATYN13_ADDQUEST7_NPC", "KATYN13_ADDQUEST2_TRIGGER1", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(723, 40095, " ", "f_katyn_13", 20.36, 240.76, 1426.14, 0, "KATYN13_ADDQUEST8_NPC", "KATYN13_ADDQUEST3_TRIGGER1", "", 1);
		
		// Captain Owl's Favor
		//-------------------------------------------------------------------------
		AddNpc(750, 20041, "Captain Owl's Favor", "f_katyn_13", -985, 199, -2369, 0, "", "KATYN13_1_TO_2_TRIGGER", "");
		
		// Weak Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(754, 48004, "Weak Owl Sculpture", "f_katyn_13", -1180, 238, 977, 0, "KATYN13_1_OWLJUNIOR3_AFTER", "", "", 1);
		
		// Saknis Plains
		//-------------------------------------------------------------------------
		AddNpc(759, 40001, "Saknis Plains", "f_katyn_13", -2725, 240, 1296, 270, "", "KATYN13_KATYN14", "");
		
		// ThaumaturgeElementalist5thAdvancementTrigger
		//-------------------------------------------------------------------------
		AddNpc(761, 20026, "ThaumaturgeElementalist5thAdvancementTrigger", "f_katyn_13", -1211.792, 288.1821, 1237.367, 90, "", "JOB_THAUELE5_1_TRIGGER", "");
		AddNpc(762, 20041, "Trigger of Hidden Shop Creation", "f_katyn_13", 2130, 238, -613, 90, "", "", "");
		
		// Septyni Glen
		//-------------------------------------------------------------------------
		AddNpc(765, 40001, "Septyni Glen", "f_katyn_13", -1079.035, 200.5295, -2373.376, 270, "", "KATYN13_HUEVILLAGE58_4", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(766, 147392, "Lv1 Treasure Chest", "f_katyn_13", -752.2082, 237.8263, 218.0627, 0, "KATYN13_1_TO_OWLJUNIOR3_S1_BOX", "", "", 0);
		
		// Caved Area
		//-------------------------------------------------------------------------
		AddNpc(767, 147372, "Caved Area", "f_katyn_13", -737.9014, 238.8102, -1405.336, 90, "KATYN13_1_KEY_SUB1_TRUFFLE", "", "", 0);
		
		// Magic Condenser
		//-------------------------------------------------------------------------
		AddNpc(768, 153059, "Magic Condenser", "f_katyn_13", 719.2162, 288.6631, -367.0856, -44, "PARTY_Q7_DEVICE", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(769, 147369, " ", "f_katyn_13", 718.7714, 288.663, -368.1559, -39, "", "PARTY_Q7_DEVICE02", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(773, 147392, "Lv1 Treasure Chest", "f_katyn_13", -1017.59, 237.9, -1066.07, 90, "TREASUREBOX_LV_F_KATYN_13773", "", "");
		
		// Unidentified Spirit
		//-------------------------------------------------------------------------
		AddNpc(775, 152002, "Unidentified Spirit", "f_katyn_13", 1930.831, 238.9895, -236.8079, 69, "CHAR120_MSTEP6_1_NPC1", "", "", 1);
		
		// Unidentified Spirit
		//-------------------------------------------------------------------------
		AddNpc(776, 20138, "Unidentified Spirit", "f_katyn_13", 1896.364, 238.9895, -260.493, 90, "CHAR120_MSTEP6_1_NPC2", "", "", 1);
		
		// Unidentified Spirit
		//-------------------------------------------------------------------------
		AddNpc(777, 20154, "Unidentified Spirit", "f_katyn_13", 1923.415, 238.9895, -189.9675, 47, "CHAR120_MSTEP6_1_NPC3", "", "", 1);
		
		// Asana
		//-------------------------------------------------------------------------
		AddNpc(778, 152001, "Asana", "f_katyn_13", 2014, 238, -226, 47, "CHAR120_MSTEP5_2_NPC3", "", "", 1);
		
		// Eimantas
		//-------------------------------------------------------------------------
		AddNpc(780, 147481, "Eimantas", "f_katyn_13", 1987.851, 238.9895, -252.8366, 90, "CHAR120_MSTEP5_NPC2", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(781, 20026, "", "f_katyn_13", 1066.655, 238.6115, -827.7272, 90, "", "CHAR220_MSETP2_2_1_GEN_INIT", "");
		
		// Eimantas
		//-------------------------------------------------------------------------
		AddNpc(774, 155041, "Eimantas", "f_katyn_13", 1987.851, 238.9895, -252.8366, 90, "CHAR120_MSTEP5_NPC1", "CHAR120_MSTEP5_NPC1_IN", "", 1);
	}
}
