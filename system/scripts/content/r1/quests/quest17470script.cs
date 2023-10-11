//--- Melia Script -----------------------------------------------------------
// The Chosen One [Sadhu Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Sadhu master.
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

[QuestScript(17470)]
public class Quest17470Script : QuestScript
{
	protected override void Load()
	{
		SetId(17470);
		SetName("The Chosen One [Sadhu Advancement]");
		SetDescription("Meet the Sadhu master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 20 Red Tree Ambulo(s)", new KillObjective(20, MonsterId.TreeAmbulo_Red));

		AddDialogHook("JOB_SADU3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SADU3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SADU4_1_ST", "JOB_SADU4_1", "I will defeat it", "Decline"))
		{
			case 1:
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

		await dialog.Msg("JOB_SADU4_1_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

