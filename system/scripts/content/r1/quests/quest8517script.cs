//--- Melia Script -----------------------------------------------------------
// Get a Hold of Yourself! (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Donatas.
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

[QuestScript(8517)]
public class Quest8517Script : QuestScript
{
	protected override void Load()
	{
		SetId(8517);
		SetName("Get a Hold of Yourself! (2)");
		SetDescription("Talk to Follower Donatas");

		AddPrerequisite(new LevelPrerequisite(44));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE576_MQ_07"));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 660));

		AddDialogHook("CHAPEL576_DONATAS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL576_DONATAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE576_MQ_08_01", "CHAPLE576_MQ_08", "It could be difficult but I'll try", "I need to find out more about the demons"))
		{
			case 1:
				await dialog.Msg("CHAPLE576_MQ_08_02");
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

		await dialog.Msg("CHAPLE576_MQ_08_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

