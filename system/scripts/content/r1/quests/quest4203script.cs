//--- Melia Script -----------------------------------------------------------
// Not as Intended (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Supply Officer.
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

[QuestScript(4203)]
public class Quest4203Script : QuestScript
{
	protected override void Load()
	{
		SetId(4203);
		SetName("Not as Intended (1)");
		SetDescription("Talk to the Supply Officer");

		AddPrerequisite(new LevelPrerequisite(7));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 91));

		AddDialogHook("SIAUL_EAST_SUPPLY_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_SUPPLY_MANAGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ACT2_DISS1_dlg1", "ACT2_DISS1", "I'll help you retrieve the supplies", "Cancel"))
		{
			case 1:
				dialog.UnHideNPC("ACT2_DISS1_BOX");
				dialog.ShowHelp("QUEST_ACT2_DISS1");
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

		await dialog.Msg("ACT2_DISS1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

