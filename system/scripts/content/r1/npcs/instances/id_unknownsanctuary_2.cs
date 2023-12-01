//--- Melia Script ----------------------------------------------------------
// Unknown Sanctuary 2F
//--- Description -----------------------------------------------------------
// NPCs found in and around Unknown Sanctuary 2F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class IdUnknownsanctuary2NpcScript : GeneralScript
{
	public override void Load()
	{
		// Unknown Sanctuary Gate
		//-------------------------------------------------------------------------
		AddNpc(12, 155174, "Unknown Sanctuary Gate", "id_Unknownsanctuary_2", 1733.314, 39.25313, -187.8173, 73, "UNKNOWN_SANTUARY_GATE_DUNGEON", "", "");
	}
}
