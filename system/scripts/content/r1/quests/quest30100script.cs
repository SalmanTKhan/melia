//--- Melia Script -----------------------------------------------------------
// Corpse Poison [Wugushi Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wugushi Master.
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

[QuestScript(30100)]
public class Quest30100Script : QuestScript
{
	protected override void Load()
	{
		SetId(30100);
		SetName("Corpse Poison [Wugushi Advancement]");
		SetDescription("Talk to the Wugushi Master");

		AddPrerequisite(new LevelPrerequisite(85));

		AddReward(new ItemReward("Hat_628067", 1));

		AddDialogHook("JOB_2_WUGUSHI_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_WUGUSHI_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_WUGUSHI_4_1_select", "JOB_2_WUGUSHI_4_1", "Where can I get it from?", "I want to stop; it's too scary"))
		{
			case 1:
				await dialog.Msg("JOB_2_WUGUSHI_4_1_agree");
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

		await dialog.Msg("JOB_2_WUGUSHI_4_1_succ");
		dialog.ShowHelp("TUTO_CLASS_WUGUSHI");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

