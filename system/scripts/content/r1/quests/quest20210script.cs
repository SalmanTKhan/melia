//--- Melia Script -----------------------------------------------------------
// Astral Tracing (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Talus.
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

[QuestScript(20210)]
public class Quest20210Script : QuestScript
{
	protected override void Load()
	{
		SetId(20210);
		SetName("Astral Tracing (3)");
		SetDescription("Talk to Hunter Talus");

		AddPrerequisite(new LevelPrerequisite(99));
		AddPrerequisite(new CompletedPrerequisite("REMAIN38_MQ02"));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_HUNTER", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_HUNTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN38_MQ03_select01", "REMAIN38_MQ03", "Alright, I'll help you", "Decline"))
		{
			case 1:
				await dialog.Msg("REMAIN38_MQ03_AG");
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

		await dialog.Msg("REMAIN38_MQ03_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

