//--- Melia Script -----------------------------------------------------------
// Velcoffer Armor (1)
//--- Description -----------------------------------------------------------
// Quest to Defeat Velcoffer.
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

[QuestScript(50373)]
public class Quest50373Script : QuestScript
{
	protected override void Load()
	{
		SetId(50373);
		SetName("Velcoffer Armor (1)");
		SetDescription("Defeat Velcoffer");

		AddPrerequisite(new LevelPrerequisite(360));

		AddObjective("kill0", "Kill 1 Velcoffer", new KillObjective(1, MonsterId.Raid_Boss_Velcoffer));

		AddReward(new ItemReward("VELCOFFER_MQ1_ITEM", 1));

		AddDialogHook("VELCOFFER_MQ_START_IN", "BeforeStart", BeforeStart);
		AddDialogHook("VELCOFFER_MQ_START_IN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		// Func/SCR_VELCOPFFER_MQ_END;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

