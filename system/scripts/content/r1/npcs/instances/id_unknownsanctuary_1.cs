//--- Melia Script ----------------------------------------------------------
// Unknown Sanctuary 1F
//--- Description -----------------------------------------------------------
// NPCs found in and around Unknown Sanctuary 1F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class IdUnknownsanctuary1NpcScript : GeneralScript
{
	public override void Load()
	{
		// Unknown Sanctuary Gate
		//-------------------------------------------------------------------------
		AddNpc(13, 155174, "Unknown Sanctuary Gate", "id_Unknownsanctuary_1", 336.6789, 124.1318, 994.4829, 15, "UNKNOWN_SANTUARY_GATE_DUNGEON", "", "");
	}
}
