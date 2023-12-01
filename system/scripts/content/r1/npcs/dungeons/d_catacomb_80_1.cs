//--- Melia Script ----------------------------------------------------------
// Rancid Labyrinth
//--- Description -----------------------------------------------------------
// NPCs found in and around Rancid Labyrinth.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCatacomb801NpcScript : GeneralScript
{
	public override void Load()
	{
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(1, 153137, "Magic Stone Enhancer", "d_catacomb_80_1", 121.66, 151.27, -1707.27, 90, "CATACOMB_80_1_CRYSTAL", "", "");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(1, 153137, "Magic Stone Enhancer", "d_catacomb_80_1", -1005.516, 195.41, -629.6679, 90, "CATACOMB_80_1_CRYSTAL", "", "");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(1, 153137, "Magic Stone Enhancer", "d_catacomb_80_1", 958.97, 195.41, -667.27, 90, "CATACOMB_80_1_CRYSTAL", "", "");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(1, 153137, "Magic Stone Enhancer", "d_catacomb_80_1", 1063.195, 127.74, 1557.351, 90, "CATACOMB_80_1_CRYSTAL", "", "");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(1, 153137, "Magic Stone Enhancer", "d_catacomb_80_1", -1133.47, 127.74, 1555.81, 90, "CATACOMB_80_1_CRYSTAL", "", "");
		AddNpc(2, 154005, " ", "d_catacomb_80_1", 1119.87, 132.48, 319.9, 90, "", "", "");
		AddNpc(2, 154005, " ", "d_catacomb_80_1", -49.95, 194.39, 2069.47, 90, "", "", "");
		AddNpc(2, 154005, " ", "d_catacomb_80_1", -1102.88, 128.5, 377.43, 90, "", "", "");
		AddNpc(3, 154005, " ", "d_catacomb_80_1", -55.24404, 126.23, -1456.568, 90, "", "", "");
		
		// Balaam Camp Site
		//-------------------------------------------------------------------------
		AddNpc(5, 147507, "Balaam Camp Site", "d_catacomb_80_1", -32.95918, 204.68, -1085.865, 176, "CATACOMB_80_1_TO_CATACOMB_80_2", "", "");
		AddNpc(6, 147362, "", "d_catacomb_80_1", -33.53, 204.37, -1086.39, 90, "", "", "");
		
		// Grynas Hills
		//-------------------------------------------------------------------------
		AddNpc(7, 147507, "Grynas Hills", "d_catacomb_80_1", -58.37, 193.36, -2527.01, 90, "CATACOMB_80_1_TO_KATYN_45_3", "", "");
		AddNpc(6, 147362, "", "d_catacomb_80_1", -61.53, 193.36, -2526.35, 90, "", "", "");
	}
}
