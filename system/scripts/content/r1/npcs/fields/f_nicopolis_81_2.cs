//--- Melia Script ----------------------------------------------------------
// Feline Post Town
//--- Description -----------------------------------------------------------
// NPCs found in and around Feline Post Town.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FNicopolis812NpcScript : GeneralScript
{
	public override void Load()
	{
		// Starry Town
		//-------------------------------------------------------------------------
		AddNpc(9, 40001, "Starry Town", "f_nicopolis_81_2", 1650.421, -81.12152, -1984.765, -25, "", "NICO812_NICO811", "");
		
		// Spell Tome Town
		//-------------------------------------------------------------------------
		AddNpc(10, 40001, "Spell Tome Town", "f_nicopolis_81_2", -2474.083, -69.1584, -993.7436, 261, "", "NICO812_NICO813", "");
		AddNpc(11, 147362, "", "f_nicopolis_81_2", 1652.001, -81.12152, -1964.034, 90, "", "", "");
		AddNpc(11, 147362, "", "f_nicopolis_81_2", -2480.801, -69.1584, -994.9099, 261, "", "", "");
		
		// Auguste Dupin
		//-------------------------------------------------------------------------
		AddNpc(12, 153226, "Auguste Dupin", "f_nicopolis_81_2", 1283.974, 132.7135, -748.9042, -78, "NICO812_SUBQ_NPC1", "", "", 0);
		
		// Auguste Dupin
		//-------------------------------------------------------------------------
		AddNpc(13, 153226, "Auguste Dupin", "f_nicopolis_81_2", -1020, 31.07, -219, 90, "NICO812_SUBQ_NPC2", "", "", 1);
		
		// Auguste Dupin
		//-------------------------------------------------------------------------
		AddNpc(14, 153226, "Auguste Dupin", "f_nicopolis_81_2", -535.6924, 32.77958, -1700.734, 90, "NICO812_SUBQ_NPC3", "", "", 1);
		
		// Secretary
		//-------------------------------------------------------------------------
		AddNpc(15, 153217, "Secretary", "f_nicopolis_81_2", 601.1397, 132.7135, -1062.711, 90, "NICO812_SUBQ_NPC4", "", "");
		
		// Watch Guard Bace
		//-------------------------------------------------------------------------
		AddNpc(16, 153227, "Watch Guard Bace", "f_nicopolis_81_2", 1405.407, -79.58559, 2552.623, 14, "NICO812_SUBQ_NPC5", "", "");
		
		// Town Beggar
		//-------------------------------------------------------------------------
		AddNpc(17, 20117, "Town Beggar", "f_nicopolis_81_2", 319.8857, -72.27256, 1969.111, 97, "NICO812_SUBQ_NPC6", "", "");
		
		// Kelly
		//-------------------------------------------------------------------------
		AddNpc(18, 153218, "Kelly", "f_nicopolis_81_2", -641.4952, 29.59159, 348.712, 6, "NICO812_SUBQ_NPC7", "", "");
		
		// Chemist
		//-------------------------------------------------------------------------
		AddNpc(19, 153219, "Chemist", "f_nicopolis_81_2", -974.8642, 31.96643, -271.7142, 90, "NICO812_SUBQ_NPC8", "", "");
		
		// Exorcist Daivis
		//-------------------------------------------------------------------------
		AddNpc(20, 153208, "Exorcist Daivis", "f_nicopolis_81_2", -642.1682, 34.93459, -1085.546, 90, "NICO812_SUBQ_NPC9", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(21, 20024, "", "f_nicopolis_81_2", 270.4164, -69.58057, 2359.394, 90, "NICO812_SUB5_NPC", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(21, 20024, "", "f_nicopolis_81_2", 556.7601, -71.97522, 2408.764, 90, "NICO812_SUB5_NPC", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(21, 20024, "", "f_nicopolis_81_2", 460.3743, -72.16583, 1838.67, 90, "NICO812_SUB5_NPC", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(21, 20024, "", "f_nicopolis_81_2", 858.5783, -71.97522, 2131.586, 90, "NICO812_SUB5_NPC", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(22, 20025, "", "f_nicopolis_81_2", -1187.253, -69.1582, -1175.077, 90, "NICO812_SUB10_NPC1", "", "", 0);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(23, 20025, "", "f_nicopolis_81_2", -780.2454, 32.82594, -1663.655, 90, "NICO812_SUB10_NPC2", "", "", 0);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(24, 20025, "", "f_nicopolis_81_2", -570.7966, 32.94231, -1398.967, 90, "NICO812_SUB10_NPC3", "", "", 0);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(25, 20025, "", "f_nicopolis_81_2", 878.2021, -65.88526, 2229.354, 90, "", "NICO812_SUB5_NPC1_IN", "");
		AddNpc(26, 20040, "", "f_nicopolis_81_2", 581.4303, -71.97522, 2187.465, 90, "", "", "");
		
		// Artist
		//-------------------------------------------------------------------------
		AddNpc(27, 153221, "Artist", "f_nicopolis_81_2", -881.8968, 32.77958, -1380.193, 90, "NICO812_SUBQ_NPC10", "", "", 0);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(28, 20024, "", "f_nicopolis_81_2", -1187.25, -69.15, -1175.07, 90, "", "NICO812_SUB10_HIDE_NPC1", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(29, 20024, "", "f_nicopolis_81_2", -780.24, 32.82, -1663.65, 90, "", "NICO812_SUB10_HIDE_NPC2", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(30, 20024, "", "f_nicopolis_81_2", -570.79, 32.94, -1398.96, 90, "", "NICO812_SUB10_HIDE_NPC3", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(31, 20026, "", "f_nicopolis_81_2", -1013.253, 31.06528, -219.086, 90, "", "NICO812_SUBQ8_IN", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(32, 20026, "", "f_nicopolis_81_2", -604.457, 34.93459, -1044.839, 90, "", "NICO812_SUBQ12_IN", "");
		
		// Artist
		//-------------------------------------------------------------------------
		AddNpc(33, 153221, "Artist", "f_nicopolis_81_2", -488.3481, 32.77958, -1676.686, 90, "NICO812_SUB12_NPC1", "", "", 1);
		AddNpc(35, 160034, "Transportation Device", "f_nicopolis_81_2", 217.5959, 19.73396, -1542.467, 90, "", "", "");
		AddNpc(36, 160034, "Transportation Device", "f_nicopolis_81_2", -73.95179, 5.06913, -1590.266, 90, "", "", "");
	}
}