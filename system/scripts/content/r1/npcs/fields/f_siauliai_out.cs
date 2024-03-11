//--- Melia Script ----------------------------------------------------------
// Miners' Village
//--- Description -----------------------------------------------------------
// NPCs found in and around Miners' Village.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FSiauliaiOutNpcScript : GeneralScript
{
	public override void Load()
	{
		// Crystal Mine
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Crystal Mine", "f_siauliai_out", -213, 245, -17, -75, "", "WS_ACT3_ACT4_1", "");
		
		// Srautas Gorge
		//-------------------------------------------------------------------------
		AddNpc(3, 40001, "Srautas Gorge", "f_siauliai_out", 1832, 43, -578, 85, "", "SIALLAIOUT_GELE571", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(5, 40120, "Statue of Goddess Vakarine", "f_siauliai_out", 190.5049, 42.7921, -1214.24, 0, "WARP_F_SIAULIAI_OUT", "STOUP_CAMP", "STOUP_CAMP");
		
		// Hidden house of Krivis
		//-------------------------------------------------------------------------
		AddNpc(342, 20025, "Hidden house of Krivis", "f_siauliai_out", -142.9346, 160.27, -221.0289, 90, "JOB_KRIWI1_OUT", "", "");
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(151, 46212, "Relief Box", "f_siauliai_out", -1086, 42, -1522, 175, "SIAULIAIOUT_119_2", "", "", 0);
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(152, 46212, "Relief Box", "f_siauliai_out", -1197, 42, -1627, 175, "SIAULIAIOUT_119_3", "", "", 0);
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(153, 46212, "Relief Box", "f_siauliai_out", -1237, 90, -1457, 175, "SIAULIAIOUT_119_4", "", "", 0);
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(154, 46212, "Relief Box", "f_siauliai_out", -1160, 171, -1225, 175, "SIAULIAIOUT_119_5", "", "", 0);
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(155, 46212, "Relief Box", "f_siauliai_out", -1364, 171, -1002, 175, "SIAULIAIOUT_119_6", "", "", 0);
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(156, 46212, "Relief Box", "f_siauliai_out", -1576.49, 42.83, -1673.1, 175, "SIAULIAIOUT_119_7", "", "", 0);
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(157, 46212, "Relief Box", "f_siauliai_out", -1807, 43, -1853, 175, "SIAULIAIOUT_119_8", "", "", 0);
		
		// Relief Box
		//-------------------------------------------------------------------------
		AddNpc(158, 46212, "Relief Box", "f_siauliai_out", -2078.32, 42.83, -1782.61, 181, "SIAULIAIOUT_119_9", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(200, 10033, " ", "f_siauliai_out", -1901, 40, -1414, 90, "", "SIAULIAIOUT_RETUA", "");
		
		// Healer Lady
		//-------------------------------------------------------------------------
		AddNpc(202, 20168, "Healer Lady", "f_siauliai_out", -1913, 40, -1428, 136, "SIAULIAIOUT_HEALER_B", "", "", 0);
		
		// Healer Lady
		//-------------------------------------------------------------------------
		AddNpc(203, 20168, "Healer Lady", "f_siauliai_out", -1913, 40, -1428, -55, "SIAULIAIOUT_HEALER_C", "", "", 1);
		
		// SIAULIAIOUTQ01
		//-------------------------------------------------------------------------
		AddNpc(300, 20026, "SIAULIAIOUTQ01", "f_siauliai_out", 506, 35, -1622, 0, "", "SIAULIAIOUT_Q01", "");
		
		// Kepa Wagon
		//-------------------------------------------------------------------------
		AddNpc(306, 45315, "Kepa Wagon", "f_siauliai_out", -82, 156, -612, 61, "", "SIAULIAIOUT_CART", "");
		
		// Kepa Wagon
		//-------------------------------------------------------------------------
		AddNpc(306, 45315, "Kepa Wagon", "f_siauliai_out", -41, 157, -608, 0, "", "SIAULIAIOUT_CART", "");
		
		// Kepa Wagon
		//-------------------------------------------------------------------------
		AddNpc(306, 45315, "Kepa Wagon", "f_siauliai_out", -64, 161, -557, 0, "", "SIAULIAIOUT_CART", "");
		
		// Mine Manager Brinker
		//-------------------------------------------------------------------------
		AddNpc(308, 20109, "Mine Manager Brinker", "f_siauliai_out", -1758.601, 170.0456, -813.7792, 270, "SIAULIAIOUT_MINER_B", "", "", 0);
		
		// Mine Manager Brinker
		//-------------------------------------------------------------------------
		AddNpc(309, 20109, "Mine Manager Brinker", "f_siauliai_out", 355, 43, -1117, 0, "SIAULIAIOUT_MINER_A", "", "", 1);
		
		// Miners' Village Mayor
		//-------------------------------------------------------------------------
		AddNpc(312, 20118, "Miners' Village Mayor", "f_siauliai_out", -87.64736, 145.2319, -802.0891, 90, "SIAULIAIOUT_CHIEF_A", "", "");
		
		// SIAULIAIOUT_MIRTIS
		//-------------------------------------------------------------------------
		AddNpc(311, 20026, "SIAULIAIOUT_MIRTIS", "f_siauliai_out", 1900, 148, 130, 90, "", "SIAULIAIOUT_MIRTIS", "");
		
		// [Alchemist Master]{nl}Vaidotas
		//-------------------------------------------------------------------------
		AddNpc(313, 20110, "[Alchemist Master]{nl}Vaidotas", "f_siauliai_out", 1309.119, 147.3516, 331.726, 4, "SIAULIAIOUT_ALCHE", "", "", 0);
		
		// SIAULIAIOUTALCHE
		//-------------------------------------------------------------------------
		AddNpc(314, 20026, "SIAULIAIOUTALCHE", "f_siauliai_out", 1298, 147, 307, 90, "", "SIAULIAIOUT_PREAL", "");
		
		// SIAULIAIOUTBOSS
		//-------------------------------------------------------------------------
		AddNpc(315, 20026, "SIAULIAIOUTBOSS", "f_siauliai_out", 1434, 231, 535, 90, "", "SIAULIAIOUT_BOSS", "");
		
		// SIAULIAIOUTQ03
		//-------------------------------------------------------------------------
		AddNpc(316, 20026, "SIAULIAIOUTQ03", "f_siauliai_out", -468, 39, -1514, 90, "", "SIAULIAIOUT_Q03", "");
		
		// Hunter
		//-------------------------------------------------------------------------
		AddNpc(317, 47245, "Hunter", "f_siauliai_out", -945, 39, -1812, 90, "SIAULIAIOUT_HUNTER", "", "");
		
		// SIAULIAIOUTQ06
		//-------------------------------------------------------------------------
		AddNpc(318, 20026, "SIAULIAIOUTQ06", "f_siauliai_out", -1143, 169, -1248, 90, "", "SIAULIAIOUT_Q06", "");
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(159, 10043, "Reinforcement Stone", "f_siauliai_out", -1749, 171, -1110, 90, "SIAULIAIOUT_STONE", "", "", 1);
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(160, 10043, "Reinforcement Stone", "f_siauliai_out", -1704, 171, -1248, 90, "SIAULIAIOUT_STONE", "", "", 1);
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(161, 10043, "Reinforcement Stone", "f_siauliai_out", -1591, 171, -1208, 90, "SIAULIAIOUT_STONE", "", "", 1);
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(162, 10043, "Reinforcement Stone", "f_siauliai_out", -1514, 171, -1323, 90, "SIAULIAIOUT_STONE", "", "", 1);
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(163, 10043, "Reinforcement Stone", "f_siauliai_out", -1426, 171, -1163, 90, "SIAULIAIOUT_STONE", "", "", 1);
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(164, 10043, "Reinforcement Stone", "f_siauliai_out", -1229, 171, -1099, 90, "SIAULIAIOUT_STONE", "", "", 1);
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(165, 10043, "Reinforcement Stone", "f_siauliai_out", -1186, 171, -975, 90, "SIAULIAIOUT_STONE", "", "", 1);
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(166, 10043, "Reinforcement Stone", "f_siauliai_out", -1090, 171, -1151, 90, "SIAULIAIOUT_STONE", "", "", 1);
		
		// Reinforcement Stone
		//-------------------------------------------------------------------------
		AddNpc(167, 10043, "Reinforcement Stone", "f_siauliai_out", -1560, 171, -826, 90, "SIAULIAIOUT_STONE", "", "", 1);
		
		// SIAULIAIOUTQ11
		//-------------------------------------------------------------------------
		AddNpc(319, 20026, "SIAULIAIOUTQ11", "f_siauliai_out", 828, 37, -931, 90, "", "SIAULIAIOUT_Q11", "");
		
		// SIAULIAIOUTQ12
		//-------------------------------------------------------------------------
		AddNpc(320, 20026, "SIAULIAIOUTQ12", "f_siauliai_out", 1377, 43, -455, 90, "", "SIAULIAIOUT_Q12", "");
		
		// [Alchemist Master]{nl}Vaidotas
		//-------------------------------------------------------------------------
		AddNpc(321, 20110, "[Alchemist Master]{nl}Vaidotas", "f_siauliai_out", -38.88, 85.27, -1021.81, 90, "SIAULIAIOUT_ALCHE_A", "SIAULIAIOUT_ALCHE_A", "", 1);
		
		// Wagon Explosion
		//-------------------------------------------------------------------------
		AddNpc(322, 40095, "Wagon Explosion", "f_siauliai_out", -61, 157, -656, 90, "SIAULIAIOUT_BLOCK", "", "", 1);
		
		// SOUT_SUDD
		//-------------------------------------------------------------------------
		AddNpc(329, 20026, "SOUT_SUDD", "f_siauliai_out", -1531.77, 42.83, -1751.32, 90, "", "SOUT_SUDD", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(10001, 20041, "", "f_siauliai_out", 1911, 140, 75, 90, "", "JOB_HUNTER2_1_TRIGGER", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(10003, 20041, "", "f_siauliai_out", 57, 153, -133, 90, "", "JOB_HUNTER2_3_TRIGGER", "");
		
		// Notice
		//-------------------------------------------------------------------------
		AddNpc(10004, 40070, "Notice", "f_siauliai_out", -142, 153, -435, 90, "F_SIAULIA_OUT_BOARD01", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(10005, 20041, "", "f_siauliai_out", 49, 85, -1038, 90, "", "JOB_PRIEST2_1_TRIGGER", "");
		
		// Village Aunt
		//-------------------------------------------------------------------------
		AddNpc(10007, 20114, "Village Aunt", "f_siauliai_out", -54, 85, -1064, 90, "F_SIAU_OUT_NPC01", "", "", 1);
		
		// Miner
		//-------------------------------------------------------------------------
		AddNpc(10008, 20150, "Miner", "f_siauliai_out", 36, 85, -968, 90, "F_SIAU_OUT_NPC02", "", "", 1);
		
		// Village Girl
		//-------------------------------------------------------------------------
		AddNpc(10009, 147473, "Village Girl", "f_siauliai_out", 66, 88, -1083, 90, "F_SIAU_OUT_NPC03", "", "", 1);
		
		// Lot 2 Closure Notice
		//-------------------------------------------------------------------------
		AddNpc(10014, 40070, "Lot 2 Closure Notice", "f_siauliai_out", 129, 153, -18, 360, "F_SIAULIAI_OUT_BOARD02", "", "");
		
		// [Psychokino Submaster]{nl}Cielle Gudan
		//-------------------------------------------------------------------------
		AddNpc(10016, 155072, "[Psychokino Submaster]{nl}Cielle Gudan", "f_siauliai_out", 554.1078, 42.7921, -879.4257, 45, "JOB_PSYCHOKINESIST2_1_NPC", "", "");
		
		// [Linker Submaster]{nl}Roddie Kuska
		//-------------------------------------------------------------------------
		AddNpc(10017, 155073, "[Linker Submaster]{nl}Roddie Kuska", "f_siauliai_out", 312, 88, -1010, -40, "JOB_LINKER2_1_NPC", "", "", 0);
		AddNpc(10018, 147362, "Field Gen x", "f_siauliai_out", -949.56, 37.42, -1798.78, 90, "", "", "");
		AddNpc(10019, 147366, "Field Gen x", "f_siauliai_out", 71.82, 88.36, -1047.46, 90, "", "", "");
		AddNpc(10019, 147366, "Field Gen x", "f_siauliai_out", 197.06, 37.42, -1305.24, 90, "", "", "");
		AddNpc(10018, 147362, "Field Gen x", "f_siauliai_out", 1350.77, 147.35, 271.9, 90, "", "", "");
		AddNpc(10018, 147362, "Field Gen x", "f_siauliai_out", 1448.56, 229.56, 509.96, 90, "", "", "");
		
		// JOB_PSYCHOKINESIST4_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(10020, 20026, "JOB_PSYCHOKINESIST4_1_TRIGGER", "f_siauliai_out", 1463.91, 213.65, 478.93, 90, "", "JOB_PSYCHOKINESIST4_1_TRIGGER", "");
		
		// Hidden trigger for 5th advancement Psychokino_Linker_Alchemist
		//-------------------------------------------------------------------------
		AddNpc(10021, 20026, "Hidden trigger for 5th advancement Psychokino_Linker_Alchemist", "f_siauliai_out", -2108.24, 42.83, -1829.4, 121, "", "JOB_SPYLIAL5_1_TRIGGER", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(10026, 147392, "Lv1 Treasure Chest", "f_siauliai_out", 1651.87, 147.35, 427.34, 90, "TREASUREBOX_BUBE", "", "", 0);
		AddNpc(10027, 147364, "Field Gen x", "f_siauliai_out", 1733.196, 43.3667, -550.8875, 90, "", "", "");
		AddNpc(10018, 147362, "Field Gen x", "f_siauliai_out", -183.86, 246.08, -17.58, 90, "", "", "");
		
		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(10031, 40110, "Statue of Goddess Zemyna", "f_siauliai_out", -2194, 40, -2055, 84, "F_SIAULIAI_OUT_EV_55_001", "F_SIAULIAI_OUT_EV_55_001", "F_SIAULIAI_OUT_EV_55_001");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(10032, 20026, "", "f_siauliai_out", 83.14928, 88.3609, -1082.023, 90, "", "JOB_CLERIC2_2_TRIGGER", "");
		
		// Refugee
		//-------------------------------------------------------------------------
		AddNpc(10033, 152000, "Refugee", "f_siauliai_out", -2242.07, 42.83, -1971.59, 72, "SOUT_REFUGEE01", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(10036, 152000, " ", "f_siauliai_out", -1958.963, 42.8264, -1449.023, 72, "SOUT_REFUGEE01_1", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(10037, 152001, " ", "f_siauliai_out", -1935.062, 42.8264, -1467.271, 135, "SOUT_REFUGEE02_1", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(10034, 152001, " ", "f_siauliai_out", -2266.51, 42.83, -1973.57, -18, "SOUT_REFUGEE02", "", "", 0);
		
		// Safety Instructions
		//-------------------------------------------------------------------------
		AddNpc(10044, 40070, "Safety Instructions", "f_siauliai_out", -58, 150, -133, 45, "F_SIAULIAI_OUT_BOARD03", "", "");
		
		// Mine Manager Brinker
		//-------------------------------------------------------------------------
		AddNpc(10045, 20109, "Mine Manager Brinker", "f_siauliai_out", -1758.601, 170.0456, -813.7792, 15, "SIAULIAIOUT_MINER_C", "", "", 1);
		
		// Pharmacist Lady
		//-------------------------------------------------------------------------
		AddNpc(10046, 147493, "Pharmacist Lady", "f_siauliai_out", -47.84776, 85.2688, -1212.506, 90, "SOUT_PHARMACY", "", "", 1);
		
		// Soldier Jace
		//-------------------------------------------------------------------------
		AddNpc(10048, 20016, "Soldier Jace", "f_siauliai_out", 90.9569, 50.21651, -1225.092, 90, "SIAULIAIOUT_SOLDIRE_SQ31", "", "", 1);
		
		// Soldier Edgar
		//-------------------------------------------------------------------------
		AddNpc(10049, 20019, "Soldier Edgar", "f_siauliai_out", 429.0146, 42.7921, -1201.718, 90, "SIAULIAIOUT_SOLDIRE_SQ32", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(10050, 20045, "", "f_siauliai_out", -60.96616, 157.2962, -605.2911, 90, "", "SOUT_Q_16_WALL", "");
		AddNpc(10027, 147364, "Field Gen x", "f_siauliai_out", -1981.886, 42.8264, -1479.492, 90, "", "", "");
		AddNpc(10018, 147362, "Field Gen x", "f_siauliai_out", -2189.991, 42.8263, -2028.112, 90, "", "", "");
		AddNpc(10018, 147362, "Field Gen x", "f_siauliai_out", -1722.428, 170.5456, -863.6018, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(10053, 47252, " ", "f_siauliai_out", 323.6613, 150.3979, -190.6289, 27, "SIAU_HUAN_MNT", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(10054, 147392, "Lv1 Treasure Chest", "f_siauliai_out", 1224.35, 198.02, 279.95, 90, "TREASUREBOX_LV_F_SIAULIAI_OUT10054", "", "");
		
		// Lens of the Stars [Quarrel Shooter Advancement]
		//-------------------------------------------------------------------------
		AddNpc(10055, 20026, "Lens of the Stars [Quarrel Shooter Advancement]", "f_siauliai_out", -73.10419, 150.7959, -209.0591, 90, "", "JOB_QUARRELSHOOTER1_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(10056, 40095, " ", "f_siauliai_out", 1534.596, 146.8516, 221.9166, 90, "", "EXPLORER_MISLE3", "");
	}
}
