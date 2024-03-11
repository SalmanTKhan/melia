//--- Melia Script ----------------------------------------------------------
// Mission Test per Hour 1
//--- Description -----------------------------------------------------------
// NPCs found in and around Mission Test per Hour 1.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class OnehourTest1NpcScript : GeneralScript
{
	public override void Load()
	{
		// 
		//-------------------------------------------------------------------------
		AddNpc(1, 151078, "", "onehour_test1", -194.8476, 0, 60.90105, 90, "BRACKEN631_RP_1_NPC", "", "");
		
		// [TP Trader]{nl}Leticia
		//-------------------------------------------------------------------------
		AddNpc(5, 20068, "[TP Trader]{nl}Leticia", "onehour_test1", -255.6, 0, -55.23, 90, "TP_NPC", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(9, 161001, "", "onehour_test1", -246.1496, 0, 117.0886, 90, "VELLCOFFER_ENTER_01", "", "");
		
		// Weapon Type Change Helper
		//-------------------------------------------------------------------------
		AddNpc(10, 154012, "Weapon Type Change Helper", "onehour_test1", -215.8064, 0, 208.5604, 90, "WEAPON_AFFILIATION_NPC", "", "");
		
		// Appraiser
		//-------------------------------------------------------------------------
		AddNpc(11, 157039, "Appraiser", "onehour_test1", -139.8292, 0, 152.1131, 90, "FEDIMIAN_APPRAISER", "TUTO_APPRAISE_NPC", "", 0);
	}
}
