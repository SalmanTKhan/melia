//--- Melia Script ----------------------------------------------------------
// Moroth Embassy in Kingdom
//--- Description -----------------------------------------------------------
// NPCs found in and around Moroth Embassy in Kingdom.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CKlaipeCastleNpcScript : GeneralScript
{
	public override void Load()
	{
		// 
		//-------------------------------------------------------------------------
		AddNpc(1, 20049, "", "c_klaipe_castle", 1891.982, -126.8505, -388.0709, 90, "", "EP14_3LINE_TUTO_MQ_1_GATE", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(2, 20049, "", "c_klaipe_castle", 1586.985, -128.3544, -132.6602, 0, "", "EP14_3LINE_TUTO_MQ_5_GATE", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(3, 20049, "", "c_klaipe_castle", 1599.878, 0.919632, 470.0856, 180, "", "EP14_3LINE_TUTO_MQ_4_GATE", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(4, 20049, "", "c_klaipe_castle", 2184.39, 0.919632, 480.7589, 180, "", "EP14_3LINE_TUTO_MQ_9_1_GATE", "");
		AddNpc(5, 20049, "", "c_klaipe_castle", 2181.095, -125.1783, -80.32453, 180, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(6, 20061, " ", "c_klaipe_castle", 1822.235, -157.3853, -465.2905, 99, "EP14_3LINE_TUTO_MQ_2_F_PEOPLE_1", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(7, 20063, " ", "c_klaipe_castle", 1826.767, -157.3853, -487.3989, 181, "EP14_3LINE_TUTO_MQ_2_M_PEOPLE_1", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(8, 151092, " ", "c_klaipe_castle", 1953.404, -157.3853, -461.4131, 3, "EP14_3LINE_TUTO_MQ_2_M_PEOPLE_2", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(9, 151093, " ", "c_klaipe_castle", 1937.661, -157.3853, -470.608, 82, "EP14_3LINE_TUTO_MQ_2_M_PEOPLE_1", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(10, 153109, " ", "c_klaipe_castle", 1821.678, -157.3853, -584.795, 181, "EP14_3LINE_TUTO_MQ_2_M_PEOPLE_1", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(11, 147407, " ", "c_klaipe_castle", 1825.533, -157.3853, -567.0358, -17, "EP14_3LINE_TUTO_MQ_2_M_PEOPLE_2", "", "", 0);
		AddNpc(12, 150290, " ", "c_klaipe_castle", 1858.365, -125.8316, -422.8796, -7, "", "", "");
		AddNpc(13, 150290, " ", "c_klaipe_castle", 1930.433, -125.8528, -421.4096, -7, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(14, 155022, " ", "c_klaipe_castle", 1942.033, -157.3853, -515.2402, -8, "EP14_3LINE_TUTO_MQ_2_M_PEOPLE_2", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(15, 155021, " ", "c_klaipe_castle", 1943.687, -157.3853, -538.9835, 171, "EP14_3LINE_TUTO_MQ_2_F_PEOPLE_1", "", "", 0);
		
		// [Guard General]{nl}Heosha
		//-------------------------------------------------------------------------
		AddNpc(16, 150286, "[Guard General]{nl}Heosha", "c_klaipe_castle", 1927.275, 109.1807, 740.5197, 21, "EP14_HEOSHAA_NPC", "", "", 1);
		
		// [Great General]{nl}Ramin
		//-------------------------------------------------------------------------
		AddNpc(17, 150287, "[Great General]{nl}Ramin", "c_klaipe_castle", 1983.8, -127.0293, 6.899456, 10, "EP14_RAMIN_NPC", "", "", 1);
		
		// [Regent]{nl}Kaoneela Henrjusi
		//-------------------------------------------------------------------------
		AddNpc(18, 150285, "[Regent]{nl}Kaoneela Henrjusi", "c_klaipe_castle", 1498.721, 27.15005, 828.2349, 18, "EP14_KAONEELA_NPC", "", "", 1);
		AddNpc(19, 150289, "", "c_klaipe_castle", 2003.073, -127.0296, -28.05763, 183, "", "", "");
		AddNpc(20, 150289, "", "c_klaipe_castle", 1970.471, -127.0287, -27.40614, 176, "", "", "");
		AddNpc(21, 150212, "[Rangda Master]{nl}Uolios Wahid", "c_klaipe_castle", -642.0793, -134.6223, -58.46703, -28, "", "", "");
		AddNpc(22, 150240, "Rangda Girl", "c_klaipe_castle", -641.2117, -134.6223, -90.47173, 201, "", "", "");
		
		// Illusion of the Girl
		//-------------------------------------------------------------------------
		AddNpc(23, 150238, "Illusion of the Girl", "c_klaipe_castle", 1890.304, -157.3853, -461.5717, 18, "EP14_MULIA_NPC_1", "", "", 1);
		
		// Illusion of the Girl
		//-------------------------------------------------------------------------
		AddNpc(24, 150238, "Illusion of the Girl", "c_klaipe_castle", 1685.186, -127.0212, 19.75056, 13, "EP14_MULIA_NPC_2", "", "", 1);
		
		// Owynia Dilben
		//-------------------------------------------------------------------------
		AddNpc(25, 153223, "Owynia Dilben", "c_klaipe_castle", 1102.163, -139.5452, 310.6166, -1, "EP14_OWYNIA_NPC", "", "", 1);
		
		// For Testing
		//-------------------------------------------------------------------------
		AddNpc(26, 157016, "For Testing", "c_klaipe_castle", 1876.109, -157.3853, -547.8932, 22, "TEST_GQ_GM_NPC", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(27, 20026, "", "c_klaipe_castle", 1893.812, -126.5571, -395.6186, 90, "", "EP14_3LINE_TUTO_MQ_1_NPC", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(28, 20026, "", "c_klaipe_castle", 1501.069, 26.88049, 570.4113, 90, "", "EP14_3LINE_TUTO_MQ_4_NPC", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(29, 20026, "", "c_klaipe_castle", -286.86, -131.6208, -250.7145, 90, "", "EP14_3LINE_TUTO_MQ_9_NPC", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(30, 20026, "", "c_klaipe_castle", 3243.214, 0.9619508, 484.2336, 90, "", "EP14_3LINE_TUTO_MQ_9_1_HELP", "");
		
		// Skip Tutorial
		//-------------------------------------------------------------------------
		AddNpc(31, 40001, "Skip Tutorial", "c_klaipe_castle", 1893.886, -157.3853, -586.0467, -2, "EP14_TUTO_SKIP_NPC", "", "", 1);
		AddNpc(32, 150290, "Embassy Guards", "c_klaipe_castle", 1613.219, -127.1853, -71.50716, 90, "", "", "");
		AddNpc(32, 150290, "Embassy Guards", "c_klaipe_castle", 1612.108, -127.3052, -204.1716, 90, "", "", "");
		AddNpc(32, 150290, "Embassy Guards", "c_klaipe_castle", 2144.786, -127.0312, -19.95486, -81, "", "", "");
		AddNpc(32, 150290, "Embassy Guards", "c_klaipe_castle", 2146.624, -127.0312, -148.9358, -88, "", "", "");
		AddNpc(32, 150290, "Embassy Guards", "c_klaipe_castle", 1473.142, 0.919632, 522.161, 4, "", "", "");
		AddNpc(32, 150290, "Embassy Guards", "c_klaipe_castle", 1532.346, 0.919632, 523.1144, -11, "", "", "");
		AddNpc(32, 150290, "Embassy Guards", "c_klaipe_castle", 594.1059, -139.2175, -142.9153, 96, "", "", "");
		AddNpc(32, 150290, "Embassy Guards", "c_klaipe_castle", 1246.516, -137.6674, -132.7262, -74, "", "", "");
		AddNpc(32, 150290, "Embassy Guards", "c_klaipe_castle", 87.62735, -162.3, -313.489, 12, "", "", "");
		AddNpc(32, 150290, "Embassy Guards", "c_klaipe_castle", 3208.362, -160.4947, 91.60307, -85, "", "", "");
		
		// Orsha Refugee
		//-------------------------------------------------------------------------
		AddNpc(33, 153109, "Orsha Refugee", "c_klaipe_castle", 3773.703, 1, 625.7218, -4, "EP14_3LINE_TUTO_MQ_9_1_NPC", "", "", 0);
		AddNpc(34, 20061, "Orsha Refugee", "c_klaipe_castle", 717.2319, -139.1346, 306.2433, 81, "", "", "");
		AddNpc(34, 20061, "Orsha Refugee", "c_klaipe_castle", 813.5759, -148.127, 70.34998, 165, "", "", "");
		AddNpc(35, 20062, "Orsha Refugee", "c_klaipe_castle", 975.9125, -137.4758, -136.9272, 8, "", "", "");
		AddNpc(36, 153111, "Orsha Refugee", "c_klaipe_castle", 969.3024, -136.817, 209.533, 188, "", "", "");
		AddNpc(36, 153111, "Orsha Refugee", "c_klaipe_castle", 786.1227, -137.3891, -134.5627, 17, "", "", "");
		AddNpc(37, 151096, "Orsha Refugee", "c_klaipe_castle", 917.3158, -148.1271, 65.80245, 165, "", "", "");
		AddNpc(38, 151091, "Orsha Refugee", "c_klaipe_castle", 1014.993, -148.1271, 69.59435, 179, "", "", "");
		AddNpc(39, 151096, "Orsha Refugee", "c_klaipe_castle", 667.499, -137.7626, 82.51191, 90, "", "", "");
		AddNpc(39, 151096, "Orsha Refugee", "c_klaipe_castle", 1147.412, -138.9282, -176.5666, -81, "", "", "");
	}
}