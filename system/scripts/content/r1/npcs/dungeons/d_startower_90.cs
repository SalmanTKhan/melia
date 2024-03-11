//--- Melia Script ----------------------------------------------------------
// Astral Tower 12F
//--- Description -----------------------------------------------------------
// NPCs found in and around Astral Tower 12F.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DStartower90NpcScript : GeneralScript
{
	public override void Load()
	{
		// Astral Tower 4F
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Astral Tower 4F", "d_startower_90", 1875, 75, -905, 90, "", "D_STARTOWER_90_TO_D_STARTOWER_89", "");
		
		// Astral Tower 20F
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Astral Tower 20F", "d_startower_90", 817.5574, 388.2075, 2402.892, 180, "", "D_STARTOWER_90_TO_D_STARTOWER_91", "");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(3, 156120, "Resistance Commander Byle", "d_startower_90", 1740, 98, -860, 0, "D_STARTOWER_90_RESISTANCE_LEADER_BAYL_01", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(4, 155163, "Resistance Soldier", "d_startower_90", 1700, 98, -866, 45, "D_STARTOWER_90_RESISTANCE_MEMBER_01_1", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(5, 156127, "Resistance Soldier", "d_startower_90", 1685, 96, -978, 135, "D_STARTOWER_90_RESISTANCE_MEMBER_02_1", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(6, 155165, "Resistance Soldier", "d_startower_90", 1747, 97, -974, 270, "D_STARTOWER_90_RESISTANCE_MEMBER_03_1", "", "", 1);
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(7, 156120, "Resistance Commander Byle", "d_startower_90", 540, 311, 2057, 135, "D_STARTOWER_90_RESISTANCE_LEADER_BAYL_02", "", "", 1);
		
		// Elder Adaux
		//-------------------------------------------------------------------------
		AddNpc(8, 150178, "Elder Adaux", "d_startower_90", 608, 311, 2122, 0, "D_STARTOWER_90_SCHAFFENSTAR_ELDER_ADAUX", "", "", 1);
		
		// Schaffenstar Member
		//-------------------------------------------------------------------------
		AddNpc(9, 156123, "Schaffenstar Member", "d_startower_90", 561, 311, 2175, 0, "D_STARTOWER_90_SCHAFFENSTAR_MEMBER_01", "", "", 1);
		
		// Schaffenstar Member
		//-------------------------------------------------------------------------
		AddNpc(10, 156124, "Schaffenstar Member", "d_startower_90", 617, 311, 2180, 0, "D_STARTOWER_90_SCHAFFENSTAR_MEMBER_02", "", "", 1);
		
		// Schaffenstar Member
		//-------------------------------------------------------------------------
		AddNpc(11, 156125, "Schaffenstar Member", "d_startower_90", 680, 311, 2182, 0, "D_STARTOWER_90_SCHAFFENSTAR_MEMBER_03", "", "", 1);
		
		// Schaffenstar Member
		//-------------------------------------------------------------------------
		AddNpc(12, 156126, "Schaffenstar Member", "d_startower_90", 587, 311, 2205, 0, "D_STARTOWER_90_SCHAFFENSTAR_MEMBER_04", "", "", 1);
		
		// Schaffenstar Member
		//-------------------------------------------------------------------------
		AddNpc(13, 156127, "Schaffenstar Member", "d_startower_90", 645, 311, 2224, 0, "D_STARTOWER_90_SCHAFFENSTAR_MEMBER_05", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(14, 156126, "Resistance Soldier", "d_startower_90", 512, 311, 1979, 135, "D_STARTOWER_90_RESISTANCE_MEMBER_04", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(15, 155165, "Resistance Soldier", "d_startower_90", 553, 311, 1947, 135, "D_STARTOWER_90_RESISTANCE_MEMBER_05", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(16, 156127, "Resistance Soldier", "d_startower_90", 509, 311, 1917, 135, "D_STARTOWER_90_RESISTANCE_MEMBER_06", "", "", 1);
		
		// Second Defensive Device
		//-------------------------------------------------------------------------
		AddNpc(17, 153137, "Second Defensive Device", "d_startower_90", 1842, 10, 913, 180, "D_STARTOWER_90_2ND_DEFENCE_DEVICE", "", "");
		
		// First Defensive Device
		//-------------------------------------------------------------------------
		AddNpc(18, 153137, "First Defensive Device", "d_startower_90", -722, -6, -1499, 180, "D_STARTOWER_90_1ST_DEFENCE_DEVICE", "", "", 1);
		
		// Transparency Controls
		//-------------------------------------------------------------------------
		AddNpc(19, 151006, "Transparency Controls", "d_startower_90", 1415, 2, -1521, 180, "D_STARTOWER_90_1ST_HIDE_CONTROL_DEVICE", "", "");
		
		// Transparency Controls
		//-------------------------------------------------------------------------
		AddNpc(20, 151006, "Transparency Controls", "d_startower_90", 778, -6, -1431, 180, "D_STARTOWER_90_2ND_HIDE_CONTROL_DEVICE", "", "");
		
		// Transparency Controls
		//-------------------------------------------------------------------------
		AddNpc(21, 151006, "Transparency Controls", "d_startower_90", 264, -6, -1527, 180, "D_STARTOWER_90_3RD_HIDE_CONTROL_DEVICE", "", "");
		
		// Statue of Goddess Laima
		//-------------------------------------------------------------------------
		AddNpc(22, 40100, "Statue of Goddess Laima", "d_startower_90", -1261, 67, 158, 90, "D_STARTOWER_90_STATUE", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(23, 20026, " ", "d_startower_90", 1812, 86, -906, 90, "", "D_STARTOWER_90_MQ_10_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(24, 20045, " ", "d_startower_90", 56, 63, 1003, 87, "D_STARTOWER_90_MQ_HIDDENWALL", "D_STARTOWER_90_MQ_HIDDENWALL", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(25, 20026, " ", "d_startower_90", -324, 67, 151, 90, "", "D_STARTOWER_90_MQ_50_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(26, 20026, " ", "d_startower_90", -713.5576, 83.28046, -1037.372, 90, "", "D_STARTOWER_90_MQ_30_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(27, 20026, " ", "d_startower_90", 112, 64, 448, 90, "", "D_STARTOWER_90_MQ_60_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 154066, " ", "d_startower_90", 56, 62, 996, 90, "D_STARTOWER_90_MQ_HIDDENWALL_TRIGGER", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 20042, " ", "d_startower_90", 1419, 2, -1379, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 20042, " ", "d_startower_90", 808, -6, -1426, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 20042, " ", "d_startower_90", 269, -6, -1450, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 20042, " ", "d_startower_90", -716, -6, -1469, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 20042, " ", "d_startower_90", -713, 98, -910, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 20042, " ", "d_startower_90", 248, 98, -932, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 20042, " ", "d_startower_90", 978, 98, -894, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 20042, " ", "d_startower_90", 62, 83, -354, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 20042, " ", "d_startower_90", 786, 67, 163, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 20042, " ", "d_startower_90", 132, 67, 255, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_01", "STARTOWER_90_ARROWRAIN_TRAP_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(31, 20042, " ", "d_startower_90", 1788, 10, 894, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(31, 20042, " ", "d_startower_90", 1254, 137, 1201, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(31, 20042, " ", "d_startower_90", 121, 305, 1942, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(31, 20042, " ", "d_startower_90", -458, 292, 1876, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(31, 20042, " ", "d_startower_90", -1399, 67, 736, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(31, 20042, " ", "d_startower_90", -761, 67, 761, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(31, 20042, " ", "d_startower_90", 640, 163, 1175, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(31, 20042, " ", "d_startower_90", -330, 163, 1242, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(31, 20042, " ", "d_startower_90", -1142, 163, 1343, 90, "", "STARTOWER_90_ARROWRAIN_TRAP_02", "STARTOWER_90_ARROWRAIN_TRAP_02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 20042, " ", "d_startower_90", 1420.143, 2.3727, -1380.3, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 20042, " ", "d_startower_90", 796.5229, -6.903305, -1436.854, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 20042, " ", "d_startower_90", 277.7894, -6.986292, -1447.742, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 20042, " ", "d_startower_90", -732.1516, -6.98631, -1487.259, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 20042, " ", "d_startower_90", -672.809, 97.97355, -890.9528, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 20042, " ", "d_startower_90", 116.3271, 83.89508, -542.799, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 20042, " ", "d_startower_90", 770.9013, 98.23804, -938.5419, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 20042, " ", "d_startower_90", -309.6108, 67.26565, 162.2018, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 20042, " ", "d_startower_90", 247.8276, 67.26566, 155.4086, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(32, 20042, " ", "d_startower_90", 839.2718, 67.26567, 123.2209, 90, "", "STARTOWER_90_EVIL_ENERGY", "STARTOWER_90_EVIL_ENERGY");
		AddNpc(33, 154066, " ", "d_startower_90", 1761.35, 98.24, -868.11, 90, "", "", "");
	}
}
