//--- Melia Script -----------------------------------------------------------
// Demon Sisters
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Vaidutis.
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

[QuestScript(8513)]
public class Quest8513Script : QuestScript
{
	protected override void Load()
	{
		SetId(8513);
		SetName("Demon Sisters");
		SetDescription("Talk to Follower Vaidutis");

		AddPrerequisite(new LevelPrerequisite(44));

		AddObjective("kill0", "Kill 20 Pawndel(s)", new KillObjective(20, MonsterId.Pawndel));
		AddObjective("kill1", "Kill 10 Pawnd(s)", new KillObjective(10, MonsterId.Pawnd));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 660));

		AddDialogHook("CHAPEL_VIRGINIJA", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL_VIRGINIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE576_MQ_03_01", "CHAPLE576_MQ_04", "I will defeat it", "I don't have time"))
		{
			case 1:
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

		await dialog.Msg("CHAPLE576_MQ_04_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

