//--- Melia Script -----------------------------------------------------------
// Kaliss Wants the Truth
//--- Description -----------------------------------------------------------
// Quest to Talk to Bokor Edita.
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

[QuestScript(8851)]
public class Quest8851Script : QuestScript
{
	protected override void Load()
	{
		SetId(8851);
		SetName("Kaliss Wants the Truth");
		SetDescription("Talk to Bokor Edita");

		AddPrerequisite(new LevelPrerequisite(196));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 6076));

		AddDialogHook("FLASH64_EDITA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_EDITA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH64_SQ_07_01", "FLASH64_SQ_07", "I'll come back after I light up the bonfire", "Decline"))
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

		await dialog.Msg("FLASH64_SQ_07_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

