//--- Melia Script ----------------------------------------------------------
// Highlander Master's Training Hall
//--- Description -----------------------------------------------------------
// NPCs found in and around Highlander Master's Training Hall.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CHighlanderNpcScript : GeneralScript
{
	public override void Load()
	{
		// [Highlander Master]{nl}Douglas Black
		//-------------------------------------------------------------------------
		AddNpc(1, 20029, "[Highlander Master]{nl}Douglas Black", "c_highlander", 6, 0, 59, 90, "MASTER_HIGHLANDER", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(22, 20041, "", "c_highlander", 98, 0, 116, 90, "", "JOB_KLAIPE_TRIGGER", "");
		
		// Highlander Hidden Quest
		//-------------------------------------------------------------------------
		AddNpc(23, 20026, "Highlander Hidden Quest", "c_highlander", 83.49036, 0.7928, 69.78707, 90, "", "WOOD_CARVING_SESSION_CREATE", "WOOD_CARVING_SESSION_DESTROY");
	}
}
