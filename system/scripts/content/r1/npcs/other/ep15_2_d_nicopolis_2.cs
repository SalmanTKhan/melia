//--- Melia Script ----------------------------------------------------------
// Demonic Dwellings
//--- Description -----------------------------------------------------------
// NPCs found in and around Demonic Dwellings.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep152DNicopolis2NpcScript : GeneralScript
{
	public override void Load()
	{
		// Secret Laboratory
		//-------------------------------------------------------------------------
		AddNpc(4, 160065, "Secret Laboratory", "ep15_2_d_nicopolis_2", 3.349541, 1, -1242.374, 90, "EP15_2_DNICOPOLIS_2_PORTAL", "", "");
		
		// Goddess Ausrine
		//-------------------------------------------------------------------------
		AddNpc(7, 150237, "Goddess Ausrine", "ep15_2_d_nicopolis_2", 84.17868, 1, -1093.702, -17, "EP15_2_D_NICO_2_AUSIRINE_1", "", "", 1);
		
		// Demonic Dwellings
		//-------------------------------------------------------------------------
		AddNpc(8, 160065, "Demonic Dwellings", "ep15_2_d_nicopolis_2", -24.67467, 1, -910.4783, 58, "EP15_2_D_NICO_2_PORTAL_1", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(9, 154065, "", "ep15_2_d_nicopolis_2", 3.776787, 1, -1180.856, -5, "", "EP15_2_D_NICOPOLIS_2_MQ_1_HIDDEN", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(10, 154065, "", "ep15_2_d_nicopolis_2", -957.8557, 1, -599.6189, 1, "", "EP15_2_D_NICOPOLIS_2_MQ_3_HIDDEN", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(11, 154065, "", "ep15_2_d_nicopolis_2", 939.0314, 1, -580.4754, -11, "", "EP15_2_D_NICOPOLIS_2_MQ_4_HIDDEN", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(12, 154065, "", "ep15_2_d_nicopolis_2", 54.81117, 0.5, 665.5202, 7, "", "EP15_2_D_NICOPOLIS_2_MQ_5_HIDDEN_2", "");
		
		// Demonic Dwellings
		//-------------------------------------------------------------------------
		AddNpc(13, 160065, "Demonic Dwellings", "ep15_2_d_nicopolis_2", 54.65359, 0.5, 619.0107, 90, "EP15_2_D_NICO_2_PORTAL_2", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(14, 154065, "", "ep15_2_d_nicopolis_2", 139.3855, 1, -978.6815, 90, "", "EP15_2_D_NICOPOLIS_2_MQ_5_HIDDEN_1", "");
		
		// Ausrine's Gourd Bottle 
		//-------------------------------------------------------------------------
		AddNpc(15, 160151, "Ausrine's Gourd Bottle ", "ep15_2_d_nicopolis_2", 4.918999, 0.5, 1130.763, -37, "GODDESS_EP15_2_RAID_PORTAL", "", "", 1);
		
		// Goddess Ausrine
		//-------------------------------------------------------------------------
		AddNpc(16, 150237, "Goddess Ausrine", "ep15_2_d_nicopolis_2", -153.602, 0.5, 980.4985, 90, "EP15_2_D_NICOPOLIS_2_MQ_6_END", "", "", 1);
	}
}
