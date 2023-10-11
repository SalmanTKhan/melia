//--- Melia Script -----------------------------------------------------------
// Visit Beauty Shop
//--- Description -----------------------------------------------------------
// Quest to Visit Beauty Shop in Klaipeda.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(1166)]
public class Quest1166Script : QuestScript
{
	protected override void Load()
	{
		SetId(1166);
		SetName("Visit Beauty Shop");
		SetDescription("Visit Beauty Shop in Klaipeda");

		AddPrerequisite(new LevelPrerequisite(15));

		AddDialogHook("BEAUTY_IN_MOVE", "BeforeStart", BeforeStart);
		AddDialogHook("BEAUTY_IN_MOVE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

