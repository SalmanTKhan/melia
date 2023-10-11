//--- Melia Script -----------------------------------------------------------
// Root of the Divine Tree (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Austeja.
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

[QuestScript(80460)]
public class Quest80460Script : QuestScript
{
	protected override void Load()
	{
		SetId(80460);
		SetName("Root of the Divine Tree (7)");
		SetDescription("Talk to Goddess Austeja");

		AddPrerequisite(new LevelPrerequisite(431));
		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_99_MQ_06"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("F_CASTLE_99_MQ_07_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_CASTLE_99_MQ_07_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_CASTLE_99_MQ_07_ST", "F_CASTLE_99_MQ_07", "I won't be any help.", "There is no way."))
		{
			case 1:
				await dialog.Msg("F_CASTLE_99_MQ_07_AFST");
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

		await dialog.Msg("F_CASTLE_99_MQ_07_SU");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		await dialog.Msg("FadeOutIN/3000");
		dialog.HideNPC("F_CASTLE_99_MQ_07_NPC");
		dialog.HideNPC("F_CASTLE_99_MQ_07_NPC2");
		dialog.HideNPC("F_CASTLE_99_MQ_07_NPC3");
		dialog.HideNPC("F_CASTLE_99_MQ_07_NPC4");
		dialog.UnHideNPC("CASTLE102_AUSTEJA_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

