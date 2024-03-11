//--- Melia Script -----------------------------------------------------------
// Fedimian's Investigator (1)
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

[QuestScript(72148)]
public class Quest72148Script : QuestScript
{
	protected override void Load()
	{
		SetId(72148);
		SetName("Fedimian's Investigator (1)");
		SetDescription("Talk to the Ranger Master");

		AddPrerequisite(new LevelPrerequisite(85));
		AddPrerequisite(new CompletedPrerequisite("MASTER_RANGER1"));

		AddDialogHook("MASTER_RANGER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_WARLOCK3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_RANGER1_1_DLG1", "MASTER_RANGER2_1", "Tell me about it", "Return!"))
		{
			case 1:
				await dialog.Msg("JOB_RANGER3_1_AG");
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

		await dialog.Msg("JOB_RANGER3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MASTER_RANGER2_2");
	}
}

