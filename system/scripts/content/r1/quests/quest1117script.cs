//--- Melia Script -----------------------------------------------------------
// Luck of the Spear Blades [Hoplite Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hoplite Submaster.
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

[QuestScript(1117)]
public class Quest1117Script : QuestScript
{
	protected override void Load()
	{
		SetId(1117);
		SetName("Luck of the Spear Blades [Hoplite Advancement]");
		SetDescription("Talk to the Hoplite Submaster");

		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("JOB_HOPLITE2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HOPLITE2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HOPLITE3_1_select1", "JOB_HOPLITE3_1", "I agree", "I disagree"))
		{
			case 1:
				await dialog.Msg("JOB_HOPLITE3_1_select1_Q");
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

		await dialog.Msg("JOB_HOPLITE3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

