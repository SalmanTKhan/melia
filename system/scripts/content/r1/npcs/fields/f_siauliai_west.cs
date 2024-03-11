//--- Melia Script ----------------------------------------------------------
// West Siauliai Woods
//--- Description -----------------------------------------------------------
// NPCs found in and around West Siauliai Woods.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FSiauliaiWestNpcScript : GeneralScript
{
	public override void Load()
	{
		// Scout
		//-------------------------------------------------------------------------
		AddNpc(1, 10032, "Scout", "f_siauliai_west", -1121, 260, -528, -9, "SIALUL_WEST_DRASIUS", "", "");

		// Search Scout
		//-------------------------------------------------------------------------
		AddNpc(3, 41206, "Search Scout", "f_siauliai_west", -1488, 260, -138, 0, "SIAUL_WEST_NAGLIS2", "SIAUL_WEST_NAGLIS2", "SIAUL_WEST_NAGLIS2");

		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(4, 40120, "Statue of Goddess Vakarine", "f_siauliai_west", -525, 260, -435, 0, "WARP_F_SIAULIAI_WEST", "STOUP_CAMP", "STOUP_CAMP");

		// Knight Titas
		//-------------------------------------------------------------------------
		AddNpc(7, 20107, "Knight Titas", "f_siauliai_west", -576, 260, -719, 254, "SIAUL_WEST_CAMP_MANAGER", "", "");

		// Laimonas
		//-------------------------------------------------------------------------
		AddNpc(9, 20117, "Laimonas", "f_siauliai_west", 326.5086, 210.2119, -346.8529, 0, "SIAUL_WEST_LAIMONAS", "", "");

		// Sentinel
		//-------------------------------------------------------------------------
		AddNpc(8, 20016, "Sentinel", "f_siauliai_west", -652, 260, -953, 0, "SIAU_FRON_NPC_01", "", "");

		// Klaipeda Resident
		//-------------------------------------------------------------------------
		AddNpc(11, 20114, "Klaipeda Resident", "f_siauliai_west", -624, 260, -385, 7, "SIAUL_WEST_RESIDENT1", "", "");

		// Laimonas 1 Trigger
		//-------------------------------------------------------------------------
		AddNpc(12, 20041, "Laimonas 1 Trigger", "f_siauliai_west", 773, 258, -125, 90, "", "SIAUL_WEST_LAIMONAS1_TRIGGER", "SIAUL_WEST_LAIMONAS1_TRIGGER");

		// Laimonas 2 Trigger
		//-------------------------------------------------------------------------
		AddNpc(14, 20041, "Laimonas 2 Trigger", "f_siauliai_west", 980, 285, 559, 90, "", "SIAUL_WEST_LAIMONAS2_TRIGGER", "");

		// Siauliai Guard
		//-------------------------------------------------------------------------
		AddNpc(102, 10022, "Siauliai Guard", "f_siauliai_west", -851, 260, -495, -59, "F_SIAUL_GAURD", "", "");

		// Klaipeda Guard
		//-------------------------------------------------------------------------
		AddNpc(26, 10032, "Klaipeda Guard", "f_siauliai_west", 1651, 210, -706, -19, "SIAUL_ST1_ST2_GAURD", "", "");

		// Klaipeda Guard Captain
		//-------------------------------------------------------------------------
		AddNpc(27, 20019, "Klaipeda Guard Captain", "f_siauliai_west", 1626, 210, -798, 270, "SIAUL_ST1_ST2", "", "");

		// Chase Trigger of Hanaming
		//-------------------------------------------------------------------------
		AddNpc(21, 20041, "Chase Trigger of Hanaming", "f_siauliai_west", -403, 322, 363, 90, "", "SIAUL_WEST_HANAMING_TRIGGER", "");

		// Klaipeda Guard
		//-------------------------------------------------------------------------
		AddNpc(29, 10032, "Klaipeda Guard", "f_siauliai_west", 1650, 210, -854, 195, "SIAUL_WEST_SOLDIER3", "", "");

		// SIAUL_WEST_ADD_SUB_01
		//-------------------------------------------------------------------------
		AddNpc(49, 20026, "SIAUL_WEST_ADD_SUB_01", "f_siauliai_west", -443, 322, 120, 90, "", "SIAUL_WEST_ADD_SUB_01", "");

		// SIAUL_WEST_LAIMONAS3_2
		//-------------------------------------------------------------------------
		AddNpc(50, 20026, "SIAUL_WEST_LAIMONAS3_2", "f_siauliai_west", 1565.729, 285.0458, 327.5524, 90, "", "SIAUL_WEST_LAIMONAS3_2_TRIGGER", "");

		// Sentinel
		//-------------------------------------------------------------------------
		AddNpc(51, 10032, "Sentinel", "f_siauliai_west", -626, 260, -757, 176, "SIAU_FRON_NPC_04", "", "");

		// Sentinel
		//-------------------------------------------------------------------------
		AddNpc(52, 10032, "Sentinel", "f_siauliai_west", -619, 260, -707, 16, "SIAU_FRON_NPC_05", "", "");

		// Sentinel
		//-------------------------------------------------------------------------
		AddNpc(53, 10032, "Sentinel", "f_siauliai_west", -509, 260, -821, 251, "SIAU_FRON_NPC_03", "", "");

		// Sentinel
		//-------------------------------------------------------------------------
		AddNpc(54, 10032, "Sentinel", "f_siauliai_west", -589, 260, -822, 90, "SIAU_FRON_NPC_02", "", "");

		// Start Trigger
		//-------------------------------------------------------------------------
		AddNpc(55, 20026, "Start Trigger", "f_siauliai_west", -560, 260, -780, 90, "", "SIAUL_WEST_MEET_TITAS_AUTO", "");

		// Battle Commander
		//-------------------------------------------------------------------------
		AddNpc(2002, 20016, "Battle Commander", "f_siauliai_west", -663, 322, 503, 90, "SIAUL_WEST_SOL3", "", "");

		// Medium Boss Golem Trigger
		//-------------------------------------------------------------------------
		AddNpc(2007, 20041, "Medium Boss Golem Trigger", "f_siauliai_west", -550, 359, 1370, 0, "", "SIAUL_WEST_BOSS_GOLEM_TRIGGER", "");

		// Large Kepa Trigger
		//-------------------------------------------------------------------------
		AddNpc(5, 20041, "Large Kepa Trigger", "f_siauliai_west", -2005, 260, 102, 90, "", "SIALUL_WEST_ONION_BIG_TRIGGER", "");

		// Large Kepa Trigger
		//-------------------------------------------------------------------------
		AddNpc(5, 20041, "Large Kepa Trigger", "f_siauliai_west", -1765, 260, 102, 90, "", "SIALUL_WEST_ONION_BIG_TRIGGER", "");

		// Large Kepa Trigger
		//-------------------------------------------------------------------------
		AddNpc(5, 20041, "Large Kepa Trigger", "f_siauliai_west", -1845, 260, 102, 90, "", "SIALUL_WEST_ONION_BIG_TRIGGER", "");

		// Large Kepa Trigger
		//-------------------------------------------------------------------------
		AddNpc(5, 20041, "Large Kepa Trigger", "f_siauliai_west", -1925, 260, 102, 90, "", "SIALUL_WEST_ONION_BIG_TRIGGER", "");

		// Warning
		//-------------------------------------------------------------------------
		AddNpc(1002, 40080, "Warning", "f_siauliai_west", -1566, 260, -1096, 8, "SIAUL1_BOARD2", "", "");

		// Warning
		//-------------------------------------------------------------------------
		AddNpc(1003, 40080, "Warning", "f_siauliai_west", -1692, 260, -150, 4, "SIAUL1_BOARD3", "", "");

		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(1004, 40070, "Bulletin Board", "f_siauliai_west", 487, 209, -139, 40, "SIAUL1_BOARD4", "", "");

		// Warning
		//-------------------------------------------------------------------------
		AddNpc(1005, 40080, "Warning", "f_siauliai_west", -572, 322, 449, 182, "SIAUL1_BOARD5", "", "");

		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(1006, 40070, "Bulletin Board", "f_siauliai_west", -695, 322, 840, 26, "SIAUL1_BOARD6", "", "");

		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(1007, 40070, "Bulletin Board", "f_siauliai_west", -547, 260, -453, -3, "SIAUL1_BOARD7", "", "");

		// 
		//-------------------------------------------------------------------------
		AddNpc(2011, 40070, "", "f_siauliai_west", -1822, 260, -925, 405, "SIAUL1_BOARDCRYSTAL", "", "");

		// 
		//-------------------------------------------------------------------------
		AddNpc(2012, 20041, "", "f_siauliai_west", 175, 322, 384, 90, "", "JOB_SAPPER2_1_TRIGGER", "");

		// [Hoplite Submaster]{nl}Vysiege Thurmore
		//-------------------------------------------------------------------------
		AddNpc(2013, 155065, "[Hoplite Submaster]{nl}Vysiege Thurmore", "f_siauliai_west", -331, 260, -400, 0, "JOB_HOPLITE2_NPC", "", "");

		// For Krivis' 4th advancement quest track
		//-------------------------------------------------------------------------
		AddNpc(2014, 20026, "For Krivis' 4th advancement quest track", "f_siauliai_west", 1505.41, 210.21, -778.63, 90, "", "JOB_KRIVI4_2_TRACK", "");

		// JOB_WIZARD4_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(2015, 20026, "JOB_WIZARD4_1_TRIGGER", "f_siauliai_west", -595.97, 359.52, 1356.17, 90, "", "JOB_WIZARD4_1_TRIGGER", "");

		// JOB_CRYOMANCER4_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(2016, 20026, "JOB_CRYOMANCER4_1_TRIGGER", "f_siauliai_west", 1697.45, 285.05, 387.61, 90, "", "JOB_CRYOMANCER4_1_TRIGGER", "");

		// Soldier Recruitment Notice
		//-------------------------------------------------------------------------
		AddNpc(2018, 40070, "Soldier Recruitment Notice", "f_siauliai_west", 1615.97, 210.21, -713.26, -7, "SIAUL_WEST_HQ01_INFO01", "", "");

		// Soldier Recruitment Notice
		//-------------------------------------------------------------------------
		AddNpc(2019, 40070, "Soldier Recruitment Notice", "f_siauliai_west", -558.6, 260.83, -1021.28, 269, "SIAUL_WEST_HQ01_INFO02", "", "");

		// Soldier Recruitment Notice
		//-------------------------------------------------------------------------
		AddNpc(2020, 40070, "Soldier Recruitment Notice", "f_siauliai_west", -1277.39, 260.83, -614.18, 90, "SIAUL_WEST_HQ01_INFO03", "", "");

		// Klaipeda Officer
		//-------------------------------------------------------------------------
		AddNpc(2021, 147416, "Klaipeda Officer", "f_siauliai_west", 1553.76, 210.21, -695.25, 90, "TUTO_SKIP_NPC", "", "");

		// Rocktortuga Spawn Trigger
		//-------------------------------------------------------------------------
		AddNpc(2025, 20026, "Rocktortuga Spawn Trigger", "f_siauliai_west", 1428.38, 210.21, -922.82, 90, "", "SIAUL_WEST_ROCK", "");

		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(2026, 20026, "Statue of Goddess Zemyna", "f_siauliai_west", 1705.19, 285.05, 390.19, 90, "", "SIAUL_WEST_LAIMONAS3_TRIGGER", "");

		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(2027, 147392, "Lv1 Treasure Chest", "f_siauliai_west", 1564, 210, -370, 270, "TREASUREBOX_LV_F_SIAULIAI_WEST2027", "", "");

		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(2029, 40110, "Statue of Goddess Zemyna", "f_siauliai_west", 1687, 285.05, 366, 20, "F_SIAULIAI_WEST_EV_55_001", "F_SIAULIAI_WEST_EV_55_001", "F_SIAULIAI_WEST_EV_55_001");
		AddNpc(2030, 152003, " ", "f_siauliai_west", 1409.854, 210.2119, -245.3474, -2, "", "", "");

		// West Siauliai Woods
		//-------------------------------------------------------------------------
		AddNpc(2031, 40001, "West Siauliai Woods", "f_siauliai_west", 2755.275, 423.3865, 443.1412, -24, "", "SIAULIAI_WEST_OUT_OF_SECRET", "");

		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(2032, 147392, "Lv1 Treasure Chest", "f_siauliai_west", -580, 260, -1417, 180, "TREASUREBOX_LV_F_SIAULIAI_WEST2032", "", "");
		AddNpc(2033, 147364, "Field Gen x", "f_siauliai_west", 231.365, 322.8697, 328.5694, 90, "", "", "");

		// [Dievdirbys Master]{nl}Sculptor Tesla
		//-------------------------------------------------------------------------
		AddNpc(31, 47239, "[Dievdirbys Master]{nl}Sculptor Tesla", "f_siauliai_west", -751.0155, 260.8254, -362.2574, 0, "JOB_DIEVDIRBYS2_NPC", "", "", 0);

		// 
		//-------------------------------------------------------------------------
		AddNpc(32, 47248, "", "f_siauliai_west", -778.9161, 260.8254, -353.6469, 0, "JOB_DIEVDIRBYS3_3_NPC", "", "", 1);

		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(2034, 147392, "Lv1 Treasure Chest", "f_siauliai_west", -2004.07, 260.93, -940.17, 0, "TREASUREBOX_LV_F_SIAULIAI_WEST2034", "", "");

		// Lv3 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(2035, 147393, "Lv3 Treasure Chest", "f_siauliai_west", 185.81, 210.31, -856.9, 90, "TREASUREBOX_LV_F_SIAULIAI_WEST2035", "", "");

		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(2036, 147392, "Lv1 Treasure Chest", "f_siauliai_west", 1346.05, 210.31, -1087.24, 90, "TREASUREBOX_LV_F_SIAULIAI_WEST2036", "", "");

		//  
		//-------------------------------------------------------------------------
		AddNpc(2037, 147469, " ", "f_siauliai_west", 3221.666, 423.3865, 865.9946, 90, "RUNECASTER_SIAULIAI_WEST_STONE", "", "", 1);

		//  
		//-------------------------------------------------------------------------
		AddNpc(2039, 40095, " ", "f_siauliai_west", -2067.653, 260.8254, -1273.606, 90, "", "EXPLORER_MISLE1", "");
	}
}
