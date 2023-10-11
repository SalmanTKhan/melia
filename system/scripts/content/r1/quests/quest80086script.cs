//--- Melia Script -----------------------------------------------------------
// Removing Tree Vines (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elgos Monk.
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

[QuestScript(80086)]
public class Quest80086Script : QuestScript
{
	protected override void Load()
	{
		SetId(80086);
		SetName("Removing Tree Vines (1)");
		SetDescription("Talk to Elgos Monk");

		AddPrerequisite(new LevelPrerequisite(229));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_10"), new CompletedPrerequisite("ABBEY_35_4_SQ_8"));

		AddDialogHook("ABBEY_35_3_MONK", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_3_SQ_9_start", "ABBEY_35_3_SQ_9", "I will tell you about Lucienne Winterspoon", "I'm not sure"))
		{
			case 1:
				await dialog.Msg("ABBEY_35_3_SQ_9_agree");
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

		await dialog.Msg("ABBEY_35_3_SQ_9_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

