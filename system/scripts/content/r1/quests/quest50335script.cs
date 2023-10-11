//--- Melia Script -----------------------------------------------------------
// Narvas Temple's Barrier (1)
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

[QuestScript(50335)]
public class Quest50335Script : QuestScript
{
	protected override void Load()
	{
		SetId(50335);
		SetName("Narvas Temple's Barrier (1)");
		SetDescription("Talk to Monk Aistis");

		AddPrerequisite(new LevelPrerequisite(351));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_2_SQ8"));

		AddDialogHook("WTREES22_3_SUBQ1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_3_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_3_SUBQ1_START1", "WTREES22_3_SQ1", "I've been sent here by a monk from Tekel Shelter.", "I need a moment to take a breath. I'll tell you right after."))
		{
			case 1:
				await dialog.Msg("WTREES22_3_SUBQ1_AGG1");
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

		await dialog.Msg("WTREES22_3_SUBQ1_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

