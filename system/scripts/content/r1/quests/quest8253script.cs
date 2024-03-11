//--- Melia Script -----------------------------------------------------------
// Leadership of Philipas
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Officer Philipas.
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

[QuestScript(8253)]
public class Quest8253Script : QuestScript
{
	protected override void Load()
	{
		SetId(8253);
		SetName("Leadership of Philipas");
		SetDescription("Talk to Senior Officer Philipas");

		AddPrerequisite(new LevelPrerequisite(114));
		AddPrerequisite(new CompletedPrerequisite("KATYN14_MQ_08"));

		AddObjective("kill0", "Kill 2 Big Blue Griba(s)", new KillObjective(2, MonsterId.Mushroom_Ent_Blue));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 2736));

		AddDialogHook("KATYN14_VACENIN", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_VACENIN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN14_MQ_12_01", "KATYN14_MQ_12", "I will cooperate", "That is unfair"))
		{
			case 1:
				await dialog.Msg("KATYN14_MQ_12_01_a");
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

		await dialog.Msg("KATYN14_MQ_12_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

