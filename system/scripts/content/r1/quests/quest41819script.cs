//--- Melia Script -----------------------------------------------------------
// Finding the Relic
//--- Description -----------------------------------------------------------
// Quest to Talk to the Recovery Squad Leader.
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

[QuestScript(41819)]
public class Quest41819Script : QuestScript
{
	protected override void Load()
	{
		SetId(41819);
		SetName("Finding the Relic");
		SetDescription("Talk to the Recovery Squad Leader");

		AddPrerequisite(new LevelPrerequisite(388));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_1_SQ_8"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("F_3CMLAKE_27_1_NPC4", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_1_NPC4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_1_SQ_9_DLG1", "F_3CMLAKE_27_1_SQ_9", "I can help you search.", "No, I can't do that."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_27_1_SQ_9_DLG2");
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

		await dialog.Msg("F_3CMLAKE_27_1_SQ_9_DLG3");
		// Func/FADEFUNC;
		dialog.HideNPC("F_3CMLAKE_27_1_NPC4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

