//--- Melia Script ----------------------------------------------------------
// Demon Prison District 4
//--- Description -----------------------------------------------------------
// NPCs found in and around Demon Prison District 4.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DVelniasprison513NpcScript : GeneralScript
{
	public override void Load()
	{
		// Kupole Daiva
		//-------------------------------------------------------------------------
		AddNpc(1, 154013, "Kupole Daiva", "d_velniasprison_51_3", -3158.28, 160.4527, -653.9012, 90, "VPRISON513_MQ_DAIVA_01", "", "", 1);
		
		// Kupole Daiva
		//-------------------------------------------------------------------------
		AddNpc(2, 154013, "Kupole Daiva", "d_velniasprison_51_3", -1382.819, 91.0399, 940.3401, 90, "VPRISON513_MQ_DAIVA_02", "", "", 1);
		
		// Kupole Sigita
		//-------------------------------------------------------------------------
		AddNpc(3, 154012, "Kupole Sigita", "d_velniasprison_51_3", 1307.429, 91.0399, 916.9585, 269, "VPRISON513_MQ_SIGITA", "", "", 1);
		
		// Demon Prison District 3
		//-------------------------------------------------------------------------
		AddNpc(4, 154000, "Demon Prison District 3", "d_velniasprison_51_3", -3317, 161, -807, 90, "VELNIASP513_TO_VELNIASP514", "", "");
		
		// Demon Prison District 5
		//-------------------------------------------------------------------------
		AddNpc(5, 154000, "Demon Prison District 5", "d_velniasprison_51_3", 2867, 131, -751, 90, "VELNIASP513_TO_VELNIASP515", "", "");
		
		// Demon Lord Hauberk
		//-------------------------------------------------------------------------
		AddNpc(6, 57840, "Demon Lord Hauberk", "d_velniasprison_51_3", -2517.733, 93.4918, -400.7579, 171, "", "VPRISON513_MQ_01_NPC", "");
		
		// Kupole Daiva
		//-------------------------------------------------------------------------
		AddNpc(12, 154013, "Kupole Daiva", "d_velniasprison_51_3", 1154.901, 91.0399, 969.0727, 90, "VPRISON513_MQ_DAIVA_03", "", "", 1);
		AddNpc(13, 147365, "Gate Entrance x", "d_velniasprison_51_3", -3261.873, 160.504, -692.1519, 90, "", "", "");
		AddNpc(13, 147365, "Gate Entrance x", "d_velniasprison_51_3", -1361.857, 91.0399, 880.6473, 90, "", "", "");
		AddNpc(13, 147365, "Gate Entrance x", "d_velniasprison_51_3", 1196.384, 91.0399, 876.2986, 90, "", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(17, 147392, "Lv1 Treasure Chest", "d_velniasprison_51_3", 1736.33, 128.36, -1242.48, 90, "TREASUREBOX_LV_D_VELNIASPRISON_51_317", "", "");
	}
}
