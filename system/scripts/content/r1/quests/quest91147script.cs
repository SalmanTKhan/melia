//--- Melia Script -----------------------------------------------------------
// Magic Control (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the General Ramin.
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

[QuestScript(91147)]
public class Quest91147Script : QuestScript
{
	protected override void Load()
	{
		SetId(91147);
		SetName("Magic Control (2)");
		SetDescription("Talk to the General Ramin");

		AddPrerequisite(new LevelPrerequisite(475));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE2_MQ_3"));

		AddObjective("kill0", "Kill 10 Blickferret Lancer(s) or Eerie Blickferret(s) or Grasme Bird(s) or Grasme Crow(s)", new KillObjective(10, 59749, 59751, 59744, 59745));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_2_LAMIN1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_2_LAMIN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_2_DCASTLE2_MQ_4_DLG1", "EP14_2_DCASTLE2_MQ_4", "Alright", "That's not something I want to do."))
		{
			case 1:
				await dialog.Msg("EP14_2_DCASTLE2_MQ_4_DLG2");
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

		await dialog.Msg("EP14_2_DCASTLE2_MQ_4_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE2_MQ_5");
	}
}

