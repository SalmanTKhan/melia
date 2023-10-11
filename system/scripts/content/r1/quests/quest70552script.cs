//--- Melia Script -----------------------------------------------------------
// Stopping the Pilgrimage
//--- Description -----------------------------------------------------------
// Quest to Meet Pilgrim Vados at Mova Wilderness.
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

[QuestScript(70552)]
public class Quest70552Script : QuestScript
{
	protected override void Load()
	{
		SetId(70552);
		SetName("Stopping the Pilgrimage");
		SetDescription("Meet Pilgrim Vados at Mova Wilderness");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ12"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PILGRIM414_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PILGRIM414_SQ_13_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

