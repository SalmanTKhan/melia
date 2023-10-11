//--- Melia Script -----------------------------------------------------------
// Prove Your Might [Fencer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Fencer Master.
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

[QuestScript(90154)]
public class Quest90154Script : QuestScript
{
	protected override void Load()
	{
		SetId(90154);
		SetName("Prove Your Might [Fencer Advancement]");
		SetDescription("Talk with the Fencer Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("MASTER_FENCER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FENCER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_FENCER_8_1_ST", "JOB_FENCER_8_1", "I will prove it.", "I'm not so sure about it"))
		{
			case 1:
				await dialog.Msg("JOB_FENCER_8_1_AG");
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

		await dialog.Msg("JOB_FENCER_8_1_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

