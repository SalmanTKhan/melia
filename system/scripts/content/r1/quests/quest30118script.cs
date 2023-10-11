//--- Melia Script -----------------------------------------------------------
// From Ground to Air, From Ground to Ground [Cannoneer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Canonneer Master.
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

[QuestScript(30118)]
public class Quest30118Script : QuestScript
{
	protected override void Load()
	{
		SetId(30118);
		SetName("From Ground to Air, From Ground to Ground [Cannoneer Advancement]");
		SetDescription("Talk with the Canonneer Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddReward(new ItemReward("CAN01_103", 1));

		AddDialogHook("CANNONEER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("CANNONEER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CANNONEER_7_1_select", "JOB_CANNONEER_7_1", "I will learn it", "I will return next time"))
		{
			case 1:
				await dialog.Msg("JOB_CANNONEER_7_1_agree");
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

		await dialog.Msg("JOB_CANNONEER_7_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

