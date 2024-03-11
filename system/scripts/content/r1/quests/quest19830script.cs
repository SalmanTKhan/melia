//--- Melia Script -----------------------------------------------------------
// Sincerity in the Sanctum
//--- Description -----------------------------------------------------------
// Quest to Receive the Sanctum's Blessing.
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

[QuestScript(19830)]
public class Quest19830Script : QuestScript
{
	protected override void Load()
	{
		SetId(19830);
		SetName("Sincerity in the Sanctum");
		SetDescription("Receive the Sanctum's Blessing");

		AddPrerequisite(new LevelPrerequisite(129));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3225));

		AddDialogHook("PILGRIM51_SR05", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM51_SR05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM51_SQ_8_ST", "PILGRIM51_SQ_8", "Obtain some flowers", "Pass by"))
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

		// Func/SCR_PILGRIM51_SR05_AFTER;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

