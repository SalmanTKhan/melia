//--- Melia Script -----------------------------------------------------------
// Remembering the Victims (2)
//--- Description -----------------------------------------------------------
// Quest to Carve a Message to Honor the Victims.
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

[QuestScript(50277)]
public class Quest50277Script : QuestScript
{
	protected override void Load()
	{
		SetId(50277);
		SetName("Remembering the Victims (2)");
		SetDescription("Carve a Message to Honor the Victims");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("ABBEY64_2_HQ1"));

		AddDialogHook("ABBEY64_2_HIDDENQ2_OBJ1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_TOWN_PEAPLE2", "BeforeEnd", BeforeEnd);
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

		//SCR_ABBEY64_2_HQ2_ACHIEVE_REWARD
		await dialog.Msg("ABBEY64_2_HQ2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

