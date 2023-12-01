//--- Melia Script ----------------------------------------------------------
// Astral Tower 20F
//--- Description -----------------------------------------------------------
// NPCs found in and around Astral Tower 20F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DStartower91NpcScript : GeneralScript
{
	public override void Load()
	{
		// Astral Tower 12F
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Astral Tower 12F", "d_startower_91", 2482, 1143, -1924, 0, "", "D_STARTOWER_91_TO_D_STARTOWER_90", "");
		
		// Astral Tower 21F
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Astral Tower 21F", "d_startower_91", -2268, 1647, 1625, 270, "", "D_STARTOWER_91_TO_D_STARTOWER_92", "");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(3, 156120, "Resistance Commander Byle", "d_startower_91", 2507, 1211, -1137, 0, "D_STARTOWER_91_RESISTANCE_LEADER_BAYL_01", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(4, 155163, "Resistance Soldier", "d_startower_91", 2599, 1143, -1529, 270, "D_STARTOWER_91_RESISTANCE_MEMBER_01", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(5, 150180, "Resistance Soldier", "d_startower_91", 2401, 1143, -1535, 90, "D_STARTOWER_91_RESISTANCE_MEMBER_02", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(6, 156129, "Resistance Soldier", "d_startower_91", 2379, 1211, -1369, 180, "D_STARTOWER_91_RESISTANCE_MEMBER_03", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(7, 150179, "Resistance Soldier", "d_startower_91", 2421, 1211, -1302, 0, "D_STARTOWER_91_RESISTANCE_MEMBER_04", "", "", 1);
		
		// Resistance Adjutant
		//-------------------------------------------------------------------------
		AddNpc(8, 156116, "Resistance Adjutant", "d_startower_91", 2624, 1210, -1289, 135, "D_STARTOWER_91_RESISTANCE_MEMBER_05", "", "", 1);
		
		// Resistance Adjutant
		//-------------------------------------------------------------------------
		AddNpc(9, 156131, "Resistance Adjutant", "d_startower_91", 2668, 1210, -1262, -45, "D_STARTOWER_91_RESISTANCE_MEMBER_06", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(10, 155164, "Resistance Soldier", "d_startower_91", 2097, 1173, -1332, 90, "D_STARTOWER_91_RESISTANCE_MEMBER_07", "", "", 1);
		
		// Protective Device
		//-------------------------------------------------------------------------
		AddNpc(11, 151109, "Protective Device", "d_startower_91", 1107, 1169, -2115, 90, "D_STARTOWER_91_1ST_SUB_DEVICE", "", "");
		
		// Protective Device
		//-------------------------------------------------------------------------
		AddNpc(12, 151109, "Protective Device", "d_startower_91", 1444, 874, -70, 90, "D_STARTOWER_91_2ND_SUB_DEVICE", "", "");
		
		// Protective Device
		//-------------------------------------------------------------------------
		AddNpc(13, 151109, "Protective Device", "d_startower_91", 138, 903, -1488, 90, "D_STARTOWER_91_3RD_SUB_DEVICE", "", "");
		
		// Protective Device
		//-------------------------------------------------------------------------
		AddNpc(14, 151109, "Protective Device", "d_startower_91", -59, 928, -294, 90, "D_STARTOWER_91_4TH_SUB_DEVICE_01", "", "", 0);
		
		// Defensive Device
		//-------------------------------------------------------------------------
		AddNpc(15, 153137, "Defensive Device", "d_startower_91", -1040, 890, -610, 180, "D_STARTOWER_91_1ST_DEFENCE_DEVICE", "", "");
		
		// Elevator Controls
		//-------------------------------------------------------------------------
		AddNpc(16, 153187, "Elevator Controls", "d_startower_91", -1893, 1653, 1903, 90, "D_STARTOWER_91_ELEVATER_CONFIG_DEVICE", "", "");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(17, 156120, "Resistance Commander Byle", "d_startower_91", 741, 1059, 256, 45, "D_STARTOWER_91_RESISTANCE_LEADER_BAYL_02", "", "", 1);
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(18, 156120, "Resistance Commander Byle", "d_startower_91", -2129, 1647, 1516, 90, "D_STARTOWER_91_RESISTANCE_LEADER_BAYL_03", "", "", 1);
		
		// Resistance Adjutant Arcadius
		//-------------------------------------------------------------------------
		AddNpc(19, 156115, "Resistance Adjutant Arcadius", "d_startower_91", -894, 760, -1015, 90, "D_STARTOWER_91_RESISTANCE_SENIOR_ARKADIJUS", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(20, 155163, "Resistance Soldier", "d_startower_91", 837, 1059, 298, 0, "D_STARTOWER_91_RESISTANCE_MEMBER_08", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(21, 156128, "Resistance Soldier", "d_startower_91", 839, 1059, 222, 225, "D_STARTOWER_91_RESISTANCE_MEMBER_09", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(22, 150179, "Resistance Soldier", "d_startower_91", 812.3074, 1059.677, 258.3079, 90, "D_STARTOWER_91_RESISTANCE_MEMBER_10", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(23, 156127, "Resistance Soldier", "d_startower_91", -1925, 1647, 1505, 225, "D_STARTOWER_91_RESISTANCE_MEMBER_11", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(24, 156126, "Resistance Soldier", "d_startower_91", -1918, 1647, 1567, -45, "D_STARTOWER_91_RESISTANCE_MEMBER_12", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(25, 20026, " ", "d_startower_91", 817, 907, -585, 90, "", "D_STARTOWER_91_MQ_60_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(26, 20026, " ", "d_startower_91", -835, 1089, 566, 90, "", "D_STARTOWER_91_MQ_90_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(28, 40095, " ", "d_startower_91", -810, 758, -822, 90, "", "D_STARTOWER_91_MQ_50_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", 1999.59, 1020.432, -914.7778, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", 1363.555, 937.5612, -1340.371, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", 1278.025, 1029.948, -2077.467, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", 1407.324, 874.9324, -254.4317, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", 811.4783, 760.6241, -993.1345, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", 214.9686, 853.1097, -452.8471, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", 231.0099, 828.5038, -1847.929, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", -416.2837, 760.6241, -1003.883, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", -828.9007, 758.3363, -501.6103, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", -1324.354, 760.6241, -984.6934, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", 925.8737, 1152.235, 905.3857, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", 968.1367, 1393.055, 1739.943, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", -9.171572, 1237.306, 1037.82, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", -97.73727, 1059.676, 323.0533, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", -1520.069, 1280.664, 1182.628, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", -1143.008, 1059.677, 355.0061, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 20042, " ", "d_startower_91", 795.6636, 907.2095, -149.2745, 90, "", "STARTOWER_91_ARROWRAIN_TRAP", "STARTOWER_91_ARROWRAIN_TRAP");
		
		// Protective Device
		//-------------------------------------------------------------------------
		AddNpc(30, 151109, "Protective Device", "d_startower_91", -59, 928, -294, 90, "D_STARTOWER_91_4TH_SUB_DEVICE_02", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(41, 151117, " ", "d_startower_91", -845, 669, -1539, 0, "D_STARTOWER_91_BOOKSHELF_04", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(44, 151117, " ", "d_startower_91", -845, 669, -1459, 0, "D_STARTOWER_91_BOOKSHELF_01", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(42, 151117, " ", "d_startower_91", -802, 669, -1539, 0, "D_STARTOWER_91_BOOKSHELF_05", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(43, 151117, " ", "d_startower_91", -888, 669, -1539, 0, "D_STARTOWER_91_BOOKSHELF_03", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(45, 151117, " ", "d_startower_91", -802, 669, -1459, 0, "D_STARTOWER_91_BOOKSHELF_02", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(46, 40120, "Statue of Goddess Vakarine", "d_startower_91", 2501, 1211, -1388, 45, "WARP_D_STARTOWER_91", "STOUP_CAMP", "STOUP_CAMP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(50, 40095, " ", "d_startower_91", -1879.207, 1653.434, 2359.069, 90, "", "EXPLORER_MISLE34", "");
	}
}
