//--- Melia Script ----------------------------------------------------------
// Astral Tower 1F
//--- Description -----------------------------------------------------------
// NPCs found in and around Astral Tower 1F.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DStartower88NpcScript : GeneralScript
{
	public override void Load()
	{
		// Barynwell 87 Waters
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Barynwell 87 Waters", "d_startower_88", 2359, 212, 1769, 180, "", "D_STARTOWER_88_TO_F_3CMLAKE_87", "");
		
		// Astral Tower 4F
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Astral Tower 4F", "d_startower_88", 1208, 411, 3327, 170, "", "D_STARTOWER_88_TO_D_STARTOWER_89", "");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(3, 155163, "Resistance Soldier", "d_startower_88", 2298, 212, 1319, 45, "D_STARTOWER_88_RESISTANCE_MEMBER_01", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(4, 155164, "Resistance Soldier", "d_startower_88", 2312, 212, 1245, 135, "D_STARTOWER_88_RESISTANCE_MEMBER_02", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(5, 155165, "Resistance Soldier", "d_startower_88", 2374, 212, 1312, 270, "D_STARTOWER_88_RESISTANCE_MEMBER_03", "", "", 1);
		
		// Resistance Adjutant
		//-------------------------------------------------------------------------
		AddNpc(6, 156114, "Resistance Adjutant", "d_startower_88", 2531, 212, 1521, 90, "D_STARTOWER_88_RESISTANCE_SENIOR_01", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(7, 156127, "Resistance Soldier", "d_startower_88", 2589, 212, 1561, -45, "D_STARTOWER_88_RESISTANCE_MEMBER_04", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(8, 156128, "Resistance Soldier", "d_startower_88", 2586, 212, 1472, 225, "D_STARTOWER_88_RESISTANCE_MEMBER_05", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(9, 156129, "Resistance Soldier", "d_startower_88", 137, 212, 1406, 45, "D_STARTOWER_88_RESISTANCE_MEMBER_06", "", "", 1);
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(10, 155166, "Resistance Soldier", "d_startower_88", 176.0067, 212.5968, 1377.653, 225, "D_STARTOWER_88_RESISTANCE_MEMBER_07", "", "", 1);
		
		// Resistance Deputy Commander Kron
		//-------------------------------------------------------------------------
		AddNpc(11, 156119, "Resistance Deputy Commander Kron", "d_startower_88", 2186, 212, 1658, 45, "D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_01", "", "", 1);
		
		// Resistance Deputy Commander Kron
		//-------------------------------------------------------------------------
		AddNpc(12, 156119, "Resistance Deputy Commander Kron", "d_startower_88", 5, 212, 1232, 90, "D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_02", "", "", 1);
		
		// Defensive Device
		//-------------------------------------------------------------------------
		AddNpc(13, 153137, "Defensive Device", "d_startower_88", -245, 266, 2707, 180, "D_STARTOWER_88_1ST_DEFENCE_DEVICE", "D_STARTOWER_88_1ST_DEFENCE_DEVICE", "", 0);
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(14, 154067, "Demon Summoning Portal", "d_startower_88", -8, 127, -54, 90, "D_STARTOWER_88_VELNIAS_3RD_SUMMON_PORTAL", "", "", 0);
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(15, 154067, "Demon Summoning Portal", "d_startower_88", 9, 127, -484, 90, "D_STARTOWER_88_VELNIAS_1ST_SUMMON_PORTAL", "", "", 0);
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(16, 154067, "Demon Summoning Portal", "d_startower_88", 284, 127, -479, 90, "D_STARTOWER_88_VELNIAS_2ND_SUMMON_PORTAL", "", "", 0);
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(17, 154067, "Demon Summoning Portal", "d_startower_88", 274, 127, -47, 90, "D_STARTOWER_88_VELNIAS_4TH_SUMMON_PORTAL", "", "", 0);
		
		// Portal Suppressor
		//-------------------------------------------------------------------------
		AddNpc(19, 151064, "Portal Suppressor", "d_startower_88", 32, 127, -484, 45, "D_STARTOWER_88_VELNIAS_1ST_CONTROL_DEVICE", "", "", 1);
		
		// Portal Suppressor
		//-------------------------------------------------------------------------
		AddNpc(20, 151064, "Portal Suppressor", "d_startower_88", 307, 127, -479, 45, "D_STARTOWER_88_VELNIAS_2ND_CONTROL_DEVICE", "", "", 1);
		
		// Portal Suppressor
		//-------------------------------------------------------------------------
		AddNpc(21, 151064, "Portal Suppressor", "d_startower_88", 17, 127, -53, 45, "D_STARTOWER_88_VELNIAS_3RD_CONTROL_DEVICE", "", "", 1);
		
		// Portal Suppressor
		//-------------------------------------------------------------------------
		AddNpc(22, 151064, "Portal Suppressor", "d_startower_88", 302, 127, -47, 45, "D_STARTOWER_88_VELNIAS_4TH_CONTROL_DEVICE", "", "", 1);
		
		// Defensive Device
		//-------------------------------------------------------------------------
		AddNpc(23, 153137, "Defensive Device", "d_startower_88", -245, 266, 2707, 180, "D_STARTOWER_88_1ST_DEFENCE_AFTER_DEVICE", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(24, 20042, " ", "d_startower_88", 1480, 212, 1227, 90, "", "STARTOWER_88_ARROWRAIN_TRAP", "STARTOWER_88_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(24, 20042, " ", "d_startower_88", 773, 139, 1225, 90, "", "STARTOWER_88_ARROWRAIN_TRAP", "STARTOWER_88_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(24, 20042, " ", "d_startower_88", 24, 212, 476, 90, "", "STARTOWER_88_ARROWRAIN_TRAP", "STARTOWER_88_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(24, 20042, " ", "d_startower_88", 175, 127, -185, 90, "", "STARTOWER_88_ARROWRAIN_TRAP", "STARTOWER_88_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(24, 20042, " ", "d_startower_88", -204, 130, 2100, 90, "", "STARTOWER_88_ARROWRAIN_TRAP", "STARTOWER_88_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(24, 20042, " ", "d_startower_88", 517, 130, 2620, 90, "", "STARTOWER_88_ARROWRAIN_TRAP", "STARTOWER_88_ARROWRAIN_TRAP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(24, 20042, " ", "d_startower_88", 1105, 422, 2952, 90, "", "STARTOWER_88_ARROWRAIN_TRAP", "STARTOWER_88_ARROWRAIN_TRAP");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(34, 40120, "Statue of Goddess Vakarine", "d_startower_88", 2352.313, 212.6299, 1488.612, 45, "WARP_D_STARTOWER_88", "STOUP_CAMP", "STOUP_CAMP");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 264.7976, 127.9265, 72.96165, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 300.9818, 127.9265, -85.70864, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 420.9281, 127.9265, -53.10691, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 303.4561, 127.9265, -299.0227, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 410.8188, 127.9265, -437.3646, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 271.5826, 127.9265, -504.4998, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 370.5735, 127.9265, -246.1415, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 77.54555, 127.9265, -506.1563, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", -87.10231, 127.9265, -440.3877, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", -142.867, 127.9263, -514.1299, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", -124.4491, 127.9265, -289.1425, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 4.755657, 127.9265, -349.5658, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", -94.47321, 127.9265, -128.9446, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", -156.3448, 127.9265, -37.91904, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", -78.51158, 127.9265, 36.96342, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 30.75482, 134.5071, 83.35756, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 23.89389, 127.9265, -74.06413, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 153.8297, 127.9265, -120.4937, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
		
		// Demon Summoning Portal
		//-------------------------------------------------------------------------
		AddNpc(37, 154067, "Demon Summoning Portal", "d_startower_88", 128.7825, 127.9265, -386.4752, 90, "STARTOWER_88_MQ_20_PORTAL_NPC", "", "");
	}
}
