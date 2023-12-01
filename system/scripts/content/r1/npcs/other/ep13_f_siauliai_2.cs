//--- Melia Script ----------------------------------------------------------
// Woods of the Linked Bridges
//--- Description -----------------------------------------------------------
// NPCs found in and around Woods of the Linked Bridges.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep13FSiauliai2NpcScript : GeneralScript
{
	public override void Load()
	{
		// Lemprasa Pond
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Lemprasa Pond", "ep13_f_siauliai_2", 3378.182, 139.0712, -671.4368, 90, "", "WARP_EP13_F_SIAULIAI_2_TO_EP13_F_SIAULIAI_1", "");
		
		// Paupys Crossing
		//-------------------------------------------------------------------------
		AddNpc(4, 40001, "Paupys Crossing", "ep13_f_siauliai_2", 898.933, 256.3913, 1795.521, 166, "", "WARP_EP13_F_SIAULIAI_2_TO_EP13_F_SIAULIAI_3", "");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(5, 150242, "Goddess Lada", "ep13_f_siauliai_2", 2521.595, 139.0712, -910.572, 97, "EP13_F_SIAULIAI_2_MQ_LADA_1", "", "", 1);
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(6, 150243, "Mirtinas Crevice", "ep13_f_siauliai_2", 1268.405, 139.071, -1029.074, 90, "EP13_F_SIAULIAI_2_MQ_03_CRACK", "", "");
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(7, 150243, "Mirtinas Crevice", "ep13_f_siauliai_2", 1396.782, 139.0712, -895.5403, 263, "EP13_F_SIAULIAI_2_MQ_03_CRACK", "", "");
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(8, 150243, "Mirtinas Crevice", "ep13_f_siauliai_2", 1137.989, 139.0711, -839.8904, 6, "EP13_F_SIAULIAI_2_MQ_03_CRACK", "", "");
		AddNpc(10, 150244, " ", "ep13_f_siauliai_2", 1422.781, 139.0711, -936.9665, 91, "", "", "");
		AddNpc(11, 150244, " ", "ep13_f_siauliai_2", 1231.28, 139.071, -1059.163, -20, "", "", "");
		AddNpc(12, 150244, " ", "ep13_f_siauliai_2", 1189.12, 139.0711, -832.0726, 164, "", "", "");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(13, 150242, "Goddess Lada", "ep13_f_siauliai_2", 738.2251, 139.071, -629.3263, 12, "EP13_F_SIAULIAI_2_MQ_LADA_2", "", "", 1);
		
		// Beholder's Black Crystal
		//-------------------------------------------------------------------------
		AddNpc(14, 150245, "Beholder's Black Crystal", "ep13_f_siauliai_2", -1185.698, 2.755466, -1127.989, 84, "EP13_F_SIAULIAI_2_MQ_04_BLACKCRYSTAL", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(17, 150246, " ", "ep13_f_siauliai_2", -1185.326, 2.755467, -1126.53, 90, "", "EP13_F_SIAULIAI_2_MQ_04_SMOKE", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(18, 150247, " ", "ep13_f_siauliai_2", -1186.76, 2.755466, -1127.079, 40, "", "EP13_F_SIAULIAI_2_MQ_05_AFTER", "");
		
		// Beholder's Black Crystal
		//-------------------------------------------------------------------------
		AddNpc(19, 150245, "Beholder's Black Crystal", "ep13_f_siauliai_2", 487.0453, 183.6621, 571.4534, 90, "EP13_F_SIAULIAI_2_MQ_06_BLACKCRYSTAL", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20, 150242, "", "ep13_f_siauliai_2", 546.6949, 183.6621, 618.324, 46, "EP13_F_SIAULIAI_2_MQ_LADA_3", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(21, 150246, " ", "ep13_f_siauliai_2", 487.1336, 183.6621, 570.8532, 90, "", "EP13_F_SIAULIAI_2_MQ_06_SMOKE", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(22, 150247, " ", "ep13_f_siauliai_2", 485.1155, 183.6621, 572.2502, 46, "", "EP13_F_SIAULIAI_2_MQ_07_AFTER", "");
		AddNpc(24, 150243, " ", "ep13_f_siauliai_2", 1638.605, 256.3912, 826.5189, -57, "", "", "");
		AddNpc(25, 150243, " ", "ep13_f_siauliai_2", -1777.724, 58.8075, -439.9069, -38, "", "", "");
		AddNpc(26, 150243, " ", "ep13_f_siauliai_2", -2092.62, 2.755327, -1123.087, -37, "", "", "");
		AddNpc(27, 150243, " ", "ep13_f_siauliai_2", -245.7287, 245.2458, -1488.497, 110, "", "", "");
		AddNpc(28, 150243, " ", "ep13_f_siauliai_2", 389.1377, 139.071, -1076.282, 189, "", "", "");
		AddNpc(29, 150243, " ", "ep13_f_siauliai_2", 1186.155, 183.6621, 36.98663, -7, "", "", "");
		AddNpc(30, 150243, " ", "ep13_f_siauliai_2", -1263.25, 183.6621, 436.2546, 90, "", "", "");
		AddNpc(31, 150243, " ", "ep13_f_siauliai_2", -559.7032, 275.8461, 1711.259, 1, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 147469, " ", "ep13_f_siauliai_2", 641.5677, 256.1976, 1436.733, 90, "", "EP13_F_SIAULIAI_2_MQ_08_TRACK_1", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(33, 40120, "Statue of Goddess Vakarine", "ep13_f_siauliai_2", 2428.743, 139.0712, -912.3688, 45, "WARP_EP13_F_SIAULIAI_2", "STOUP_CAMP", "STOUP_CAMP");
		
		// [Kingdom Reconstruction]{nl}Orsha Volunteer
		//-------------------------------------------------------------------------
		AddNpc(34, 20059, "[Kingdom Reconstruction]{nl}Orsha Volunteer", "ep13_f_siauliai_2", 3219.082, 139.0712, -656.717, 22, "EP13_F_SIAULIAI_2_REPUTATION_01", "", "");
		AddNpc(35, 147363, " ", "ep13_f_siauliai_2", 3218.542, 139.0712, -656.7622, 90, "", "", "");
		
		// [Kingdom Reconstruction]{nl}Orsha Damage Recovery Team
		//-------------------------------------------------------------------------
		AddNpc(1044, 20064, "[Kingdom Reconstruction]{nl}Orsha Damage Recovery Team", "ep13_f_siauliai_2", 3112.793, 139.0712, -658.1342, -6, "EP13_SUB_RECONSTRUCTION_NPC_SIAU_2_1", "", "", 1);
		
		// [Kingdom Reconstruction]{nl}Orsha Damage Recovery Team
		//-------------------------------------------------------------------------
		AddNpc(1045, 20064, "[Kingdom Reconstruction]{nl}Orsha Damage Recovery Team", "ep13_f_siauliai_2", 840.0926, 256.3913, 1744.823, 6, "EP13_SUB_RECONSTRUCTION_NPC_SIAU_2_2", "", "", 1);
		
		// Saint's Sacellum
		//-------------------------------------------------------------------------
		AddNpc(1046, 154065, "Saint's Sacellum", "ep13_f_siauliai_2", -371.0349, 245.2458, -1465.935, 90, "GODDESS_RAID_VASILISSA_PORTAL", "", "", 1);
		
		// [Arbalester Master]{nl} Vilnius
		//-------------------------------------------------------------------------
		AddNpc(1047, 150213, "[Arbalester Master]{nl} Vilnius", "ep13_f_siauliai_2", -345.8438, 245.2458, -1432.316, 105, "MASTER_ARBALESTER_NPC", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1048, 40095, " ", "ep13_f_siauliai_2", -1286.507, 183.6622, 471.8385, 90, "", "EXPLORER_MISLE12", "");
		
		// Novaha Institute
		//-------------------------------------------------------------------------
		AddNpc(1049, 40001, "Novaha Institute", "ep13_f_siauliai_2", 2048.08, 256.3913, 1031.038, 94, "", "WARP_EP13_F_SIAULIAI_2_TO_EP15_1_FABBEY_1", "");
	}
}
