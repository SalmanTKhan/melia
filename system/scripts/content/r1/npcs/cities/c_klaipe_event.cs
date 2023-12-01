//--- Melia Script ----------------------------------------------------------
// Halloween Dungeon - Creepy Klaipeda
//--- Description -----------------------------------------------------------
// NPCs found in and around Halloween Dungeon - Creepy Klaipeda.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CKlaipeEventNpcScript : GeneralScript
{
	public override void Load()
	{
		AddNpc(1, 20026, " ", "c_Klaipe_event", -971.0716, 240.7832, 869.505, 90, "", "", "");
		
		// Scaredy Scarecrow
		//-------------------------------------------------------------------------
		AddNpc(2, 157054, "Scaredy Scarecrow", "c_Klaipe_event", -206.5314, 149.1097, 94.02247, 47, "AGARIO_DUNGEON_NPC", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(3, 46216, " ", "c_Klaipe_event", -840.4724, 241.052, 84.85162, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(4, 46216, " ", "c_Klaipe_event", -162.4379, -1.157186, -803.4096, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(5, 46216, " ", "c_Klaipe_event", 669.4443, -1.156544, 133.3863, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(6, 46216, " ", "c_Klaipe_event", -235.9899, 241.052, 819.2154, 90, "AGARIO_MINE_DMG", "AGARIO_MINE_DMG", "");
	}
}
