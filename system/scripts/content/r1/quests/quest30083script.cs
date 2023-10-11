//--- Melia Script -----------------------------------------------------------
// Unknown Force [Psychokino Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Psychokino Master.
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

[QuestScript(30083)]
public class Quest30083Script : QuestScript
{
	protected override void Load()
	{
		SetId(30083);
		SetName("Unknown Force [Psychokino Advancement]");
		SetDescription("Talk to the Psychokino Master");

		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("JOB_2_PSYCHOKINO_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PSYCHOKINO_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_PSYCHOKINO_3_1_select", "JOB_2_PSYCHOKINO_3_1", "Tell him you would challenge for it", "That's too complicated; I quit"))
		{
			case 1:
				await dialog.Msg("JOB_2_PSYCHOKINO_3_1_agree");
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

		await dialog.Msg("JOB_2_PSYCHOKINO_3_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

