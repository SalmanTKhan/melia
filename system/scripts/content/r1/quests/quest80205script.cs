//--- Melia Script -----------------------------------------------------------
// Good Use For a Wand (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Ruodell.
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

[QuestScript(80205)]
public class Quest80205Script : QuestScript
{
	protected override void Load()
	{
		SetId(80205);
		SetName("Good Use For a Wand (5)");
		SetDescription("Talk to Priest Ruodell");

		AddPrerequisite(new LevelPrerequisite(142));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL54_SQ06"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3692));

		AddDialogHook("CHATHEDRAL54_SQ04_PART2", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL56_SQ03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_SQ07_select01", "CHATHEDRAL54_SQ07", "I'll deliver it for you", "That will be hard"))
		{
			case 1:
				await dialog.Msg("CHATHEDRAL54_SQ07_agree01");
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

		await dialog.Msg("CHATHEDRAL54_SQ07_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

