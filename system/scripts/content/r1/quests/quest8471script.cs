//--- Melia Script -----------------------------------------------------------
// Goddess Gabija (1)
//--- Description -----------------------------------------------------------
// Quest to Someone is looking for you.
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

[QuestScript(8471)]
public class Quest8471Script : QuestScript
{
	protected override void Load()
	{
		SetId(8471);
		SetName("Goddess Gabija (1)");
		SetDescription("Someone is looking for you");

		AddPrerequisite(new LevelPrerequisite(113));

		AddReward(new ExpReward(690268, 690268));

		AddDialogHook("FEDIMIAN_GRITA", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS40_GRITA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TO_THE_TOWER_01_select01", "TO_THE_TOWER_01", "Let's go help Grita at Fedimian Suburbs", "About the Mage Tower", "I'm busy"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("TO_THE_TOWER_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.HideNPC("FEDIMIAN_GRITA");
		await dialog.Msg("FadeOutIN/500");
		dialog.UnHideNPC("REMAINS40_GRITA");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

