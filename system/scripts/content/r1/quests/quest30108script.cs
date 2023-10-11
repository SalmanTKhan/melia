//--- Melia Script -----------------------------------------------------------
// Living Poison [Wugushi Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wugushi Master.
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

[QuestScript(30108)]
public class Quest30108Script : QuestScript
{
	protected override void Load()
	{
		SetId(30108);
		SetName("Living Poison [Wugushi Advancement]");
		SetDescription("Talk to the Wugushi Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("JOB_2_WUGUSHI_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_WUGUSHI_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_WUGUSHI_5_1_select", "JOB_2_WUGUSHI_5_1", "I'll help you", "That sounds dangerous; I'll pass"))
		{
			case 1:
				await dialog.Msg("JOB_2_WUGUSHI_5_1_agree");
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

		await dialog.Msg("JOB_2_WUGUSHI_5_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

