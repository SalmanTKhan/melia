//--- Melia Script -----------------------------------------------------------
// Till the Last Drop 
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Vaidas.
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

[QuestScript(8525)]
public class Quest8525Script : QuestScript
{
	protected override void Load()
	{
		SetId(8525);
		SetName("Till the Last Drop ");
		SetDescription("Talk to Follower Vaidas");

		AddPrerequisite(new LevelPrerequisite(40));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE575_MQ_06"));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 600));

		AddDialogHook("CHAPEL_VIDAS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL_VIDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE575_MQ_07_01", "CHAPLE575_MQ_07", "I can help you", "Hold on a little longer"))
		{
			case 1:
				await dialog.Msg("CHAPLE575_MQ_07_AG");
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

		await dialog.Msg("CHAPLE575_MQ_07_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

