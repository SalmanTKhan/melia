//--- Melia Script ----------------------------------------------------------
// PvP Mine Lawless Zone
//--- Description -----------------------------------------------------------
// NPCs found in and around PvP Mine Lawless Zone.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class PvpMine2NpcScript : GeneralScript
{
	public override void Load()
	{
		AddNpc(1, 20026, " ", "pvp_Mine_2", -42, 0, 42, 90, "", "", "");
		AddNpc(2, 20026, " ", "pvp_Mine_2", -1444, 149, -1569, 90, "", "", "");
		AddNpc(3, 20026, " ", "pvp_Mine_2", 1634, 149, 1580, 90, "", "", "");
	}
}
