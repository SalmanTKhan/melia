//--- Melia Script ----------------------------------------------------------
// Balaam Camp Site
//--- Description -----------------------------------------------------------
// NPCs found in and around Balaam Camp Site.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCatacomb802NpcScript : GeneralScript
{
	public override void Load()
	{
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(1, 153137, "Magic Stone Enhancer", "d_catacomb_80_2", 979.8, 10.59, -772.57, 90, "CATACOMB_80_1_CRYSTAL", "", "");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(1, 153137, "Magic Stone Enhancer", "d_catacomb_80_2", -633, 9.11, -786.33, 90, "CATACOMB_80_1_CRYSTAL", "", "");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(1, 153137, "Magic Stone Enhancer", "d_catacomb_80_2", -1502.7, 87.8, 1141.8, 90, "CATACOMB_80_1_CRYSTAL", "", "");
		
		// Magic Stone Enhancer
		//-------------------------------------------------------------------------
		AddNpc(1, 153137, "Magic Stone Enhancer", "d_catacomb_80_2", 1757.39, 85.03, 1132.05, 90, "CATACOMB_80_1_CRYSTAL", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(2, 154000, " ", "d_catacomb_80_2", 1748.07, 80.37, -918.5, 90, "", "CATACOMB_80_2_HEAL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(2, 154000, " ", "d_catacomb_80_2", 931.64, 4.67, 1021.31, 90, "", "CATACOMB_80_2_HEAL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(2, 154000, " ", "d_catacomb_80_2", -799.79, 8.21, 1011.68, 90, "", "CATACOMB_80_2_HEAL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(2, 154000, " ", "d_catacomb_80_2", -1668.39, 87.8, -918.99, 90, "", "CATACOMB_80_2_HEAL", "");
		AddNpc(3, 154005, " ", "d_catacomb_80_2", -1615.82, 81.32, 168.2, 90, "", "", "");
		AddNpc(3, 154005, " ", "d_catacomb_80_2", -26.42, 2.72, 1865.57, 90, "", "", "");
		AddNpc(3, 154005, " ", "d_catacomb_80_2", 1607.97, 80.29, 152.3, 90, "", "", "");
		AddNpc(3, 154005, " ", "d_catacomb_80_2", 932.02, 4.67, 1016.16, 90, "", "", "");
		
		// Rancid Labyrinth
		//-------------------------------------------------------------------------
		AddNpc(5, 147507, "Rancid Labyrinth", "d_catacomb_80_2", 35.08328, 68.15, -2316.688, -5, "CATACOMB_80_2_TO_CATACOMB_80_1", "", "");
		AddNpc(7, 147362, " ", "d_catacomb_80_2", 27.74, 68.16, -2316.83, 90, "", "", "");
		AddNpc(7, 147362, " ", "d_catacomb_80_2", 27.74, 68.16, -2316.83, 90, "", "", "");
		
		// Michmas Temple
		//-------------------------------------------------------------------------
		AddNpc(6, 147507, "Michmas Temple", "d_catacomb_80_2", -521.4592, -95.11, -1668.701, -87, "CATACOMB_80_2_TO_CATACOMB_80_3", "", "");
		AddNpc(7, 147362, " ", "d_catacomb_80_2", -521.16, -95.11, -1670.33, 90, "", "", "");
	}
}