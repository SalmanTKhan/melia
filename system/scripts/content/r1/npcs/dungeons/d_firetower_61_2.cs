//--- Melia Script ----------------------------------------------------------
// Roxona Reconstruction Agency East Building
//--- Description -----------------------------------------------------------
// NPCs found in and around Roxona Reconstruction Agency East Building.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DFiretower612NpcScript : GeneralScript
{
	public override void Load()
	{
		// Roxona Reconstruction Agency West Building
		//-------------------------------------------------------------------------
		AddNpc(8, 40001, "Roxona Reconstruction Agency West Building", "d_firetower_61_2", -1891.504, 267.6633, -1702.749, 0, "", "FIRETOWER612_TO_FIRETOWER611", "");
		AddNpc(9, 147306, "Demons' Sealed Sphere", "d_firetower_61_2", -31, 143, -1505, 176, "", "", "");
		AddNpc(15, 154005, "Hidden North Area Manager", "d_firetower_61_2", -1293, 380, 683, 90, "", "", "");
		AddNpc(16, 154005, "Hidden South Area Manager", "d_firetower_61_2", 984, 289, -975, 90, "", "", "");
		
		// North Side
		//-------------------------------------------------------------------------
		AddNpc(17, 147469, "North Side", "d_firetower_61_2", -2074, 180, 1347, 90, "FD_FIRETOWER612_T01_GATE_NOUTH_RUN_2", "", "");
		
		// South Side
		//-------------------------------------------------------------------------
		AddNpc(18, 147469, "South Side", "d_firetower_61_2", 1695, 180, -1557, 90, "FD_FIRETOWER612_T01_GATE_SOUTH_RUN_2", "", "");
		AddNpc(19, 154005, "Green Crystal Controller", "d_firetower_61_2", -79.70574, 147.0017, 68.96259, 90, "", "", "");
		AddNpc(20, 154005, "White Crystal Controller", "d_firetower_61_2", -45.63173, 147.0017, 67.06168, 90, "", "", "");
		AddNpc(22, 147364, "Monster Genx", "d_firetower_61_2", -1898.343, 268.4465, -1520.467, 90, "", "", "");
		AddNpc(23, 147366, "Monster Genx", "d_firetower_61_2", -2100.664, 179.8584, 1377.934, 90, "", "", "");
		AddNpc(23, 147366, "Monster Genx", "d_firetower_61_2", 1680.336, 179.8653, -1555.738, 90, "", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(1000, 147392, "Lv1 Treasure Chest", "d_firetower_61_2", 905.93, 332.71, 400.7, 225, "TREASUREBOX_LV_D_FIRETOWER_61_21000", "", "");
	}
}
