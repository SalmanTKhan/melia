//--- Melia Script -----------------------------------------------------------
// Procuring Distance [Musketeer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Musketeer Master.
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

[QuestScript(30119)]
public class Quest30119Script : QuestScript
{
	protected override void Load()
	{
		SetId(30119);
		SetName("Procuring Distance [Musketeer Advancement]");
		SetDescription("Talk with the Musketeer Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddReward(new ItemReward("MUS01_103", 1));

		AddDialogHook("MUSKETEER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MUSKETEER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_MUSKETEER_7_1_select", "JOB_MUSKETEER_7_1", "I'll do it, I understand", "It doesn't seem to fit for me"))
		{
			case 1:
				await dialog.Msg("JOB_MUSKETEER_7_1_agree");
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

		await dialog.Msg("JOB_MUSKETEER_7_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

