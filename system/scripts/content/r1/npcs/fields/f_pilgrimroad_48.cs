//--- Melia Script ----------------------------------------------------------
// Manahas
//--- Description -----------------------------------------------------------
// NPCs found in and around Manahas.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FPilgrimroad48NpcScript : GeneralScript
{
	public override void Load()
	{
		// Fasika Plateau
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Fasika Plateau", "f_pilgrimroad_48", -560.6875, 546.9031, 1498.365, 206, "", "PILGRIM_48_TO_PILGRIM_36_2", "");
		
		// Genar Field
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Genar Field", "f_pilgrimroad_48", -1470.036, 382.684, -2171.64, -6, "", "PILGRIM_48_TO_PILGRIM_49", "");
		
		// [Kedoran Merchant Alliance]{nl}Leopoldas
		//-------------------------------------------------------------------------
		AddNpc(4, 147484, "[Kedoran Merchant Alliance]{nl}Leopoldas", "f_pilgrimroad_48", -165.5285, 546.9031, 1501.194, 6, "PILGRIM_48_LEOPOLDAS", "", "");
		
		// [Kedoran Merchant Alliance]{nl}Merrisa
		//-------------------------------------------------------------------------
		AddNpc(5, 152064, "[Kedoran Merchant Alliance]{nl}Merrisa", "f_pilgrimroad_48", -174.2117, 382.695, -205.1203, 90, "PILGRIM_48_JURATE", "", "");
		
		// [Kedoran Merchant Alliance]{nl}Margellius
		//-------------------------------------------------------------------------
		AddNpc(6, 147485, "[Kedoran Merchant Alliance]{nl}Margellius", "f_pilgrimroad_48", -6.034502, 382.684, -138.5854, -34, "PILGRIM_48_MARCELIJUS", "", "");
		
		// [Kedoran Merchant Alliance]{nl}Gerda
		//-------------------------------------------------------------------------
		AddNpc(7, 147473, "[Kedoran Merchant Alliance]{nl}Gerda", "f_pilgrimroad_48", -53.00045, 546.9031, 1594.12, 90, "PILGRIM_48_GERDA", "", "");
		
		// [Kedoran Merchant Alliance]{nl}Serapinas
		//-------------------------------------------------------------------------
		AddNpc(8, 147483, "[Kedoran Merchant Alliance]{nl}Serapinas", "f_pilgrimroad_48", 5.860531, 546.9031, 1596.749, -25, "PILGRIM_48_SERAPINAS", "", "");
		
		// Record Member
		//-------------------------------------------------------------------------
		AddNpc(9, 20114, "Record Member", "f_pilgrimroad_48", 90.37851, 382.684, -214.3848, 74, "PILGRIM_48_NPC02", "", "");
		
		// Collection Member
		//-------------------------------------------------------------------------
		AddNpc(10, 20158, "Collection Member", "f_pilgrimroad_48", -271.4866, 382.684, -311.0471, 90, "PILGRIM_48_NPC01", "", "");
		
		// Record Member
		//-------------------------------------------------------------------------
		AddNpc(11, 20156, "Record Member", "f_pilgrimroad_48", 148.3876, 382.684, -199.5782, -47, "PILGRIM_48_NPC03", "", "");
		AddNpc(12, 152040, " ", "f_pilgrimroad_48", 43.94047, 382.684, -185.7952, 7, "", "", "");
		AddNpc(12, 152040, " ", "f_pilgrimroad_48", 127.0995, 382.684, -207.8566, -19, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(13, 40070, " ", "f_pilgrimroad_48", 676.2576, 546.9031, 1285.715, 35, "PILGRIM_48_BOARD", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(14, 147469, " ", "f_pilgrimroad_48", 687.7766, 546.9031, 1288.692, 90, "PILGRIM_48_BOARDPLACE", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(15, 147469, " ", "f_pilgrimroad_48", -705.6685, 382.684, -1357.29, 90, "PILGRIM_48_EXCAVATION01", "", "");
		
		// PILGRIM_48_SQ_050Trigger for quest
		//-------------------------------------------------------------------------
		AddNpc(16, 20026, "PILGRIM_48_SQ_050Trigger for quest", "f_pilgrimroad_48", 1030.004, 546.9031, 1347.188, 90, "", "PILGRIM_48_SQ_050_TRIGGER", "");
		
		// PILGRIM_48_SQ_060For quest
		//-------------------------------------------------------------------------
		AddNpc(17, 20026, "PILGRIM_48_SQ_060For quest", "f_pilgrimroad_48", -1078.692, 382.684, 585.9547, 90, "PILGRIM_48_EXCAVATION03", "", "");
		
		// PILGRIM_48_SQ_060_DISTANCE_CHECK
		//-------------------------------------------------------------------------
		AddNpc(18, 20026, "PILGRIM_48_SQ_060_DISTANCE_CHECK", "f_pilgrimroad_48", -870.4012, 382.684, 356.5185, 90, "", "PILGRIM_48_SQ_060_E", "");
		
		// PILGRIM_48_SQ_090_DISTANCE_CHECK
		//-------------------------------------------------------------------------
		AddNpc(19, 20026, "PILGRIM_48_SQ_090_DISTANCE_CHECK", "f_pilgrimroad_48", 1638.641, 469.9118, 239.7801, 90, "", "PILGRIM_48_SQ_090_E", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(20, 40120, "Statue of Goddess Vakarine", "f_pilgrimroad_48", -260.2179, 382.684, 19.69579, 45, "WARP_F_PILGRIMROAD_48", "STOUP_CAMP", "STOUP_CAMP");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(26, 147392, "Lv1 Treasure Chest", "f_pilgrimroad_48", 234, 546, 1479, 90, "TREASUREBOX_LV_F_PILGRIMROAD_4826", "", "");
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 310.2977, 427.1307, -1497.419, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 70.58665, 427.1307, -1515.514, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", -115.1053, 427.1307, -1355.233, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", -117.0158, 427.1307, -1158.186, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", -116.0068, 427.1307, -967.9064, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 120.8987, 427.1307, -1110.406, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 253.4272, 427.1307, -1164.96, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 429.037, 427.1307, -1266.777, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 695.1608, 427.1307, -1366.195, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 526.9686, 427.1307, -1433.375, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 637.7759, 427.1307, -1152.961, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 651.275, 427.1307, -1005.753, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 574.7047, 427.1307, -820.0602, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 390.1572, 427.1307, -776.9429, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 204.1524, 427.1307, -853.7637, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 353.8049, 427.1307, -1007.111, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 683.2675, 427.1307, -898.1469, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 219.7955, 427.1307, -1335.437, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// Pile of Soil
		//-------------------------------------------------------------------------
		AddNpc(27, 155026, "Pile of Soil", "f_pilgrimroad_48", 534.6473, 427.1307, -933.1989, 90, "PILGRIM48_RP_1_OBJ", "", "", 1);
		
		// [Inquisitor Master]{nl}Thomas Iquinostasys
		//-------------------------------------------------------------------------
		AddNpc(28, 153169, "[Inquisitor Master]{nl}Thomas Iquinostasys", "f_pilgrimroad_48", -510.8484, 382.684, -319.2973, 90, "INQUISITOR_MASTER", "", "");
		AddNpc(29, 20026, "HIDDEN_MIKO_PILGRIM_48_TRIGGER", "f_pilgrimroad_48", -70.75451, 382.713, -154.5551, 90, "", "", "");
	}
}
