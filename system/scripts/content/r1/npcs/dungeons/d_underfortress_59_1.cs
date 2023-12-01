//--- Melia Script ----------------------------------------------------------
// Royal Mausoleum Workers Lodge
//--- Description -----------------------------------------------------------
// NPCs found in and around Royal Mausoleum Workers Lodge.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DUnderfortress591NpcScript : GeneralScript
{
	public override void Load()
	{
		// Tiltas Valley
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Tiltas Valley", "d_underfortress_59_1", -90.56654, 311.2216, -478.4176, 270, "", "UNDERF591_TO_ROKAS28", "");
		
		// Royal Mausoleum Constructors' Chapel
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Royal Mausoleum Constructors' Chapel", "d_underfortress_59_1", 626.9723, 162.4948, 481.9314, 180, "", "UNDERF591_TO_UNDERF592", "");
		AddNpc(14, 154005, " ", "d_underfortress_59_1", -506.2733, 312.4211, 758.6379, 90, "", "", "");
		
		// Evil Energy Purifier
		//-------------------------------------------------------------------------
		AddNpc(21, 154007, "Evil Energy Purifier", "d_underfortress_59_1", 857.0598, 236.9152, 1107.961, 1, "UNDERF591_TYPEB_OBJ", "", "");
		AddNpc(22, 154005, "TypeD_Buff Manager", "d_underfortress_59_1", 834.3771, 236.9152, 1001.917, 261, "", "", "");
		
		// Eviction Order
		//-------------------------------------------------------------------------
		AddNpc(27, 147312, "Eviction Order", "d_underfortress_59_1", -81.6588, 236.9152, -53.02641, 90, "ROKAS_MEMO01_NPC", "", "", 0);
		
		// Lantern
		//-------------------------------------------------------------------------
		AddNpc(31, 47253, "Lantern", "d_underfortress_59_1", -507.6955, 236.9152, -1407.308, 0, "FD_UNDERF591_TYPED_LAMP_01", "", "");
		
		// Lantern
		//-------------------------------------------------------------------------
		AddNpc(32, 47253, "Lantern", "d_underfortress_59_1", -1061.69, 236.9152, -1422.807, 0, "FD_UNDERF591_TYPED_LAMP_01", "", "");
		
		// Lantern
		//-------------------------------------------------------------------------
		AddNpc(33, 47253, "Lantern", "d_underfortress_59_1", -1057.27, 236.9152, -817.8938, 0, "FD_UNDERF591_TYPED_LAMP_01", "", "");
		
		// Lantern
		//-------------------------------------------------------------------------
		AddNpc(34, 47253, "Lantern", "d_underfortress_59_1", -478.0948, 236.9152, -813.058, 0, "FD_UNDERF591_TYPED_LAMP_01", "", "");
		AddNpc(11, 154004, " ", "d_underfortress_59_1", -392.0393, 236.9152, 864.4229, 90, "", "", "");
		AddNpc(11, 154004, " ", "d_underfortress_59_1", -456.2365, 236.9152, 924.8855, 90, "", "", "");
		AddNpc(11, 154004, " ", "d_underfortress_59_1", -461.373, 236.9152, 1006.438, 90, "", "", "");
		AddNpc(11, 154004, " ", "d_underfortress_59_1", -392.2364, 236.9152, 1050.904, 90, "", "", "");
		AddNpc(11, 154004, " ", "d_underfortress_59_1", -326.7645, 236.9152, 1098.184, 90, "", "", "");
		AddNpc(35, 147362, "Gate Entrance x", "d_underfortress_59_1", -77.6767, 311.2216, -464.3758, 90, "", "", "");
		AddNpc(35, 147362, "Gate Entrance x", "d_underfortress_59_1", 623.4534, 182.2066, 410.3501, 90, "", "", "");
		AddNpc(37, 154005, "BossGen", "d_underfortress_59_1", -45.86461, 312.4211, 1418.455, 90, "", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(38, 147392, "Lv1 Treasure Chest", "d_underfortress_59_1", 59, 236, -1362, 90, "TREASUREBOX_LV_D_UNDERFORTRESS_59_138", "", "");
		
		// JOB_MIKO_6_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(39, 20026, "JOB_MIKO_6_1_TRIGGER", "d_underfortress_59_1", -951.0374, 236.9152, 1427.649, 90, "JOB_MIKO_6_1_UNDER_59_1", "", "", 1);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40, 40095, " ", "d_underfortress_59_1", -225.6708, 312.4211, 1663.541, 90, "", "EXPLORER_MISLE38", "");
	}
}
