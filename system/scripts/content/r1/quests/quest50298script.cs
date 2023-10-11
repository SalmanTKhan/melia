//--- Melia Script -----------------------------------------------------------
// Quality Certificate [Appraiser Advancement](1) 
//--- Description -----------------------------------------------------------
// Quest to Talk to the Appraiser Master.
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

[QuestScript(50298)]
public class Quest50298Script : QuestScript
{
	protected override void Load()
	{
		SetId(50298);
		SetName("Quality Certificate [Appraiser Advancement](1) ");
		SetDescription("Talk to the Appraiser Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("FEDIMIAN_APPRAISER_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FEDIMIAN_APPRAISER_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_APPRAISER5_1_start1", "JOB_APPRAISER5_1", "Alright, I'll help you", "Please ask someone else."))
		{
			case 1:
				await dialog.Msg("JOB_APPRAISER5_1_agree1");
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

		await dialog.Msg("JOB_APPRAISER5_1_succ1");
		await dialog.Msg("NPCAin/FEDIMIAN_APPRAISER_NPC/LOOK/0");
		await Task.Delay(1200);
		await dialog.Msg("NPCAin/FEDIMIAN_APPRAISER_NPC/STD/0");
		await dialog.Msg("JOB_APPRAISER5_1_succ2");
		await dialog.Msg("BalloonText/JOB_APPRAISER5_1_INFOR1/3");
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

