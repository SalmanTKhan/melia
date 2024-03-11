//--- Melia Script ----------------------------------------------------------
// Rinksmas Ruins
//--- Description -----------------------------------------------------------
// NPCs found in and around Rinksmas Ruins.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FDesolatedCapital531NpcScript : GeneralScript
{
	public override void Load()
	{
		// Skalda Outskirts
		//-------------------------------------------------------------------------
		AddNpc(6, 40001, "Skalda Outskirts", "f_desolated_capital_53_1", 3608.171, 6.151794, 1241.829, 90, "", "WARP_DCAPITAL53_1_TO_CASTLE102", "");
		
		// Path of Desition
		//-------------------------------------------------------------------------
		AddNpc(7, 40001, "Path of Desition", "f_desolated_capital_53_1", 3178.219, 166.0747, 3389.617, 90, "", "WARP_DCAPITAL53_1_TO_DCAPITAL104", "");
		AddNpc(8, 147363, " ", "f_desolated_capital_53_1", 1619.282, 111.8744, 2320.372, 90, "", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(9, 40120, "Statue of Goddess Vakarine", "f_desolated_capital_53_1", 1515.549, 111.8744, 2274.188, 45, "WARP_DCAPITAL53_1", "STOUP_CAMP", "STOUP_CAMP");
		AddNpc(11, 147366, "", "f_desolated_capital_53_1", 1681.555, 111.8744, 2727.906, 90, "", "", "");
		AddNpc(11, 147366, "", "f_desolated_capital_53_1", 1499.021, 111.8744, 2265.281, 90, "", "", "");
		AddNpc(11, 147366, "", "f_desolated_capital_53_1", 1619.678, 111.8744, 2253.272, 90, "", "", "");
		AddNpc(11, 147366, "", "f_desolated_capital_53_1", 1823.141, 111.8744, 2382.98, 90, "", "", "");
		
		// Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(12, 150226, "Owl Sculpture", "f_desolated_capital_53_1", 2085.823, 111.8744, 2335.286, 90, "DCAPITAL53_1_SUB_OWL_STATUE01", "", "");
		
		// Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(13, 150226, "Owl Sculpture", "f_desolated_capital_53_1", 1617.194, 110.4872, 1948.605, 0, "DCAPITAL53_1_SUB_OWL_STATUE02", "", "");
		
		// Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(14, 150226, "Owl Sculpture", "f_desolated_capital_53_1", 1259.073, 127.4073, 2045.555, -45, "DCAPITAL53_1_SUB_OWL_STATUE03", "", "");
		
		// Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(15, 150226, "Owl Sculpture", "f_desolated_capital_53_1", 1165.111, 239.7621, 2496.761, 180, "DCAPITAL53_1_SUB_OWL_STATUE04", "", "");
		
		// Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(16, 150226, "Owl Sculpture", "f_desolated_capital_53_1", 1967.376, 124.7114, 2869.105, 90, "DCAPITAL53_1_SUB_OWL_STATUE05", "", "");
		
		// Dievdirbys Vitoldas
		//-------------------------------------------------------------------------
		AddNpc(17, 156005, "Dievdirbys Vitoldas", "f_desolated_capital_53_1", 1760, 112, 2301, 180, "DCAPITAL53_1_MAIN_NPC01", "", "", 1);
		
		// Dievdirbys Adolfas
		//-------------------------------------------------------------------------
		AddNpc(18, 157004, "Dievdirbys Adolfas", "f_desolated_capital_53_1", 1755, 112, 2330, 45, "DCAPITAL53_1_MAIN_NPC02", "", "", 1);
		
		// Dievdirbys Nemunas
		//-------------------------------------------------------------------------
		AddNpc(19, 157005, "Dievdirbys Nemunas", "f_desolated_capital_53_1", 1784, 111, 2342, -45, "DCAPITAL53_1_MAIN_NPC03", "", "", 1);
		
		// Paladin Follower
		//-------------------------------------------------------------------------
		AddNpc(20, 150225, "Paladin Follower", "f_desolated_capital_53_1", 1341.293, 111.8744, 2061.481, -45, "DCAPITAL53_1_SUB_NPC01", "", "");
		
		// Royal Army Guard
		//-------------------------------------------------------------------------
		AddNpc(21, 150219, "Royal Army Guard", "f_desolated_capital_53_1", 1647.132, 111.8744, 1974.566, 0, "DCAPITAL53_1_SUB_NPC02", "", "");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(22, 150221, "Resistance Soldier", "f_desolated_capital_53_1", 2060.531, 111.8744, 2386.672, 90, "DCAPITAL53_1_SUB_NPC03", "", "");
		
		// Royal Army Guard
		//-------------------------------------------------------------------------
		AddNpc(23, 150219, "Royal Army Guard", "f_desolated_capital_53_1", 2045.183, 111.8744, 2299.125, 90, "DCAPITAL53_1_SUB_NPC04", "", "");
		
		// Royal Army Guard
		//-------------------------------------------------------------------------
		AddNpc(24, 150219, "Royal Army Guard", "f_desolated_capital_53_1", 1147.451, 239.4141, 2479.388, 180, "DCAPITAL53_1_SUB_NPC05", "", "");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(25, 150222, "Resistance Soldier", "f_desolated_capital_53_1", 1893.812, 111.8744, 2819.379, 90, "DCAPITAL53_1_SUB_NPC06", "", "");
		
		// Paladin Follower
		//-------------------------------------------------------------------------
		AddNpc(26, 150224, "Paladin Follower", "f_desolated_capital_53_1", 1883.251, 111.8744, 2881.708, 90, "DCAPITAL53_1_SUB_NPC07", "", "");
		
		// Resistance Soldier
		//-------------------------------------------------------------------------
		AddNpc(27, 150220, "Resistance Soldier", "f_desolated_capital_53_1", 1301.028, 111.8744, 2120.708, -45, "DCAPITAL53_1_SUB_NPC08", "", "");
		
		// Resistance Officer
		//-------------------------------------------------------------------------
		AddNpc(28, 150223, "Resistance Officer", "f_desolated_capital_53_1", 1576.808, 111.245, 1967.347, 0, "DCAPITAL53_1_SUB_NPC09", "", "");
		
		// Royal Army Guard
		//-------------------------------------------------------------------------
		AddNpc(29, 150219, "Royal Army Guard", "f_desolated_capital_53_1", 1186.681, 238.0406, 2508.748, 180, "DCAPITAL53_1_SUB_NPC10", "", "");
		
		// Demon Idol
		//-------------------------------------------------------------------------
		AddNpc(30, 47150, "Demon Idol", "f_desolated_capital_53_1", 1950, -65, 725, 45, "", "DCAPITAL53_1_MQ_03_OBJ", "");
		
		// Demon Idol
		//-------------------------------------------------------------------------
		AddNpc(31, 47150, "Demon Idol", "f_desolated_capital_53_1", 803, 40, 1320, 90, "DCAPITAL53_1_MQ_04_OBJ", "", "", 0);
		
		// Demon Idol
		//-------------------------------------------------------------------------
		AddNpc(32, 47150, "Demon Idol", "f_desolated_capital_53_1", 1172, 207, 3246, 0, "", "DCAPITAL53_1_MQ_05_OBJ", "");
		AddNpc(11, 147366, "", "f_desolated_capital_53_1", 1544.543, 111.8744, 2574.269, 90, "", "", "");
		
		// Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(33, 150226, "Owl Sculpture", "f_desolated_capital_53_1", 2066.782, 111.8744, 2250.891, 90, "DCAPITAL53_1_SUB_OWL_STATUE06", "", "");
		
		// Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(34, 150226, "Owl Sculpture", "f_desolated_capital_53_1", 2105.112, 111.8744, 2432.844, 90, "DCAPITAL53_1_SUB_OWL_STATUE07", "", "");
	}
}
