//--- Melia Script ----------------------------------------------------------
// Bokor Master's Home
//--- Description -----------------------------------------------------------
// NPCs found in and around Bokor Master's Home.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CVoodooNpcScript : GeneralScript
{
	public override void Load()
	{
		// [Bokor Master]{nl}Mama Marie Lavoie
		//-------------------------------------------------------------------------
		AddNpc(1, 20136, "[Bokor Master]{nl}Mama Marie Lavoie", "c_voodoo", -22, 0, 32, 360, "MASTER_BOCORS", "", "");
	}
}
