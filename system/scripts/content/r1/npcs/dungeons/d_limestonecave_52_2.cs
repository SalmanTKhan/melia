//--- Melia Script ----------------------------------------------------------
// Tevhrin Stalactite Cave Section 2
//--- Description -----------------------------------------------------------
// NPCs found in and around Tevhrin Stalactite Cave Section 2.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DLimestonecave522NpcScript : GeneralScript
{
	public override void Load()
	{
		// Tevhrin Stalactite Cave Section 1
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Tevhrin Stalactite Cave Section 1", "d_limestonecave_52_2", -1460.944, -974.1772, -1811.588, -18, "", "LIMESTONECAVE_52_2_LIMESTONECAVE_52_1", "");
		
		// Tevhrin Stalactite Cave Section 3
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Tevhrin Stalactite Cave Section 3", "d_limestonecave_52_2", 1287.455, -502.3526, -119.2307, 90, "", "LIMESTONECAVE_52_2_LIMESTONECAVE_52_3", "");
		
		// Kupole Alena
		//-------------------------------------------------------------------------
		AddNpc(3, 154015, "Kupole Alena", "d_limestonecave_52_2", -1893.854, -1064.119, 188.0698, 45, "LIMESTONE_52_2_ALLENA", "", "");
		
		// Kupole Serija
		//-------------------------------------------------------------------------
		AddNpc(4, 154012, "Kupole Serija", "d_limestonecave_52_2", -689.7747, -674.7427, 1385.901, 27, "LIMESTONE_52_2_SERIJA", "", "", 0);
		
		// Kupole Medena
		//-------------------------------------------------------------------------
		AddNpc(15, 154014, "Kupole Medena", "d_limestonecave_52_2", -1584.416, -961.8538, -1512.56, 100, "LIMESTONECAVE_52_2_MEDENA", "", "", 1);
		
		// LIMESTONE_52_2_MQ_1_TRIG
		//-------------------------------------------------------------------------
		AddNpc(16, 20026, "LIMESTONE_52_2_MQ_1_TRIG", "d_limestonecave_52_2", -1836.807, -1065.715, 165.6414, 90, "", "LIMESTONE_52_2_MQ_1_PROG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(18, 20046, " ", "d_limestonecave_52_2", -1894.317, -1064.119, 187.7024, 90, "", "LIMESTONE_52_2_DARKWALL", "");
		
		// LIMESTONE_52_2_MQ_3_TRIG
		//-------------------------------------------------------------------------
		AddNpc(17, 20026, "LIMESTONE_52_2_MQ_3_TRIG", "d_limestonecave_52_2", -632.9493, -674.7427, 1367.69, 90, "", "LIMESTONE_52_2_MQ_3_PROG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(19, 20046, " ", "d_limestonecave_52_2", -688.631, -674.7427, 1387.274, 90, "", "LIMESTONE_52_2_DARKWALL_2", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(11, 152056, " ", "d_limestonecave_52_2", -100.401, -726.4668, 684.7335, 90, "LIMESTONE_52_2_EVIL_1", "LIMESTONE_52_2_MQ_3_FAKE_1", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(12, 152056, " ", "d_limestonecave_52_2", -348.2186, -853.5803, 110.8734, 45, "LIMESTONE_52_2_EVIL_2", "LIMESTONE_52_2_MQ_3_FAKE_1", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(13, 152055, " ", "d_limestonecave_52_2", -1009.624, -948.2627, 361.4804, 90, "LIMESTONE_52_2_EVIL_3", "LIMESTONE_52_2_MQ_3_FAKE_2", "", 0);
		
		// Holy Place of Recover
		//-------------------------------------------------------------------------
		AddNpc(10, 147413, "Holy Place of Recover", "d_limestonecave_52_2", 668.1122, -455.7971, 482.8394, 90, "LIMESTONE_52_2_HEALING", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(14, 147358, " ", "d_limestonecave_52_2", 220.9686, -570.644, 1635.496, 90, "LIMESTONE_52_2_ANTIEVIL", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(1000, 147392, "Lv1 Treasure Chest", "d_limestonecave_52_2", -1444.84, -961.75, -1527.41, 90, "TREASUREBOX_LV_D_LIMESTONECAVE_52_21000", "", "");
	}
}
