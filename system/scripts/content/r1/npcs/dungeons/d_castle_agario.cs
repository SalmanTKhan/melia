//--- Melia Script ----------------------------------------------------------
// Halloween Dungeon - Creepy Klaipeda
//--- Description -----------------------------------------------------------
// NPCs found in and around Halloween Dungeon - Creepy Klaipeda.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCastleAgarioNpcScript : GeneralScript
{
	public override void Load()
	{
		AddNpc(1, 20026, " ", "d_castle_agario", 203, 187, -381, 90, "", "", "");
		
		// Scaredy Scarecrow
		//-------------------------------------------------------------------------
		AddNpc(2, 157054, "Scaredy Scarecrow", "d_castle_agario", 337, 187, -438, 47, "AGARIO_DUNGEON_NPC", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(3, 46216, " ", "d_castle_agario", 1546, 85, -404, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(4, 46216, " ", "d_castle_agario", 916, 92, -1075, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(5, 46216, " ", "d_castle_agario", -24, 105, -1210, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(6, 46216, " ", "d_castle_agario", 746, 79, 472, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG", "");
	}
}
