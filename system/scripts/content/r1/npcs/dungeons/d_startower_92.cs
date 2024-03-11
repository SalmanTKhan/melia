//--- Melia Script ----------------------------------------------------------
// Astral Tower 21F
//--- Description -----------------------------------------------------------
// NPCs found in and around Astral Tower 21F.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DStartower92NpcScript : GeneralScript
{
	public override void Load()
	{
		// Astral Tower 20F
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Astral Tower 20F", "d_startower_92", -102, -193, 255, 0, "", "D_STARTOWER_92_TO_D_STARTOWER_91", "");
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(2, 156120, "Resistance Commander Byle", "d_startower_92", -153, -193, 747, 45, "D_STARTOWER_92_RESISTANCE_LEADER_BAYL_01", "", "", 1);
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(3, 156120, "Resistance Commander Byle", "d_startower_92", 425.3863, -31.7854, 1195.494, 78, "D_STARTOWER_92_RESISTANCE_LEADER_BAYL_02", "", "", 1);
		
		// Resistance Commander Byle
		//-------------------------------------------------------------------------
		AddNpc(4, 156120, "Resistance Commander Byle", "d_startower_92", -704, 275, -782, 90, "D_STARTOWER_92_RESISTANCE_LEADER_BAYL_03", "", "", 1);
		
		// Medic
		//-------------------------------------------------------------------------
		AddNpc(5, 155163, "Medic", "d_startower_92", -617, 275, -484, 135, "D_STARTOWER_92_RESISTANCE_MEMBER_01", "", "", 1);
		
		// Injured Soldier
		//-------------------------------------------------------------------------
		AddNpc(6, 155164, "Injured Soldier", "d_startower_92", -598, 275, -465, 45, "D_STARTOWER_92_RESISTANCE_MEMBER_03", "", "", 1);
		
		// Medic
		//-------------------------------------------------------------------------
		AddNpc(7, 156122, "Medic", "d_startower_92", -624, 275, -461, 90, "D_STARTOWER_92_RESISTANCE_MEMBER_02", "", "", 1);
		
		// Resistance Adjutant
		//-------------------------------------------------------------------------
		AddNpc(8, 156117, "Resistance Adjutant", "d_startower_92", -495, 275, -719, 135, "D_STARTOWER_92_RESISTANCE_MEMBER_04", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(9, 156125, "Resistance Soldier", "d_startower_92", -473, 275, -548, 45, "D_STARTOWER_92_RESISTANCE_MEMBER_05", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(10, 156129, "Resistance Soldier", "d_startower_92", -290, -235, 1808, 135, "D_STARTOWER_92_RESISTANCE_MEMBER_06", "", "", 1);
		
		// Supply Soldier
		//-------------------------------------------------------------------------
		AddNpc(11, 156122, "Supply Soldier", "d_startower_92", -221, -235, 1578, 0, "D_STARTOWER_92_RESISTANCE_MEMBER_07", "", "", 1);
		
		// Supply Soldier
		//-------------------------------------------------------------------------
		AddNpc(12, 156123, "Supply Soldier", "d_startower_92", 13, -235, 1714, 90, "D_STARTOWER_92_RESISTANCE_MEMBER_08", "", "", 1);
		
		// Demon Device
		//-------------------------------------------------------------------------
		AddNpc(13, 155169, "Demon Device", "d_startower_92", 299, 244, -752, 90, "D_STARTOWER_92_VALNIAS_DEVICE", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(15, 20026, " ", "d_startower_92", -1468, 374, -295, 90, "", "D_STARTOWER_92_MQ_40_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(16, 20026, " ", "d_startower_92", -1326, 670, 1419, 90, "", "D_STARTOWER_92_MQ_50_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(17, 154066, " ", "d_startower_92", -1425, 720, 1399, 90, "D_STARTOWER_92_MQ_60_TRIGGER", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1425.546, 0.7373962, 935.1099, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1578.023, 0.7373962, 956.2756, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1682.264, 0.7373962, 827.5134, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1663.174, 0.7373962, 658.387, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1520.234, 0.7373962, 696.4199, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1585.973, -1.060441, -44.77604, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1699.822, -0.155953, -138.8375, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1795.275, -2.225863, -54.03248, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1826.053, 0.7373962, 252.1331, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1647.598, -3.584396, 169.6483, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1610.561, -6.637207, -800.2825, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1547.507, -6.637207, -669.6632, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1735.731, -3.040392, -671.7823, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1691.113, 0.7373962, -950.3977, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 154066, " ", "d_startower_92", 1463.26, 0.7373962, -916.6982, 90, "STARTOWER_92_MQ_20_HIDDEN_NPC", "STARTOWER_92_MQ_20_HIDDEN_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(27, 20042, " ", "d_startower_92", 34.13864, 251.9847, -713.6741, 90, "", "D_STARTOWER_92_MQ_30_TRIGGER", "");
	}
}
