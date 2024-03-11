//--- Melia Script ----------------------------------------------------------
// Secret Laboratory
//--- Description -----------------------------------------------------------
// NPCs found in and around Secret Laboratory.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep152DNicopolis1NpcScript : GeneralScript
{
	public override void Load()
	{
		// Starry Town
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Starry Town", "ep15_2_d_nicopolis_1", -369.8695, 74.53714, -1179.084, -89, "", "EP15_2_D_NICOPOLIS_1_NICO811", "");
		
		// Demonic Dwellings
		//-------------------------------------------------------------------------
		AddNpc(2, 160065, "Demonic Dwellings", "ep15_2_d_nicopolis_1", -1107.738, 119.6233, 779.0779, 90, "EP15_2_DNICOPOLIS_PORTAL", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(3, 154065, "", "ep15_2_d_nicopolis_1", -281.9803, 74.53714, -1186.032, 90, "", "EP15_2_D_NICOPOLIS_1_MQ_2_TRIGGER", "");
		
		// Goddess Ausrine
		//-------------------------------------------------------------------------
		AddNpc(4, 150237, "Goddess Ausrine", "ep15_2_d_nicopolis_1", -275.0428, 74.53714, -1098.504, 90, "EP15_2_D_NICO_AUSIRINE_1", "", "", 1);
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(5, 40120, "Statue of Goddess Vakarine", "ep15_2_d_nicopolis_1", 462.7657, -16.0284, -1101.348, 90, "WARP_EP15_2_D_NICOPOLIS_1", "STOUP_CAMP", "STOUP_CAMP");
		
		// Goddess Ausrine
		//-------------------------------------------------------------------------
		AddNpc(6, 150237, "Goddess Ausrine", "ep15_2_d_nicopolis_1", 527.9447, -16.0284, -1182.5, 90, "EP15_2_D_NICO_AUSIRINE_2", "", "", 1);
		
		// Beholder's Black Crystal
		//-------------------------------------------------------------------------
		AddNpc(8, 150245, "Beholder's Black Crystal", "ep15_2_d_nicopolis_1", 757.8013, -16.0284, -1333.505, 90, "EP15_2_D_NICOPOLIS_1_MQ_4_CRYSTAL", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(10, 154065, "", "ep15_2_d_nicopolis_1", -36.25761, 74.53714, 537.0837, 90, "", "EP15_2_D_NICOPOLIS_1_MQ_5_HIDDEN", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(11, 154065, "", "ep15_2_d_nicopolis_1", 791.8691, 74.53714, 749.1041, 90, "", "EP15_2_D_NICOPOLIS_1_MQ_6_HIDDEN", "");
		
		// Goddess Ausrine
		//-------------------------------------------------------------------------
		AddNpc(12, 150237, "Goddess Ausrine", "ep15_2_d_nicopolis_1", 1034.273, 74.53714, 832.0216, -18, "EP15_2_D_NICO_AUSIRINE_3", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(13, 150245, "", "ep15_2_d_nicopolis_1", 1084.74, 74.53714, 738.8344, 90, "EP15_2_D_NICOPOLIS_1_MQ_6_CRYSTAL", "", "", 1);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(16, 154065, "", "ep15_2_d_nicopolis_1", -622.4207, 74.53714, 780.2271, 90, "", "EP15_2_D_NICOPOLIS_1_MQ_8_HIDDEN", "");
		
		// Ausrine's Gourd Bottle 
		//-------------------------------------------------------------------------
		AddNpc(17, 160151, "Ausrine's Gourd Bottle ", "ep15_2_d_nicopolis_1", 688.815, -16.0284, -1078.522, -34, "GODDESS_EP15_2_RAID_PORTAL2", "", "", 1);
	}
}
