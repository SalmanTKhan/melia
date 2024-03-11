//--- Melia Script -----------------------------------------------------------
// Nibble Nibble
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Tomas.
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

[QuestScript(8520)]
public class Quest8520Script : QuestScript
{
	protected override void Load()
	{
		SetId(8520);
		SetName("Nibble Nibble");
		SetDescription("Talk to Follower Tomas");

		AddPrerequisite(new LevelPrerequisite(40));

		AddObjective("kill0", "Kill 8 Yognome(s)", new KillObjective(8, MonsterId.Yognome));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Drug_SP1_Q", 30));
		AddReward(new ItemReward("Vis", 600));

		AddDialogHook("CHAPEL_TOMAS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL_TOMAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE575_MQ_02_01", "CHAPLE575_MQ_02", "I'll take care of it quickly", "I'll go when it is safer"))
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

		await dialog.Msg("CHAPLE575_MQ_02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

