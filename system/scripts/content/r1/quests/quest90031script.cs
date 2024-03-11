//--- Melia Script -----------------------------------------------------------
// Favor for an Old Dievdirbys
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Asel.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(90031)]
public class Quest90031Script : QuestScript
{
	protected override void Load()
	{
		SetId(90031);
		SetName("Favor for an Old Dievdirbys");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(245));

		AddDialogHook("KATYN_45_1_AJEL1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_1_OWL1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_1_SQ_1_ST", "KATYN_45_1_SQ_1", "What can I help you with?", "Tell him that it would be hard"))
		{
			case 1:
				await dialog.Msg("KATYN_45_1_SQ_1_AG");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		// Func/SCR_KATYN_45_1_SQ1;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

