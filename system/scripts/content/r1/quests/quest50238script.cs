//--- Melia Script -----------------------------------------------------------
// Evil Spirits, Obey My Command [Warlock Advancement]
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

[QuestScript(50238)]
public class Quest50238Script : QuestScript
{
	protected override void Load()
	{
		SetId(50238);
		SetName("Evil Spirits, Obey My Command [Warlock Advancement]");
		SetDescription("Talk with the Warlock Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("WARLOCK_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("WARLOCK_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WARLOCK_8_1_START1", "JOB_WARLOCK_8_1", "I will go and use the Seal of Dominance.", "I have learnt enough skills."))
		{
			case 1:
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

		await dialog.Msg("JOB_WARLOCK_8_1_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

