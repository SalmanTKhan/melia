//--- Melia Script ----------------------------------------------------------
// Unknown Sanctuary 3F
//--- Description -----------------------------------------------------------
// NPCs found in and around Unknown Sanctuary 3F.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class IdUnknownsanctuary3NpcScript : GeneralScript
{
	public override void Load()
	{
		// Unknown Sanctuary
		//-------------------------------------------------------------------------
		AddNpc(6, 155174, "Unknown Sanctuary", "id_Unknownsanctuary_3", -1219.34, 70.81, -631.15, 90, "UNKNOWN_SANTUARY_GATE_DUNGEON", "", "");
	}
}
