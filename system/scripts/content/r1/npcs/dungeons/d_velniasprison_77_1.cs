//--- Melia Script ----------------------------------------------------------
// Tatenye Prison
//--- Description -----------------------------------------------------------
// NPCs found in and around Tatenye Prison.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DVelniasprison771NpcScript : GeneralScript
{
	public override void Load()
	{
		// Ruklys Street
		//-------------------------------------------------------------------------
		AddNpc(1, 147507, "Ruklys Street", "d_velniasprison_77_1", -802, 38, -1042, 90, "VELNIASPRISON_77_1_TO_FLASH_61", "", "");
	}
}
