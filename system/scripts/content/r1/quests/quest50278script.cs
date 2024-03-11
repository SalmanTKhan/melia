//--- Melia Script -----------------------------------------------------------
// Unexpected News
//--- Description -----------------------------------------------------------
// Quest to Talk to Squire Williya.
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

[QuestScript(50278)]
public class Quest50278Script : QuestScript
{
	protected override void Load()
	{
		SetId(50278);
		SetName("Unexpected News");
		SetDescription("Talk to Squire Williya");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM313_SQ_07"));

		AddReward(new ItemReward("misc_scrollskulp", 1));

		AddDialogHook("PILGRIM313_WILLIYA", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SQUIRE3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM31_3_HQ1_start1", "PILGRIM31_3_HQ1", "I'll go to the Squire Master myself.", "Just go"))
		{
			case 1:
				await dialog.Msg("PILGRIM31_3_HQ1_agree1");
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

