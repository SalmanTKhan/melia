//--- Melia Script -----------------------------------------------------------
// Prequisite Blessing
//--- Description -----------------------------------------------------------
// Quest to Receive the Sanctum's Blessing.
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

[QuestScript(19810)]
public class Quest19810Script : QuestScript
{
	protected override void Load()
	{
		SetId(19810);
		SetName("Prequisite Blessing");
		SetDescription("Receive the Sanctum's Blessing");

		AddPrerequisite(new LevelPrerequisite(129));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3225));

		AddDialogHook("PILGRIM51_SR04", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM51_SR04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM51_SQ_6_ST", "PILGRIM51_SQ_6", "Get some Pure Water", "Quit"))
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

		// Func/SCR_PILGRIM51_SR04_AFTER;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

