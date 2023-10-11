//--- Melia Script -----------------------------------------------------------
// Narvas Temple's Barrier (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50339)]
public class Quest50339Script : QuestScript
{
	protected override void Load()
	{
		SetId(50339);
		SetName("Narvas Temple's Barrier (5)");
		SetDescription("Talk to Monk Aistis");

		AddPrerequisite(new LevelPrerequisite(351));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_3_SQ4"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 17901));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES22_3_SUBQ1_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_3_SUBQ1_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_3_SUBQ5_START1", "WTREES22_3_SQ5", "What do you need me to do?", "Let's leave it be, and go somewhere else."))
		{
			case 1:
				await dialog.Msg("WTREES22_3_SUBQ5_AGG1");
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

		await dialog.Msg("WTREES22_3_SQ5_SUCC1");
		// Func/SCR_WTREES22_3_SUBQ5_COMP;
		await dialog.Msg("WTREES22_3_SQ5_SUCC2");
		dialog.UnHideNPC("WTREES22_3_SUBQ1_NPC4");
		dialog.HideNPC("WTREES22_3_SUBQ1_NPC3");
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

