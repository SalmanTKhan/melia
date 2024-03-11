//--- Melia Script ----------------------------------------------------------
// East Siauliai Woods
//--- Description -----------------------------------------------------------
// NPCs found in and around East Siauliai Woods.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FSiauliai2NpcScript : GeneralScript
{
	public override void Load()
	{
		// Rescuing Aras (4)
		//-------------------------------------------------------------------------
		AddNpc(38, 20041, "Rescuing Aras (4)", "f_siauliai_2", 164, 130, 440, 0, "", "SIAUL_EAST_CAMP4", "");
		
		// Knight Aras
		//-------------------------------------------------------------------------
		AddNpc(2, 20125, "Knight Aras", "f_siauliai_2", 167, 151, 697, 0, "SIAUL_EAST_MANAGER", "", "");
		
		// Recapture the Eastern Woods (1)
		//-------------------------------------------------------------------------
		AddNpc(39, 20041, "Recapture the Eastern Woods (1)", "f_siauliai_2", 206, 130, 428, 0, "", "SIAUL_EAST_RECLAIM1", "");
		
		// Recapture the Eastern Woods (3)
		//-------------------------------------------------------------------------
		AddNpc(40, 20041, "Recapture the Eastern Woods (3)", "f_siauliai_2", 487.258, 130.0227, -309.2897, 0, "", "SIAUL_EAST_RECLAIM3", "");
		
		// Recapture the Eastern Woods (3)
		//-------------------------------------------------------------------------
		AddNpc(40, 20041, "Recapture the Eastern Woods (3)", "f_siauliai_2", 515.2833, 130.0227, -528.2397, 0, "", "SIAUL_EAST_RECLAIM3", "");
		
		// Farm Sentinel
		//-------------------------------------------------------------------------
		AddNpc(45, 20013, "Farm Sentinel", "f_siauliai_2", 357, 130, 593, 0, "SIAUL_EAST_SOLDIER6", "", "", 1);
		
		// Farm Sentinel
		//-------------------------------------------------------------------------
		AddNpc(46, 20015, "Farm Sentinel", "f_siauliai_2", 210, 130, 260, 0, "SIAUL_EAST_SOLDIER7", "", "", 1);
		
		// Supply Soldier
		//-------------------------------------------------------------------------
		AddNpc(42, 20016, "Supply Soldier", "f_siauliai_2", 615, 130, -196, 0, "SIAUL_EAST_SOLDIER4", "", "", 1);
		
		// Supply Soldier
		//-------------------------------------------------------------------------
		AddNpc(43, 20011, "Supply Soldier", "f_siauliai_2", 741, 130, 411, 0, "SIAUL_EAST_SOLDIER5", "", "");
		
		// Supply Officer
		//-------------------------------------------------------------------------
		AddNpc(41, 20016, "Supply Officer", "f_siauliai_2", 660.7096, 130.0227, -453.2739, 0, "SIAUL_EAST_SUPPLY_MANAGER", "", "", 1);
		
		// Recapture the Eastern Woods (7)
		//-------------------------------------------------------------------------
		AddNpc(47, 20041, "Recapture the Eastern Woods (7)", "f_siauliai_2", 462, 130, -882, 0, "", "SIAUL_EAST_RECLAIM7", "");
		
		// Aras' Commission (2)
		//-------------------------------------------------------------------------
		AddNpc(48, 20041, "Aras' Commission (2)", "f_siauliai_2", -2124, 130, 1122, 0, "", "SIAUL_EAST_REQUEST2", "");
		
		// Aras' Commission (3)
		//-------------------------------------------------------------------------
		AddNpc(49, 20041, "Aras' Commission (3)", "f_siauliai_2", 1165.004, 138.7939, 218.1753, 0, "", "SIAUL_EAST_REQUEST3", "");
		
		// Eastern Woods Search Scout
		//-------------------------------------------------------------------------
		AddNpc(50, 10032, "Eastern Woods Search Scout", "f_siauliai_2", 1242, 130, 339, 0, "SIAUL_EAST_SOLDIER8", "", "", 1);
		
		// Aras' Commission (6)
		//-------------------------------------------------------------------------
		AddNpc(51, 20041, "Aras' Commission (6)", "f_siauliai_2", 1886.658, 185.0949, -476.8274, 0, "", "SIAUL_EAST_REQUEST6", "");
		
		// Outpost Sentinel
		//-------------------------------------------------------------------------
		AddNpc(53, 10032, "Outpost Sentinel", "f_siauliai_2", 205, 151, 667, 0, "SIAUL_EAST_SOLDIER10", "", "");
		
		// Outpost Sentinel
		//-------------------------------------------------------------------------
		AddNpc(52, 10032, "Outpost Sentinel", "f_siauliai_2", 133, 151, 672, 0, "SIAUL_EAST_SOLDIER9", "", "");
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(61, 46212, "Supplies Box", "f_siauliai_2", 301, 130, -569, 177, "ACT2_DISS1_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(62, 46212, "Supplies Box", "f_siauliai_2", 289, 130, -758, 177, "ACT2_DISS1_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(63, 46212, "Supplies Box", "f_siauliai_2", 176, 130, -492, 177, "ACT2_DISS1_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(64, 46212, "Supplies Box", "f_siauliai_2", 125, 130, -247, 177, "ACT2_DISS1_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(65, 46212, "Supplies Box", "f_siauliai_2", -158, 130, -876, 177, "ACT2_DISS1_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(66, 46212, "Supplies Box", "f_siauliai_2", -270, 130, -581, 177, "ACT2_DISS1_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(67, 46212, "Supplies Box", "f_siauliai_2", -223, 130, -452, 177, "ACT2_DISS1_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(68, 46212, "Supplies Box", "f_siauliai_2", 952, 130, -742, 177, "ACT2_DISS1_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(69, 46212, "Supplies Box", "f_siauliai_2", 728, 130, -789, 177, "ACT2_DISS1_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(70, 46212, "Supplies Box", "f_siauliai_2", 309.8956, 130.0227, -335.3998, 177, "ACT2_DISS1_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(71, 46212, "Supplies Box", "f_siauliai_2", 600, 130, -19, 177, "ACT2_DISS1_BOX", "", "", 1);
		
		// Miners' Village Entry (2)
		//-------------------------------------------------------------------------
		AddNpc(54, 20041, "Miners' Village Entry (2)", "f_siauliai_2", 1650, 186, 931, 0, "", "SIAUL_EAST_BUBE", "");
		
		// Aras' Commission (2)
		//-------------------------------------------------------------------------
		AddNpc(48, 20041, "Aras' Commission (2)", "f_siauliai_2", -2241, 130, 1047, 0, "", "SIAUL_EAST_REQUEST2", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(33, 40120, "Statue of Goddess Vakarine", "f_siauliai_2", 233, 157, 724, 0, "WARP_F_SIAULIAI_EST", "STOUP_CAMP", "STOUP_CAMP");
		
		// Rescuing Aras (4)
		//-------------------------------------------------------------------------
		AddNpc(38, 20041, "Rescuing Aras (4)", "f_siauliai_2", -46, 151, 818, 90, "", "SIAUL_EAST_CAMP4", "");
		
		// Operations Officer
		//-------------------------------------------------------------------------
		AddNpc(30, 20014, "Operations Officer", "f_siauliai_2", -1290, 130, 928, 0, "SIAUL_EAST_SUPPLY_MANAGER2", "", "");
		
		// Defeat the monsters blocking the road
		//-------------------------------------------------------------------------
		AddNpc(704, 20041, "Defeat the monsters blocking the road", "f_siauliai_2", -1143, 129, 884, 90, "", "SIAUL_EAST_REQUEST1_S1_TRIGGER", "");
		
		// [Sapper Master]{nl} Leonard Quicktongue
		//-------------------------------------------------------------------------
		AddNpc(10001, 147434, "[Sapper Master]{nl} Leonard Quicktongue", "f_siauliai_2", 440.7196, 162.4583, 1204.537, 0, "JOB_SAPPER2_1_NPC", "", "");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(10005, 40070, "Warning", "f_siauliai_2", -969, 130, 63, 51, "F_SIAULIA_2_BOARD01", "", "");
		
		// [Hunter Master]{nl}    Fiona Ieva
		//-------------------------------------------------------------------------
		AddNpc(10002, 57231, "[Hunter Master]{nl}    Fiona Ieva", "f_siauliai_2", 379.9978, 162.4583, 1196.955, 0, "JOB_HUNTER2_1_NPC", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 307.31, 130.02, 369.86, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 2048.78, 185.09, -308.63, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 672.1855, 130.0227, -472.7712, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", -2335.3, 130.02, 1316.72, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", -2069.188, 130.0227, 1625.553, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 1623.578, 190.3209, 909.2892, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 1255.115, 130.0227, 216.4147, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 894.24, 199.52, -125.49, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 906.65, 199.99, -595.02, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 2468.092, 130.0227, 1035.285, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 2568.337, 130.0227, 1027.196, 90, "", "", "");
		
		// [Barbarian Master]{nl}Walder Junnot
		//-------------------------------------------------------------------------
		AddNpc(10015, 57237, "[Barbarian Master]{nl}Walder Junnot", "f_siauliai_2", 316.8622, 162.4583, 1178.065, 0, "JOB_BARBARIAN2_NPC", "", "");
		
		// For the 4th Bokor Advancement
		//-------------------------------------------------------------------------
		AddNpc(10017, 20026, "For the 4th Bokor Advancement", "f_siauliai_2", -1247.509, 243.5222, -1485.488, 90, "", "JOB_BOCOR4_4_TRIGGER", "");
		
		// JOB_PYROMANCER4_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(10018, 20026, "JOB_PYROMANCER4_1_TRIGGER", "f_siauliai_2", 564.0366, 130.0227, 278.1627, 90, "", "JOB_PYROMANCER4_1_TRIGGER", "");
		
		// JOB_LINKER4_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(10019, 20026, "JOB_LINKER4_1_TRIGGER", "f_siauliai_2", 2017.164, 185.0949, -395.4728, 90, "", "JOB_LINKER4_1_TRIGGER", "");
		
		// Hidden trigger for 5th advancement of Wizard, Pyromancer, Cryomancer
		//-------------------------------------------------------------------------
		AddNpc(10021, 20026, "Hidden trigger for 5th advancement of Wizard, Pyromancer, Cryomancer", "f_siauliai_2", -2269.651, 130.0227, 1192.537, 90, "", "JOB_WIPYCRY5_1_TRIGGER", "");
		
		// Lv2 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(10023, 40030, "Lv2 Treasure Chest", "f_siauliai_2", 49.24, 130.12, -963.25, 90, "TREASUREBOX_LV_F_SIAULIAI_210023", "", "");
		
		// Eastern Woods Sentinel
		//-------------------------------------------------------------------------
		AddNpc(10024, 10033, "Eastern Woods Sentinel", "f_siauliai_2", -2207.416, 243.5222, -1057.399, 1, "SAUI_EAST_GUARD_01", "", "");
		
		// Eastern Woods Sentinel
		//-------------------------------------------------------------------------
		AddNpc(10025, 10033, "Eastern Woods Sentinel", "f_siauliai_2", -2213.944, 243.5222, -1111.96, 195, "SAUI_EAST_GUARD_02", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", -1220.981, 130.0227, -138.6922, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", -2211.128, 243.5222, -1078.529, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 419.9119, 162.4583, 1211.224, 90, "", "", "");
		AddNpc(10034, 147366, "Field Gen x", "f_siauliai_2", 74.9924, 151.7621, 713.1538, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 753.0049, 130.0227, 416.6965, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", -1324.608, 130.0227, 923.2641, 90, "", "", "");
		AddNpc(10012, 147363, "Field Gen x", "f_siauliai_2", 600.9479, 130.0227, -238.4718, 90, "", "", "");
		AddNpc(10035, 147362, "Field Gen x", "f_siauliai_2", 1257.513, 130.0227, 345.1109, 90, "", "", "");
		AddNpc(10037, 153056, " ", "f_siauliai_2", 478.7444, 130.0227, -511.84, 90, "", "", "");
		AddNpc(10037, 153056, " ", "f_siauliai_2", 487.4036, 130.0227, -468.5829, 48, "", "", "");
		AddNpc(10037, 153056, " ", "f_siauliai_2", 578.2407, 130.0227, -448.1719, 143, "", "", "");
		
		// SIAULIA_2_JOB_SPARRING_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(10038, 20026, "SIAULIA_2_JOB_SPARRING_TRIGGER", "f_siauliai_2", -269.2691, 130.0227, 1009.522, 90, "", "SIAULIA_2_JOB_SPARRING_TRIGGER", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(10039, 147392, "Lv1 Treasure Chest", "f_siauliai_2", -2235.57, 130.12, 690.81, 90, "TREASUREBOX_LV_F_SIAULIAI_210039", "", "");
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(10042, 46212, "Supplies Box", "f_siauliai_2", 223.62, 130.02, -455.3, 190, "LOWLV_BOASTER_SQ_10_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(10042, 46212, "Supplies Box", "f_siauliai_2", 279.23, 130.02, -214.07, 129, "LOWLV_BOASTER_SQ_10_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(10042, 46212, "Supplies Box", "f_siauliai_2", 321.41, 130.02, -702.45, 189, "LOWLV_BOASTER_SQ_10_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(10042, 46212, "Supplies Box", "f_siauliai_2", 440.45, 130.02, -343.8, 133, "LOWLV_BOASTER_SQ_10_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(10042, 46212, "Supplies Box", "f_siauliai_2", 486.08, 130.02, -162.39, 170, "LOWLV_BOASTER_SQ_10_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(10042, 46212, "Supplies Box", "f_siauliai_2", 491.63, 130.05, -579.61, 173, "LOWLV_BOASTER_SQ_10_BOX", "", "", 1);
		
		// Supplies Box
		//-------------------------------------------------------------------------
		AddNpc(10042, 46212, "Supplies Box", "f_siauliai_2", 78.19, 130.02, -366.91, 195, "LOWLV_BOASTER_SQ_10_BOX", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(10043, 40095, " ", "f_siauliai_2", -760.9055, 243.5222, -712.1299, 90, "", "EXPLORER_MISLE2", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(10044, 20026, "", "f_siauliai_2", 2068.243, 185.0949, -508.522, 90, "", "CHAR220_MSETP2_1_2_GEN_INIT", "");
	}
}
