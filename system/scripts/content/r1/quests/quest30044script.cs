//--- Melia Script -----------------------------------------------------------
// Perfect Shot [Schwarzer Reiter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Schwarzer Reiter Master.
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

[QuestScript(30044)]
public class Quest30044Script : QuestScript
{
	protected override void Load()
	{
		SetId(30044);
		SetName("Perfect Shot [Schwarzer Reiter Advancement]");
		SetDescription("Talk to the Schwarzer Reiter Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("MASTER_SCHWARZEREITER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SCHWARZEREITER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SCHWARZEREITER_6_1_select", "JOB_SCHWARZEREITER_6_1", "I can do it", "I don't want to do it"))
		{
			case 1:
				await dialog.Msg("JOB_SCHWARZEREITER_6_1_agree");
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

		await dialog.Msg("JOB_SCHWARZEREITER_6_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

