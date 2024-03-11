//--- Melia Script -----------------------------------------------------------
// Surfacing Truth
//--- Description -----------------------------------------------------------
// Quest to Talk with Royal Army Guard Rofdel.
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

[QuestScript(8842)]
public class Quest8842Script : QuestScript
{
	protected override void Load()
	{
		SetId(8842);
		SetName("Surfacing Truth");
		SetDescription("Talk with Royal Army Guard Rofdel");

		AddPrerequisite(new LevelPrerequisite(193));

		AddReward(new ExpReward(1189715, 1189715));
		AddReward(new ItemReward("expCard10", 1));
		AddReward(new ItemReward("Vis", 5983));

		AddDialogHook("FLASH63_ROFHDEL", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH63_ROFHDEL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH63_SQ_10_01", "FLASH63_SQ_10", "I'll destroy it", "About the city in the past", "Decline"))
		{
			case 1:
				dialog.UnHideNPC("FLASH63_SQ_10_NPC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH63_SQ_11_02");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH63_SQ_10_03");
		dialog.HideNPC("FLASH63_SQ_10_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

