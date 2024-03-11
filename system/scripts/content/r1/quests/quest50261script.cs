//--- Melia Script -----------------------------------------------------------
// Good News
//--- Description -----------------------------------------------------------
// Quest to Talk to Rose.
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

[QuestScript(50261)]
public class Quest50261Script : QuestScript
{
	protected override void Load()
	{
		SetId(50261);
		SetName("Good News");
		SetDescription("Talk to Rose");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_3_MQ050"));

		AddReward(new ItemReward("misc_scrollskulp", 1));

		AddDialogHook("ABBEY643_ROZE01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY643_ROZE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY64_3_HQ1_start1", "ABBAY64_3_HQ1", "I'll deliver the news.", "I have other issues to tend to."))
		{
			case 1:
				await dialog.Msg("ABBAY64_3_HQ1_agree1");
				await dialog.Msg("BalloonText/ABBAY64_3_HQ1_ROZE/5");
				await dialog.Msg("FadeOutIN/1000");
				await dialog.Msg("ABBAY64_3_HQ1_agree2");
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
}

