//--- Melia Script ----------------------------------------------------------
// Irredian Shelter
//--- Description -----------------------------------------------------------
// NPCs found in and around Irredian Shelter.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DIrredians1131NpcScript : GeneralScript
{
	public override void Load()
	{
		// Spell Tome Town
		//-------------------------------------------------------------------------
		AddNpc(1, 147507, "Spell Tome Town", "d_irredians_113_1", -569.6205, 150.3034, -1383.483, 90, "IRREDIANS1131_TO_NICO813", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(6, 40120, "Statue of Goddess Vakarine", "d_irredians_113_1", -517.5229, 92.14448, -981.6158, 54, "WARP_D_IRREDIANS113_1", "STOUP_CAMP", "STOUP_CAMP");
		
		// Portal to Checkpoint
		//-------------------------------------------------------------------------
		AddNpc(8, 154069, "Portal to Checkpoint", "d_irredians_113_1", -4.8335, -79.9115, 261.7278, 90, "IRREDIANS1131_ENTRANCE", "", "");
		
		// Exit
		//-------------------------------------------------------------------------
		AddNpc(9, 154069, "Exit", "d_irredians_113_1", 1057.289, 46.90249, -373.9422, 90, "IRREDIANS1131_ESCAPE_EAST", "", "");
		
		// Exit
		//-------------------------------------------------------------------------
		AddNpc(10, 154069, "Exit", "d_irredians_113_1", -1102.984, 49.4668, -664.1795, 90, "IRREDIANS1131_ESCAPE_WEST", "", "");
		AddNpc(11, 154005, "WestSide", "d_irredians_113_1", -1019.19, 9.00365, -38.04139, 90, "", "", "");
		AddNpc(12, 154005, "EastSide", "d_irredians_113_1", 1016.872, 4.973202, 106.3059, 90, "", "", "");
		AddNpc(13, 154005, "Center", "d_irredians_113_1", 16.7612, 4.168772, -581.1641, 90, "", "", "");
		
		// Abandoned Book
		//-------------------------------------------------------------------------
		AddNpc(14, 147311, "Abandoned Book", "d_irredians_113_1", -441.1452, 96.47264, -919.5415, 90, "IRREDIANS1131_BOOK_1_NPC", "", "");
		
		// Blackened Diary
		//-------------------------------------------------------------------------
		AddNpc(15, 153014, "Blackened Diary", "d_irredians_113_1", -274.447, -79.9115, 577.2573, 90, "IRREDIANS1131_BOOK_2_NPC", "", "");
		
		// Wrinkled Paper
		//-------------------------------------------------------------------------
		AddNpc(16, 151121, "Wrinkled Paper", "d_irredians_113_1", -1044.864, 50.25259, 862.3054, 260, "IRREDIANS1131_BOOK_3_NPC", "", "");
		
		// Scribbled Paper
		//-------------------------------------------------------------------------
		AddNpc(17, 151121, "Scribbled Paper", "d_irredians_113_1", 1346.778, 67.82127, 461.4918, 90, "IRREDIANS1131_SCROLL_1_NPC", "", "");
		
		// Scribbled Paper
		//-------------------------------------------------------------------------
		AddNpc(18, 151121, "Scribbled Paper", "d_irredians_113_1", -654.9801, -28.76204, 1045.385, 90, "IRREDIANS1131_SCROLL_2_NPC", "", "");
		
		// Scribbled Paper
		//-------------------------------------------------------------------------
		AddNpc(19, 151121, "Scribbled Paper", "d_irredians_113_1", -1170.398, 47.4057, -811.7021, 90, "IRREDIANS1131_SCROLL_3_NPC", "", "");
		
		// Scribbled Paper
		//-------------------------------------------------------------------------
		AddNpc(20, 151121, "Scribbled Paper", "d_irredians_113_1", 1352.553, 46.90249, -363.1545, 90, "IRREDIANS1131_SCROLL_4_NPC", "", "");
		
		// [Portal] Madon Maid
		//-------------------------------------------------------------------------
		AddNpc(21, 154069, "[Portal] Madon Maid", "d_irredians_113_1", -55.85426, 19.70161, -401.3149, 90, "IRREDIAN1131_CLP_NPC", "", "");
		
		// [Portal] Amiss Dog
		//-------------------------------------------------------------------------
		AddNpc(22, 154069, "[Portal] Amiss Dog", "d_irredians_113_1", 78.44424, 19.70005, -402.6823, 90, "IRREDIAN1131_CRP_NPC", "", "");
		
		// Tel Harsha
		//-------------------------------------------------------------------------
		AddNpc(27, 160030, "Tel Harsha", "d_irredians_113_1", 23.01482, 4.16877, -478.0077, 360, "FREEDUNGEON_TELHARSHA_ENTER", "", "");
		AddNpc(28, 147366, "CantGen", "d_irredians_113_1", -67.7836, 4.168772, -591.8438, 90, "", "", "");
		AddNpc(28, 147366, "CantGen", "d_irredians_113_1", 115.2909, 4.168774, -611.1503, 90, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(29, 40095, " ", "d_irredians_113_1", 827.8661, 46.90249, -343.0114, 90, "", "EXPLORER_MISLE16", "");
	}
}
