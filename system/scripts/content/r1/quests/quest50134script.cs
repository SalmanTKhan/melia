//--- Melia Script -----------------------------------------------------------
// Rescue Rose (1)
//--- Description -----------------------------------------------------------
// Quest to Follow Edmundas Into the Novaha Institute to rescue Rose.
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

[QuestScript(50134)]
public class Quest50134Script : QuestScript
{
	protected override void Load()
	{
		SetId(50134);
		SetName("Rescue Rose (1)");
		SetDescription("Follow Edmundas Into the Novaha Institute to rescue Rose");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_2_MQ040"));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 954));

		AddDialogHook("ABBEY643_EDMONDA01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY643_EDMONDA01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_3_MQ010_startnpc01", "ABBAY_64_3_MQ010", "What do I have to do?", "Tell him that you need some time to think"))
		{
			case 1:
				await dialog.Msg("ABBAY_64_3_MQ010_AG");
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBAY_64_3_MQ020");
	}
}

