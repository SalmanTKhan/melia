//--- Melia Script -----------------------------------------------------------
// The Suspicious Dagger (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ranger Master.
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

[QuestScript(50013)]
public class Quest50013Script : QuestScript
{
	protected override void Load()
	{
		SetId(50013);
		SetName("The Suspicious Dagger (3)");
		SetDescription("Talk to the Ranger Master");

		AddPrerequisite(new LevelPrerequisite(69));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_50_1_SQ_050"));

		AddDialogHook("MASTER_RANGER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_060_select01", "SIAULIAI_50_1_SQ_060", "Do you know someone who is familiar with poison?", "OK. (Stop the pursuit)"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_50_1_SQ_060_selectnpc01");
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

		await dialog.Msg("SIAULIAI_50_1_SQ_060_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_50_1_SQ_070");
	}
}

