//--- Melia Script -----------------------------------------------------------
// Magic Control (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Ramin.
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

[QuestScript(91146)]
public class Quest91146Script : QuestScript
{
	protected override void Load()
	{
		SetId(91146);
		SetName("Magic Control (1)");
		SetDescription("Talk to Ramin");

		AddPrerequisite(new LevelPrerequisite(475));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE2_MQ_2"));

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

		switch (await dialog.Select("EP14_2_DCASTLE2_MQ_3_DLG1", "EP14_2_DCASTLE2_MQ_3", "Alright", "I'll work on other things first."))
		{
			case 1:
				await dialog.Msg("EP14_2_DCASTLE2_MQ_3_DLG2");
				await dialog.Msg("FadeOutIN/2500");
				dialog.HideNPC("EP14_2_2_PAJAUTA1");
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

		await dialog.Msg("EP14_2_DCASTLE2_MQ_3_DLG4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE2_MQ_4");
	}
}

