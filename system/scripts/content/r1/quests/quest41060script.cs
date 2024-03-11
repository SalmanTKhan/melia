//--- Melia Script -----------------------------------------------------------
// Restoring the Tombstone (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Damijonas.
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

[QuestScript(41060)]
public class Quest41060Script : QuestScript
{
	protected override void Load()
	{
		SetId(41060);
		SetName("Restoring the Tombstone (1)");
		SetDescription("Talk to Damijonas");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_055"));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_EDVINAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_36_2_SQ_060_ST", "PILGRIM_36_2_SQ_060", "Ask what should I do", "Give me some time"))
		{
			case 1:
				await dialog.Msg("PILGRIM_36_2_SQ_060_AC");
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

		await dialog.Msg("PILGRIM_36_2_SQ_060_COMP");
		dialog.HideNPC("PILGRIM_36_2_MATERIALS");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

