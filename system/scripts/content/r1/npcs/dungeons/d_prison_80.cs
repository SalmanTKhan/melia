//--- Melia Script ----------------------------------------------------------
// Solitary Cells
//--- Description -----------------------------------------------------------
// NPCs found in and around Solitary Cells.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DPrison80NpcScript : GeneralScript
{
	public override void Load()
	{
		// Storage
		//-------------------------------------------------------------------------
		AddNpc(4, 40001, "Storage", "d_prison_80", 1348.961, 366.9938, -1690.937, 144, "", "PRISON80_PRISON79", "");
		
		// Workshop
		//-------------------------------------------------------------------------
		AddNpc(5, 40001, "Workshop", "d_prison_80", -1256.333, 267.7394, -1134.59, 90, "", "PRISON80_PRISON81", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(7, 151051, " ", "d_prison_80", -254.3998, 290.4832, 391.4258, 90, "DELIVERY_CHARGES_GAME", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(8, 147475, " ", "d_prison_80", 1224.893, 147.621, 415.5754, 90, "DTACURLING", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(9, 152030, " ", "d_prison_80", -276.1338, 377.3964, -722.9951, 90, "PRISON_80_MIXING", "", "");
		AddNpc(10, 20026, " ", "d_prison_80", 663.2285, 333.8782, -918.4008, 90, "", "", "");
		AddNpc(10, 20026, " ", "d_prison_80", -669.5571, 290.4832, -85.64705, 180, "", "", "");
		AddNpc(11, 20026, " ", "d_prison_80", 1213.26, 160.9524, 606.8317, 0, "", "", "");
		AddNpc(11, 20026, " ", "d_prison_80", -216.9094, 290.4832, 205.5619, 90, "", "", "");
		
		// Zanas' Soul
		//-------------------------------------------------------------------------
		AddNpc(12, 151107, "Zanas' Soul", "d_prison_80", 959.276, 333.8782, -906.8856, 0, "PRISON_80_NPC_1", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(13, 151111, " ", "d_prison_80", -68.45441, 377.3964, -889.7062, 45, "PRISON_80_OBJ_1", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(14, 151108, " ", "d_prison_80", 550.7872, 366.8347, -719.628, 45, "PRISON_80_OBJ_2", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(15, 151111, " ", "d_prison_80", 1220.483, 147.621, 189.4619, 90, "PRISON_80_OBJ_3", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(16, 147469, " ", "d_prison_80", -125, 290.4832, 524, 90, "PRISON_80_OBJ_4", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(17, 20026, " ", "d_prison_80", -156.5224, 125.7254, 1079.112, 90, "", "PRISON_80_MQ_7_TRIGGER", "");
		
		// Zanas' Soul
		//-------------------------------------------------------------------------
		AddNpc(18, 151107, "Zanas' Soul", "d_prison_80", -225.4855, 290.48, 429.9146, 45, "PRISON_80_NPC_2", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 151108, " ", "d_prison_80", -1034.475, 328.9453, 300.8317, 45, "PRISON_80_OBJ_5", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20, 46215, " ", "d_prison_80", -1128.756, 328.9453, 329.7686, 90, "PRISON_80_OBJ_6_1", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(21, 46215, " ", "d_prison_80", -1108.056, 328.9453, 234.4706, 90, "PRISON_80_OBJ_6_2", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(22, 46215, " ", "d_prison_80", -1012.815, 328.9453, 204.8901, 90, "PRISON_80_OBJ_6_3", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(23, 46215, " ", "d_prison_80", -935.7294, 328.9453, 274.7069, 90, "PRISON_80_OBJ_6_4", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(24, 46215, " ", "d_prison_80", -958.3124, 328.9453, 371.3957, 90, "PRISON_80_OBJ_6_5", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(25, 46215, " ", "d_prison_80", -1051.375, 328.9453, 400.624, 90, "PRISON_80_OBJ_6_6", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(26, 20026, " ", "d_prison_80", -1128.756, 328.9453, 329.7686, 90, "", "PRISON_80_OBJ_6_AFTER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(26, 20026, " ", "d_prison_80", -1108.056, 328.9453, 234.4706, 90, "", "PRISON_80_OBJ_6_AFTER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(26, 20026, " ", "d_prison_80", -1012.815, 328.9453, 204.8901, 90, "", "PRISON_80_OBJ_6_AFTER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(26, 20026, " ", "d_prison_80", -935.7294, 328.9453, 274.7069, 90, "", "PRISON_80_OBJ_6_AFTER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(26, 20026, " ", "d_prison_80", -958.3124, 328.9453, 371.3957, 90, "", "PRISON_80_OBJ_6_AFTER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(26, 20026, " ", "d_prison_80", -1051.375, 328.9453, 400.624, 90, "", "PRISON_80_OBJ_6_AFTER", "");
		
		// Demon Barrier
		//-------------------------------------------------------------------------
		AddNpc(27, 147469, "Demon Barrier", "d_prison_80", -863.2603, 155.9955, -330.1364, 90, "PRISON_80_MQ_10_TRIGGER", "PRISON_80_MQ_10_TRIGGER", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(28, 147469, " ", "d_prison_80", -863.2603, 155.9955, -330.1364, 90, "", "PRISON_80_MQ_10_TRIGGER_AFTER", "");
		AddNpc(29, 147364, "CantGen200", "d_prison_80", 1340.427, 366.9938, -1704.783, 90, "", "", "");
		AddNpc(29, 147364, "CantGen200", "d_prison_80", 1038.235, 333.8782, -867.8471, 90, "", "", "");
		AddNpc(29, 147364, "CantGen200", "d_prison_80", -1248.573, 267.7394, -1071.009, 90, "", "", "");
		AddNpc(29, 147364, "CantGen200", "d_prison_80", -234.0495, 290.4832, 438.8271, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(30, 147469, " ", "d_prison_80", 962.3539, 158.0417, 517.7187, 90, "PRISON_80_SQ_OBJ_1", "", "");
		
		// Chest of Confiscated Goods
		//-------------------------------------------------------------------------
		AddNpc(31, 151030, "Chest of Confiscated Goods", "d_prison_80", -666.3862, 290.4832, 65.25813, 45, "PRISON_80_SQ_OBJ_2", "", "");
	}
}