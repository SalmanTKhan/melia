//--- Melia Script -----------------------------------------------------------
// Worship for the Blessing (1)
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

[QuestScript(19720)]
public class Quest19720Script : QuestScript
{
	protected override void Load()
	{
		SetId(19720);
		SetName("Worship for the Blessing (1)");
		SetDescription("Receive the Sanctum's Blessing");

		AddPrerequisite(new LevelPrerequisite(129));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3225));

		AddDialogHook("PILGRIM51_SR02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM51_SR02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM51_SQ_2_ST", "PILGRIM51_SQ_2", "Let's offer the monsters nearby as sacrifices", "You don't need blessings just go on your way"))
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

		// Func/SCR_PILGRIM51_SR02_RANDOM_DEBUFF;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "The sanctum has been corrupted instead of being blessed", 5);
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

