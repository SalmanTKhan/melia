//--- Melia Script -----------------------------------------------------------
// Eternal Rest Interrupted
//--- Description -----------------------------------------------------------
// Quest to Talk with the Warlock Master.
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

[QuestScript(50290)]
public class Quest50290Script : QuestScript
{
	protected override void Load()
	{
		SetId(50290);
		SetName("Eternal Rest Interrupted");
		SetDescription("Talk with the Warlock Master");

		AddPrerequisite(new LevelPrerequisite(188));

		AddReward(new ItemReward("Gacha_H_005", 1));

		AddDialogHook("WARLOCK_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("WARLOCK_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB38_2_HQ1_start1", "CATACOMB38_2_HQ1", "I'll find this evil spirit.", "Do it yourself"))
		{
			case 1:
				await dialog.Msg("CATACOMB38_2_HQ1_agree1");
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

		await dialog.Msg("CATACOMB38_2_HQ1_succ1");
		// Func/CATACOMB382_HIDDENQ1_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

