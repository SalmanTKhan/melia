//--- Melia Script ----------------------------------------------------------
// Sentry Bailey
//--- Description -----------------------------------------------------------
// NPCs found in and around Sentry Bailey.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DUnderfortress65NpcScript : GeneralScript
{
	public override void Load()
	{
		// Inner Enceinte District
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Inner Enceinte District", "d_underfortress_65", 585.64, 602.314, -2290.492, -22, "", "UNDERFORTRESS65_FLASH64", "");
		
		// Drill Ground of Confliction
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Drill Ground of Confliction", "d_underfortress_65", -437.928, 337.3494, 1978.133, 215, "", "UNDERFORTRESS65_UNDERFORTRESS66", "");
		
		// [Amanda Grave Robbers]{nl}Amanda
		//-------------------------------------------------------------------------
		AddNpc(3, 153040, "[Amanda Grave Robbers]{nl}Amanda", "d_underfortress_65", 695.9851, 599.8887, -1597.089, 197, "AMANDA_65_1", "", "", 1);
		
		// [Amanda Grave Robbers]{nl}Amanda
		//-------------------------------------------------------------------------
		AddNpc(4, 153040, "[Amanda Grave Robbers]{nl}Amanda", "d_underfortress_65", -537.0524, 174.7112, -693.9525, 30, "AMANDA_65_2", "", "", 1);
		
		// [Amanda Grave Robbers]{nl}Amanda
		//-------------------------------------------------------------------------
		AddNpc(5, 153040, "[Amanda Grave Robbers]{nl}Amanda", "d_underfortress_65", 582.7185, 238.7984, 170.6073, -32, "AMANDA_65_3", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(7, 20026, "", "d_underfortress_65", -1581.72, 128.5476, 866.6563, 90, "", "UNDER65_SQ01_SESSION_CREATE", "UNDER65_SQ01_SESSION_DESTROY");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(8, 40095, " ", "d_underfortress_65", -664.259, 252.2664, 94.06122, 90, "SETUP_BOOM01", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(9, 40095, " ", "d_underfortress_65", 1164.697, 99.2021, -702.0095, 90, "SETUP_BOOM02", "", "", 0);
		
		// Thunderous Herb
		//-------------------------------------------------------------------------
		AddNpc(16, 47201, "Thunderous Herb", "d_underfortress_65", 392.1516, 99.20201, -1166.115, 90, "GLASS_MATERIAL", "", "");
		
		// Thunderous Herb
		//-------------------------------------------------------------------------
		AddNpc(16, 47201, "Thunderous Herb", "d_underfortress_65", 209.3366, 99.202, -1027.207, 78, "GLASS_MATERIAL", "", "");
		
		// Thunderous Herb
		//-------------------------------------------------------------------------
		AddNpc(16, 47201, "Thunderous Herb", "d_underfortress_65", -168.5831, 99.202, -1220.917, 90, "GLASS_MATERIAL", "", "");
		
		// Thunderous Herb
		//-------------------------------------------------------------------------
		AddNpc(16, 47201, "Thunderous Herb", "d_underfortress_65", -182.0019, 98.82617, -742.488, 90, "GLASS_MATERIAL", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(22, 20026, "", "d_underfortress_65", -1502.282, 248.7981, 271.3642, 90, "UNDER65_SQ02_BOMB_RANGE01", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(23, 20026, "", "d_underfortress_65", -1723.752, 248.7981, 333.0049, 90, "UNDER65_SQ02_BOMB_RANGE02", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(24, 20026, "", "d_underfortress_65", -1657.622, 248.7981, 121.0251, 90, "UNDER65_SQ02_BOMB_RANGE03", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(25, 20026, "", "d_underfortress_65", -1333.613, 244.001, 123.5278, 90, "UNDER65_SQ02_BOMB_RANGE04", "", "", 1);
		
		// [Amanda Grave Robbers]{nl}Amanda
		//-------------------------------------------------------------------------
		AddNpc(27, 153040, "[Amanda Grave Robbers]{nl}Amanda", "d_underfortress_65", -350.48, 303.23, 760, 90, "AMANDA_65_4", "", "", 1);
		
		// Drill Ground of Confliction
		//-------------------------------------------------------------------------
		AddNpc(28, 147469, "Drill Ground of Confliction", "d_underfortress_65", -412.5195, 303.2323, 616.1574, 90, "UNDER65_TO_UNDER66_WARP", "", "");
		
		// Unknown Box
		//-------------------------------------------------------------------------
		AddNpc(29, 147394, "Unknown Box", "d_underfortress_65", -336.02, 303.23, 796.36, -27, "", "UNDER66_MQ7_TRIGGER", "");
		AddNpc(30, 20026, " ", "d_underfortress_65", 683.9134, 599.8887, -1576.433, 90, "", "", "");
		
		// Thunderous Herb
		//-------------------------------------------------------------------------
		AddNpc(16, 47201, "Thunderous Herb", "d_underfortress_65", 139.5764, 99.20198, -1239.388, 90, "GLASS_MATERIAL", "", "");
		
		// Thunderous Herb
		//-------------------------------------------------------------------------
		AddNpc(16, 47201, "Thunderous Herb", "d_underfortress_65", 11.47386, 99.20197, -982.937, 90, "GLASS_MATERIAL", "", "");
		
		// Resounding Bomb
		//-------------------------------------------------------------------------
		AddNpc(31, 147459, "Resounding Bomb", "d_underfortress_65", -660.9693, 252.2664, 94.89284, 90, "", "UNDER_65_SOUND_BOMB01", "");
		
		// Resounding Bomb
		//-------------------------------------------------------------------------
		AddNpc(32, 147459, "Resounding Bomb", "d_underfortress_65", 1166.35, 99.20209, -703.4342, 90, "", "UNDER_65_SOUND_BOMB02", "");
		AddNpc(34, 147362, "", "d_underfortress_65", -535.9322, 174.7112, -694.0863, 90, "", "", "");
		AddNpc(34, 147362, "", "d_underfortress_65", 583.0949, 238.7984, 169.8066, 90, "", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(35, 40120, "Statue of Goddess Vakarine", "d_underfortress_65", 537.7255, 602.314, -1996.485, 45, "WARP_D_UNDERFORTRESS_65", "STOUP_CAMP", "STOUP_CAMP");
		AddNpc(36, 147364, "FieldCantGen", "d_underfortress_65", 661.5071, 602.314, -2037.621, 90, "", "", "");
		
		// Sventimas Exile
		//-------------------------------------------------------------------------
		AddNpc(38, 40001, "Sventimas Exile", "d_underfortress_65", -1661.972, 113.4736, 1215.049, 168, "", "UNDERFORTRESS65_TABLELAND72", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(39, 20024, "", "d_underfortress_65", -133.23, 99.2, -985.52, 90, "", "UNDER67_HIDDENQ1_AREA1", "");
		
		// Thunderous Herb
		//-------------------------------------------------------------------------
		AddNpc(16, 47201, "Thunderous Herb", "d_underfortress_65", -195.4525, 99.20196, -1124.701, 90, "GLASS_MATERIAL", "", "");
		
		// Thunderous Herb
		//-------------------------------------------------------------------------
		AddNpc(16, 47201, "Thunderous Herb", "d_underfortress_65", 51.14796, 99.20198, -1165.748, 90, "GLASS_MATERIAL", "", "");
		
		// Thunderous Herb
		//-------------------------------------------------------------------------
		AddNpc(16, 47201, "Thunderous Herb", "d_underfortress_65", 280.6423, 99.202, -1264.399, 90, "GLASS_MATERIAL", "", "");
		
		// Thunderous Herb
		//-------------------------------------------------------------------------
		AddNpc(16, 47201, "Thunderous Herb", "d_underfortress_65", 304.6177, 99.20201, -1005.833, 90, "GLASS_MATERIAL", "", "");
	}
}
