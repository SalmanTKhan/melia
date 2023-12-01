//--- Melia Script ----------------------------------------------------------
// Hidden Dimension
//--- Description -----------------------------------------------------------
// NPCs found in and around Hidden Dimension.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class ShadowRaidMiniDungeonNpcScript : GeneralScript
{
	public override void Load()
	{
		// 
		//-------------------------------------------------------------------------
		AddNpc(2, 151041, "", "shadow_raid_mini_dungeon", -138, 2, 189, 45, "CASTLE102_AUSTEJA_02", "", "", 0);
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(3, 154086, "", "shadow_raid_mini_dungeon", -99, 2, 189, 0, "CASTLE102_MQ_06_VIVORA", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1, 154066, " ", "shadow_raid_mini_dungeon", -218, 2, 188, 90, "ANOTHER_SPACE_PORTAL", "", "", 0);
	}
}
