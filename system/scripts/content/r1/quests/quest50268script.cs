//--- Melia Script -----------------------------------------------------------
// Best of the Best
//--- Description -----------------------------------------------------------
// Quest to Talk to Revelator Mihail.
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

[QuestScript(50268)]
public class Quest50268Script : QuestScript
{
	protected override void Load()
	{
		SetId(50268);
		SetName("Best of the Best");
		SetDescription("Talk to Revelator Mihail");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ09"));

		AddReward(new ItemReward("Collection_Base_CASTLE65_3_HQ1", 1));

		AddDialogHook("CASTLE653_MQ_04_2", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_04_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE65_3_HQ1_start1", "CASTLE65_3_HQ1", "How are you doing?", "Just go"))
		{
			case 1:
				await dialog.Msg("CASTLE65_3_HQ1_agree1");
				await dialog.Msg("BalloonText/CASTLE65_3_HIDDENQ1_MSG1/5");
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

