//--- Melia Script -----------------------------------------------------------
// Secret of the Fletchers [Quarrel Shooter Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Quarrel Shooter Master.
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

[QuestScript(1119)]
public class Quest1119Script : QuestScript
{
	protected override void Load()
	{
		SetId(1119);
		SetName("Secret of the Fletchers [Quarrel Shooter Advancement] (1)");
		SetDescription("Talk to the Quarrel Shooter Master");

		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("MASTER_QU", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_QUARREL3_1_select1", "JOB_QUARREL3_1", "Alright, I'll help you", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_QUARREL3_1_succ_startnpc");
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

		await dialog.Msg("JOB_QUARREL3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_QUARREL3_2");
	}
}

