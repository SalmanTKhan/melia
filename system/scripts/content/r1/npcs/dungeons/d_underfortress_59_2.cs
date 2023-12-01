//--- Melia Script ----------------------------------------------------------
// Royal Mausoleum Constructors' Chapel
//--- Description -----------------------------------------------------------
// NPCs found in and around Royal Mausoleum Constructors' Chapel.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DUnderfortress592NpcScript : GeneralScript
{
	public override void Load()
	{
		// Royal Mausoleum Storage
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Royal Mausoleum Storage", "d_underfortress_59_2", -40.84153, -2.557541, 281.1239, 270, "", "UNDERF592_TO_UNDERF593", "");
		
		// Royal Mausoleum Workers Lodge
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Royal Mausoleum Workers Lodge", "d_underfortress_59_2", 456.9549, 4.873723, -386.4884, 93, "", "UNDERF592_TO_UNDERF591", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(3, 154001, " ", "d_underfortress_59_2", -954, 1, -928, 90, "", "UNDERF592_TYPEB_GATE_1", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(4, 154001, " ", "d_underfortress_59_2", -1059, 1, -692, 180, "", "UNDERF592_TYPEB_GATE_2", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(5, 154001, " ", "d_underfortress_59_2", -1058, 1, -239, 180, "", "UNDERF592_TYPEB_GATE_3", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(6, 154001, " ", "d_underfortress_59_2", -1059, 1, 187, 180, "", "UNDERF592_TYPEB_GATE_4", "");
		AddNpc(7, 154001, " ", "d_underfortress_59_2", -954, 0.377, 401, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(8, 154001, " ", "d_underfortress_59_2", -847, 1, 168, 180, "", "UNDERF592_TYPEB_GATE_5", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(9, 154001, " ", "d_underfortress_59_2", -838, 1, -698, 180, "", "UNDERF592_TYPEB_GATE_6", "");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(10, 147357, "Chapel Altar", "d_underfortress_59_2", -968.345, 0.377, -1142.851, 45, "UNDERF592_TYPEB_ALTER_1", "", "");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(11, 147357, "Chapel Altar", "d_underfortress_59_2", -1326.646, 0.377, -717.1221, 45, "UNDERF592_TYPEB_ALTER_2", "", "");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(12, 147357, "Chapel Altar", "d_underfortress_59_2", -1326.666, 0.377, -227.6213, 45, "UNDERF592_TYPEB_ALTER_3", "", "");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(13, 147357, "Chapel Altar", "d_underfortress_59_2", -1313.609, 0.377, 171.6777, 45, "UNDERF592_TYPEB_ALTER_4", "", "");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(14, 147357, "Chapel Altar", "d_underfortress_59_2", -623.6964, 0.377, 191.6919, 45, "UNDERF592_TYPEB_ALTER_5", "", "");
		
		// Chapel Altar
		//-------------------------------------------------------------------------
		AddNpc(15, 147357, "Chapel Altar", "d_underfortress_59_2", -601.874, 0.377, -695.8885, 45, "UNDERF592_TYPEB_ALTER_6", "", "");
		
		// Abandoned Altar
		//-------------------------------------------------------------------------
		AddNpc(16, 147417, "Abandoned Altar", "d_underfortress_59_2", -328.7843, 1.495392, 797.9495, 90, "FD_UNDERF592_TYPEA_ALTER", "", "");
		AddNpc(27, 154005, "TypeB_Controller", "d_underfortress_59_2", -958.3696, 0.377, -515.412, 90, "", "", "");
		
		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(28, 40110, "Statue of Goddess Zemyna", "d_underfortress_59_2", -951.0473, 0.377, 696.8472, 0, "UNDERF592_ZEMINA_STATUE", "UNDERF592_ZEMINA_STATUE", "UNDERF592_ZEMINA_STATUE");
		AddNpc(29, 154005, "TypeBSuccess manager", "d_underfortress_59_2", -968.9522, 0.377, 200.3747, 207, "", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(37, 40120, "Statue of Goddess Vakarine", "d_underfortress_59_2", 449.585, 0.377, -208.2484, -30, "WARP_D_UNDERFORTRESS_59_2", "STOUP_CAMP", "STOUP_CAMP");
		AddNpc(38, 154005, "TypeB_Final", "d_underfortress_59_2", -951.0599, 0.377, 347.2141, 90, "", "", "");
		
		// The Grass of King Zachariel
		//-------------------------------------------------------------------------
		AddNpc(39, 153014, "The Grass of King Zachariel", "d_underfortress_59_2", -555.3775, 0.377, -319.4533, 90, "ROKAS_MEMO02_NPC", "", "", 0);
		AddNpc(42, 147362, "Gate Entrance x", "d_underfortress_59_2", 1.403871, 0.3769534, 276.414, 90, "", "", "");
		AddNpc(42, 147362, "Gate Entrance x", "d_underfortress_59_2", 482.2683, 21.20656, -385.9878, 90, "", "", "");
		
		// Chapel Light Beacon
		//-------------------------------------------------------------------------
		AddNpc(43, 154041, "Chapel Light Beacon", "d_underfortress_59_2", 987.5584, 118.9185, -195.5981, 90, "UNDERF592_TYPEC_DEFENCE_1", "", "");
		AddNpc(44, 154005, "bossgen", "d_underfortress_59_2", 591.0416, 83.80196, 1145.804, 90, "", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(45, 147392, "Lv1 Treasure Chest", "d_underfortress_59_2", -963, 0, -1128, 90, "TREASUREBOX_LV_D_UNDERFORTRESS_59_245", "", "");
		AddNpc(46, 154004, " ", "d_underfortress_59_2", 376.6106, 0.3769534, 998.9171, 90, "", "", "");
		AddNpc(46, 154004, " ", "d_underfortress_59_2", 376.1166, 0.3769534, 1091.624, 90, "", "", "");
		AddNpc(46, 154004, " ", "d_underfortress_59_2", 376.9242, 0.3769534, 1184.966, 90, "", "", "");
	}
}
