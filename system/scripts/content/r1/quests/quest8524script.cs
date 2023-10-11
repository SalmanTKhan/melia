//--- Melia Script -----------------------------------------------------------
// Light Attack (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Tiberius.
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

[QuestScript(8524)]
public class Quest8524Script : QuestScript
{
	protected override void Load()
	{
		SetId(8524);
		SetName("Light Attack (2)");
		SetDescription("Talk to Follower Tiberius");

		AddPrerequisite(new LevelPrerequisite(40));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE575_MQ_05"));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 600));

		AddDialogHook("CHAPEL_TABERIJUS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL_TABERIJUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE575_MQ_06_01", "CHAPLE575_MQ_06", "Hmm, alright", "I need more preparation"))
		{
			case 1:
				await dialog.Msg("CHAPLE575_MQ_06_01_AG");
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

		await dialog.Msg("CHAPLE575_MQ_06_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

