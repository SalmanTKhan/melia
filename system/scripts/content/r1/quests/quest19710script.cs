//--- Melia Script -----------------------------------------------------------
// Sanctum of Blessings
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

[QuestScript(19710)]
public class Quest19710Script : QuestScript
{
	protected override void Load()
	{
		SetId(19710);
		SetName("Sanctum of Blessings");
		SetDescription("Receive the Sanctum's Blessing");

		AddPrerequisite(new LevelPrerequisite(129));

		AddDialogHook("PILGRIM51_SR01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM51_SR01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM51_SQ_1_ST", "PILGRIM51_SQ_1", "Make some contribution", "Let's not waste silvers on this kind of thing"))
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


		return HookResult.Break;
	}
}

